// File: Config/ConfigTool.cs
// Purpose: Reads Config.xml and applies prefab + component tweaks.

namespace ConfigXML
{
    using Game.Prefabs;      // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;            // Exception, Type
    using System.Reflection; // BindingFlags, FieldInfo, MethodInfo
    using Unity.Entities;    // Entity, EntityManager, ComponentType, World, IComponentData
    using Unity.Mathematics; // math

    public static class ConfigTool
    {
        // Enables late-prefab patch logic (if used elsewhere).
        public static bool isLatePrefabsActive = false;

        private static PrefabSystem? m_PrefabSystem;
        private static EntityManager m_EntityManager;

        // -----------------------------------------
        // DEBUG: dump component fields to log
        // -----------------------------------------
        public static void DumpFields(PrefabBase prefab, ComponentBase component)
        {
            var className = component.GetType().Name;
            Mod.Log($"{prefab.name}.{component.name}.CLASS: {className}");

            Type type = component.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                // Skip noisy base fields.
                if (field.Name == "isDirty" || field.Name == "active" || field.Name == "components")
                {
                    continue;
                }

                object? value = field.GetValue(component);
                Mod.Log($"{prefab.name}.{component.name}.{field.Name}: {value}");
            }
        }

        // -----------------------------------------
        // CORE: configure prefab + components
        // -----------------------------------------
        private static void ConfigurePrefab(PrefabBase prefab, PrefabXml prefabConfig, Entity entity, bool skipEntity = false)
        {
            Mod.LogIf($"{prefab.name}: valid {prefab.GetType().Name} entity {entity.Index} skipEntity={skipEntity}");

            // Apply config to the root prefab instance.
            ConfigureComponent(prefab, prefabConfig, prefab, entity, skipEntity);

            // Apply config to each attached component.
            foreach (ComponentBase component in prefab.components)
            {
                ConfigureComponent(prefab, prefabConfig, component, entity, skipEntity);
            }
        }

        private static void ConfigureComponent(
            PrefabBase prefab,
            PrefabXml prefabConfig,
            ComponentBase component,
            Entity entity,
            bool skipEntity = false)
        {
            if (skipEntity)
            {
                Mod.LogIf($"{prefab.name}.{component.name}: skipEntity flag set, skipping configuration.");
                return;
            }

            string compName = component.GetType().Name;
            bool isPatched = false;

            // -----------------------------
            // Special-case: ProcessingCompany.process (struct)
            // -----------------------------
            if (compName == "ProcessingCompany"
                && prefabConfig.TryGetComponent("IndustrialProcess", out ComponentXml structConfig)
                && component is ProcessingCompany comp)
            {
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

                // When verbose VerboseLogs is OFF, emit one short summary line.
                if (Mod.setting != null && !Mod.setting.VerboseLogs)
                {
                    Mod.Log(
                        $"{prefab.name}.IndustrialProcess: workersPerCell={comp.process.m_MaxWorkersPerCell}, " +
                        $"output={comp.process.m_Output.m_Amount}");
                }

                isPatched = true;
            }

            // -----------------------------
            // Default reflection-based patching
            // -----------------------------
            if (prefabConfig.TryGetComponent(compName, out ComponentXml compConfig))
            {
                Mod.LogIf($"{prefab.name}.{compName}: valid");

                foreach (FieldXml fieldConfig in compConfig.Fields)
                {
                    FieldInfo? field = component.GetType().GetField(
                        fieldConfig.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (field == null)
                    {
                        Mod.LogIf($"{prefab.name}.{compName}: field not found: {fieldConfig.Name}");
                        continue;
                    }

                    object? oldValue = field.GetValue(component);

                    // NOTE: ConfigXml rules: only ValueInt/ValueFloat are supported safely.
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
                        field.SetValue(component, (uint)math.clamp(fieldConfig.ValueInt ?? 0, 0, int.MaxValue));
                    }
                    else if (field.FieldType == typeof(short))
                    {
                        field.SetValue(component, (short)math.clamp(fieldConfig.ValueInt ?? 0, short.MinValue, short.MaxValue));
                    }
                    else if (field.FieldType == typeof(byte))
                    {
                        field.SetValue(component, (byte)math.clamp(fieldConfig.ValueInt ?? 0, 0, byte.MaxValue));
                    }
                    else
                    {
                        // Unsupported field types are intentionally not handled.
                        // Leave unchanged to avoid crashing or corrupting prefabs.
                        Mod.LogIf($"{prefab.name}.{compName}.{field.Name}: unsupported field type {field.FieldType.Name}; skipped");
                        continue;
                    }

                    if (Mod.setting != null && Mod.setting.VerboseLogs)
                    {
                        Mod.Log(
                            $"{prefab.name}.{compName}.{field.Name}: {oldValue} -> {field.GetValue(component)} " +
                            $"({field.FieldType}, {fieldConfig})");
                    }

                    isPatched = true;
                }

                if (Mod.setting != null && Mod.setting.VerboseLogs)
                {
                    DumpFields(prefab, component);
                }
            }

            if (!isPatched)
            {
                Mod.LogIf($"{prefab.name}.{compName}: SKIP");
                return;
            }

            // -----------------------------
            // Entity update hooks (Initialize/LateInitialize)
            // -----------------------------
            Type componentType = component.GetType();
            MethodInfo? methodInit = componentType.GetMethod("Initialize");
            MethodInfo? methodLate = componentType.GetMethod("LateInitialize");
            MethodInfo? methodArch = componentType.GetMethod("RefreshArchetype");

            bool hasInit = methodInit != null && methodInit.DeclaringType == componentType;
            bool hasLate = methodLate != null && methodLate.DeclaringType == componentType;
            bool hasArch = methodArch != null;

            Mod.LogIf(
                prefab.name + "." + compName +
                ": INIT " + hasInit +
                " LATE " + hasLate +
                " ARCH " + hasArch);

            // Both init paths present: skip to avoid unknown side-effects.
            if (hasInit && hasLate)
            {
                Mod.Warn($"DUALINIT: {prefab.name}.{compName} has both Init and LateInit; skipped.");
                return;
            }

            // LateInitialize preferred when present.
            if (hasLate)
            {
                Mod.LogIf($"{prefab.name}.{compName}: calling LateInitialize");
                component.LateInitialize(m_EntityManager, entity);
            }
            else if (hasInit)
            {
                Mod.LogIf($"{prefab.name}.{compName}: calling Initialize");
                component.Initialize(m_EntityManager, entity);
            }
            else
            {
                // Some components do not require init hooks; keep warning minimal.
                if (compName != "ResourcePrefab" && compName != "CompanyPrefab")
                {
                    Mod.Warn($"ZEROINIT: {prefab.name}.{compName} has no Init/LateInit; prefab may not refresh.");
                }
            }

            // RefreshArchetype exists on some components; not supported here.
            if (hasArch)
            {
                Mod.Warn($"ARCHETYPE: {prefab.name}.{compName} has RefreshArchetype; not supported.");
            }
        }

