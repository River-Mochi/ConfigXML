// Setting.cs
// Options UI + Config.xml helpers for City Services Redux.

namespace RealCity
{
    using System;                         // Exception
    using System.IO;                      // Path, Directory
    using Colossal.IO.AssetDatabase;      // ModSetting, FileLocation
    using Game.Modding;                   // IMod
    using Game.Settings;                  // Settings attributes
    using UnityEngine;                    // Application.persistentDataPath, OpenURL

    [FileLocation("ModsSettings/RealCity/RealCity")]
    [SettingsUITabOrder(
        kSection,
        kDebugSection)]
    [SettingsUIGroupOrder(
        kToggleGroup,
        kButtonGroup,
        kConfigUsageGroup,
        kInfoGroup,
        kDebugGroup)]
    [SettingsUIShowGroupName(
        kToggleGroup,
        kButtonGroup,
        kConfigUsageGroup,
        kInfoGroup,
        kDebugGroup)]
    public class Setting : ModSetting
    {
        // Tabs (sections)
        public const string kSection = "Actions";
        public const string kDebugSection = "Debug";

        // Groups
        public const string kToggleGroup = "Options";
        public const string kButtonGroup = "Actions";
        public const string kConfigUsageGroup = "ConfigUsage";
        public const string kInfoGroup = "Info";
        public const string kDebugGroup = "Debug";

        // UIButton row grouping for custom config buttons
        private const string kCustomButtonsRow = "CustomConfigButtonsRow";

        // External links
        private const string kUrlParadoxMods =
             "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        // Backing fields for mutually exclusive toggles
        private bool m_UseModPresets;
        private bool m_UseLocalConfig;

        public Setting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        // Used to force saving of ModSettings even if all visible options are defaults
        // (would otherwise be empty and not created).
        [SettingsUIHidden]
        public bool _Hidden
        {
            get; set;
        }

        // --------------------
        // Actions tab: Options
        // --------------------

