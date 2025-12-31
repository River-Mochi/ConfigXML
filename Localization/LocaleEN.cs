// Localization/LocaleEN.cs
// English en-US for Config-XML.

namespace ConfigXML
{
    using Colossal;
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Options - pick one" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "How to use Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Display name of this mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Current version number." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Quick-Start Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Quick Start> - applies built-in presets automatically.\n" +
                    "EASY Mode:  1-Click and DONE!\n\n" +
                    "Recommended for most players.\n" +
                    "Increases worker numbers (and other minor tweaks to education levels required for a job).\n" +
                    "You can switch between Presets and Custom file at any time.\n" +
                    "Preset file and ModsData custom file are separate."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Use Custom File" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<POWER USERS>\n" +
                    "Uses a local custom file: <ModsData/ConfigXML/Config.xml>\n" +
                    "instead of the Mod provided presets.\n" +

                    "<TIPS>\n" +
                    "Click **Open Config folder**\n" +
                    "• Edit **Config.xml** with a text editor (Notepad++)\n" +
                    "• Don't set workers to 0 (use small values for few workers).\n" +
                    "• After edits: save the file, then click <APPLY New Config Now>\n\n" +
                    "<Reset to Defaults> replaces the existing custom file.\n" +
                    "Switch back to Presets any time (separate files)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OPEN Config folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Optional\n" +
                    "• Opens <ModsData/ConfigXML/> folder that contains **Config.xml**.\n" +
                    "1. Edit this with your preferred text editor (Notepad++).\n\n" +
                    "2. Example path (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLY New Config Now" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Reads <ModsData/ConfigXML/Config.xml> and applies the new values to service prefabs (e.g., building workers)\n" +
                    "• Applies to **new buildings** (not existing ones).\n" +
                    "• For existing cities, replace the old building to see new values.\n" +
                    "• Click **Apply New** again after edit+save Config.xml."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Apply changes to newly built service buildings?\n " +
                    "Are you sure?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset to Default Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER** button.\n\n" +
                    "Overwrite **ModsData/ConfigXML/Config.xml** with a fresh default copy (presets included with the mod).\n" +
                    "• Use this if the custom file is corrupt or a clean reset is needed.\n\n" +
                    "• Close any open Config.xml files before trying to Reset."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Overwrite ModsData/ConfigXML/Config.xml with default (presets) file?\n\n" +
                    "New file REPLACES existing file."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Option 1 - Quick Start>\n" +
                    "Select  **[Quick-Start Presets]** for built-in presets.\n" +
                    "Done - play game."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Option 2 - Power users>\n" +
                    "**[Use CUSTOM File]** to make custom settings.\n\n" +
                    "1. Click **[OPEN Config folder]**\n" +
                    "2. Edit and save **Config.xml** (Notepad++).\n" +
                    "3. Click **[APPLY New Config Now]**\n" +
                    "4. Build a new service building to see new values.\n" +
                    "5. Steps 1-4 can be repeated with no restart if you click <APPLY NEW> after changes.\n\n" +

                    "Migration note:\n" +
                    "If ModsData/RealCity/Config.xml existed, it was copied to **ModsData/ConfigXML/Config.xml**.\n" +
                    "Check Logs/ConfigXML.log to confirm.\n" +
                    "To ignore the old file: delete ModsData/RealCity (optional), start game, and\n" +
                    "use **[Reset to Defaults]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Dump Prefab status to log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER USERS**\n" +
                    "One-Time check: logs whether each prefab listed in Config.xml is OK or missing.\n" +
                    "• Useful after game patches to see which entries no longer match the game.\n" +
                    "• Ignore warnings for prefabs of DLC buildings you do not own - it's normal.\n" +
                     "Log File: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Verbose logs (Read Warnings on right side before use)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<NOT for normal gameplay.>\n" +
                    "Verbose logging can slow the game and create large log files.\n" +
                    "Enable only **temporarily** for debugging.\n" +
                    "<If you don't know what this is, best to leave it DISABLED.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Open the **Paradox Mods** webpage for the author's mods."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Reset to Defaults (make new Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Same as the Actions tab reset\n" +
                    "Overwrites <ModsData/ConfigXML/Config.xml> with the default file" +
                    "Use this if your custom file is broken, you want a fresh start, or want the new mod version (some updates have more buildings)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> with the default file?\n" +
                    "Any custom changes will be replaced."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
