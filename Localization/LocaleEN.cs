// File: Localization/LocaleEN.cs
// English en-US for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            var title = Mod.ModName;

            // Show "Config-XML 0.6.2" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Pick one" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "How to use Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "RECOMMENDED PRESETS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Quick Start** - apply all built-in **preset** settings.\n" +
                    "EASY Mode:  1-Click and DONE!\n\n" +
                    "• Best for most players - curated tweaks (e.g. workers/wages).\n\n" +
                    "• You can switch between <Presets> and <Custom file> any time."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Use Custom File" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "Uses a custom file: <ModsData/ConfigXML/Config.xml>\n" +
                    "instead of the mod’s presets.\n\n" +
                    "<Steps>\n" +
                    "Click **[Open Config folder]**\n" +
                    "• Edit and Save **Config.xml** (Notepad++)\n" +
                    "• Then click **[APPLY New Config Now]**\n\n" +
                    "• Note: don’t set workers to 0.\n" +
                    "• Switch back to presets any time (separate file)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OPEN CONFIG FOLDER" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Opens folder with **Config.xml**.\n" +
                    "1. Edit file with a text editor (**Notepad++**).\n\n" +
                    "2. Example path (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLY NEW CONFIG NOW" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Reads **Config.xml** and applies new values to service prefabs (e.g., building workers)\n" +
                    "• Applies to **new buildings** (not existing ones).\n" +
                    "• Replace buildings to see new values.\n" +
                    "• Restart also applies the chosen config file."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Apply changes to any *new* service building?\nAre you sure?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset to Default Config" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER** button.\n\n" +
                    "**Overwrite Config.xml** with a fresh default file (includes presets).\n" +
                    "• Use this if the custom file is corrupt or you want a clean reset.\n\n" +
                    "• Close any open Config.xml files before Reset.\n" +
                    "• Copies to: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> with default (presets) file?\n\nNew file REPLACES existing file."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<RECOMMENDED> defaults - Done, play game :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Power Users**\n" +
                    "<[Use CUSTOM File]> to make custom settings.\n\n" +
                    "1. Click <[OPEN Config folder]>\n" +
                    "2. <Edit + Save **Config.xml**>.\n" +
                    "3. Click <[APPLY New Config Now]>\n" +
                    "4. Repeat steps 1-3 with no restart.\n\n" +
                    "<--------------------------->\n" +
                    "Migration from old mod:\n" +
                    "• Old </RealCity/Config.xml> (if present) was copied to <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Check Logs/ConfigXML.log for confirmation."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Display name of this mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Current version number." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Open the **Paradox Mods** webpage for the author’s mods."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Dump Prefab Status to log" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• One-time checks: logs whether each prefab in Config.xml is OK or Missing.\n" +
                    "• Useful after patches to see which entries no longer match.\n" +
                    "• Missing prefabs from DLC you don’t own is normal.\n\n" +
                    "• Output file: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> or <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Dump Component Fields (one-shot)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "One-time dump of prefab + component fields for prefabs listed in Config.xml.\n" +
                    "Output: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> or <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Warning: outputs a large file.\n\nLocation: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> or <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Reset to Default (make new Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Same** Reset button as Actions tab.\n" +
                    "**Overwrites Config.xml** with the default file.\n" +
                    "• File: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> with the default file?\nAny custom changes will be replaced."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Verbose logs (debug only)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<Do NOT use in normal gameplay.>\n" +
                    "• Can slow the game and create large files.\n" +
                    "• Enable only briefly for debugging."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
