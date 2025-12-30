// LocaleEN.cs
// English en-US for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using Game.Events;
    using System.Collections.Generic;
    using static Game.Prefabs.VehicleSelectRequirementData;

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
                    "**Quick Start** - apply all Quick-Start Presets\n" +
                    "EASY Mode:  1-Click and DONE!\n\n" +
                    "Recommended for most players; already has increaseed worker numbers that differ from game defaults" +
                    "(and other minor tweaks to education levels required for jobs.)\n" +
                    "You can switch between Presets and Custom file at any time (preset file is in a different location from ModsData/ customizable file)."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "USE CUSTOM FILE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "When enabled, allows using a local custom <ModsData/ConfigXML/Config.xml> instead of the built-in presets.\n" +
                    "• For advanced users who want different service settings per save or per machine.\n\n" +
                    "**TIPS**\n" +
                    "Click Open config folder button\n" +
                    "• It shows location of provided Config.xml in ModsData/ConfigXML, then tweak worker counts or other fields.\n" +
                    "• **Never** set workplaces to 0; use small positive values if you need low staffing.\n" +
                    "• After making changes, save the file, then use the **APPLY** button to update file changes to the mod.\n\n" +
                    "Use <Reset to Defaults>  <ONLY> if you mess up or just want a completely fresh Config.xml - replaces existing file.\n" +
                    "You can switch back to **PRESETS** at any time as the preset file is in a different location from ModsData/ customizable file."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OPEN Config folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "This is not required, only use this if you plan on changing the default presets already set by the mod.\n" +
                    "• Opens <ModsData/ConfigXML/> folder that contains **Config.xml**.\n" +
                    "1. Edit this with your preferred text editor (<Notepad++>).\n\n" +
                    "2. Example path (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLY New Config Now" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Reads your local <ModsData/ConfigXML/Config.xml> and applies the new values to service prefabs (e.g., building workplaces, etc..)" +
                    "• Applies to **new buildings** and not existing ones.\n" +
                    "• For existing cities, delete the old building; new buildings show changed values.\n" +
                    "• If you are happy with the settings, just load a city.\n" +
                    "• Only need to click **Apply New** when you update Config.xml again."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Apply your changes to all newly built service buildings.\n " +
                    "Are you sure?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset to Default Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER BUTTON**\n\n" +
                    "Overwrite any custom **ModsData/ConfigXML/Config.xml** with a fresh copy of the default presets included with the mod.\n" +
                    "• Use this if your custom file becomes corrupt or you just want to start over.\n\n" +
                    "• **Reset to Defaults** replaces the existing file - must close all Config.xml files first."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Overwrite ModsData/ConfigXML/Config.xml with original default file?\n\n" +
                    "New default presets file REPLACES any existing file you made."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Option 1 (Quick Start)>\n" +
                    "Select  [Quick-Start Presets] for built-in presets.\n" +
                    "Done - play game."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Option 2 - Power users>\n" +
                    "**[Use CUSTOM File]** to edit your own Config.xml.\n\n" +
                    "1. Click **[OPEN Config folder]**\n" +
                    "2. Open, edit, save **Config.xml** with a text editor (e.g., Notepad++).\n" +
                    "3. Click **[APPLY New Config Now]** - updates any changes to file.\n" +
                    "4. Load City, make a new building to see new values.\n" +
                    "5. Steps 1-4 can be repeated with no restart if you click <APPLY NEW> button.\n\n" +

                    "Migration note:\n" +
                    "If an old ../RealCity/Config.xml was found, it was copied to the new ../ConfigXML/Config.xml.\n" +
                    "Check ../Logs/ConfigXML to confirm.\n" +
                    "If you don't want your old file: delete ModsData/RealCity (optional), start game." +
                    " The <Reset to Defaults> will make a new copy of the Mod Preset file in ModsData/ for you to customize."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Dump Prefab status to log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER USERS**\n" +
                    "One-Time button: checks every prefab listed in Config.xml and logs whether it is OK or missing.\n" +
                    "• Use this after a game patch to see which entries in Config.xml no longer match the game.\n" +
                    "• Ignore warnings for prefabs of DLC buildings you do not own - it's normal.\n" +
                     "Location: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Verbose logs (Read Warnings on right side before use)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<Do NOT use> for normal gameplay.\n" +
                    "Excessive logging can slow the game and create large log files.\n" +
                    "Turn this on only **temporarily** when collecting data or debugging.\n" +
                    "<If you do not know what this is, best to leave it DISABLED.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Open the **Paradox Mods** webpage for **Config-XML** and other mods."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Reset to Defaults (make new Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Same as the Actions tab button: overwrite the local <ModsData/ConfigXML/Config.xml> with a fresh copy of " +
                    "the original mod default file (Quick-Start Presets file).\n" +
                    "Use this if your custom file is broken, you want a fresh start, or want the new mod version (some updates have more builings)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> with original mod PRESETS file?\n" +
                    "Any custom changes will be replaced by new file."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
