// File: Config/ConfigTool.cs
// Purpose: Reads Config.xml and applies prefab + component tweaks.
// Notes:
// - Re-entrancy guard for Apply.
// - Skips duplicate rapid Apply calls (fixes double-apply on startup).
// - Only calls Initialize/LateInitialize when something actually changed.
// - Adds safe enum support (removes noisy "unsupported type" for common enum fields).
// - Adds DumpConfiguredPrefabComponentFieldsToFile() (Debug button support).
// - PrefabStatus "ALL" output goes to a file to avoid logger spam.

namespace ConfigXML
{
    using Game.Prefabs;       // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;             // Exception, Type, DateTime
    using System.Collections.Generic; // HashSet, Dictionary, List
    using System.IO;          // Path, Directory, StreamWriter
    using System.Reflection;  // BindingFlags, FieldInfo, MethodInfo
    using System.Text;        // StringBuilder
    using System.Threading;   // Interlocked
    using Unity.Entities;     // Entity, EntityManager, ComponentType, World, IComponentData
    using Unity.Mathematics;  // math
    using UnityEngine;        // Application

    public static class ConfigTool
    {
        // Enables late-prefab patch logic (if used elsewhere).
        public static bool isLatePrefabsActive = false;

        private static PrefabSystem? m_PrefabSystem;
        private static EntityManager m_EntityManager;

        // Prevent re-entrant apply (UI toggles / bindings can double-trigger).
        private static int s_IsApplying;

        // Safety limit: even "Verbose" shouldn't be able to generate infinite output.
        // This is per-apply call.
        private const int kVerboseLineLimitPerApply = 6000;
        private static int s_VerboseLinesThisApply;
        private static bool s_VerboseLimitLogged;

        // Skip duplicate rapid applies (fixes the “apply twice on startup” pattern).
        private static int s_LastApplyMode; // 0 = preset, 1 = local
        private static long s_LastApplyUtcTicks;
        private const long kApplyCooldownTicks = TimeSpan.TicksPerMillisecond * 250;

        // WarnOnce support (avoid repeating the same warning 222 times).
        private static readonly object s_WarnLock = new object();
        private static readonly HashSet<string> s_WarnOnceKeys = new HashSet<string>();

        // -----------------------------
        // Internal logging helpers
        // -----------------------------

        private static void V(string message)
        {
            if (!Mod.IsVerboseEnabled)
            {
                return;
            }

            int n = Interlocked.Increment(ref s_VerboseLinesThisApply);
            if (n > kVerboseLineLimitPerApply)
            {
                if (!s_VerboseLimitLogged)
                {
                    s_VerboseLimitLogged = true;
                    Mod.Warn($"{Mod.ModTag} Verbose log limit reached ({kVerboseLineLimitPerApply} lines for this apply). Additional verbose lines suppressed.");
                }

                return;
            }

            Mod.LogIfVerbose(message);
        }

        private static void WarnOnce(string key, string message)
        {
            lock (s_WarnLock)
            {
                if (s_WarnOnceKeys.Contains(key))
                {
                    return;
                }

                s_WarnOnceKeys.Add(key);
            }

            Mod.Warn(message);
        }

        private static string GetModsDataDir()
        {
            // Matches the game’s pattern you’re already seeing in logs:
            // .../Cities Skylines II/ModsData/ConfigXML
            return Path.Combine(Application.persistentDataPath, "ModsData", "ConfigXML");
        }

        private static bool ShouldSkipRapidApply(int mode)
        {
            long now = DateTime.UtcNow.Ticks;
            long last = Interlocked.Read(ref s_LastApplyUtcTicks);

            if (s_LastApplyMode == mode && (now - last) < kApplyCooldownTicks)
            {
                return true;
            }

            s_LastApplyMode = mode;
            Interlocked.Exchange(ref s_LastApplyUtcTicks, now);
            return false;
        }

        // -----------------------------------------
        // DEBUG: dump component fields (one component) to log (manual use only)
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
            V($"{prefab.name}: applying {prefab.GetType().Name} entity {entity.Index} skipEntity={skipEntity}");

