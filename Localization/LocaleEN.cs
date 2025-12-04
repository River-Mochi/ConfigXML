// LocaleEN.cs
// English en-US City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.3" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
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
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "RECOMMENDED PRESETS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Quick Start** - apply all recommended presets\n" +
                    "EASY Mode:  1-Click and DONE!\n\n" +

                    "Recommended for most players - already has curated tweaks e.g. worker numbers/wages and more that differ from game defaults."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "USE CUSTOM FILE" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "When enabled, allows using a local custom <ModsData/RealCity/Config.xml> instead of the built-in presets.\n" +
                    "• For advanced users who want different service settings per save or per machine.\n\n" +
                    "**TIPS**\n" +
                    "Click Open config folder button\n" +
                    "• It shows location of provided Config.xml in ModsData/RealCity, then tweak worker counts or other fields.\n" +
                    "• **Never** set workplaces to 0; use small positive values if you need low staffing.\n" +
                    "• After making changes, save the file, then use the **APPLY** button to update file changes to the mod.\n\n" +
                    "Use <Reset new> file <ONLY> if you mess up or just want a completely fresh Config.xml - replaces existing file.\n" +
                    "You can switch back to **PRESETS** at any time. "
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OPEN Config folder" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "This is not required, only use this if you plan on changing the default presets already set by the mod.\n" +
                    "• Opens <ModsData/RealCity/> folder that contains **Config.xml**.\n" +
                    "1. Edit this with your preferred text editor (i.e., <Notepad++>).\n\n" +
                    "2. Example path it opens (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APPLY new configuration now"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Reads your local <ModsData/RealCity/Config.xml> and applies the new values to city-service prefabs" +
                    "(workplaces, processing rates, etc.).\n\n" +
                    "• Applies to **new buildings** and not existing ones.\n" +
                    "• For existing cities, delete the old building; new buildings show changed values.\n" +
                    "• If you are happy with the settings, you can just load a city.\n" +
                    "   Only need to click **Apply New** when you update Config.xml again."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Apply your new custom changes to many city-service buildings.\n " +
                    "Are you sure?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Reset new Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "START OVER BUTTON\n\n" +
                    "Overwrite the **ModsData/RealCity/Config.xml** with a fresh copy of the original mod presets.\n" +
                    "• Use this <only> if your custom file becomes corrupt or you just want to start over.\n\n" +
                    "• **Reset new** replaces the existing file - must close original Config.xml file first."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Overwrite ModsData/RealCity/Config.xml with original file?\n\n" +
                    "Custom changes you applied to the file are replaced with a fresh copy."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Select  <[RECOMMENDED PRESETS]> for built-in presets.\n" +
                    "If you pick PRESETS, done - Play game.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 - Power users\n" +
                    "Select  <[Use CUSTOM FILE]> to edit your own Config.xml.\n\n" +
                    "1. Click <[OPEN Config folder]>\n" +
                    "2. Open, edit, save <Config.xml> with a text editor (e.g., Notepad++).\n" +
                    "3. Click <[APPLY NEW Configuration Now]> - updates any changes to file.\n" +
                    "4. <Load City> (or reload) to see changes to <NEW> buildings.\n" +
                    "5. Steps 1-4 can be repeated with no restart if you click <APPLY> changes."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "Verbose logs (Read Warnings on right side before use)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Writes a lot of extra information to the log file.\n" +
                    "<Do NOT use> for normal gameplay.\n" +
                    "Excessive logging can slow the game and create large log files.\n" +
                    "Turn this on only temporarily when collecting data or debugging.\n" +
                    "If you don't know what this is, best to leave it DISABLED."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Dump prefab status to log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER USERS**\n" +
                    "Checks every prefab listed in Config.xml and logs whether it is OK or missing.\n" +
                    "• Use this after a game patch to see which entries in Config.xml no longer match the game.\n" +
                    "• Ignore warnings for prefabs of DLC buildings you do not own - it's normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Open the **Paradox Mods** webpage for City Services Redux and other mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Reset new Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Same as the Actions tab button: overwrite the local <ModsData/RealCity/Config.xml> with a fresh copy of " +
                    "the original mod Presets.\n" +
                    "Use this if your custom file is broken or you want to start fresh."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/RealCity/Config.xml> with original mod PRESETS file?\n\n" +
                    "Any custom changes will be replaced by new file."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
