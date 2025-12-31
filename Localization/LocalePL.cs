// Localization/LocalePL.cs
// Polish pl-PL for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opcje - wybierz jedną" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Jak używać Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nazwa wyświetlana moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktualny numer wersji." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Presety - Szybki Start" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Szybki Start> - automatycznie stosuje wbudowane presety.\n" +
                    "Tryb EASY:  1 klik i GOTOWE!\n\n" +
                    "Polecane dla większości graczy.\n" +
                    "Zwiększa liczbę pracowników (plus drobne zmiany wymagań edukacji).\n" +
                    "Możesz przełączać Presety / Plik własny w każdej chwili.\n" +
                    "Plik presetów i plik ModsData (własny) są osobne."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Użyj pliku własnego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<DLA ZAAWANSOWANYCH>\n" +
                    "Używa lokalnego pliku: <ModsData/ConfigXML/Config.xml>\n" +
                    "zamiast presetów moda.\n" +

                    "<Wskazówki>\n" +
                    "Kliknij **Otwórz folder Config**\n" +
                    "• Edytuj **Config.xml** w edytorze tekstu (Notepad++)\n" +
                    "• Nie ustawiaj pracowników na 0 (użyj małych wartości).\n" +
                    "• Po zmianach: zapisz plik i kliknij <ZASTOSUJ nową config TERAZ>\n\n" +
                    "<Przywróć domyślne> zastępuje istniejący plik własny.\n" +
                    "W każdej chwili możesz wrócić do presetów (osobne pliki)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OTWÓRZ folder Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Opcjonalne\n" +
                    "• Otwiera folder <ModsData/ConfigXML/> z **Config.xml**.\n" +
                    "1. Edytuj w swoim edytorze (Notepad++).\n\n" +
                    "2. Przykładowa ścieżka (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "ZASTOSUJ nową config TERAZ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Czyta <ModsData/ConfigXML/Config.xml> i stosuje nowe wartości do prefabów usług (np. pracownicy)\n" +
                    "• Działa na **nowe budynki** (nie na istniejące).\n" +
                    "• W istniejących miastach: zastąp budynek, żeby zobaczyć zmiany.\n" +
                    "• Po edycji + zapisie Config.xml kliknij **Zastosuj nową** ponownie."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Zastosować zmiany do nowo budowanych budynków usług?\n " +
                    "Na pewno?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Przywróć domyślne Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OD NOWA**.\n\n" +
                    "Nadpisuje **ModsData/ConfigXML/Config.xml** świeżą kopią domyślną (presety w modzie).\n" +
                    "• Użyj, gdy plik jest uszkodzony albo chcesz czysty reset.\n\n" +
                    "• Zamknij otwarty Config.xml przed resetem."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Nadpisać ModsData/ConfigXML/Config.xml plikiem domyślnym (presety)?\n\n" +
                    "Nowy plik ZASTĘPUJE istniejący."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Opcja 1 - Szybki Start>\n" +
                    "Wybierz **[Presety - Szybki Start]**.\n" +
                    "Gotowe - graj."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Opcja 2 - Dla zaawansowanych>\n" +
                    "**[Użyj pliku własnego]** żeby ustawić po swojemu.\n\n" +
                    "1. Kliknij **[OTWÓRZ folder Config]**\n" +
                    "2. Edytuj i zapisz **Config.xml** (Notepad++).\n" +
                    "3. Kliknij **[ZASTOSUJ nową config TERAZ]**\n" +
                    "4. Zbuduj nowy budynek usług, aby zobaczyć nowe wartości.\n" +
                    "5. Powtarzaj 1-4 bez restartu, klikając <ZASTOSUJ nową> po zmianach.\n\n" +

                    "Uwaga (migracja):\n" +
                    "Jeśli istniał ModsData/RealCity/Config.xml, został skopiowany do **ModsData/ConfigXML/Config.xml**.\n" +
                    "Sprawdź Logs/ConfigXML.log.\n" +
                    "Aby zignorować stary plik: usuń ModsData/RealCity (opcjonalnie), uruchom grę i\n" +
                    "użyj **[Przywróć domyślne]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Wypisz status prefabów do logu"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**DLA ZAAWANSOWANYCH**\n" +
                    "Jednorazowy test: loguje, czy prefab z Config.xml jest OK czy brakuje.\n" +
                    "• Przydatne po patchach gry.\n" +
                    "• Ostrzeżenia dla prefabów DLC, których nie masz, ignoruj - to normalne.\n" +
                    "Log: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Szczegółowe logi (najpierw przeczytaj ostrzeżenia po prawej)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NIE do normalnej gry.>\n" +
                    "Szczegółowe logi mogą spowolnić grę i tworzyć duże pliki.\n" +
                    "Włącz tylko **na chwilę** do debugowania.\n" +
                    "<Nie wiesz co to? Zostaw WYŁĄCZONE.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Otwiera stronę **Paradox Mods** z modami autora."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Przywróć domyślne (nowy Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "To samo co reset w zakładce Akcje\n" +
                    "Nadpisuje <ModsData/ConfigXML/Config.xml> plikiem domyślnym.\n" +
                    "Użyj, gdy plik jest zepsuty, chcesz reset, albo chcesz nową wersję domyślnych wartości (czasem update dodaje budynki)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Nadpisać <ModsData/ConfigXML/Config.xml> plikiem domyślnym?\n" +
                    "Twoje zmiany zostaną zastąpione."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
