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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Pick one" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "How to use Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "RECOMMENDED PRESETS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Quick Start** - apply all built-in **preset** settings.\n" +
                    "EASY Mode:  1-Click and DONE!\n\n" +
                    "• Best for most players - already has curated tweaks (e.g. worker numbers/wages that differ from game defaults.\n\n" +
                    "• You can switch between <Presets> and <Custom file> any time."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Use Custom File" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "Uses a local custom file: <ModsData/ConfigXML/Config.xml>\n" +
                    "instead of the Mod provided presets.\n" +

                    "<Steps>\n" +
                    "Click **[Open Config folder]**\n" +
                    "• Edit and Save **Config.xml** with a text editor (Notepad++)\n" +
                    "• Then click **[APPLY New Config Now]**\n\n" +
                    "• Note: don't set workers to 0.\n" +
                    "• Switch back to default presets any time (it's a separate file)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OPEN CONFIG FOLDER" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Opens folder with **Config.xml** file.\n" +
                    "1. Edit file with a text editor (**Notepad++**).\n\n" +
                    "2. Example path (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLY NEW CONFIG NOW" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Reads **Config.xml** and applies new values to service prefabs (e.g., building workers)\n" +
                    "• Applies to **new buildings** (not existing ones).\n" +
                    "• Replace the old buildings to see new values.\n" +
                    "• Click **Apply New** after any Edits + Save to Config.xml.\n" +
                    "• Game restart also applies the chosen config file.\n" +
                    "• Apply works on <ModsData/ConfigXML/Config.xml> file."

                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Apply changes to any *new* service building?\n " +
                    "Are you sure?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset to Default Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER** button.\n\n" +
                    "**Overwrite Config.xml** with a fresh default file (includes all presets).\n" +
                    "• Use this if the custom file is corrupt or a clean reset is needed.\n\n" +
                    "• Close any open Config.xml files before trying to Reset.\n" +
                    "• Copies a new file to: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Overwrite ModsData/ConfigXML/Config.xml with default (presets) file?\n\n" +
                    "New file REPLACES existing file."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<RECOMMENDED> for defaults (workers ↑↑) - Done, play game :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Power Users**\n" +
                    "<[Use CUSTOM File]> to make custom settings.\n\n" +
                    "1. Click <[OPEN Config folder]>\n" +
                    "2. <Edit + Save **Config.xml**>.\n" +
                    "3. Click <[APPLY New Config Now]>\n" +
                    "4. Steps 1-3 can be repeated with no restart.\n\n" +
                    "<--------------------------->\n" +
                    "Migration from old mod:\n" +
                    "• If old </RealCity/Config.xml> existed, it was copied to new <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Check Logs/ConfigXML.log for confirmation\n" +
                    "• To ignore old files: delete RealCity folder (optional), start game,\n" +
                    "• then use <[Reset to Default]> to get the newest version."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Display name of this mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Current version number." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Open the **Paradox Mods** webpage for the author's mods."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Dump Prefab Status to log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **One-Time check-up**: logs whether each prefab listed in Config.xml is OK or Missing.\n" +
                    "• Useful after game patches to see which entries no longer match the game.\n" +
                    "• Ignore warnings for prefabs of DLC buildings you do not own - it's normal.\n\n" +
                    "• Log File: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpConfiguredPrefabFieldsToFile)), "Dump Component Fields (one-shot)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpConfiguredPrefabFieldsToFile)),
                    "Writes a one-time dump of component fields for configured prefabs to ModsData/ConfigXML/ConfiguredPrefabFields.txt."
                },


                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Reset to Default (make new Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Same** Reset button that is on Actions tab.\n" +
                    "**Overwrites Config.xml** with the default file.\n" +
                    "• Use this if your custom file is broken, you want a fresh start, or want the new mod file (some updates have added buildings).\n" +
                    "• File Reset copied here: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> with the default file?\n" +
                    "Any custom changes will be replaced."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Verbose logs (Read Warnings on right side before use)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<Do NOT use in normal gameplay.>\n" +
                    "• Verbose logs can slow the game and create large files.\n" +
                    "• Enable only for a few minutes for **temporary debugging**.\n" +
                    "• <If you don't know what this is, best to leave it DISABLED.>"
                },

            };
        }

        public void Unload()
        {
        }
    }
}
