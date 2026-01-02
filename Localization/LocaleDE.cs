// File: Localization/LocaleDE.cs
// German de-DE for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "So benutzt du Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "EMPFOHLENE PRESETS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Schnellstart** - wendet alle integrierten **Presets** an.\n" +
                    "EINFACH-Modus: 1 Klick und fertig!\n\n" +
                    "• Beste Wahl für die meisten – kuratierte Tweaks (z. B. Arbeiter/Löhne).\n\n" +
                    "• Du kannst jederzeit zwischen <Presets> und <Eigene Datei> wechseln."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Eigene Datei verwenden" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**FORTGESCHRITTENE**\n" +
                    "Verwendet eine eigene Datei: <ModsData/ConfigXML/Config.xml>\n" +
                    "statt der Presets des Mods.\n\n" +
                    "<Schritte>\n" +
                    "**[CONFIG-ORDNER ÖFFNEN]** klicken\n" +
                    "• **Config.xml** bearbeiten und speichern (Notepad++)\n" +
                    "• Dann **[NEUE CONFIG JETZT ANWENDEN]** klicken\n\n" +
                    "• Hinweis: Arbeiter nicht auf 0 setzen.\n" +
                    "• Zurück zu Presets jederzeit möglich (separate Datei)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIG-ORDNER ÖFFNEN" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Öffnet den Ordner mit **Config.xml**.\n" +
                    "1. Datei mit einem Editor bearbeiten (**Notepad++**).\n\n" +
                    "2. Beispielpfad (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "NEUE CONFIG JETZT ANWENDEN" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest **Config.xml** und wendet neue Werte auf Service-Prefabs an (z. B. Arbeiter)\n" +
                    "• Gilt für **neue Gebäude** (nicht für bestehende).\n" +
                    "• Gebäude ersetzen, um neue Werte zu sehen.\n" +
                    "• Neustart wendet die gewählte Datei ebenfalls an."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Änderungen auf *neue* Service-Gebäude anwenden?\nBist du sicher?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Auf Standard-Config zurücksetzen" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**NEUSTART**-Button.\n\n" +
                    "**Überschreibt Config.xml** mit einer frischen Standarddatei (inkl. Presets).\n" +
                    "• Nützlich bei defekter Custom-Datei oder für einen sauberen Reset.\n\n" +
                    "• Offene Config.xml vorher schließen.\n" +
                    "• Kopiert nach: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "<ModsData/ConfigXML/Config.xml> mit Standard (Presets) überschreiben?\n\nNeue Datei ERSETZT die vorhandene."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<EMPFOHLEN> Standardwerte - Fertig, viel Spaß :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Fortgeschrittene**\n" +
                    "<[Eigene Datei verwenden]> für eigene Einstellungen.\n\n" +
                    "1. <[CONFIG-ORDNER ÖFFNEN]> klicken\n" +
                    "2. <**Config.xml** bearbeiten + speichern>.\n" +
                    "3. <[NEUE CONFIG JETZT ANWENDEN]> klicken\n" +
                    "4. Schritte 1-3 ohne Neustart wiederholen.\n\n" +
                    "<--------------------------->\n" +
                    "Migration vom alten Mod:\n" +
                    "• Alte </RealCity/Config.xml> (falls vorhanden) wurde nach <ModsData/ConfigXML/Config.xml> kopiert.\n" +
                    "• Logs/ConfigXML.log prüfen."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Anzeigename dieses Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktuelle Versionsnummer." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods**-Seite mit den Mods des Autors."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab-Status ins Log schreiben" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**FORTGESCHRITTENE**\n" +
                    "• Einmal-Check: loggt, ob jeder Prefab in Config.xml OK ist oder Missing.\n" +
                    "• Nützlich nach Patches (Einträge finden, die nicht mehr passen).\n" +
                    "• Missing-Prefabs aus DLCs, die du nicht besitzt, sind normal.\n\n" +
                    "• Ausgabedatei: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> oder <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Komponentenfelder exportieren (einmalig)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Einmal-Export der Prefab- und Komponentenfelder für Prefabs aus Config.xml.\n" +
                    "Ausgabe: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> oder <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Warnung: erzeugt eine große Datei.\n\nOrt: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> oder <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Auf Standard zurücksetzen (neues Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Gleicher** Reset-Button wie im Aktionen-Tab.\n" +
                    "**Überschreibt Config.xml** mit der Standarddatei.\n" +
                    "• Datei: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> mit Standard überschreiben?\nEigene Änderungen werden ersetzt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Ausführliche Logs (nur Debug)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NICHT im normalen Spiel verwenden.>\n" +
                    "• Kann das Spiel verlangsamen und große Dateien erzeugen.\n" +
                    "• Nur kurzzeitig fürs Debug aktivieren."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
