// File: Config/ConfigTool.Apply.cs
// Purpose: Apply path (load config, dedupe, iterate prefabs) for Config-XML.

namespace ConfigXML
{
    using Game.Prefabs;               // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;                     // Exception
    using System.Collections.Generic; // HashSet
    using System.Globalization;       // CultureInfo
    using System.IO;                  // File, FileInfo
    using System.Threading;           // Interlocked
    using Unity.Entities;             // Entity, EntityManager, World

    public static partial class ConfigTool
    {
        public static bool isLatePrefabsActive = false;

        private static PrefabSystem? m_PrefabSystem;
        private static EntityManager m_EntityManager;

        private static int s_IsApplying;

        // Dedupe back-to-back applies of the same config file (same mode + same file stamp).
        private static string? s_LastApplySignature;
        private static bool s_LastApplyWasCustom;

        private static readonly object s_WarnLock = new object();
        private static readonly HashSet<string> s_WarnedKeys = new HashSet<string>();

        private static int s_FieldsChangedThisApply;
        private static int s_ComponentsPatchedThisApply;
        private static int s_PrefabsPatchedThisApply;
        private static int s_InitCallsThisApply;
        private static int s_UnsupportedSkipsThisApply;

        private static void WarnOnce(string key, string message)
        {
            bool shouldLog;
            lock (s_WarnLock)
            {
                shouldLog = s_WarnedKeys.Add(key);
            }

            if (shouldLog)
            {
                Mod.Warn(message);
            }
        }

        // File stamp string used only for dedupe: "size|LastWriteTimeUtcTicks"
        private static string BuildFileSignature(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    return "missing";
                }

                var fi = new FileInfo(path);
                return fi.Length.ToString(CultureInfo.InvariantCulture) + "|" +
                       fi.LastWriteTimeUtc.Ticks.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {
                return "unknown";
            }
        }

        private static bool ShouldSkipApply(bool isCustomMode, string signature)
        {
            if (string.IsNullOrEmpty(signature) || signature == "missing" || signature == "unknown")
            {
                return false;
            }

            return s_LastApplySignature == signature && s_LastApplyWasCustom == isCustomMode;
        }

        private static void ConfigurePrefab(PrefabBase prefab, PrefabXml prefabConfig, Entity entity)
        {
            bool prefabPatched = false;

            if (ConfigureComponent(prefab, prefabConfig, prefab, entity))
            {
                prefabPatched = true;
            }

            if (prefab.components != null)
            {
                foreach (ComponentBase component in prefab.components)
                {
                    if (component == null)
                    {
                        continue;
                    }

                    if (ConfigureComponent(prefab, prefabConfig, component, entity))
                    {
                        prefabPatched = true;
                    }
                }
            }

            if (prefabPatched)
            {
                s_PrefabsPatchedThisApply++;
            }
        }

        public static void ReadAndApply()
        {
            if (Interlocked.Exchange(ref s_IsApplying, 1) == 1)
            {
                Mod.Warn($"{Mod.ModTag} Apply already running; skipping.");
                return;
            }

            try
            {
                s_FieldsChangedThisApply = 0;
                s_ComponentsPatchedThisApply = 0;
                s_PrefabsPatchedThisApply = 0;
                s_InitCallsThisApply = 0;
                s_UnsupportedSkipsThisApply = 0;

                string assetPath = Mod.GetAssetPathSafe();
                bool isCustom = Mod.setting != null && Mod.setting.UseLocalConfig;

                // “Signature block”: build a stamp from the actual file path we will use.
                string configPathUsed = isCustom
                    ? ConfigToolXml.GetCustomConfigPathResolved(assetPath)
                    : ConfigToolXml.GetPresetConfigPathResolved(assetPath);

                string sig = BuildFileSignature(configPathUsed);

                if (ShouldSkipApply(isCustom, sig))
                {
                    Mod.Log($"{Mod.ModTag} Apply skipped (no changes): {(isCustom ? "CUSTOM" : "PRESETS")} unchanged.");
                    return;
                }

                ConfigurationXml? config = isCustom
                    ? ConfigToolXml.LoadLocalConfig(assetPath)
                    : ConfigToolXml.LoadPresetConfig(assetPath);

                if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
                {
                    Mod.Warn("ConfigTool.ReadAndApply: no configuration data loaded; nothing to apply.");
                    return;
                }

                Mod.Log(isCustom
                    ? $"{Mod.ModTag} Apply CUSTOM Config.xml (ModsData)."
                    : $"{Mod.ModTag} Apply PRESETS Config.xml (mod folder).");

                World? world = World.DefaultGameObjectInjectionWorld;
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

                int ok = 0;
                int missingOrNoEntity = 0;

                foreach (PrefabXml prefabXml in config.Prefabs)
                {
                    PrefabID prefabID = new PrefabID(prefabXml.Type, prefabXml.Name);

                    if (m_PrefabSystem.TryGetPrefab(prefabID, out PrefabBase prefab) &&
                        m_PrefabSystem.TryGetEntity(prefab, out Entity entity))
                    {
                        ok++;
                        ConfigurePrefab(prefab, prefabXml, entity);
                    }
                    else
                    {
                        missingOrNoEntity++;
                    }
                }

                s_LastApplySignature = BuildFileSignature(configPathUsed);
                s_LastApplyWasCustom = isCustom;

                Mod.Log($"{Mod.ModTag} Apply done. OK={ok}, Missing/NoEntity={missingOrNoEntity}, PrefabsPatched={s_PrefabsPatchedThisApply}, ComponentsPatched={s_ComponentsPatchedThisApply}, FieldsChanged={s_FieldsChangedThisApply}");
            }
            finally
            {
                Interlocked.Exchange(ref s_IsApplying, 0);
            }
        }
    }
}