        // -----------------------------------------
        // APPLY: load config and patch PrefabSystem
        // -----------------------------------------
        public static void ReadAndApply()
        {
            // Resolve installed mod folder path (or empty => ConfigToolXml fallback).
            string assetPath = Mod.GetAssetPathSafe();

            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(assetPath)
                : ConfigToolXml.LoadPresetConfig(assetPath);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.Warn("ConfigTool.ReadAndApply: no configuration data loaded; nothing to apply.");
                return;
            }

            Mod.Log(useLocal
                ? "CFG: Apply LOCAL Config.xml (ModsData/ConfigXML)."
                : "CFG: Apply PRESET Config.xml (shipped mod defaults).");

            // Prefabs live in the default ECS world.
            World? world;
            try
            {
                world = World.DefaultGameObjectInjectionWorld;
            }
            catch (Exception ex)
            {
                Mod.Warn($"ConfigTool.ReadAndApply: failed to get default world: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            if (world == null)
            {
                Mod.Warn("ConfigTool.ReadAndApply: default ECS world not available; skip configuration.");
                return;
            }

            try
            {
                m_PrefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
                m_EntityManager = world.EntityManager;
            }
            catch (Exception ex)
            {
                Mod.Warn($"ConfigTool.ReadAndApply: failed to get PrefabSystem/EntityManager: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            foreach (PrefabXml prefabXml in config.Prefabs)
            {
                PrefabID prefabID = new PrefabID(prefabXml.Type, prefabXml.Name);

                if (m_PrefabSystem.TryGetPrefab(prefabID, out PrefabBase prefab)
                    && m_PrefabSystem.TryGetEntity(prefab, out Entity entity))
                {
                    Mod.LogIf($"{prefabXml} found; applying.");
                    ConfigurePrefab(prefab, prefabXml, entity);
                }
                else
                {
                    Mod.LogIf($"{prefabXml} missing; skipped.");
                }
            }
        }

        // -----------------------------------------
        // DEBUG helpers
        // -----------------------------------------

        // Dump tests that the *active* config’s prefab IDs exist in the current game.
        // - Always prints a summary.
        // - By default prints ONLY problems (MISSING / NO_ENTITY).
        // - In DEBUG builds, if VerboseLogs is enabled, prints ALL entries.
        public static void DumpPrefabStatus()
        {
            string assetPath = Mod.GetAssetPathSafe();

            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

            // Dump the config the player is actually using right now.
            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(assetPath)
                : ConfigToolXml.LoadPresetConfig(assetPath);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.Log("DumpPrefabStatus: config has no Prefabs to check.");
                return;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                Mod.Log("DumpPrefabStatus: default ECS world not available; skip.");
                return;
            }

            PrefabSystem prefabSystem;
            try
            {
                prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
            }
            catch (Exception ex)
            {
                Mod.Log($"DumpPrefabStatus: failed to get PrefabSystem: {ex.GetType().Name}: {ex.Message}");
                return;
            }

            bool showAll = false;
#if DEBUG
            showAll = (Mod.setting != null && Mod.setting.VerboseLogs);
#endif

            int ok = 0;
            int missing = 0;
            int noEntity = 0;

            string mode = useLocal ? "LOCAL" : "PRESET";
            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP BEGIN ({mode}) ===");
            Mod.Log($"{Mod.ModTag} Total prefabs in config: {config.Prefabs.Count}");
            Mod.Log($"{Mod.ModTag} Output mode: {(showAll ? "ALL" : "PROBLEMS ONLY")}");

            foreach (PrefabXml prefabXml in config.Prefabs)
            {
                PrefabID id = new PrefabID(prefabXml.Type, prefabXml.Name);

                string status;
                if (!prefabSystem.TryGetPrefab(id, out PrefabBase prefab))
                {
                    status = "MISSING";
                    missing++;
                }
                else if (!prefabSystem.TryGetEntity(prefab, out _))
                {
                    status = "NO_ENTITY";
                    noEntity++;
                }
                else
                {
                    status = "OK";
                    ok++;
                }

                // Default: only print problems.
                if (showAll || status != "OK")
                {
                    Mod.Log($"{Mod.ModTag} PREFAB {status}: {prefabXml}");
                }
            }

            Mod.Log($"{Mod.ModTag} Summary: OK={ok}, NO_ENTITY={noEntity}, MISSING={missing}");
            Mod.Log($"{Mod.ModTag} Note: MISSING prefabs from DLC you do not own is normal.");
#if DEBUG
            if (!showAll)
            {
                Mod.Log($"{Mod.ModTag} Tip: enable VerboseLogs (Debug builds) to print ALL entries.");
            }
#endif
            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP END ===");
        }


        internal static void ListComponents(PrefabBase prefab, Entity entity)
        {
            // Requires ReadAndApply to have initialized EntityManager.
            if (m_PrefabSystem == null)
            {
                return;
            }

            foreach (ComponentType componentType in m_EntityManager.GetComponentTypes(entity))
            {
                Mod.Log($"{prefab.GetType().Name}.{prefab.name}.{componentType.GetManagedType().Name}: {componentType}");
            }
        }

        // -----------------------------------------
        // NOT USED helpers (kept for future work)
        // -----------------------------------------

        public static void SetFieldValue<T>(ref T component, string fieldName, object newValue)
            where T : struct, IComponentData
        {
            Type type = typeof(T);
            FieldInfo? field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (field == null)
            {
                Mod.LogIf($"Field not found: {type.Name}.{fieldName}");
                return;
            }

            object? oldValue = field.GetValue(component);
            field.SetValueDirect(__makeref(component), newValue);

            // Verbose only; avoid log spam.
            Mod.LogIf($"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
        }

        public static void ConfigureComponentData<T>(ComponentXml compXml, ref T component)
            where T : struct, IComponentData
        {
            // Known to be unsafe currently; keep disabled unless explicitly re-enabled.
            Type type = typeof(T);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo field in fields)
            {
                object? oldValue = field.GetValue(component);

                if (compXml.TryGetField(field.Name, out FieldXml fieldXml))
                {
                    if (field.FieldType == typeof(float))
                    {
                        field.SetValueDirect(__makeref(component), fieldXml.ValueFloat);
                    }
                    else
                    {
                        field.SetValueDirect(__makeref(component), fieldXml.ValueInt);
                    }

                    Mod.LogIf($"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
                }
                else
                {
                    Mod.LogIf($"{type.Name}.{field.Name}: {oldValue}");
                }
            }
        }
    }
}
