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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Wybierz jedno" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Jak używać Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "ZALECANE PRESETY" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**ZALECANE** - stosuje wbudowane **presety**.\n" +
                    "Tryb łatwy (EASY): 1 klik i gotowe!\n\n" +
                    "• Najlepsze dla większości graczy (pracownicy ↑).\n" +
                    "• W każdej chwili możesz przełączyć między <Presetami> i <Plikiem własnym>.\n" +
                    "  (Plik presetów i własny plik w ModsData są osobne.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Użyj pliku własnego" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**DLA ZAAWANSOWANYCH**\n" +
                    "Używa lokalnego pliku: <ModsData/ConfigXML/Config.xml>\n" +
                    "zamiast presetów dostarczczonych przez mod.\n" +

                    "<Kroki>\n" +
                    "Kliknij **[OTWÓRZ FOLDER CONFIG]**\n" +
                    "• Edytuj i zapisz **Config.xml** w edytorze tekstu (Notepad++)\n" +
                    "• Potem kliknij **[ZASTOSUJ NOWĄ KONFIGURACJĘ TERAZ]**\n\n" +
                    "• Uwaga: nie ustawiaj pracowników na 0.\n" +
                    "• W każdej chwili możesz wrócić do domyślnych presetów (osobne pliki)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OTWÓRZ FOLDER CONFIG" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Otwiera folder z plikiem **Config.xml**.\n" +
                    "1. Edytuj plik w edytorze tekstu (**Notepad++**).\n\n" +
                    "2. Przykładowa ścieżka (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "ZASTOSUJ NOWĄ KONFIGURACJĘ TERAZ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Czyta **Config.xml** i stosuje nowe wartości do prefabów usług (np. pracownicy budynku)\n" +
                    "• Działa na **nowe budynki** (nie na istniejące).\n" +
                    "• Aby zobaczyć nowe wartości, zastąp stare budynki.\n" +
                    "• Kliknij **Zastosuj** po każdej edycji + zapisie Config.xml.\n" +
                    "• Restart gry również stosuje wybrany plik konfiguracji.\n" +
                    "• Przycisk **Zastosuj** działa na pliku <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Zastosować zmiany do każdego *nowego* budynku usług?\n " +
                    "Na pewno?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Resetuj do domyślnej konfiguracji" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Przycisk **ZACZNIJ OD NOWA**.\n\n" +
                    "**Nadpisuje Config.xml** świeżym plikiem domyślnym (zawiera wszystkie presety).\n" +
                    "• Użyj, jeśli plik własny jest uszkodzony lub potrzebujesz czystego resetu.\n\n" +
                    "• Przed resetem zamknij wszystkie otwarte pliki Config.xml.\n" +
                    "• Kopiuje nowy plik do: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Nadpisać ModsData/ConfigXML/Config.xml plikiem domyślnym (presety)?\n\n" +
                    "Nowy plik ZASTĘPUJE istniejący."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<ZALECANE> dla domyślnych (pracownicy ↑↑) - gotowe, graj :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opcja 2 - Dla zaawansowanych**\n" +
                    "<[Użyj pliku własnego]> aby zrobić własne ustawienia.\n\n" +
                    "1. Kliknij <[OTWÓRZ FOLDER CONFIG]>\n" +
                    "2. <Edytuj + Zapisz **Config.xml**>.\n" +
                    "3. Kliknij <[ZASTOSUJ NOWĄ KONFIGURACJĘ TERAZ]>\n" +
                    "4. Kroki 1-3 możesz powtarzać bez restartu.\n\n" +
                    "<--------------------------->\n" +
                    "Migracja ze starego moda:\n" +
                    "• Jeśli istniał stary </RealCity/Config.xml>, został skopiowany do nowego <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Sprawdź Logs/ConfigXML.log dla potwierdzenia\n" +
                    "• Aby zignorować stare pliki: usuń folder RealCity (opcjonalnie), uruchom grę,\n" +
                    "• a potem użyj <[Resetuj do domyślnej konfiguracji]>, aby dostać najnowszą wersję."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Wyświetlana nazwa tego moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Aktualny numer wersji." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Otwiera stronę **Paradox Mods** z modami autora."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Zapisz status prefabów do logu"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "DLA ZAAWANSOWANYCH\n" +
                    "• **Jednorazowy przegląd**: loguje, czy każdy prefab z Config.xml jest OK czy BRAK.\n" +
                    "• Przydatne po patchach gry, aby zobaczyć, co już nie pasuje.\n" +
                    "• Ostrzeżenia dla prefabów z DLC, których nie posiadasz, są normalne.\n\n" +
                    "• Plik logu: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Resetuj do domyślnej (utwórz nowy Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Ten sam** reset co w zakładce Akcje.\n" +
                    "**Nadpisuje Config.xml** plikiem domyślnym.\n" +
                    "• Użyj, jeśli plik własny jest uszkodzony, chcesz świeży start lub chcesz nowy plik moda (czasem aktualizacje dodają budynki).\n" +
                    "• Plik resetu kopiowany tutaj: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Nadpisać <ModsData/ConfigXML/Config.xml> plikiem domyślnym?\n" +
                    "Wszystkie własne zmiany zostaną zastąpione."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Szczegółowe logi (przeczytaj ostrzeżenia po prawej przed użyciem)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NIE używaj w normalnej rozgrywce.>\n" +
                    "• Szczegółowe logi mogą spowolnić grę i tworzyć duże pliki.\n" +
                    "• Włącz tylko na kilka minut do **tymczasowego debugowania**.\n" +
                    "• <Jeśli nie wiesz co to jest, lepiej zostaw WYŁĄCZONE.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
