// File: Settings/Setting.cs
// Purpose: Options UI + Config.xml helpers for Config-XML.

namespace ConfigXML
{
    using Colossal.IO.AssetDatabase; // ModSetting, FileLocation
    using Game.Modding;              // IMod
    using Game.Settings;             // Settings attributes
    using System;                    // Exception, StringComparison
    using System.IO;                 // Path, Directory
    using UnityEngine;               // Application

    [FileLocation("ModsSettings/ConfigXML/ConfigSettings")]
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
        // --------------------
        // Tabs (sections)
        // --------------------

        public const string kSection = "Actions";
        public const string kDebugSection = "Debug";

        // --------------------
        // Groups
        // --------------------

        public const string kToggleGroup = "Options";
        public const string kButtonGroup = "Actions";
        public const string kConfigUsageGroup = "ConfigUsage";
        public const string kInfoGroup = "Info";
        public const string kDebugGroup = "Debug";

        // Keep multiple buttons on one row.
        private const string kCustomButtonsRow = "CustomConfigButtonsRow";

        // External links
        private const string kUrlParadoxMods =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        // Backing fields for mutually exclusive toggles.
        private bool m_UseModPresets;
        private bool m_UseLocalConfig;

        public Setting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        // Used to force saving of ModSettings even if all selected options are defaults
        [SettingsUIHidden]
        public bool _Hidden
        {
            get; set;
        }

        // --------------------
        // Actions tab: Options
        // --------------------

        [SettingsUISection(kSection, kToggleGroup)]
        public bool UseModPresets
        {
            get => m_UseModPresets;
            set
            {
                // Prevent both toggles from being false.
                if (!value && !m_UseLocalConfig)
                {
                    return;
                }

                bool changed = m_UseModPresets != value;
                m_UseModPresets = value;

                if (!m_UseModPresets)
                {
                    return;
                }

                // Presets on => custom off.
                m_UseLocalConfig = false;

                if (!changed)
                {
                    return;
                }

                try
                {
                    ConfigTool.ReadAndApply();
                }
                catch (Exception ex)
                {
                    Mod.Log($"Use Presets apply failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        [SettingsUISection(kSection, kToggleGroup)]
        public bool UseLocalConfig
        {
            get => m_UseLocalConfig;
            set
            {
                // Prevent both toggles from being false.
                if (!value && !m_UseModPresets)
                {
                    return;
                }

                bool changed = m_UseLocalConfig != value;
                m_UseLocalConfig = value;

                if (!m_UseLocalConfig)
                {
                    return;
                }

                // Custom on => presets off.
                m_UseModPresets = false;

                if (!changed)
                {
                    return;
                }

                try
                {
                    ConfigTool.ReadAndApply();
                }
                catch (Exception ex)
                {
                    Mod.Log($"Use Custom apply failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // -----------------------------------------
        // Actions tab: custom config buttons
        // Only visible when UseLocalConfig is enabled.
        // -----------------------------------------

        [SettingsUIButtonGroup(kCustomButtonsRow)]
        [SettingsUIButton]
        [SettingsUISection(kSection, kButtonGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        public bool OpenConfigFile      // opens folder
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    string configPath = ConfigToolXml.GetConfigFilePathForUI();
                    string? modsDataDir = Path.GetDirectoryName(configPath);

                    if (string.IsNullOrEmpty(modsDataDir))
                    {
                        return;
                    }

                    if (!Directory.Exists(modsDataDir))
                    {
                        Directory.CreateDirectory(modsDataDir);
                    }

                    OpenWithUnityFileUrl(modsDataDir, isDirectory: true);
                }
                catch (Exception ex)
                {
                    Mod.Log($"OpenConfig folder failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

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

                try
                {
                    Mod.Log("Apply Config clicked.");
                    ConfigTool.ReadAndApply();
                }
                catch (Exception ex)
                {
                    Mod.Warn($"Apply Config failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

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

        // ------------------------------------
        // Actions tab: How to use Config.xml
        // ------------------------------------

        [SettingsUIMultilineText]
        [SettingsUISection(kSection, kConfigUsageGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), false)]
        public string PresetUsageSteps => string.Empty;

        [SettingsUIMultilineText]
        [SettingsUISection(kSection, kConfigUsageGroup)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(UseLocalConfig), true)]
        public string CustomUsageSteps => string.Empty;

        // ---------------
        // Debug tab: Info
        // ---------------

        [SettingsUISection(kDebugSection, kInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(kDebugSection, kInfoGroup)]
        public string VersionDisplay => Mod.ModVersion;

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
                    Mod.Log($"Failed to open Paradox Mods: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // ----------------
        // Debug tab: Debug
        // ----------------

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
                    Mod.Warn($"DumpPrefabStatus failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

#if DEBUG
        [SettingsUIButton]
        [SettingsUISection(kDebugSection, kDebugGroup)]
        [SettingsUIConfirmation]
        public bool DumpComponentFields
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    ConfigTool.DumpXMLComponentFields();
                }
                catch (Exception ex)
                {
                    Mod.Warn($"DumpXMLComponentFields failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }
#else
        // Release build placeholder so Locale*.cs can reference nameof(Setting.DumpComponentFields) safely.
        [SettingsUIHidden]
        public bool DumpComponentFields
        {
            set { }
        }
#endif

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

        // VerboseLogs: DEBUG-only UI; hidden/no-op in Release (keeps locale keys stable).
#if DEBUG
        [SettingsUISection(kDebugSection, kDebugGroup)]
        public bool VerboseLogs
        {
            get; set;
        }
#else
        [SettingsUIHidden]
        public bool VerboseLogs
        {
            get => false;
            set { }
        }
#endif

        // -------------------------------
        // Helpers
        // -------------------------------

        private static void ResetLocalConfigInternal()
        {
            try
            {
                string assetPath = Mod.GetAssetPathSafe();
                ConfigToolXml.RestoreDefaultConfigForUI(assetPath);
            }
            catch (Exception ex)
            {
                Mod.Log($"ResetLocalConfig failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private static void OpenWithUnityFileUrl(string path, bool isDirectory = false)
        {
            try
            {
                string normalized = path.Replace('\\', '/');

                if (isDirectory && !normalized.EndsWith("/", StringComparison.Ordinal))
                {
                    normalized += "/";
                }

                string uri = "file:///" + normalized;
                Application.OpenURL(uri);
            }
            catch
            {
            }
        }

        // -----------------------------
        // Defaults: 1st run or missing
        // -----------------------------

        public override void SetDefaults()
        {
            _Hidden = true;         // always make settings file even if not needed
            // Default: PRESETS (no CUSTOM ModsData file).
            m_UseModPresets = true; 
            m_UseLocalConfig = false;

            VerboseLogs = false;   // currently disabled for all.
        }
    }
}