        /// <summary>
        /// Use the Config.xml that ships with the mod (mod presets).
        /// Mutually exclusive with UseLocalConfig toggle.
        /// Selecting this will immediately apply the preset configuration.
        /// </summary>
        [SettingsUISection(kSection, kToggleGroup)]
        public bool UseModPresets
        {
            get => m_UseModPresets;
            set
            {
                // Do not allow both toggles to be false.
                if (!value && !m_UseLocalConfig)
                {
                    return;
                }

                var changed = m_UseModPresets != value;
                m_UseModPresets = value;

                if (m_UseModPresets)
                {
                    // Presets on => local custom off.
                    m_UseLocalConfig = false;

                    if (changed)
                    {
                        try
                        {
                            Mod.Log("UseModPresets enabled; applying shipped preset configuration.");
                            ConfigTool.ReadAndApply();
                        }
                        catch (Exception ex)
                        {
                            Mod.Log(
                                $"UseModPresets apply failed: {ex.GetType().Name}: {ex.Message}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Use ModsData/RealCity/Config.xml as a local custom file.
        /// Mutually exclusive with UseModPresets toggle.
        /// Selecting this will immediately apply the local configuration.
        /// </summary>
        [SettingsUISection(kSection, kToggleGroup)]
        public bool UseLocalConfig
        {
            get => m_UseLocalConfig;
            set
            {
                // Do not allow both toggles to be false.
                if (!value && !m_UseModPresets)
                {
                    return;
                }

                var changed = m_UseLocalConfig != value;
                m_UseLocalConfig = value;

                if (m_UseLocalConfig)
                {
                    // Local custom on => presets off.
                    m_UseModPresets = false;

                    if (changed)
                    {
                        try
                        {
                            Mod.Log("UseLocalConfig enabled; applying local configuration.");
                            ConfigTool.ReadAndApply();
                        }
                        catch (Exception ex)
                        {
                            Mod.Log(
                                $"UseLocalConfig apply failed: {ex.GetType().Name}: {ex.Message}");
                        }
                    }
                }
            }
        }

        // -----------------------------
        // Actions tab: custom config buttons
        // Only visible when UseLocalConfig is enabled.
        // -----------------------------

        // Open Folder: ModsData/RealCity that contains Config.xml
        [SettingsUIButtonGroup(kCustomButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(kSection, kButtonGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        public bool OpenConfigFile
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    // Ensure the Config.xml exists (copy from shipped or create stub)
                    // and then open the containing folder.
                    var configPath = ConfigToolXml.GetConfigFilePathForUI();
                    var modsDataDir = Path.GetDirectoryName(configPath);

                    if (!string.IsNullOrEmpty(modsDataDir))
                    {
                        if (!Directory.Exists(modsDataDir))
                        {
                            Directory.CreateDirectory(modsDataDir);
                        }

                        // Just open the folder; player chooses their editor.
                        OpenWithUnityFileUrl(modsDataDir, isDirectory: true);
                    }
                }
                catch (Exception ex)
                {
                    // Never throw from options UI.
                    Mod.Log($"OpenConfigFile (folder) failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Apply-Update Config.xml (local custom file)
        [SettingsUIButtonGroup(kCustomButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(kSection, kButtonGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        [SettingsUIConfirmation]
        public bool ApplyConfiguration
        {
            set
            {
                if (!value)
                {
                    return;
                }

                Mod.Log("ApplyConfiguration clicked (local custom file).");
                ConfigTool.ReadAndApply();
            }
        }

        // Refresh file button: "I messed up my custom config file, give me a fresh copy" (Actions tab)
        [SettingsUIButton]
        [SettingsUISection(kSection, kButtonGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        [SettingsUIConfirmation]
        public bool ResetLocalConfig
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ResetLocalConfigInternal();
            }
        }

        // “How to use Config.xml” body text under the header (multiline).
        // Only visible when using a local custom config.
        [SettingsUIMultilineText]
        [SettingsUISection(kSection, kConfigUsageGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        public string ConfigUsageSteps => string.Empty;

        // ---------------
        // Debug tab: Info
        // ---------------

        [SettingsUISection(kDebugSection, kInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(kDebugSection, kInfoGroup)]
        public string VersionDisplay => Mod.ModVersion;

        // Paradox Mods link (Debug tab, under info)
        [SettingsUIButtonGroup("SocialLinks")]
        [SettingsUIButton]
        [SettingsUISection(kDebugSection, kInfoGroup)]
        public bool OpenParadoxModsButton
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(kUrlParadoxMods);
                }
                catch (Exception ex)
                {
                    Mod.Log(
                        $"Failed to open Paradox Mods: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // ----------------
        // Debug tab: DEBUG
        // ----------------

        [SettingsUISection(kDebugSection, kDebugGroup)]
        public bool Logging
        {
            get; set;
        }

        // Debug tab: dump current prefab status vs Config.xml into RealCity.log
        [SettingsUIButton]
        [SettingsUISection(kDebugSection, kDebugGroup)]
        public bool DumpPrefabStatus
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    ConfigTool.DumpPrefabStatus();
                }
                catch (Exception ex)
                {
                    // Don't let debug helper bubble an exception to the UI.
                    Mod.s_Log?.Warn(
                        $"DumpPrefabStatus failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Duplicate reset button on Debug tab (always visible)
        [SettingsUIButton]
        [SettingsUISection(kDebugSection, kDebugGroup)]
        [SettingsUIConfirmation]
        public bool ResetLocalConfigDebug
        {
            set
            {
                if (!value)
                {
                    return;
                }

                ResetLocalConfigInternal();
            }
        }

        public override void SetDefaults()
        {
            _Hidden = true;
            Logging = false;          // default OFF

            // Default behaviour: use shipped presets, no local custom file.
            m_UseModPresets = true;
            m_UseLocalConfig = false;
        }

        // -------------------------------
        // HELPERS
        // -------------------------------

        // Shared reset implementation used by both reset buttons.
        private static void ResetLocalConfigInternal()
        {
            try
            {
                var assetPath = Mod.modAsset != null ? Mod.modAsset.path : string.Empty;
                ConfigToolXml.RestoreDefaultConfigForUI(assetPath);
            }
            catch (Exception ex)
            {
                Mod.Log($"ResetLocalConfig failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // Helper: open a file or folder via Unity, using a file:/// URI.
        private static void OpenWithUnityFileUrl(string path, bool isDirectory = false)
        {
            try
            {
                // Normalize to forward slashes for URI.
                var normalized = path.Replace('\\', '/');

                // Some platforms like a trailing slash for directories.
                if (isDirectory && !normalized.EndsWith("/", StringComparison.Ordinal))
                {
                    normalized += "/";
                }

                var uri = "file:///" + normalized;
                Application.OpenURL(uri);
            }
            catch
            {
                // Swallow; callers already log if needed.
            }
        }
    }
}