            // Apply config to the root prefab instance.
            ConfigureComponent(prefab, prefabConfig, prefab, entity, skipEntity);

            // Apply config to each attached component.
            if (prefab.components == null)
            {
                return;
            }

            foreach (ComponentBase component in prefab.components)
            {
                if (component == null)
                {
                    continue;
                }

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
                V($"{prefab.name}.{component.name}: skipEntity flag set; skipping configuration.");
                return;
            }

            string compName = component.GetType().Name;
            bool anyChange = false;

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
                    float newVal = mwpcField.ValueFloat ?? oldProc.m_MaxWorkersPerCell;
                    if (!newVal.Equals(oldProc.m_MaxWorkersPerCell))
                    {
                        comp.process.m_MaxWorkersPerCell = newVal;
                        anyChange = true;
                        V($"{prefab.name}.IndustrialProcess.m_MaxWorkersPerCell: {oldProc.m_MaxWorkersPerCell} -> {comp.process.m_MaxWorkersPerCell}");
                    }
                }

                if (structConfig.TryGetField("m_Output.m_Amount", out FieldXml outamtField)
                    && outamtField.ValueIntSpecified)
                {
                    int newVal = outamtField.ValueInt ?? oldProc.m_Output.m_Amount;
                    if (newVal != oldProc.m_Output.m_Amount)
                    {
                        comp.process.m_Output.m_Amount = newVal;
                        anyChange = true;
                        V($"{prefab.name}.IndustrialProcess.m_Output.m_Amount: {oldProc.m_Output.m_Amount} -> {comp.process.m_Output.m_Amount}");
                    }
                }

