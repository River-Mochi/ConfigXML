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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Azioni" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Scegline una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Come usare Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRESET CONSIGLIATI" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**CONSIGLIATO** - applica i **preset** inclusi.\n" +
                    "Modalità FACILE:  1 clic e FATTO!\n\n" +
                    "• Ideale per la maggior parte dei giocatori: aumenta i lavoratori.\n" +
                    "• Puoi passare tra <Preset> e <File personalizzato> quando vuoi.\n" +
                    "  (Il file dei preset e il file ModsData personalizzato sono separati.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usa file personalizzato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "Usa un file locale personalizzato: <ModsData/ConfigXML/Config.xml>\n" +
                    "invece dei preset forniti dal mod.\n" +

                    "<Steps>\n" +
                    "Clicca **[APRI CARTELLA CONFIG]**\n" +
                    "• Modifica e salva **Config.xml** con un editor di testo (Notepad++)\n" +
                    "• Poi clicca **[APPLICA NUOVA CONFIG ORA]**\n\n" +
                    "• Nota: non impostare i lavoratori a 0.\n" +
                    "• Puoi tornare ai preset quando vuoi (file separati)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "APRI CARTELLA CONFIG" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Apre la cartella che contiene **Config.xml**.\n" +
                    "1. Modifica il file con un editor di testo (**Notepad++**).\n\n" +
                    "2. Percorso di esempio (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLICA NUOVA CONFIG ORA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Legge **Config.xml** e applica i nuovi valori ai prefab dei servizi (es. lavoratori)\n" +
                    "• Vale per **nuovi edifici** (non quelli esistenti).\n" +
                    "• Sostituisci gli edifici vecchi per vedere i nuovi valori.\n" +
                    "• Dopo modifica + salvataggio di Config.xml: clicca **Applica**.\n" +
                    "• Anche riavviare il gioco applica il file scelto.\n" +
                    "• Apply usa il file <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Applicare le modifiche a qualsiasi edificio di servizio *nuovo*?\n" +
                    "Confermi?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Ripristina Config predefinita" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Pulsante **RIPARTI**.\n\n" +
                    "**Sovrascrive Config.xml** con un nuovo file predefinito (include tutti i preset).\n" +
                    "• Usalo se il file personalizzato è corrotto o serve un reset pulito.\n\n" +
                    "• Chiudi eventuali Config.xml aperti prima di ripristinare.\n" +
                    "• Copia un nuovo file in: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sovrascrivere ModsData/ConfigXML/Config.xml con il file predefinito (preset)?\n\n" +
                    "Il nuovo file SOSTITUISCE quello esistente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<CONSIGLIATO> per i valori predefiniti (lavoratori ↑↑) - Fatto, gioca :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opzione 2 - Power Users**\n" +
                    "<[USA FILE PERSONALIZZATO]> per fare le tue impostazioni.\n\n" +
                    "1. Clic <[APRI CARTELLA CONFIG]>\n" +
                    "2. <Modifica + salva **Config.xml**>.\n" +
                    "3. Clic <[APPLICA NUOVA CONFIG ORA]>\n" +
                    "4. I passi 1-3 si possono ripetere senza riavvio.\n\n" +
                    "<--------------------------->\n" +
                    "Migrazione dal vecchio mod:\n" +
                    "• Se esisteva </RealCity/Config.xml>, è stato copiato in <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Controlla Logs/ConfigXML.log per conferma\n" +
                    "• Per ignorare i vecchi file: elimina la cartella RealCity (opzionale), avvia il gioco,\n" +
                    "• poi usa <[RIPRISTINA PREDEFINITI]> per ottenere la versione più nuova."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome visualizzato di questo mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numero versione attuale." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Apri la pagina **Paradox Mods** dei mod dell'autore."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Scrivi stato prefab nel log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **Controllo una tantum**: scrive nel log se ogni prefab in Config.xml è OK o mancante.\n" +
                    "• Utile dopo patch del gioco per vedere quali voci non combaciano più.\n" +
                    "• Ignora avvisi per prefab DLC non posseduti - è normale.\n\n" +
                    "• Log: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Ripristina predefiniti (nuovo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Stesso** pulsante Reset della scheda Azioni.\n" +
                    "**Sovrascrive Config.xml** con il file predefinito.\n" +
                    "• Usalo se il file è rotto, vuoi ripartire, o vuoi il nuovo file del mod (alcuni update aggiungono edifici).\n" +
                    "• File copiato qui: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sovrascrivere <ModsData/ConfigXML/Config.xml> con il file predefinito?\n" +
                    "Le modifiche personalizzate verranno sostituite."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Log verbosi (leggi gli avvisi a destra prima di usare)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NON usare nel gameplay normale.>\n" +
                    "• I log verbosi possono rallentare il gioco e creare file grandi.\n" +
                    "• Attiva solo per pochi minuti per **debug temporaneo**.\n" +
                    "• <Se non sai cos'è, meglio lasciarlo DISATTIVATO.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
