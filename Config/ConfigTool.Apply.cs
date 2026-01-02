// File: Config/ConfigTool.Apply.cs
// Purpose: Apply path (load config, dedupe, iterate prefabs) for Config-XML.

namespace ConfigXML
{
    using Game.Prefabs;               // PrefabSystem, PrefabBase, ComponentBase, PrefabID
    using System;                     // Exception
    using System.Collections.Generic; // HashSet
    using System.Globalization;       // CultureInfo
    using System.IO;                  // File, FileInfo
    using System.Text;                // StringBuilder
    using System.Threading;           // Interlocked
    using Unity.Entities;             // Entity, EntityManager, World

    public static partial class ConfigTool
    {
        public static bool isLatePrefabsActive = false;

        private static PrefabSystem? m_PrefabSystem;
        private static EntityManager m_EntityManager;

        private static int s_IsApplying;

        private static string? s_LastApplySignature;
        private static bool s_LastApplyWasLocal; // True = CUSTOM, False = PRESETS

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

        private static bool ShouldSkipApply(bool useCustom, string signature)
        {
            if (string.IsNullOrEmpty(signature) || signature == "missing" || signature == "unknown")
            {
                return false;
            }

            return s_LastApplySignature == signature && s_LastApplyWasLocal == useCustom;
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

        private static string BuildApplyDoneLine(int ok, int missingOrNoEntity)
        {
            // Base is always shown.
            var sb = new StringBuilder(128);
            sb.Append(Mod.ModTag);
            sb.Append(" Apply done. OK=");
            sb.Append(ok);
            sb.Append(", Missing/NoEntity=");
            sb.Append(missingOrNoEntity);

            // Only show patch counters when they actually change something.
            if (s_PrefabsPatchedThisApply != 0)
            {
                sb.Append(", PrefabsPatched=");
                sb.Append(s_PrefabsPatchedThisApply);
            }

            if (s_ComponentsPatchedThisApply != 0)
            {
                sb.Append(", ComponentsPatched=");
                sb.Append(s_ComponentsPatchedThisApply);
            }

            if (s_FieldsChangedThisApply != 0)
            {
                sb.Append(", FieldsChanged=");
                sb.Append(s_FieldsChangedThisApply);
            }

            return sb.ToString();
        }

        public static void ReadAndApply()
        {
            // Silent guard prevents accidental extra log lines from UI double-trigger.
            if (Interlocked.Exchange(ref s_IsApplying, 1) == 1)
            {
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
                bool useCustom = Mod.setting != null && Mod.setting.UseLocalConfig;

                // Signature is built from the actual resolved path used (preset may fall back to custom).
                string configPathUsed = useCustom
                    ? ConfigToolXml.GetLocalConfigPathResolved(assetPath)
                    : ConfigToolXml.GetPresetConfigPathResolved(assetPath);

                string sig = BuildFileSignature(configPathUsed);

                if (ShouldSkipApply(useCustom, sig))
                {
                    return;
                }

                ConfigurationXml? config = useCustom
                    ? ConfigToolXml.LoadLocalConfig(assetPath)
                    : ConfigToolXml.LoadPresetConfig(assetPath);

                if (config == null || config.Prefabs == null || config.Prefabs.Count == 0)
                {
                    Mod.Warn("ConfigTool.ReadAndApply: no configuration data loaded; nothing to apply.");
                    return;
                }

                // Line 1 of 2 (exact wording you requested)
                Mod.Log(useCustom
                    ? $"{Mod.ModTag} Apply CUSTOM Config.xml (ModsData)."
                    : $"{Mod.ModTag} Apply PRESETS Config.xml (DLL folder).");

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
                s_LastApplyWasLocal = useCustom;

                // Line 2 of 2 (counters only when non-zero)
                Mod.Log(BuildApplyDoneLine(ok, missingOrNoEntity));
            }
            finally
            {
                Interlocked.Exchange(ref s_IsApplying, 0);
            }
        }
    }
}
