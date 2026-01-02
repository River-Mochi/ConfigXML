// File: Localization/LocaleIT.cs
// Italian it-IT for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Scegline una" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Come usare Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRESET CONSIGLIATI" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Avvio rapido** - applica tutti i **preset** integrati.\n" +
                    "Modalità FACILE: 1 click e fatto.\n\n" +
                    "• Consigliato per la maggior parte: tweak già bilanciati (es. lavoratori/salari).\n\n" +
                    "• Puoi passare tra <Preset> e <File personalizzato> in qualsiasi momento."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usa file personalizzato" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**UTENTI AVANZATI**\n" +
                    "Usa un file personalizzato: <ModsData/ConfigXML/Config.xml>\n" +
                    "invece dei preset del mod.\n\n" +
                    "<Passi>\n" +
                    "Clicca **[APRI CARTELLA CONFIG]**\n" +
                    "• Modifica e salva **Config.xml** (Notepad++)\n" +
                    "• Poi clicca **[APPLICA NUOVA CONFIG ORA]**\n\n" +
                    "• Nota: non mettere i lavoratori a 0.\n" +
                    "• Puoi tornare ai preset quando vuoi (file separato)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "APRI CARTELLA CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Apre la cartella che contiene **Config.xml**.\n" +
                    "1. Modifica il file con un editor (**Notepad++**).\n\n" +
                    "2. Percorso di esempio (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLICA NUOVA CONFIG ORA" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Legge **Config.xml** e applica nuovi valori ai prefab di servizio (es. lavoratori)\n" +
                    "• Si applica ai **nuovi edifici** (non a quelli esistenti).\n" +
                    "• Sostituisci gli edifici per vedere i nuovi valori.\n" +
                    "• Il riavvio applica anche il file scelto."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Applicare le modifiche a qualsiasi *nuovo* edificio di servizio?\nConfermi?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Ripristina Config predefinita" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Pulsante **RICOMINCIA**.\n\n" +
                    "**Sovrascrive Config.xml** con un file predefinito pulito (include i preset).\n" +
                    "• Utile se il file personalizzato è corrotto o vuoi un reset.\n\n" +
                    "• Chiudi eventuali Config.xml aperti prima del ripristino.\n" +
                    "• Copia in: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sovrascrivere <ModsData/ConfigXML/Config.xml> con il file predefinito (preset)?\n\nIl nuovo file SOSTITUISCE quello esistente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<CONSIGLIATO> valori predefiniti - Fatto, buon gioco :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opzione 2 - Utenti avanzati**\n" +
                    "<[Usa file personalizzato]> per creare i tuoi settaggi.\n\n" +
                    "1. Clicca <[APRI CARTELLA CONFIG]>\n" +
                    "2. <Modifica + salva **Config.xml**>.\n" +
                    "3. Clicca <[APPLICA NUOVA CONFIG ORA]>\n" +
                    "4. Ripeti 1-3 senza riavvio.\n\n" +
                    "<--------------------------->\n" +
                    "Migrazione dal vecchio mod:\n" +
                    "• Il vecchio </RealCity/Config.xml> (se presente) è stato copiato in <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Controlla Logs/ConfigXML.log per conferma."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome visualizzato di questo mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numero di versione corrente." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Apri la pagina **Paradox Mods** dei mod dell’autore."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Esporta stato prefab (una volta)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTENTI AVANZATI**\n" +
                    "• Controllo una tantum: indica se ogni prefab in Config.xml è OK o mancante.\n" +
                    "• Utile dopo patch per trovare voci non più valide.\n" +
                    "• Prefab mancanti di DLC non posseduti: normale.\n\n" +
                    "• File di output: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> o <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Esporta campi componenti (una volta)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Export una tantum dei campi prefab + componenti per i prefab elencati in Config.xml.\n" +
                    "Output: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> o <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Attenzione: genera un file grande.\n\nPercorso: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> o <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Ripristina predefinito (nuovo Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Stesso** pulsante Reset dell’Actions tab.\n" +
                    "**Sovrascrive Config.xml** con il file predefinito.\n" +
                    "• File: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sovrascrivere <ModsData/ConfigXML/Config.xml> con il file predefinito?\nLe modifiche personalizzate verranno sostituite."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Log dettagliati (solo debug)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NON usare nel gameplay normale.>\n" +
                    "• Può rallentare il gioco e creare file grandi.\n" +
                    "• Abilita solo per poco tempo per debug."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
