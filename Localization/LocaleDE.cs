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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Wähle eins" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "So nutzt du Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "EMPFOHLENE PRESETS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**EMPFOHLEN** - wendet integrierte **Presets** an.\n" +
                    "EASY-Modus:  1 Klick und FERTIG!\n\n" +
                    "• Am besten für die meisten Spieler, um Arbeiter zu erhöhen.\n" +
                    "• Du kannst jederzeit zwischen <Presets> und <Custom-Datei> wechseln.\n" +
                    "  (Preset-Datei und ModsData-Custom-Datei sind getrennt.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Custom-Datei verwenden" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "Nutzt eine lokale Custom-Datei: <ModsData/ConfigXML/Config.xml>\n" +
                    "statt der Mod-Presets.\n" +

                    "<Steps>\n" +
                    "Klicke **[CONFIG-ORDNER ÖFFNEN]**\n" +
                    "• **Config.xml** mit einem Texteditor bearbeiten + speichern (Notepad++)\n" +
                    "• Dann **[NEUE CONFIG JETZT ANWENDEN]** klicken\n\n" +
                    "• Hinweis: Arbeiter nicht auf 0 setzen.\n" +
                    "• Du kannst jederzeit zurück zu Presets (separate Dateien)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIG-ORDNER ÖFFNEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Öffnet den Ordner mit der **Config.xml**.\n" +
                    "1. Datei mit einem Texteditor bearbeiten (**Notepad++**).\n\n" +
                    "2. Beispielpfad (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "NEUE CONFIG JETZT ANWENDEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest **Config.xml** und wendet neue Werte auf Service-Prefabs an (z.B. Arbeiter)\n" +
                    "• Gilt für **neue Gebäude** (nicht für bestehende).\n" +
                    "• Ersetze alte Gebäude, um neue Werte zu sehen.\n" +
                    "• Nach Bearbeiten + Speichern von Config.xml: **Neu anwenden** klicken.\n" +
                    "• Ein Spiel-Neustart wendet ebenfalls die gewählte Config an.\n" +
                    "• Apply nutzt die Datei <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Änderungen auf *neu* gebaute Service-Gebäude anwenden?\n" +
                    "Sicher?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Auf Standard-Config zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OVER**-Button.\n\n" +
                    "**Config.xml überschreiben** mit einer frischen Default-Datei (enthält alle Presets).\n" +
                    "• Nutzen, wenn die Custom-Datei kaputt ist oder ein sauberer Reset nötig ist.\n\n" +
                    "• Schließe alle offenen Config.xml-Dateien vor dem Reset.\n" +
                    "• Kopiert eine neue Datei nach: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml mit Default-Datei (Presets) überschreiben?\n\n" +
                    "Neue Datei ERSETZT die vorhandene."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<EMPFOHLEN> für Defaults (Arbeiter ↑↑) - Fertig, spielen :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Power Users**\n" +
                    "<[CUSTOM-DATEI VERWENDEN]> für eigene Einstellungen.\n\n" +
                    "1. <[CONFIG-ORDNER ÖFFNEN]>\n" +
                    "2. <Config.xml bearbeiten + speichern>.\n" +
                    "3. <[NEUE CONFIG JETZT ANWENDEN]>\n" +
                    "4. Schritte 1-3 können ohne Neustart wiederholt werden.\n\n" +
                    "<--------------------------->\n" +
                    "Migration vom alten Mod:\n" +
                    "• Wenn die alte </RealCity/Config.xml> existierte, wurde sie nach <ModsData/ConfigXML/Config.xml> kopiert.\n" +
                    "• Check Logs/ConfigXML.log zur Bestätigung\n" +
                    "• Alte Dateien ignorieren: RealCity-Ordner löschen (optional), Spiel starten,\n" +
                    "• dann <[Auf Standard zurücksetzen]> nutzen, um die neueste Version zu erhalten."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Anzeigename dieses Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktuelle Versionsnummer." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods**-Webseite für die Mods des Autors."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab-Status ins Log schreiben" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **Einmal-Check-up**: loggt, ob jedes Prefab in Config.xml OK oder fehlend ist.\n" +
                    "• Nützlich nach Game-Patches, um zu sehen, welche Einträge nicht mehr passen.\n" +
                    "• Warnungen für DLC-Prefabs, die du nicht besitzt, sind normal.\n\n" +
                    "• Logdatei: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Auf Standard zurücksetzen (neue Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Gleicher** Reset-Button wie im Actions-Tab.\n" +
                    "**Überschreibt Config.xml** mit der Default-Datei.\n" +
                    "• Nutzen, wenn die Custom-Datei kaputt ist, du neu starten willst, oder du die neue Mod-Datei brauchst (manche Updates fügen Gebäude hinzu).\n" +
                    "• Datei wird hierhin kopiert: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Overwrite <ModsData/ConfigXML/Config.xml> mit der Default-Datei?\n" +
                    "Alle Custom-Änderungen werden ersetzt."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Verbose Logs (Warnungen rechts lesen, bevor du es nutzt)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NICHT im normalen Gameplay nutzen.>\n" +
                    "• Verbose Logs können das Spiel verlangsamen und große Dateien erzeugen.\n" +
                    "• Nur für ein paar Minuten für **temporäres Debugging** aktivieren.\n" +
                    "• <Wenn du nicht weißt, was das ist: besser AUS lassen.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
