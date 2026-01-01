// File: Config/ConfigTool.PatchReflection.cs
// Purpose: Reflection-based patching + safe Initialize/LateInitialize hook calls.

namespace ConfigXML
{
    using Game.Prefabs;               // PrefabBase, ComponentBase
    using System;                     // Exception, Type, Convert, Enum
    using System.Globalization;       // CultureInfo
    using System.Reflection;          // BindingFlags, FieldInfo, MethodInfo
    using Unity.Entities;             // Entity
    using Unity.Mathematics;          // math

    public static partial class ConfigTool
    {
        private static bool ConfigureComponent(PrefabBase prefab, PrefabXml prefabConfig, ComponentBase component, Entity entity)
        {
            string compName = component.GetType().Name;
            bool isPatched = false;

            // Special-case patcher(s) first (explicit, low risk).
            if (TryPatchProcessingCompanyProcess(prefab, prefabConfig, component))
            {
                isPatched = true;
            }

            // Default reflection-based patching.
            if (prefabConfig.TryGetComponent(compName, out ComponentXml compConfig))
            {
                Type componentType = component.GetType();

                foreach (FieldXml fieldConfig in compConfig.Fields)
                {
                    FieldInfo? field = componentType.GetField(
                        fieldConfig.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (field == null)
                    {
                        continue; // field missing across patches is normal
                    }

                    object? oldValue = null;
                    try
                    {
                        oldValue = field.GetValue(component);
                    }
                    catch
                    {
                    }

                    object? newValue = null;
                    bool supported = true;

                    if (field.FieldType == typeof(int))
                    {
                        if (!fieldConfig.ValueIntSpecified) { continue; }
                        newValue = fieldConfig.ValueInt ?? 0;
                    }
                    else if (field.FieldType == typeof(float))
                    {
                        if (!fieldConfig.ValueFloatSpecified) { continue; }
                        newValue = fieldConfig.ValueFloat ?? 0f;
                    }
                    else if (field.FieldType == typeof(uint))
                    {
                        if (!fieldConfig.ValueIntSpecified) { continue; }
                        newValue = (uint)math.clamp(fieldConfig.ValueInt ?? 0, 0, int.MaxValue);
                    }
                    else if (field.FieldType == typeof(short))
                    {
                        if (!fieldConfig.ValueIntSpecified) { continue; }
                        newValue = (short)math.clamp(fieldConfig.ValueInt ?? 0, short.MinValue, short.MaxValue);
                    }
                    else if (field.FieldType == typeof(byte))
                    {
                        if (!fieldConfig.ValueIntSpecified) { continue; }
                        newValue = (byte)math.clamp(fieldConfig.ValueInt ?? 0, 0, byte.MaxValue);
                    }
                    else if (field.FieldType.IsEnum)
                    {
                        if (!fieldConfig.ValueIntSpecified) { continue; }

                        int raw = fieldConfig.ValueInt ?? 0;
                        Type underlying = Enum.GetUnderlyingType(field.FieldType);

                        try
                        {
                            object boxed = Convert.ChangeType(raw, underlying, CultureInfo.InvariantCulture);
                            newValue = Enum.ToObject(field.FieldType, boxed);
                        }
                        catch
                        {
                            supported = false;
                        }
                    }
                    else
                    {
                        supported = false;
                    }

                    if (!supported)
                    {
                        s_UnsupportedSkipsThisApply++;

                        string key = "unsupported|" + compName + "|" + field.Name + "|" + field.FieldType.FullName;
                        WarnOnce(
                            key,
                            $"Unsupported field type skipped: {compName}.{field.Name} ({field.FieldType.Name}). Example prefab: {prefab.name}.");
                        continue;
                    }

                    if (Equals(oldValue, newValue))
                    {
                        continue;
                    }

                    try
                    {
                        field.SetValue(component, newValue);
                        s_FieldsChangedThisApply++;
                        isPatched = true;
                    }
                    catch (Exception ex)
                    {
                        string key = "setfail|" + compName + "|" + field.Name + "|" + field.FieldType.FullName;
                        WarnOnce(key, $"{Mod.ModTag} Failed to set {prefab.name}.{compName}.{field.Name}: {ex.GetType().Name}: {ex.Message}");
                    }
                }
            }

            if (!isPatched)
            {
                return false;
            }

            s_ComponentsPatchedThisApply++;

            // Initialize/LateInitialize hook calls (safe + guarded).
            Type componentType2 = component.GetType();
            MethodInfo? methodInit = componentType2.GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            MethodInfo? methodLate = componentType2.GetMethod("LateInitialize", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            bool hasInit = methodInit != null && methodInit.DeclaringType == componentType2;
            bool hasLate = methodLate != null && methodLate.DeclaringType == componentType2;

            // If both exist, skip calling either (avoid unknown side-effects).
            if (hasInit && hasLate)
            {
                return true;
            }

            try
            {
                if (hasLate)
                {
                    component.LateInitialize(m_EntityManager, entity);
                    s_InitCallsThisApply++;
                }
                else if (hasInit)
                {
                    component.Initialize(m_EntityManager, entity);
                    s_InitCallsThisApply++;
                }
            }
            catch (Exception ex)
            {
                string key = "initfail|" + compName;
                WarnOnce(key, $"{Mod.ModTag} Init hook failed for {prefab.name}.{compName}: {ex.GetType().Name}: {ex.Message}");
            }

            return true;
        }
    }
}
