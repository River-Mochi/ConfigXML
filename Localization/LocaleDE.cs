// Localization/LocaleDE.cs
// German de-DE for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Optionen - eine wählen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "So nutzt du Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Anzeigename dieses Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktuelle Versionsnummer." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Quick-Start Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Quick Start> - wendet integrierte Presets automatisch an.\n" +
                    "EASY-Modus:  1 Klick und FERTIG!\n\n" +
                    "Empfohlen für die meisten Spieler.\n" +
                    "Erhöht Arbeiterzahlen (plus kleine Anpassungen an Bildungsanforderungen).\n" +
                    "Du kannst jederzeit zwischen Presets und Custom-Datei wechseln.\n" +
                    "Preset-Datei und ModsData-Custom-Datei sind getrennt."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Custom-Datei verwenden" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<POWER USERS>\n" +
                    "Nutzt eine lokale Custom-Datei: <ModsData/ConfigXML/Config.xml>\n" +
                    "statt der Mod-Presets.\n" +

                    "<TIPPS>\n" +
                    "Klicke **Config-Ordner öffnen**\n" +
                    "• **Config.xml** mit Texteditor bearbeiten (Notepad++)\n" +
                    "• Arbeiter nicht auf 0 setzen (für wenige Arbeiter kleine Werte nutzen).\n" +
                    "• Nach Änderungen: speichern, dann <NEUE Config JETZT anwenden> klicken.\n\n" +
                    "<Reset to Defaults> ersetzt die bestehende Custom-Datei.\n" +
                    "Du kannst jederzeit zurück zu Presets (separate Dateien)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Config-Ordner ÖFFNEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Optional\n" +
                    "• Öffnet <ModsData/ConfigXML/> mit **Config.xml**.\n" +
                    "1. Mit deinem Texteditor bearbeiten (Notepad++).\n\n" +
                    "2. Beispielpfad (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "NEUE Config JETZT anwenden" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest <ModsData/ConfigXML/Config.xml> und wendet neue Werte auf Service-Prefabs an (z.B. Arbeiter)\n" +
                    "• Gilt für **neue Gebäude** (nicht für bestehende).\n" +
                    "• In bestehenden Städten: Gebäude ersetzen, um Änderungen zu sehen.\n" +
                    "• Nach Bearbeiten + Speichern Config.xml: nochmal **Neu anwenden** klicken."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Änderungen auf neu gebaute Service-Gebäude anwenden?\n " +
                    "Sicher?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset to Defaults (Config.xml)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER**-Button.\n\n" +
                    "Überschreibt **ModsData/ConfigXML/Config.xml** mit einer frischen Default-Kopie (Presets im Mod).\n" +
                    "• Nutzen, wenn die Custom-Datei kaputt ist oder du sauber resetten willst.\n\n" +
                    "• Vor dem Reset alle offenen Config.xml-Dateien schließen."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml mit Default-Datei (Presets) überschreiben?\n\n" +
                    "Neue Datei ERSETZT die vorhandene."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Option 1 - Quick Start>\n" +
                    "Wähle **[Quick-Start Presets]**.\n" +
                    "Fertig - spielen."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Option 2 - Power Users>\n" +
                    "**[Custom-Datei verwenden]** für eigene Settings.\n\n" +
                    "1. **[Config-Ordner ÖFFNEN]** klicken\n" +
                    "2. **Config.xml** bearbeiten und speichern (Notepad++)\n" +
                    "3. **[NEUE Config JETZT anwenden]** klicken\n" +
                    "4. Neues Service-Gebäude bauen, um neue Werte zu sehen\n" +
                    "5. Schritte 1-4 ohne Neustart wiederholen: nach Änderungen einfach <Neu anwenden>\n\n" +

                    "Migration note:\n" +
                    "Wenn ModsData/RealCity/Config.xml existierte, wurde es nach **ModsData/ConfigXML/Config.xml** kopiert.\n" +
                    "Logs/ConfigXML.log prüfen.\n" +
                    "Alte Datei ignorieren: ModsData/RealCity löschen (optional), Spiel starten und\n" +
                    "**[Reset to Defaults]** verwenden"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab-Status ins Log schreiben"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER USERS**\n" +
                    "Einmal-Check: loggt, ob jedes Prefab in Config.xml OK oder fehlend ist.\n" +
                    "• Nützlich nach Game-Patches.\n" +
                    "• Warnungen für DLC-Prefabs, die du nicht besitzt, sind normal.\n" +
                    "Logdatei: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Verbose Logs (Warnungen rechts lesen)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<NICHT fürs normale Spielen.>\n" +
                    "Verbose Logs können das Spiel verlangsamen und große Logdateien erzeugen.\n" +
                    "Nur **kurzzeitig** zum Debuggen aktivieren.\n" +
                    "<Wenn du nicht weißt, was das ist: besser AUS lassen.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods** Webseite für die Mods des Autors."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Reset to Defaults (neues Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Gleich wie der Reset im Aktionen-Tab\n" +
                    "Überschreibt <ModsData/ConfigXML/Config.xml> mit der Default-Datei.\n" +
                    "Nutzen bei kaputter Datei, für Neustart, oder wenn du die neue Mod-Version Defaults willst (manche Updates fügen Gebäude hinzu)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> mit der Default-Datei überschreiben?\n" +
                    "Alle Custom-Änderungen werden ersetzt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
