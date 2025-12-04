// LocalePL.cs
// Polish (pl-PL) City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.3" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opcje – wybierz jedną" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Jak używać Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nazwa tego moda wyświetlana w grze." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktualny numer wersji." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "ZALECANE PRESETY"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Szybki start** – zastosuj wszystkie zalecane ustawienia.\n" +
                    "Tryb ŁATWY: jeden klik i gotowe!\n\n" +
                    "Polecane dla większości graczy – zawiera już ręcznie dobrane wartości (np. liczba pracowników/pensje itd.), " +
                    "inne niż domyślne ustawienia gry."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "UŻYJ WŁASNEGO PLIKU"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**UŻYTKOWNICY ZAAWANSOWANI**\n" +
                    "Po włączeniu mod użyje lokalnego pliku <ModsData/RealCity/Config.xml> zamiast wbudowanych presetów.\n" +
                    "• Dla graczy, którzy chcą innych ustawień usług dla różnych zapisów lub komputerów.\n\n" +
                    "**WSKAZÓWKI**\n" +
                    "Kliknij przycisk Otwórz folder Config.\n" +
                    "• Otworzy folder z plikiem Config.xml w ModsData/RealCity, gdzie możesz zmieniać liczbę pracowników i inne pola.\n" +
                    "• **Nigdy** nie ustawiaj liczby pracowników na 0; używaj małych dodatnich wartości, jeśli chcesz niski poziom obsady.\n" +
                    "• Po wprowadzeniu zmian zapisz plik i użyj przycisku **APPLY**, aby mod je odczytał.\n\n" +
                    "Użyj <Reset new>, jeśli plik się zepsuje lub chcesz całkiem nowy Config.xml – zastąpi on istniejący plik.\n" +
                    "W każdej chwili możesz wrócić do **PRESETÓW**. "
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "OTWÓRZ folder Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Nie jest wymagane – użyj tylko, jeśli chcesz zmieniać domyślne presety moda.\n" +
                    "• Otwiera folder <ModsData/RealCity/>, który zawiera **Config.xml**.\n" +
                    "1. Edytuj plik w swoim ulubionym edytorze tekstu (np. <Notepad++>).\n\n" +
                    "2. Przykładowa ścieżka w Windows:\n" +
                    "C:/Users/TwojaNazwa/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "ZASTOSUJ nową konfigurację"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Odczytuje lokalny plik <ModsData/RealCity/Config.xml> i stosuje nowe wartości do prefabów usług miejskich " +
                    "(liczba pracowników, wydajność itp.).\n\n" +
                    "• Działa tylko dla **nowych budynków**, a nie dla już istniejących.\n" +
                    "• W istniejących miastach usuń stary budynek i postaw nowy, aby zobaczyć zmiany.\n" +
                    "• Jeśli ustawienia są w porządku, po prostu wczytaj miasto.\n" +
                    "   Kliknij **Zastosuj nową** tylko wtedy, gdy ponownie zmienisz Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Twoje nowe, własne ustawienia zostaną zastosowane do wielu budynków usług miejskich.\n " +
                    "Na pewno kontynuować?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Przywróć nowy Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "PRZYCISK „ZACZNIJ OD NOWA”\n\n" +
                    "Nadpisuje **ModsData/RealCity/Config.xml** nową kopią oryginalnych presetów moda.\n" +
                    "• Użyj tylko, jeśli twój własny plik jest uszkodzony lub chcesz zacząć od zera.\n\n" +
                    "• **Przywróć nowy** zastępuje istniejący plik – najpierw zamknij stary Config.xml w edytorze."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Nadpisać ModsData/RealCity/Config.xml oryginalnym plikiem?\n\n" +
                    "Twoje własne zmiany zostaną zastąpione nową kopią."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opcja 1\n" +
                    "Wybierz <[ZALECANE PRESETY]>, aby używać wbudowanych ustawień.\n" +
                    "Jeśli wybierzesz PRESETY, to wszystko – możesz grać.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opcja 2 – Zaawansowani\n" +
                    "Wybierz <[UŻYJ WŁASNEGO PLIKU]>, aby edytować własny Config.xml.\n\n" +
                    "1. Kliknij <[OTWÓRZ folder Config]>.\n" +
                    "2. Otwórz, edytuj i zapisz <Config.xml> w edytorze tekstu (np. Notepad++).\n" +
                    "3. Kliknij <[ZASTOSUJ nową konfigurację]> – zastosuje zmiany z pliku.\n" +
                    "4. <Wczytaj miasto> (lub przeładuj), aby zobaczyć zmiany w **nowych** budynkach.\n" +
                    "5. Możesz powtarzać kroki 1–4 bez restartu gry, o ile po każdej zmianie klikasz <APPLY>."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Szczegółowe logi (przeczytaj ostrzeżenia po prawej przed użyciem)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Zapisuje do pliku logu bardzo dużo dodatkowych informacji.\n" +
                    "<NIE używaj> podczas normalnej gry.\n" +
                    "Zbyt dużo logów może spowolnić grę i tworzyć ogromne pliki.\n" +
                    "Włączaj tylko tymczasowo, gdy zbierasz dane lub debugujesz problemy.\n" +
                    "Jeśli nie wiesz dokładnie, do czego to służy, najlepiej zostaw WYŁĄCZONE."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Zapisz status prefabów do logu"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UŻYTKOWNICY ZAAWANSOWANI**\n" +
                    "Sprawdza każdy prefab wymieniony w Config.xml i zapisuje, czy jest OK, czy brakujący.\n" +
                    "• Po patchu gry użyj, aby zobaczyć, które wpisy w Config.xml nie pasują już do gry.\n" +
                    "• Ostrzeżenia o prefabach z DLC, których nie posiadasz, są normalne – można je zignorować."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Otwiera stronę **Paradox Mods** dla City Services Redux i innych modów."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Przywróć nowy Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Tak samo jak przycisk w zakładce Akcje: nadpisuje <ModsData/RealCity/Config.xml> nową kopią " +
                    "oryginalnych presetów moda.\n" +
                    "Użyj, jeśli twój własny plik jest uszkodzony lub chcesz zacząć od zera."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Nadpisać <ModsData/RealCity/Config.xml> oryginalnym plikiem PRESETÓW moda?\n\n" +
                    "Wszystkie własne zmiany zostaną zastąpione nowym plikiem."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
