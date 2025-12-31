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
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml verwenden" },
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Schnellstart-Presets" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Schnellstart> - wendet integrierte Presets automatisch an.\n" +
                    "EINFACH-Modus:  1 Klick und FERTIG.\n\n" +
                    "Empfohlen für die meisten Spieler.\n" +
                    "Erhöht Arbeiterzahlen (und kleine Anpassungen an erforderliche Bildungsstufen).\n" +
                    "Wechsel zwischen Presets und Custom-Datei jederzeit möglich.\n" +
                    "Preset-Datei und ModsData-Custom-Datei sind getrennt."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Eigene Datei verwenden" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<Fortgeschrittene Nutzer>\n" +
                    "Verwendet eine lokale Datei: <ModsData/ConfigXML/Config.xml>\n" +
                    "statt der Presets des Mods.\n" +

                    "<TIPPS>\n" +
                    "**Config-Ordner öffnen**\n" +
                    "• **Config.xml** mit Texteditor bearbeiten (Notepad++)\n" +
                    "• Arbeitsplätze nicht auf 0 setzen (kleine Werte nutzen).\n" +
                    "• Nach Änderungen: speichern und <NEUE Config anwenden> klicken.\n\n" +
                    "<Auf Standard zurücksetzen> ersetzt die Custom-Datei.\n" +
                    "Zurück zu Presets jederzeit möglich (getrennte Dateien)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Config-Ordner ÖFFNEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Optional\n" +
                    "• Öffnet <ModsData/ConfigXML/> mit **Config.xml**.\n" +
                    "1. Mit bevorzugtem Texteditor bearbeiten (Notepad++).\n\n" +
                    "2. Beispielpfad (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "NEUE Config ANWENDEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest <ModsData/ConfigXML/Config.xml> und wendet neue Werte auf Service-Prefabs an (z.B. Arbeitsplätze)\n" +
                    "• Gilt für **neue Gebäude** (nicht für bestehende).\n" +
                    "• In bestehenden Städten: Gebäude ersetzen, um Änderungen zu sehen.\n" +
                    "• Nach Bearbeiten + Speichern erneut auf **Anwenden** klicken."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Änderungen auf neu gebaute Service-Gebäude anwenden?\n " +
                    "Sicher?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Config.xml auf Standard zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**NEUSTART**-Button.\n\n" +
                    "Überschreibt **ModsData/ConfigXML/Config.xml** mit einer frischen Standardkopie (Presets im Mod).\n" +
                    "• Nutzen bei defekter Datei oder sauberem Reset.\n\n" +
                    "• Offene Config.xml vor dem Reset schließen."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml mit Standarddatei (Presets) überschreiben?\n\n" +
                    "Neue Datei ERSETZT die vorhandene."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Option 1 - Schnellstart>\n" +
                    "**[Schnellstart-Presets]** auswählen.\n" +
                    "Fertig - spielen."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Option 2 - Fortgeschrittene Nutzer>\n" +
                    "**[Eigene Datei verwenden]** für eigene Einstellungen.\n\n" +
                    "1. **[Config-Ordner ÖFFNEN]** klicken\n" +
                    "2. **Config.xml** bearbeiten und speichern (Notepad++).\n" +
                    "3. **[NEUE Config ANWENDEN]** klicken\n" +
                    "4. Neues Service-Gebäude bauen, um neue Werte zu sehen.\n" +
                    "5. Schritte 1-4 ohne Neustart wiederholen, wenn nach Änderungen <ANWENDEN> geklickt wird.\n\n" +

                    "Migrationshinweis:\n" +
                    "Wenn ModsData/RealCity/Config.xml existierte, wurde es nach **ModsData/ConfigXML/Config.xml** kopiert.\n" +
                    "Logs/ConfigXML.log prüfen.\n" +
                    "Alte Datei ignorieren: ModsData/RealCity löschen (optional), Spiel starten und\n" +
                    "**[Auf Standard zurücksetzen]** verwenden"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab-Status ins Log schreiben"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**Fortgeschrittene Nutzer**\n" +
                    "Einmaliger Check: loggt, ob jedes Prefab in Config.xml OK oder fehlend ist.\n" +
                    "• Nützlich nach Patches, um kaputte Einträge zu finden.\n" +
                    "• Warnungen für DLC-Prefabs ohne Besitz ignorieren - normal.\n" +
                     "Logdatei: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Ausführliche Logs (Warnungen rechts lesen)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<NICHT fürs normale Spielen.>\n" +
                    "Ausführliche Logs können das Spiel verlangsamen und große Dateien erzeugen.\n" +
                    "Nur **kurzzeitig** zum Debuggen aktivieren.\n" +
                    "<Wenn unklar, besser DEAKTIVIERT lassen.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods** Webseite für die Mods des Autors."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Auf Standard zurücksetzen (neues Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Gleich wie der Reset in Aktionen\n" +
                    "Überschreibt <ModsData/ConfigXML/Config.xml> mit der Standarddatei" +
                    "Nutzen bei defekter Datei, für Neustart, oder für die neue Mod-Version (manche Updates haben mehr Gebäude)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> mit Standarddatei überschreiben?\n" +
                    "Alle Custom-Änderungen werden ersetzt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
