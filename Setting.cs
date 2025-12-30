// File: Setting.cs
// Purpose: Options UI + Config.xml helpers for Config-XML.

namespace ConfigXML
{
    using Colossal.IO.AssetDatabase; // ModSetting, FileLocation
    using Game.Modding;              // IMod
    using Game.Settings;             // Settings attributes
    using System;                    // Exception
    using System.IO;                 // Path, Directory
    using UnityEngine;               // Application.OpenURL

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

        // Used to force saving of ModSettings even if all visible options are defaults
        // (otherwise the settings file may not be created).
        [SettingsUIHidden]
        public bool _Hidden
        {
            get; set;
        }

        // --------------------
        // Actions tab: Options
        // --------------------

        /// <summary>
        /// Uses the Config.xml that ships with the mod (preset).
        /// Mutually exclusive with UseLocalConfig.
        /// Changing this applies immediately.
        /// </summary>
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

                // Presets on => local custom off.
                m_UseLocalConfig = false;

                if (!changed)
                {
                    return;
                }

                try
                {
                    Mod.Log("UseModPresets enabled; applying shipped preset configuration.");
                    ConfigTool.ReadAndApply();
                }
                catch (Exception ex)
                {
                    Mod.Log($"UseModPresets apply failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Uses ModsData/ConfigXML/Config.xml as a local custom file.
        /// Mutually exclusive with UseModPresets.
        /// Changing this applies immediately.
        /// </summary>
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

                // Local custom on => presets off.
                m_UseModPresets = false;

                if (!changed)
                {
                    return;
                }

                try
                {
                    Mod.Log("UseLocalConfig enabled; applying local configuration.");
                    ConfigTool.ReadAndApply();
                }
                catch (Exception ex)
                {
                    Mod.Log($"UseLocalConfig apply failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // -----------------------------------------
        // Actions tab: custom config buttons
        // Only visible when UseLocalConfig is enabled.
        // -----------------------------------------

        // Opens the folder that contains ModsData/ConfigXML/Config.xml.
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
                    // Ensures Config.xml exists before opening the folder.
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

                    // Opens the folder; editor selection is up to the player.
                    OpenWithUnityFileUrl(modsDataDir, isDirectory: true);
                }
                catch (Exception ex)
                {
                    // Never throw from Options UI callbacks.
                    Mod.Log($"OpenConfigFile failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Applies current ModsData/ConfigXML/Config.xml (local custom).
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

                Mod.Log("ApplyConfiguration clicked.");
                ConfigTool.ReadAndApply();
            }
        }

        // Restores ModsData/ConfigXML/Config.xml from shipped Config.xml (Actions tab).
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

        // Multiline help text (localized) under Config Usage group.
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

        // Paradox Mods link button.
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

        // When enabled: writes detailed per-prefab/per-field logs.
        [SettingsUISection(kDebugSection, kDebugGroup)]
        public bool Logging
        {
            get; set;
        }

        // Dumps prefab presence status vs shipped preset config.
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
                    // Avoid throwing from Options UI callbacks.
                    Mod.s_Log?.Warn($"DumpPrefabStatus failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Restores ModsData/ConfigXML/Config.xml from shipped Config.xml (Debug tab).
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

        // ----------------
        // Defaults
        // ----------------

        public override void SetDefaults()
        {
            _Hidden = true;

            // Default OFF: avoids log spam and avoids performance cost.
            Logging = false;

            // Default behavior: shipped presets (no local custom file).
            m_UseModPresets = true;
            m_UseLocalConfig = false;
        }

        // -------------------------------
        // Helpers
        // -------------------------------

        // Shared reset implementation used by both reset buttons.
        private static void ResetLocalConfigInternal()
        {
            try
            {
                // Installed mod folder path when available; empty string otherwise.
                string assetPath = Mod.GetAssetPathSafe();

                // Copies shipped Config.xml into ModsData/ConfigXML/Config.xml when available.
                ConfigToolXml.RestoreDefaultConfigForUI(assetPath);
            }
            catch (Exception ex)
            {
                // Avoid throwing from Options UI callbacks.
                Mod.Log($"ResetLocalConfig failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // Opens a file or folder via Unity using a file:/// URI.
        private static void OpenWithUnityFileUrl(string path, bool isDirectory = false)
        {
            try
            {
                // Normalize to forward slashes for URI.
                string normalized = path.Replace('\\', '/');

                // Some platforms prefer trailing slash for directories.
                if (isDirectory && !normalized.EndsWith("/", StringComparison.Ordinal))
                {
                    normalized += "/";
                }

                string uri = "file:///" + normalized;
                Application.OpenURL(uri);
            }
            catch
            {
                // Swallow; callers log on failure where needed.
            }
        }
    }
}
