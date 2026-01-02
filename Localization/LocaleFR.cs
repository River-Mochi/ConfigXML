// File: Localization/LocaleFR.cs
// French fr-FR for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

    public class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Choisir une" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Comment utiliser Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRÉRÉGLAGES RECOMMANDÉS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Démarrage rapide** - applique tous les **préréglages** intégrés.\n" +
                    "Mode FACILE : 1 clic et c’est terminé !\n\n" +
                    "• Recommandé pour la plupart des joueurs - réglages déjà optimisés (ex : travailleurs/salaires).\n\n" +
                    "• Tu peux basculer entre <Préréglages> et <Fichier personnalisé> à tout moment."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Utiliser un fichier personnalisé" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Utilise un fichier personnalisé : <ModsData/ConfigXML/Config.xml>\n" +
                    "au lieu des préréglages du mod.\n\n" +
                    "<Étapes>\n" +
                    "Cliquer **[OUVRIR LE DOSSIER CONFIG]**\n" +
                    "• Modifier et enregistrer **Config.xml** (Notepad++)\n" +
                    "• Puis cliquer **[APPLIQUER LA NOUVELLE CONFIG MAINTENANT]**\n\n" +
                    "• Note : ne mets pas les travailleurs à 0.\n" +
                    "• Retour aux préréglages possible à tout moment (fichier séparé)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OUVRIR LE DOSSIER CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Ouvre le dossier contenant **Config.xml**.\n" +
                    "1. Modifier le fichier avec un éditeur de texte (**Notepad++**).\n\n" +
                    "2. Exemple de chemin (Windows) :\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLIQUER LA NOUVELLE CONFIG MAINTENANT" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit **Config.xml** et applique les nouvelles valeurs aux prefabs de services (ex : travailleurs)\n" +
                    "• S’applique aux **nouveaux bâtiments** (pas aux existants).\n" +
                    "• Remplacer les bâtiments pour voir les nouvelles valeurs.\n" +
                    "• Un redémarrage applique aussi le fichier choisi."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Appliquer les changements à tout *nouveau* bâtiment de service ?\nConfirmer ?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Réinitialiser la Config par défaut" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Bouton **RECOMMENCER**.\n\n" +
                    "**Écrase Config.xml** avec un fichier par défaut propre (inclut les préréglages).\n" +
                    "• À utiliser si le fichier personnalisé est corrompu ou si tu veux un reset.\n\n" +
                    "• Ferme tout Config.xml ouvert avant de réinitialiser.\n" +
                    "• Copie vers : <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Écraser <ModsData/ConfigXML/Config.xml> avec le fichier par défaut (préréglages) ?\n\nLe nouveau fichier REMPLACE l’existant."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<RECOMMANDÉ> valeurs par défaut - Terminé, bon jeu :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Utilisateurs avancés**\n" +
                    "<[Utiliser un fichier personnalisé]> pour faire tes réglages.\n\n" +
                    "1. Cliquer <[OUVRIR LE DOSSIER CONFIG]>\n" +
                    "2. <Modifier + enregistrer **Config.xml**>.\n" +
                    "3. Cliquer <[APPLIQUER LA NOUVELLE CONFIG MAINTENANT]>\n" +
                    "4. Répéter 1-3 sans redémarrage.\n\n" +
                    "<--------------------------->\n" +
                    "Migration depuis l’ancien mod :\n" +
                    "• Ancien </RealCity/Config.xml> (si présent) copié vers <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Vérifier Logs/ConfigXML.log pour confirmation."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nom affiché de ce mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numéro de version actuel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Ouvrir la page **Paradox Mods** des mods de l’auteur."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Exporter l’état des prefabs (one-shot)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "• Vérification unique : indique si chaque prefab de Config.xml est OK ou manquant.\n" +
                    "• Utile après une mise à jour pour repérer les entrées qui ne correspondent plus.\n" +
                    "• Les prefabs manquants d’un DLC non possédé, c’est normal.\n\n" +
                    "• Fichier de sortie : <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> ou <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Exporter les champs des composants (one-shot)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Export unique des champs prefab + composants pour les prefabs listés dans Config.xml.\n" +
                    "Sortie : <ModsData/ConfigXML/ComponentFields_PRESETS.txt> ou <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Attention : génère un gros fichier.\n\nEmplacement : <ModsData/ConfigXML/ComponentFields_PRESETS.txt> ou <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Réinitialiser par défaut (nouveau Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Même** bouton Reset que dans l’onglet Actions.\n" +
                    "**Écrase Config.xml** avec le fichier par défaut.\n" +
                    "• Fichier : <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Écraser <ModsData/ConfigXML/Config.xml> avec le fichier par défaut ?\nToutes les modifications seront remplacées."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Logs verbeux (debug uniquement)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NE PAS utiliser en jeu normal.>\n" +
                    "• Peut ralentir le jeu et créer de gros fichiers.\n" +
                    "• Activer seulement brièvement pour du debug."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
