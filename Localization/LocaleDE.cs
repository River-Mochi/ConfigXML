// LocaleDE.cs
// German de-DE City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.1" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Optionen – eins auswählen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml verwenden" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Anzeigename dieser Mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktuelle Versionsnummer."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "EMPFOHLENE PRESETS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Schnellstart** – wendet alle empfohlenen Presets an.\n" +
                    "EASY-Modus: 1 Klick und fertig!\n\n" +
                    "Empfohlen für die meisten Spieler – enthält bereits kuratierte Anpassungen, z.B. Arbeitsplätze/Löhne, " +
                    "die von den Standardwerten des Spiels abweichen."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "EIGENE Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER-USER**\n" +
                    "Aktiviert die Verwendung einer eigenen <ModsData/RealCity/Config.xml> statt der eingebauten Presets.\n" +
                    "• Für Spieler, die pro Spielstand oder PC andere Werte nutzen möchten.\n\n" +
                    "**TIPPS**\n" +
                    "Klicke auf den Button „Config-Ordner öffnen“.\n" +
                    "• Zeigt den Ordner mit der Config.xml in ModsData/RealCity – dort kannst du Arbeitsplätze oder andere Felder anpassen.\n" +
                    "• Setze Arbeitsplätze **nie** auf 0 – nutze kleine positive Werte für sehr wenig Personal.\n" +
                    "• Nach Änderungen speichern und dann den Button **NEUE Konfiguration anwenden** benutzen, um die Mod zu aktualisieren.\n\n" +
                    "Nutze <Config.xml zurücksetzen> **nur**, wenn deine Datei kaputt ist oder du komplett neu starten möchtest – die bestehende Datei wird ersetzt.\n" +
                    "Du kannst jederzeit zurück auf **EMPFOHLENE PRESETS** wechseln."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "Config-Ordner öffnen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Nicht erforderlich – nur nutzen, wenn du die Presets der Mod anpassen möchtest.\n" +
                    "• Öffnet den Ordner <ModsData/RealCity/>, der die **Config.xml** enthält.\n" +
                    "1. Bearbeite diese Datei mit einem Texteditor (z.B. <Notepad++>).\n\n" +
                    "2. Beispielpfad (Windows):\n" +
                    "C:/Users/DeinName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "NEUE Konfiguration anwenden"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest deine lokale <ModsData/RealCity/Config.xml> und wendet neue Werte auf City-Service-Prefabs an " +
                    "(Arbeitsplätze, Verarbeitung, usw.).\n\n" +
                    "• Gilt für **neue Gebäude**, nicht für bestehende.\n" +
                    "• In bestehenden Städten alte Gebäude abreißen – neu gebaute zeigen die geänderten Werte.\n" +
                    "• Wenn du zufrieden bist, kannst du einfach eine Stadt laden.\n" +
                    "   Du musst **NEUE Konfiguration anwenden** nur anklicken, wenn du die Config.xml wieder geändert hast."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Deine neuen benutzerdefinierten Änderungen werden auf viele City-Service-Gebäude angewendet.\n" +
                    "Bist du sicher?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Config.xml zurücksetzen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "NEU STARTEN-BUTTON\n\n" +
                    "Überschreibt **ModsData/RealCity/Config.xml** mit einer frischen Kopie der ursprünglichen Mod-Presets.\n" +
                    "• Nutze dies **nur**, wenn deine eigene Datei beschädigt ist oder du komplett neu anfangen willst.\n\n" +
                    "• „Config.xml zurücksetzen“ ersetzt die vorhandene Datei – schließe die Datei im Editor, bevor du den Button nutzt."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/RealCity/Config.xml mit der ursprünglichen Datei überschreiben?\n\n" +
                    "Alle eigenen Änderungen gehen verloren."
                },

                 // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Wähle <[EMPFOHLENE PRESETS]>, um die eingebauten Presets zu verwenden.\n" +
                    "Wenn du PRESETS nutzt, bist du fertig – spiel los.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 – Power-User\n" +
                    "Wähle <[EIGENE Config.xml]>, um deine eigenen Werte zu bearbeiten.\n\n" +
                    "1. Klicke auf <[Config-Ordner öffnen]>.\n" +
                    "2. Öffne, bearbeite und speichere <Config.xml> mit deinem bevorzugten Texteditor.\n" +
                    "3. Klicke dann auf <[NEUE Konfiguration anwenden]>.\n" +
                    "4. <Lade eine Stadt> (oder neu laden), um Änderungen an **neuen** Gebäuden zu sehen."
                },

                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)),
                    " "
                },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "Ausführliches Logging (fortgeschritten)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Schreibt sehr viele zusätzliche Informationen in die Log-Datei.\n" +
                    "<NICHT empfohlen> für normales Spielen.\n" +
                    "Zuviel Logging kann das Spiel verlangsamen und große Log-Dateien erzeugen.\n" +
                    "Nur vorübergehend aktivieren, wenn du Daten sammelst oder Fehler suchst."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Prefab-Status in Log ausgeben"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER-USER**\n" +
                    "Prüft jedes Prefab aus Config.xml und protokolliert, ob es OK oder fehlend ist.\n" +
                    "• Nach einem Patch verwenden, um zu sehen, welche Einträge in Config.xml nicht mehr zum Spiel passen.\n" +
                    "• Warnungen für Prefabs aus DLC-Gebäuden, die du nicht besitzt, sind normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods**-Seite für City Services Redux und deine anderen Mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Config.xml zurücksetzen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Wie der Button im Reiter Aktionen: überschreibt <ModsData/RealCity/Config.xml> mit einer frischen Kopie " +
                    "der ursprünglichen Mod-Presets.\n" +
                    "Nutze dies, wenn deine Datei kaputt ist oder du neu beginnen möchtest."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/RealCity/Config.xml> mit der ursprünglichen PRESET-Datei überschreiben?\n\n" +
                    "Alle eigenen Änderungen werden durch eine neue Datei ersetzt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