                // When verbose is OFF, emit one short summary line only if something changed.
                if (anyChange && Mod.setting != null && !Mod.setting.VerboseLogs)
                {
                    Mod.Log($"{prefab.name}.IndustrialProcess updated: workersPerCell={comp.process.m_MaxWorkersPerCell}, output={comp.process.m_Output.m_Amount}");
                }
            }

            // -----------------------------
            // Default reflection-based patching
            // -----------------------------
            if (prefabConfig.TryGetComponent(compName, out ComponentXml compConfig))
            {
                V($"{prefab.name}.{compName}: component config found");

                foreach (FieldXml fieldConfig in compConfig.Fields)
                {
                    FieldInfo? field = component.GetType().GetField(
                        fieldConfig.Name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (field == null)
                    {
                        V($"{prefab.name}.{compName}: field not found: {fieldConfig.Name}");
                        continue;
                    }

                    object? oldValue = field.GetValue(component);

                    // Only set values if the xml actually specified that value.
                    object? newValue = null;
                    bool canSet = true;

                    if (field.FieldType == typeof(int))
                    {
                        if (!fieldConfig.ValueIntSpecified) { canSet = false; }
                        else { newValue = fieldConfig.ValueInt ?? 0; }
                    }
                    else if (field.FieldType == typeof(float))
                    {
                        if (!fieldConfig.ValueFloatSpecified) { canSet = false; }
                        else { newValue = fieldConfig.ValueFloat ?? 0f; }
                    }
                    else if (field.FieldType == typeof(uint))
                    {
                        if (!fieldConfig.ValueIntSpecified) { canSet = false; }
                        else { newValue = (uint)math.clamp(fieldConfig.ValueInt ?? 0, 0, int.MaxValue); }
                    }
                    else if (field.FieldType == typeof(short))
                    {
                        if (!fieldConfig.ValueIntSpecified) { canSet = false; }
                        else { newValue = (short)math.clamp(fieldConfig.ValueInt ?? 0, short.MinValue, short.MaxValue); }
                    }
                    else if (field.FieldType == typeof(byte))
                    {
                        if (!fieldConfig.ValueIntSpecified) { canSet = false; }
                        else { newValue = (byte)math.clamp(fieldConfig.ValueInt ?? 0, 0, byte.MaxValue); }
                    }
                    else if (field.FieldType.IsEnum)
                    {
                        if (!fieldConfig.ValueIntSpecified)
                        {
                            canSet = false;
                        }
                        else
                        {
                            int raw = fieldConfig.ValueInt ?? 0;
                            newValue = Enum.ToObject(field.FieldType, raw);

                            // If it’s not a defined enum value, warn once but still apply (some enums allow bitmasks / combos).
                            if (!Enum.IsDefined(field.FieldType, newValue))
                            {
                                string key = $"enum:{prefab.name}:{compName}:{field.Name}:{raw}";
                                WarnOnce(
                                    key,
                                    $"{Mod.ModTag} Enum value not defined (still applied): {prefab.name}.{compName}.{field.Name} <- {raw} ({field.FieldType.Name})");
                            }
                        }
                    }
                    else
                    {
                        canSet = false;

                        string key = $"unsupported:{field.FieldType.FullName}:{compName}:{field.Name}";
                        WarnOnce(
                            key,
                            $"{Mod.ModTag} Unsupported field type skipped: {prefab.name}.{compName}.{field.Name} ({field.FieldType.Name})");
                    }

                    if (!canSet)
                    {
                        V($"{prefab.name}.{compName}.{field.Name}: value not specified or unsupported; skipped");
                        continue;
                    }

                    // Only write + mark change if the value actually changes.
                    if (oldValue == null || newValue == null || !oldValue.Equals(newValue))
                    {
                        field.SetValue(component, newValue);
                        anyChange = true;

                        if (Mod.IsVerboseEnabled)
                        {
                            object? after = field.GetValue(component);
                            V($"{prefab.name}.{compName}.{field.Name}: {oldValue} -> {after}");
                        }
                    }
                    else
                    {
                        // No-op: don’t spam logs, don’t trigger init hooks.
                        V($"{prefab.name}.{compName}.{field.Name}: unchanged; skipped");
                    }
                }
            }

            // Nothing changed => do not call Initialize/LateInitialize.
            if (!anyChange)
            {
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

            V($"{prefab.name}.{compName}: INIT={hasInit} LATE={hasLate} ARCH={hasArch}");

            // Both init paths present: skip to avoid unknown side-effects.
            if (hasInit && hasLate)
            {
                V($"DUALINIT: {prefab.name}.{compName} has both Init and LateInit; skipped.");
                return;
            }

            try
            {
                if (hasLate)
                {
                    V($"{prefab.name}.{compName}: calling LateInitialize");
                    component.LateInitialize(m_EntityManager, entity);
                }
                else if (hasInit)
                {
                    V($"{prefab.name}.{compName}: calling Initialize");
                    component.Initialize(m_EntityManager, entity);
                }
                else
                {
                    V($"ZEROINIT: {prefab.name}.{compName} has no Init/LateInit; prefab may not refresh.");
                }

                if (hasArch)
                {
                    V($"ARCHETYPE: {prefab.name}.{compName} has RefreshArchetype; not supported.");
                }
            }
            catch (Exception ex)
            {
                Mod.Warn($"{Mod.ModTag} Init hook failed for {prefab.name}.{compName}: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // -----------------------------------------
        // APPLY: load config and patch PrefabSystem
        // -----------------------------------------
        public static void ReadAndApply()
        {
            // Guard against re-entrancy.
            if (Interlocked.Exchange(ref s_IsApplying, 1) == 1)
            {
                Mod.Warn($"{Mod.ModTag} Apply already running; skipping.");
                return;
            }

            s_VerboseLinesThisApply = 0;
            s_VerboseLimitLogged = false;

            try
            {
                string assetPath = Mod.GetAssetPathSafe();
                bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

                // Skip duplicate rapid apply calls (startup tends to trigger two).
                int mode = useLocal ? 1 : 0;
                if (ShouldSkipRapidApply(mode))
                {
                    V("Apply skipped (duplicate rapid call).");
                    return;
                }

                ConfigurationXml? config = useLocal
                    ? ConfigToolXml.LoadLocalConfig(assetPath)
                    : ConfigToolXml.LoadPresetConfig(assetPath);

                if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
                {
                    Mod.Warn("ConfigTool.ReadAndApply: no configuration data loaded; nothing to apply.");
                    return;
                }

                Mod.Log(useLocal
                    ? $"{Mod.ModTag} Apply LOCAL Config.xml (ModsData/ConfigXML)."
                    : $"{Mod.ModTag} Apply PRESET Config.xml (shipped mod defaults).");

                Mod.Log($"Apply config entries: {config.Prefabs.Count} prefab(s).");

                World? world = World.DefaultGameObjectInjectionWorld;
                if (world == null)
                {
                    Mod.Warn("ConfigTool.ReadAndApply: default ECS world not available; skip configuration.");
                    return;
                }

                m_PrefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();
                m_EntityManager = world.EntityManager;

                int ok = 0;
                int missingOrNoEntity = 0;

                // Dedupe identical entries in Config.xml (helps if a user accidentally duplicates rows).
                HashSet<string> seen = new HashSet<string>();

                foreach (PrefabXml prefabXml in config.Prefabs)
                {
                    string key = $"{prefabXml.Type}|{prefabXml.Name}";
                    if (!seen.Add(key))
                    {
                        WarnOnce($"dupe:{key}", $"{Mod.ModTag} Duplicate Config.xml entry skipped: {prefabXml}");
                        continue;
                    }

                    PrefabID prefabID = new PrefabID(prefabXml.Type, prefabXml.Name);

                    if (m_PrefabSystem.TryGetPrefab(prefabID, out PrefabBase prefab)
                        && m_PrefabSystem.TryGetEntity(prefab, out Entity entity))
                    {
                        V($"{prefabXml} found; applying.");
                        ConfigurePrefab(prefab, prefabXml, entity);
                        ok++;
                    }
                    else
                    {
                        V($"{prefabXml} missing/no-entity; skipped.");
                        missingOrNoEntity++;
                    }
                }

                Mod.Log($"Apply done. OK={ok}, Missing/NoEntity={missingOrNoEntity}");
            }
            catch (Exception ex)
            {
                Mod.Warn($"{Mod.ModTag} Apply failed: {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                Interlocked.Exchange(ref s_IsApplying, 0);
            }
        }

        // -----------------------------------------
        // DEBUG helpers
        // -----------------------------------------

        public static void DumpPrefabStatus()
        {
            string assetPath = Mod.GetAssetPathSafe();
            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

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

            PrefabSystem prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();

            bool wantAll = Mod.IsVerboseEnabled; // keep your existing behavior
            string mode = useLocal ? "LOCAL" : "PRESET";

            // Write ALL output to file (prevents logger spam / instability).
            string dir = GetModsDataDir();
            Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, $"PrefabStatus_{mode}.txt");

            int ok = 0;
            int missing = 0;
            int noEntity = 0;

            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP BEGIN ({mode}) ===");
            Mod.Log($"{Mod.ModTag} Total prefabs in config: {config.Prefabs.Count}");

            StreamWriter? writer = null;
            try
            {
                if (wantAll)
                {
                    writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
                    writer.WriteLine($"{Mod.ModTag} Prefab Status Dump ({mode}) @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();
                    Mod.Log($"{Mod.ModTag} Output mode: ALL (written to {filePath})");
                }
                else
                {
                    Mod.Log($"{Mod.ModTag} Output mode: PROBLEMS ONLY");
                }

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

                    if (status != "OK")
                    {
                        // Always show problems in log (actionable).
                        Mod.Log($"{Mod.ModTag} PREFAB {status}: {prefabXml}");
                    }

                    if (wantAll && writer != null)
                    {
                        writer.WriteLine($"{status}: {prefabXml}");
                    }
                }
            }
            catch (Exception ex)
            {
                Mod.Warn($"{Mod.ModTag} DumpPrefabStatus failed: {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                writer?.Dispose();
            }

            Mod.Log($"{Mod.ModTag} Summary: OK={ok}, NO_ENTITY={noEntity}, MISSING={missing}");
            Mod.Log($"{Mod.ModTag} Note: MISSING prefabs from DLC you do not own is normal.");
            Mod.Log($"{Mod.ModTag} === PREFAB STATUS DUMP END ===");
        }

        // Matches your Setting.cs call site (fixes CS0117).
        public static void DumpConfiguredPrefabComponentFieldsToFile()
        {
            string assetPath = Mod.GetAssetPathSafe();
            bool useLocal = Mod.setting != null && Mod.setting.UseLocalConfig;

            ConfigurationXml? config = useLocal
                ? ConfigToolXml.LoadLocalConfig(assetPath)
                : ConfigToolXml.LoadPresetConfig(assetPath);

            if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
            {
                Mod.Log("DumpConfiguredPrefabComponentFieldsToFile: config has no Prefabs to dump.");
                return;
            }

            World? world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                Mod.Log("DumpConfiguredPrefabComponentFieldsToFile: default ECS world not available; skip.");
                return;
            }

            PrefabSystem prefabSystem = world.GetOrCreateSystemManaged<PrefabSystem>();

            string mode = useLocal ? "LOCAL" : "PRESET";
            string dir = GetModsDataDir();
            Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, $"ConfiguredPrefabFields_{mode}.txt");

            try
            {
                using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine($"{Mod.ModTag} Configured Prefab Component Field Dump ({mode}) @ {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();

                    foreach (PrefabXml prefabXml in config.Prefabs)
                    {
                        PrefabID id = new PrefabID(prefabXml.Type, prefabXml.Name);

                        if (!prefabSystem.TryGetPrefab(id, out PrefabBase prefab))
                        {
                            writer.WriteLine($"MISSING PREFAB: {prefabXml}");
                            continue;
                        }

                        writer.WriteLine($"PREFAB: {prefabXml}  (name='{prefab.name}', type={prefab.GetType().Name})");

                        // Dump root "component" (prefab itself)
                        DumpComponentToWriter(writer, prefab, prefab);

                        if (prefab.components != null)
                        {
                            foreach (ComponentBase c in prefab.components)
                            {
                                if (c == null) { continue; }
                                DumpComponentToWriter(writer, prefab, c);
                            }
                        }

                        writer.WriteLine();
                    }
                }

                Mod.Log($"{Mod.ModTag} Component field dump saved to {filePath}");
            }
            catch (Exception ex)
            {
                Mod.Warn($"{Mod.ModTag} DumpConfiguredPrefabComponentFieldsToFile failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private static void DumpComponentToWriter(StreamWriter writer, PrefabBase prefab, ComponentBase component)
        {
            writer.WriteLine($"  COMPONENT: {component.GetType().Name}  (name='{component.name}')");

            Type type = component.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                if (field.Name == "isDirty" || field.Name == "active" || field.Name == "components")
                {
                    continue;
                }

                object? value = null;
                try
                {
                    value = field.GetValue(component);
                }
                catch
                {
                    value = "<unreadable>";
                }

                writer.WriteLine($"    {field.Name}: {value}");
            }
        }

        internal static void ListComponents(PrefabBase prefab, Entity entity)
        {
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
                if (Mod.IsVerboseEnabled)
                {
                    Mod.LogIfVerbose($"Field not found: {type.Name}.{fieldName}");
                }

                return;
            }

            object? oldValue = field.GetValue(component);
            field.SetValueDirect(__makeref(component), newValue);

            if (Mod.IsVerboseEnabled)
            {
                Mod.LogIfVerbose($"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
            }
        }

        public static void ConfigureComponentData<T>(ComponentXml compXml, ref T component)
            where T : struct, IComponentData
        {
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

                    if (Mod.IsVerboseEnabled)
                    {
                        Mod.LogIfVerbose($"{type.Name}.{field.Name}: {oldValue} -> {field.GetValue(component)} ({field.FieldType})");
                    }
                }
                else
                {
                    if (Mod.IsVerboseEnabled)
                    {
                        Mod.LogIfVerbose($"{type.Name}.{field.Name}: {oldValue}");
                    }
                }
            }
        }
    }
}
