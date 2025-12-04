// LocaleDE.cs
// German (de-DE) City Services Redux.

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

            // Show "City Services Redux 0.5.3" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Optionen - eine auswählen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "So verwendest du Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
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
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "EMPFOHLENE PRESETS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Schnellstart** – alle empfohlenen Presets anwenden\n" +
                    "EASY-Modus: 1 Klick und fertig!\n\n" +
                    "Empfohlen für die meisten Spieler – bereits kuratierte Anpassungen z.B. bei Arbeitsplätzen/Löhnen " +
                    "und mehr, die von den Standardwerten des Spiels abweichen."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "EIGENE DATEI NUTZEN"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER-USER**\n" +
                    "Wenn aktiviert, wird eine lokale eigene Datei <ModsData/RealCity/Config.xml> statt der eingebauten Presets verwendet.\n" +
                    "• Für fortgeschrittene Spieler, die je nach Spielstand oder PC andere Einstellungen möchten.\n\n" +
                    "**TIPPS**\n" +
                    "Klicke auf den Button „Config-Ordner öffnen“.\n" +
                    "• Zeigt den Ordner mit der bereitgestellten Config.xml in ModsData/RealCity, dann kannst du dort Arbeitsplätze oder andere Felder anpassen.\n" +
                    "• Setze die Arbeitsplätze **niemals** auf 0; nutze kleine positive Werte, wenn du wenig Personal willst.\n" +
                    "• Nach Änderungen Datei speichern und den Button **APPLY** nutzen, um die Änderungen in den Mod zu übernehmen.\n\n" +
                    "Nutze <Reset new>, wenn du deine Datei zerschossen hast oder einfach wieder eine frische Config.xml möchtest – ersetzt die vorhandene Datei.\n" +
                    "Du kannst jederzeit zurück zu **PRESETS** wechseln. "
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "CONFIG-Ordner öffnen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Nicht erforderlich – nutze dies nur, wenn du die vom Mod gelieferten Presets ändern willst.\n" +
                    "• Öffnet den Ordner <ModsData/RealCity/>, der **Config.xml** enthält.\n" +
                    "1. Bearbeite sie mit deinem bevorzugten Editor (z.B. <Notepad++>).\n\n" +
                    "2. Beispielpfad unter Windows:\n" +
                    "C:/Users/DeinName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "NEUE Konfiguration anwenden"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest deine lokale <ModsData/RealCity/Config.xml> und wendet die neuen Werte auf City-Service-Prefabs an " +
                    "(Arbeitsplätze, Verarbeitungsraten usw.).\n\n" +
                    "• Gilt nur für **neue Gebäude**, nicht für bestehende.\n" +
                    "• Für bestehende Städte: altes Gebäude abreißen, neues platzieren – dann siehst du die geänderten Werte.\n" +
                    "• Wenn du mit den Einstellungen zufrieden bist, kannst du einfach eine Stadt laden.\n" +
                    "   Du musst **NEUE Konfiguration anwenden** nur klicken, wenn du Config.xml erneut geändert hast."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Deine neuen benutzerdefinierten Änderungen werden auf viele City-Service-Gebäude angewendet.\n " +
                    "Bist du sicher?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Neues Config.xml wiederherstellen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "NEU ANFANGEN-BUTTON\n\n" +
                    "Überschreibt **ModsData/RealCity/Config.xml** mit einer frischen Kopie der ursprünglichen Mod-Presets.\n" +
                    "• Nutze dies nur, wenn deine eigene Datei kaputt ist oder du komplett neu anfangen willst.\n\n" +
                    "• **Reset new** ersetzt die bestehende Datei – schließe die alte Config.xml vorher im Editor."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/RealCity/Config.xml mit der Originaldatei überschreiben?\n\n" +
                    "Alle eigenen Änderungen werden durch eine frische Kopie ersetzt."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Wähle <[EMPFOHLENE PRESETS]> für die eingebauten Presets.\n" +
                    "Wenn du PRESETS wählst, bist du fertig – spiele einfach.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 – Power-User\n" +
                    "Wähle <[EIGENE DATEI NUTZEN]>, um deine eigene Config.xml zu bearbeiten.\n\n" +
                    "1. Klicke <[CONFIG-Ordner öffnen]>.\n" +
                    "2. Öffne, bearbeite und speichere <Config.xml> mit einem Texteditor (z.B. Notepad++).\n" +
                    "3. Klicke <[NEUE Konfiguration anwenden]> – übernimmt die Änderungen aus der Datei.\n" +
                    "4. <Stadt laden> (oder neu laden), um Änderungen an **neuen** Gebäuden zu sehen.\n" +
                    "5. Schritte 1–4 kannst du wiederholen, ohne das Spiel neu zu starten, solange du immer <APPLY> klickst."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Ausführliche Logs (Warnungen rechts lesen, bevor du es nutzt)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Schreibt sehr viele Zusatzinformationen in die Logdatei.\n" +
                    "<Nicht verwenden> für normales Spielen.\n" +
                    "Zu viele Logs können das Spiel verlangsamen und große Logdateien erzeugen.\n" +
                    "Nur kurzzeitig einschalten, wenn du Daten sammelst oder debuggen musst.\n" +
                    "Wenn du nicht genau weißt, was das ist, lass es besser DEAKTIVIERT."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Prefab-Status ins Log schreiben"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER-USER**\n" +
                    "Prüft jedes Prefab in Config.xml und protokolliert, ob es OK oder fehlend ist.\n" +
                    "• Nutze dies nach einem Spielepatch, um zu sehen, welche Einträge in Config.xml nicht mehr zum Spiel passen.\n" +
                    "• Warnungen für DLC-Gebäude, die du nicht besitzt, kannst du ignorieren – das ist normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Öffnet die **Paradox Mods**-Seite für City Services Redux und andere Mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Neues Config.xml wiederherstellen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Wie der Button im Reiter „Aktionen“: überschreibt <ModsData/RealCity/Config.xml> mit einer frischen Kopie " +
                    "der ursprünglichen Mod-Presets.\n" +
                    "Nutze dies, wenn deine eigene Datei kaputt ist oder du komplett neu anfangen willst."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/RealCity/Config.xml> mit der ursprünglichen PRESETS-Datei des Mods überschreiben?\n\n" +
                    "Alle eigenen Änderungen werden durch eine neue Datei ersetzt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
