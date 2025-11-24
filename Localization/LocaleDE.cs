// LocaleDE.cs
// German de-DE for City Services Redux.

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

            // Show "City Services Redux 0.5.0" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Optionen – eine auswählen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml verwenden" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),
                    "Name dieses Mods."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),
                    "Aktuelle Versionsnummer."
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
                    "**Schnellstart** – alle empfohlenen Presets auf einmal anwenden.\n" +
                    "EASY-Modus: 1 Klick und fertig!\n\n" +
                    "Empfohlen für die meisten Spieler – enthält bereits handverlesene Anpassungen, " +
                    "z.B. andere Mitarbeiterzahlen/Löhne als im Vanilla-Spiel."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "EIGENE Config.xml VERWENDEN"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER-USER**\n" +
                    "Wenn aktiviert, verwendet der Mod eine lokale Datei " +
                    "<ModsData/RealCity/Config.xml> anstelle der eingebauten Presets.\n" +
                    "• Für fortgeschrittene Spieler, die je nach Spielstand oder PC andere Dienst-Einstellungen wollen.\n\n" +
                    "**TIPPS**\n" +
                    "Klicke auf den Button „OPEN Config folder“.\n" +
                    "• Er zeigt den Speicherort der bereitgestellten Config.xml in ModsData/RealCity; " +
                    "dort kannst du Mitarbeiterzahlen und andere Werte anpassen.\n" +
                    "• Setze die Anzahl der Arbeitsplätze **nie** auf 0; nutze kleine positive Werte, wenn du sehr wenig Personal willst.\n" +
                    "• Nach Änderungen Datei speichern und dann den **APPLY**-Button nutzen, um die Änderungen im Mod zu übernehmen.\n\n" +
                    "Verwende <Restore new> <NUR>, wenn du die Datei zerschossen hast oder komplett neu anfangen möchtest – " +
                    "die vorhandene Config.xml wird dann ersetzt.\n" +
                    "Du kannst jederzeit wieder auf **[Use PRESETS]** umschalten."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "Config-Ordner ÖFFNEN"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Nicht zwingend erforderlich – nur nutzen, wenn du die Standard-Presets des Mods ändern möchtest.\n" +
                    "• Öffnet den Ordner <ModsData/RealCity/>, der **Config.xml** enthält.\n" +
                    "1. Bearbeite die Datei mit deinem bevorzugten Editor (z.B. <Notepad++>).\n\n" +
                    "2. Beispielpfad (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "NEUE Konfiguration jetzt ANWENDEN"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Liest deine lokale Datei <ModsData/RealCity/Config.xml> und wendet die neuen Werte " +
                    "auf die City-Service-Prefabs an (Arbeitsplätze, Verarbeitungsraten usw.).\n\n" +
                    "• Gilt nur für **neue Gebäude**, nicht für bereits gebaute.\n" +
                    "• In bestehenden Städten: altes Gebäude abreißen und neu platzieren, um die Änderungen zu sehen.\n" +
                    "• Wenn du mit den Werten zufrieden bist, reicht es, eine Stadt zu laden.\n" +
                    "   Du musst **Apply New** nur erneut klicken, wenn du Config.xml wieder geändert hast."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Deine neuen, benutzerdefinierten Änderungen werden auf viele City-Service-Gebäude angewendet.\n" +
                    "Bist du sicher?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Neue Config.xml wiederherstellen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "NEU STARTEN-BUTTON\n\n" +
                    "Überschreibt **ModsData/RealCity/Config.xml** mit einer frischen Kopie der ursprünglichen Mod-Presets.\n" +
                    "• Nur verwenden, wenn deine eigene Datei beschädigt ist oder du komplett neu beginnen möchtest.\n\n" +
                    "• **Restore new** ersetzt die vorhandene Datei – schließe die alte Config.xml vorher in deinem Editor."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/RealCity/Config.xml mit der Original-Datei überschreiben?\n\n" +
                    "Alle von dir gemachten Anpassungen werden durch eine frische Kopie ersetzt."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (now only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Wähle <[Use PRESETS]> – empfohlen, um die eingebauten Presets zu nutzen.\n" +
                    "Wenn du PRESETS wählst, bist du fertig – spiele einfach.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 – Power-User\n" +
                    "Wähle <[Use CUSTOM Config.xml]>, um deine eigenen Werte zu bearbeiten.\n\n" +
                    "1. Klicke auf <[OPEN Config folder]>.\n" +
                    "2. Öffne, bearbeite und speichere <Config.xml> mit deinem Texteditor.\n" +
                    "3. Klicke dann auf <[APPLY NEW Configuration Now]>.\n" +
                    "4. <Lade eine Stadt> (oder neu laden), um die Änderungen bei **neuen** Gebäuden zu sehen."
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
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Ausführliches Logging (fortgeschritten)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Schreibt viele zusätzliche Informationen in die Log-Datei.\n" +
                    "<NICHT empfohlen> für normales Spielen.\n" +
                    "Zu viel Logging kann das Spiel verlangsamen und sehr große Log-Dateien erzeugen.\n" +
                    "Nur vorübergehend aktivieren, wenn du Daten sammeln oder ein Problem debuggen willst."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Prefab-Status ins Log schreiben"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**POWER-USER**\n" +
                    "Prüft jedes Prefab, das in Config.xml aufgeführt ist, und protokolliert, ob es OK oder fehlend ist.\n" +
                    "• Nach einem Spiel-Patch nutzen, um zu sehen, welche Einträge in Config.xml nicht mehr zum Spiel passen.\n" +
                    "• Warnungen für Prefabs von DLC-Gebäuden, die du nicht besitzt, sind normal und können ignoriert werden."
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
                    "Neue Config.xml wiederherstellen"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Entspricht dem Button im „Aktionen“-Tab: überschreibt <ModsData/RealCity/Config.xml> " +
                    "mit einer neuen Kopie der ursprünglichen Presets.\n" +
                    "Verwenden, wenn deine Datei defekt ist oder du frisch anfangen willst."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/RealCity/Config.xml> mit der ursprünglichen PRESETS-Datei des Mods überschreiben?\n\n" +
                    "Alle benutzerdefinierten Änderungen werden durch eine neue Datei ersetzt."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
