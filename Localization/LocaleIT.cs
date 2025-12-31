// Localization/LocaleIT.cs
// Italian it-IT for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opzioni - scegline una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Azioni" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Come usare Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome visualizzato di questo mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numero versione attuale." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Preset Avvio rapido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Avvio rapido> - applica automaticamente i preset inclusi.\n" +
                    "Modalità FACILE:  1 clic e FATTO!\n\n" +
                    "Consigliato per la maggior parte dei giocatori.\n" +
                    "Aumenta i lavoratori (e piccole modifiche ai requisiti di istruzione).\n" +
                    "Puoi passare tra Preset e File personalizzato in qualsiasi momento.\n" +
                    "Il file Preset e il file personalizzato in ModsData sono separati."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usa file personalizzato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<UTENTI AVANZATI>\n" +
                    "Usa un file locale: <ModsData/ConfigXML/Config.xml>\n" +
                    "invece dei preset forniti dal mod.\n" +

                    "<SUGGERIMENTI>\n" +
                    "Clic **Apri cartella Config**\n" +
                    "• Modifica **Config.xml** con un editor di testo (Notepad++)\n" +
                    "• Non mettere i lavoratori a 0 (usa valori piccoli).\n" +
                    "• Dopo le modifiche: salva e clicca <APPLICA nuova config>\n\n" +
                    "<Ripristina predefiniti> sostituisce il file personalizzato.\n" +
                    "Torna ai Preset quando vuoi (file separati)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "APRI cartella Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Opzionale\n" +
                    "• Apre la cartella <ModsData/ConfigXML/> che contiene **Config.xml**.\n" +
                    "1. Modifica con l'editor preferito (Notepad++).\n\n" +
                    "2. Percorso esempio (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLICA nuova config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Legge <ModsData/ConfigXML/Config.xml> e applica i nuovi valori ai prefab dei servizi (es. lavoratori)\n" +
                    "• Vale per **nuovi edifici** (non quelli esistenti).\n" +
                    "• Nelle città esistenti, sostituisci l'edificio per vedere i cambi.\n" +
                    "• Clicca **APPLICA** di nuovo dopo modifica + salvataggio di Config.xml."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Applicare i cambi ai nuovi edifici di servizio?\n " +
                    "Confermi?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Ripristina Config.xml ai predefiniti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**RIPARTI**.\n\n" +
                    "Sovrascrive **ModsData/ConfigXML/Config.xml** con una copia predefinita (preset inclusi nel mod).\n" +
                    "• Usalo se il file è corrotto o vuoi un reset pulito.\n\n" +
                    "• Chiudi eventuali Config.xml aperti prima di ripristinare."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sovrascrivere ModsData/ConfigXML/Config.xml con il file predefinito (preset)?\n\n" +
                    "Il nuovo file SOSTITUISCE quello esistente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Opzione 1 - Avvio rapido>\n" +
                    "Seleziona **[Preset Avvio rapido]**.\n" +
                    "Fatto - gioca."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Opzione 2 - Utenti avanzati>\n" +
                    "**[Usa file personalizzato]** per impostazioni personalizzate.\n\n" +
                    "1. Clic **[APRI cartella Config]**\n" +
                    "2. Modifica e salva **Config.xml** (Notepad++).\n" +
                    "3. Clic **[APPLICA nuova config]**\n" +
                    "4. Costruisci un nuovo edificio di servizio per vedere i nuovi valori.\n" +
                    "5. Ripeti 1-4 senza riavvio cliccando <APPLICA> dopo le modifiche.\n\n" +

                    "Nota migrazione:\n" +
                    "Se esisteva ModsData/RealCity/Config.xml, è stato copiato in **ModsData/ConfigXML/Config.xml**.\n" +
                    "Controlla Logs/ConfigXML.log.\n" +
                    "Per ignorare il vecchio file: elimina ModsData/RealCity (opzionale), avvia il gioco e\n" +
                    "usa **[Ripristina predefiniti]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Scrivi stato prefab nel log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTENTI AVANZATI**\n" +
                    "Controllo una tantum: scrive nel log se ogni prefab in Config.xml è OK o mancante.\n" +
                    "• Utile dopo patch del gioco.\n" +
                    "• Ignora avvisi per prefab DLC non posseduti - è normale.\n" +
                     "Log: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Log verbosi (leggi avvisi a destra)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NON per gioco normale.>\n" +
                    "I log verbosi possono rallentare il gioco e creare file grandi.\n" +
                    "Attiva solo **temporaneamente** per debug.\n" +
                    "<Se non sai cos'è, meglio lasciarlo DISATTIVATO.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Apri la pagina **Paradox Mods** dei mod dell'autore."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Ripristina predefiniti (nuovo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Uguale al reset in Azioni\n" +
                    "Sovrascrive <ModsData/ConfigXML/Config.xml> con il file predefinito.\n" +
                    "Usalo se il file è rotto, vuoi ripartire, o vuoi la nuova versione (alcuni update aggiungono edifici)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sovrascrivere <ModsData/ConfigXML/Config.xml> con il file predefinito?\n" +
                    "Le modifiche personalizzate verranno sostituite."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
