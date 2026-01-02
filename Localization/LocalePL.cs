// File: Localization/LocalePL.cs
// Polish pl-PL for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Wybierz jedno" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Jak używać Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "POLECANE PRESETY" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Szybki start** - zastosuj wszystkie wbudowane ustawienia **preset**.\n" +
                    "Tryb EASY: 1 klik i gotowe!\n\n" +
                    "• Najlepsze dla większości graczy — dopieszczone zmiany (np. pracownicy/płace).\n\n" +
                    "• W każdej chwili możesz przełączyć <Presety> i <Własny plik>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Użyj własnego pliku" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**Dla zaawansowanych**\n" +
                    "Używa własnego pliku: <ModsData/ConfigXML/Config.xml>\n" +
                    "zamiast presetów moda.\n\n" +
                    "<Kroki>\n" +
                    "Kliknij **[OTWÓRZ FOLDER CONFIG]**\n" +
                    "• Edytuj i zapisz **Config.xml** (Notepad++)\n" +
                    "• Potem kliknij **[ZASTOSUJ NOWY CONFIG TERAZ]**\n\n" +
                    "• Uwaga: nie ustawiaj pracowników na 0.\n" +
                    "• Wróć do presetów kiedy chcesz (osobny plik)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OTWÓRZ FOLDER CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Otwiera folder z **Config.xml**.\n" +
                    "1. Edytuj plik w edytorze tekstu (**Notepad++**).\n\n" +
                    "2. Przykładowa ścieżka (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "ZASTOSUJ NOWY CONFIG TERAZ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Czyta **Config.xml** i stosuje nowe wartości do prefabów usług (np. pracownicy budynku)\n" +
                    "• Działa dla **nowych budynków** (nie zmienia istniejących).\n" +
                    "• Podmień budynki, żeby zobaczyć nowe wartości.\n" +
                    "• Restart też stosuje wybrany plik config."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Zastosować zmiany do *nowego* budynku usług?\nNa pewno?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Reset do domyślnego pliku" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**START OD NOWA**.\n\n" +
                    "**Nadpisuje Config.xml** świeżym plikiem domyślnym (z presetami).\n" +
                    "• Użyj, gdy własny plik jest uszkodzony albo chcesz czysty reset.\n\n" +
                    "• Zamknij otwarte pliki Config.xml przed resetem.\n" +
                    "• Kopiuje do: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Nadpisać <ModsData/ConfigXML/Config.xml> plikiem domyślnym (presety)?\n\nNowy plik ZASTĄPI istniejący."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<POLECANE> domyślne - Gotowe, graj :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opcja 2 - Dla zaawansowanych**\n" +
                    "<[Użyj własnego pliku]> żeby ustawić po swojemu.\n\n" +
                    "1. <[OTWÓRZ FOLDER CONFIG]>\n" +
                    "2. <Edytuj + zapisz **Config.xml**>\n" +
                    "3. <[ZASTOSUJ NOWY CONFIG TERAZ]>\n" +
                    "4. Powtarzaj kroki 1-3 bez restartu.\n\n" +
                    "<--------------------------->\n" +
                    "Migracja ze starego moda:\n" +
                    "• Stary </RealCity/Config.xml> (jeśli był) skopiowano do <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Sprawdź Logs/ConfigXML.log, żeby potwierdzić."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Wyświetlana nazwa tego moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktualny numer wersji." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Otwiera stronę **Paradox Mods** z modami autora."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Zrzuć status prefabów do logu" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**Dla zaawansowanych**\n" +
                    "• Jednorazowo: zapisuje, czy każdy prefab z Config.xml jest OK czy Missing.\n" +
                    "• Przydatne po patchach, żeby zobaczyć co już nie pasuje.\n" +
                    "• Missing z DLC, którego nie masz, to norma.\n\n" +
                    "• Plik wyjściowy: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> lub <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Zrzuć pola komponentów (jednorazowo)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Jednorazowy zrzut pól prefab + component dla prefabów z Config.xml.\n" +
                    "Wyjście: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> lub <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Uwaga: powstaje duży plik.\n\nLokalizacja: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> lub <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Reset do domyślnego (nowy Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**To samo** co Reset w zakładce Akcje.\n" +
                    "**Nadpisuje Config.xml** plikiem domyślnym.\n" +
                    "• Plik: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Nadpisać <ModsData/ConfigXML/Config.xml> plikiem domyślnym?\nWszystkie własne zmiany zostaną zastąpione."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Szczegółowe logi (tylko debug)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NIE używaj w normalnej rozgrywce.>\n" +
                    "• Może spowolnić grę i tworzyć duże pliki.\n" +
                    "• Włączaj tylko na chwilę do debugowania."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
