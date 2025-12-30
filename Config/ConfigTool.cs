// Config/ConfigTool.cs
// Reads Config.xml and applies prefab + component tweaks
namespace ConfigXML
{
    using Game.Prefabs;           // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;                 // Exception, Type
    using System.Reflection;      // BindingFlags, FieldInfo, MethodInfo
    using Unity.Entities;         // Entity, EntityManager, ComponentType, World, IComponentData
    using Unity.Mathematics;      // math

    public static class ConfigTool
    {
        // Will enable AddPrefab patch to process prefabs loaded AFTER mods are initialized (there are some).
        public static bool isLatePrefabsActive = false;

        private static PrefabSystem m_PrefabSystem = null!;
        private static EntityManager m_EntityManager;

        public static void DumpFields(PrefabBase prefab, ComponentBase component)
        {
            var className = component.GetType().Name;
            Mod.Log($"{prefab.name}.{component.name}.CLASS: {className}");

            object obj = component;
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                // field components: System.Collections.Generic.List`1[Game.Prefabs.ComponentBase]
                if (field.Name != "isDirty" && field.Name != "active" && field.Name != "components")
                {
                    object? value = field.GetValue(obj);
                    Mod.Log($"{prefab.name}.{component.name}.{field.Name}: {value}");
                }
            }
        }

        /// <summary>
        /// Configures a specific component within a specific prefab according to config data.
        /// </summary>
        private static void ConfigureComponent(
            PrefabBase prefab,
            PrefabXml prefabConfig,
            ComponentBase component,
            Entity entity,
            bool skipEntity = false)
        {
            // If skipEntity is true, skip any modifications for this component.
            if (skipEntity)
            {
                Mod.LogIf($"{prefab.name}.{component.name}: skipEntity flag set, skipping configuration.");
                return;
            }

            string compName = component.GetType().Name;
            bool isPatched = false;

            // Structs within components are handled as separate components.
            // TODO: When more structs are implemented, use reflection to create flexible code for all possible cases.
            if (compName == "ProcessingCompany"
                && prefabConfig.TryGetComponent("IndustrialProcess", out ComponentXml structConfig)
                && component is ProcessingCompany comp)
            {
                // IndustrialProcess - currently 2 fields are supported.
                Mod.LogIf($"{prefab.name}.IndustrialProcess: valid");
                IndustrialProcess oldProc = comp.process;

                if (structConfig.TryGetField("m_MaxWorkersPerCell", out FieldXml mwpcField)
                    && mwpcField.ValueFloatSpecified)
                {
                    comp.process.m_MaxWorkersPerCell = mwpcField.ValueFloat ?? oldProc.m_MaxWorkersPerCell;
                    Mod.LogIf(
                        $"{prefab.name}.IndustrialProcess.{mwpcField.Name}: {oldProc.m_MaxWorkersPerCell} -> {comp.process.m_MaxWorkersPerCell} " +
                        $"({comp.process.m_MaxWorkersPerCell.GetType()}, {mwpcField})");
                }

                if (structConfig.TryGetField("m_Output.m_Amount", out FieldXml outamtField)
                    && outamtField.ValueIntSpecified)
                {
                    comp.process.m_Output.m_Amount = outamtField.ValueInt ?? oldProc.m_Output.m_Amount;
                    Mod.LogIf(
                        $"{prefab.name}.IndustrialProcess.{outamtField.Name}: {oldProc.m_Output.m_Amount} -> {comp.process.m_Output.m_Amount} " +
                        $"({comp.process.m_Output.m_Amount.GetType()}, {outamtField})");
                }

                if (Mod.setting != null && !Mod.setting.Logging)
                {
                    // Single summary line when verbose logging is OFF.
                    Mod.s_Log.Info(
                        $"{prefab.name}.IndustrialProcess: workersPerCell={comp.process.m_MaxWorkersPerCell}, " +
                        $"output={comp.process.m_Output.m_Amount}");
                }

                isPatched = true;
            }

            // Default processing using reflection.
            if (prefabConfig.TryGetComponent(compName, out ComponentXml compConfig))
            {
                Mod.LogIf($"{prefab.name}.{compName}: valid");

                foreach (FieldXml fieldConfig in compConfig.Fields)
                {
                    // Get the FieldInfo object for the field with the given name.
                    FieldInfo? field = component.GetType().GetField(
                        fieldConfig.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (field != null)
                    {
                        object? oldValue = field.GetValue(component);

                        // TODO: extend for other field types.
                        if (field.FieldType == typeof(int))
                        {
                            field.SetValue(component, fieldConfig.ValueInt ?? 0);
                        }
                        else if (field.FieldType == typeof(float))
                        {
                            field.SetValue(component, fieldConfig.ValueFloat ?? 0f);
                        }
                        else if (field.FieldType == typeof(uint))
                        {
                            field.SetValue(
                                component,
                                (uint)math.clamp(fieldConfig.ValueInt ?? 0, 0, int.MaxValue));
                        }
                        else if (field.FieldType == typeof(short))
                        {
                            field.SetValue(
                                component,
                                (short)math.clamp(fieldConfig.ValueInt ?? 0, short.MinValue, short.MaxValue));
                        }
                        else if (field.FieldType == typeof(byte))
                        {
                            field.SetValue(
                                component,
                                (byte)math.clamp(fieldConfig.ValueInt ?? 0, 0, byte.MaxValue));
                        }
                        else
                        {
                            field.SetValue(component, fieldConfig.ValueInt ?? 0);
                        }

                        if (Mod.setting != null && Mod.setting.Logging)
                        {
                            Mod.Log(
                                $"{prefab.name}.{compName}.{field.Name}: {oldValue} -> {field.GetValue(component)} " +
                                $"({field.FieldType}, {fieldConfig})");
                        }

                        isPatched = true;
                    }
                    else
                    {
                        Mod.LogIf($"{prefab.name}.{compName}: Warning! Field {fieldConfig.Name} not found in the component.");
                    }
                }

                if (Mod.setting != null && Mod.setting.Logging)
                {
                    DumpFields(prefab, component); // debug
                }
            }

            // Quit if there is no default processing nor special cases.
            if (!isPatched)
            {
                Mod.LogIf($"{prefab.name}.{compName}: SKIP");
                return;
            }

            // Modify Entity.
            Type componentType = component.GetType();
            MethodInfo? methodInit = componentType.GetMethod("Initialize");
            MethodInfo? methodLate = componentType.GetMethod("LateInitialize");
            MethodInfo? methodArch = componentType.GetMethod("RefreshArchetype");

            bool hasInit = methodInit != null && methodInit.DeclaringType == componentType;
            bool hasLate = methodLate != null && methodLate.DeclaringType == componentType;
            bool hasArch = methodArch != null; // not declared on ComponentBase for all components.

            Mod.LogIf(
                prefab.name + "." + compName +
                ": INIT " + hasInit + " " + (methodInit != null ? methodInit.DeclaringType!.Name : "none") +
                " LATE " + hasLate + " " + (methodLate != null ? methodLate.DeclaringType!.Name : "none") +
                " ARCH " + hasArch + " " + (methodArch != null ? methodArch.DeclaringType!.Name : "none"));

            // If there is both Initialize and LateInitialize, log a warning and skip (unsupported).
            if (hasInit && hasLate)
            {
                Mod.s_Log.Warn($"DUALINIT: {prefab.name}.{compName} has both Init and LateInit; not supported.");
            }
            else if (hasLate)
            {
                Mod.LogIf("... calling LateInitialize");
                component.LateInitialize(m_EntityManager, entity);
            }
            else if (hasInit)
            {
                Mod.LogIf("... calling Initialize");
                component.Initialize(m_EntityManager, entity);
            }
            else
            {
                if (compName != "ResourcePrefab" && compName != "CompanyPrefab")
                {
                    Mod.s_Log.Warn($"ZEROINIT: {prefab.name}.{compName} has no Init and no LateInit; not supported.");
                }
            }

            // After that there are cases where RefreshArchetype is needed - very rare so can be handled as exception.
            if (hasArch)
            {
                Mod.s_Log.Warn($"ARCHETYPE: {prefab.name}.{compName} has RefreshArchetype; not supported.");
            }
        }

        // Method to change the value of a field in an ECS component by name.
        // NOT USED.
        public static void SetFieldValue<T>(
            ref T component,
            string fieldName,
            object newValue)
            where T : struct, IComponentData
        {
            Type type = typeof(T);
            FieldInfo? field = type.GetField(
                fieldName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (field != null)
            {
                object? oldValue = field.GetValue(component);
                field.SetValueDirect(__makeref(component), newValue);
                Mod.s_Log.Info($"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
            }
            else
            {
                Mod.s_Log.Info($"Field '{fieldName}' not found in struct '{type.Name}'.");
            }
        }

        // NOT USED - CRASHES THE GAME ATM.
        public static void ConfigureComponentData<T>(ComponentXml compXml, ref T component)
            where T : struct, IComponentData
        {
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                object? oldValue = field.GetValue(component);

                if (compXml.TryGetField(field.Name, out FieldXml fieldXml))
                {
                    // TODO: extend for other field types.
                    if (field.FieldType == typeof(float))
                    {
                        field.SetValueDirect(__makeref(component), fieldXml.ValueFloat);
                    }
                    else
                    {
                        field.SetValueDirect(__makeref(component), fieldXml.ValueInt);
                    }

                    Mod.s_Log.Info(
                        $"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
                }
                else
                {
                    Mod.LogIf($"{type.Name}.{field.Name}: {oldValue}");
                }
            }
        }

        /// <summary>
        /// Configures a specific prefab according to the config data.
        /// </summary>
        private static void ConfigurePrefab(
            PrefabBase prefab,
            PrefabXml prefabConfig,
            Entity entity,
            bool skipEntity = false)
        {
            Mod.LogIf(
                $"{prefab.name}: valid {prefab.GetType().Name} entity {entity.Index} skipEntity={skipEntity}");

            // Check first if the main prefab needs to be changed.
            ConfigureComponent(prefab, prefabConfig, prefab, entity, skipEntity);

            // Iterate through components and see which ones need to be changed.
            foreach (ComponentBase component in prefab.components)
            {
                ConfigureComponent(prefab, prefabConfig, component, entity, skipEntity);
            }
        }

        public static void ReadAndApply()
        {
            if (Mod.modAsset == null)
            {
                Mod.s_Log.Warn("ConfigTool.ReadAndApply called before modAsset is set; skipping configuration.");
                return;
            }

            bool useLocal =
                Mod.setting != null &&
                Mod.setting.UseLocalConfig;

            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(Mod.modAsset.path)
                : ConfigToolXml.LoadPresetConfig(Mod.modAsset.path);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.s_Log.Warn("ConfigTool.ReadAndApply: No configuration data loaded or Prefabs list is empty; nothing to apply.");
                return;
            }

            var sourceDescription = useLocal
                ? "Apply LOCAL Config.xml (ModsData/ConfigXML)"
                : "Apply PRESET Config.xml (shipped mod defaults)";

            // Go through the safe logging helper so logging failures can never NRE.
            Mod.Log($"ConfigXML: {sourceDescription}.");

            // ECS / world safety: do nothing if there's no default world yet.
            World world;
            try
            {
                world = World.DefaultGameObjectInjectionWorld;
            }
            catch (Exception ex)
            {
                Mod.s_Log.Warn($"ConfigTool.ReadAndApply: Failed to get default world: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            if (world == null)
            {
                Mod.s_Log.Warn("ConfigTool.ReadAndApply: No default world; are we in a game? Skipping configuration.");
                return;
            }

            try
            {
                m_PrefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
                m_EntityManager = world.EntityManager;
            }
            catch (Exception ex)
            {
                Mod.s_Log.Warn($"ConfigTool.ReadAndApply: Failed to get PrefabSystem / EntityManager: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            foreach (PrefabXml prefabXml in config.Prefabs)
            {
                PrefabID prefabID = new PrefabID(prefabXml.Type, prefabXml.Name);
                PrefabBase prefab;
                Entity entity;

                if (m_PrefabSystem.TryGetPrefab(prefabID, out prefab)
                    && m_PrefabSystem.TryGetEntity(prefab, out entity))
                {
                    Mod.LogIf(prefabXml + " successfully retrieved from the PrefabSystem.");
                    ConfigurePrefab(prefab, prefabXml, entity);
                }
                else
                {
                    // Only log missing prefabs when verbose logging is enabled.
                    Mod.LogIf("Failed to retrieve " + prefabXml + " from the PrefabSystem.");
                }
            }
        }


        /// <summary>
        /// DEBUG helper: dump status for every Prefab listed in Config.xml
        /// (FOUND / MISSING) to the log, without changing anything.
        /// </summary>
        public static void DumpPrefabStatus()
        {
            if (Mod.modAsset == null)
            {
                Mod.s_Log.Warn("DumpPrefabStatus: modAsset not set; cannot load configuration.");
                return;
            }

            // Always check against the preset config – that’s your “source of truth”.
            ConfigurationXml? config = ConfigToolXml.LoadPresetConfig(Mod.modAsset.path);
            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.s_Log.Warn("DumpPrefabStatus: configuration has no Prefabs to check.");
                return;
            }

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                Mod.s_Log.Warn("DumpPrefabStatus: no default world; are we in a game?");
                return;
            }

            PrefabSystem prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();

            Mod.s_Log.Info($"{Mod.ModTag} PREFAB STATUS DUMP BEGIN");
            foreach (PrefabXml prefabXml in config.Prefabs)
            {
                var id = new PrefabID(prefabXml.Type, prefabXml.Name);
                PrefabBase prefab;

                var hasPrefab = prefabSystem.TryGetPrefab(id, out prefab);

                string status;
                if (!hasPrefab)
                {
                    status = "MISSING";
                }
                else if (!prefabSystem.TryGetEntity(prefab, out _))
                {
                    status = "NO_ENTITY";
                }
                else
                {
                    status = "OK";
                }

                Mod.s_Log.Info($"{Mod.ModTag} PREFAB {status}: {prefabXml}");
            }
            Mod.s_Log.Info($"{Mod.ModTag} PREFAB STATUS DUMP END");

        }

        // List components from entity.
        internal static void ListComponents(PrefabBase prefab, Entity entity)
        {
            foreach (ComponentType componentType in m_EntityManager.GetComponentTypes(entity))
            {
                Mod.s_Log.Info(
                    $"{prefab.GetType().Name}.{prefab.name}.{componentType.GetManagedType().Name}: {componentType}");
            }
        }
    }
}
