// LocaleFR.cs
// French (fr-FR) City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.0" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Options - choisir une" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Comment utiliser Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),
                    "Nom de ce mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),
                    "Numéro de version actuel."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PRESETS RECOMMANDÉS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Démarrage rapide** - applique tous les réglages recommandés.\n" +
                    "Mode FACILE : 1 clic et c’est fait !\n\n" +
                    "Recommandé pour la plupart des joueurs : inclut déjà des réglages manuels " +
                    "comme le nombre de travailleurs/salaires différents des valeurs par défaut du jeu."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "UTILISER Config.xml PERSONNALISÉ"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Quand cette option est activée, le jeu utilise un fichier local personnalisé " +
                    "<ModsData/RealCity/Config.xml> à la place des presets intégrés.\n" +
                    "• Pour ceux qui veulent des réglages de services différents par sauvegarde ou par machine.\n\n" +
                    "**ASTUCES**\n" +
                    "Clique sur le bouton \"OPEN Config folder\".\n" +
                    "• Affiche l’emplacement du fichier Config.xml dans ModsData/RealCity, puis modifie le nombre de travailleurs ou d’autres champs.\n" +
                    "• Ne mets **jamais** le nombre de postes à 0 ; utilise de petites valeurs si tu veux peu de personnel.\n" +
                    "• Après tes modifications, enregistre le fichier puis utilise le bouton **APPLY** pour appliquer les changements au mod.\n\n" +
                    "Utilise <Restore new> <UNIQUEMENT> si tu as cassé ton fichier ou si tu veux un Config.xml complètement neuf " +
                    "(remplace le fichier existant).\n" +
                    "Tu peux revenir à **[Use PRESETS]** à tout moment."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "OUVRIR le dossier Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Pas obligatoire : à utiliser seulement si tu souhaites modifier les presets par défaut du mod.\n" +
                    "• Ouvre le dossier <ModsData/RealCity/> qui contient **Config.xml**.\n" +
                    "1. Édite le fichier avec ton éditeur préféré (par ex. <Notepad++>).\n\n" +
                    "2. Exemple de chemin ouvert (Windows) :\n" +
                    "C:/Users/TonNom/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APPLIQUER la nouvelle configuration"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit ton fichier local <ModsData/RealCity/Config.xml> et applique les nouvelles valeurs " +
                    "aux prefabs de services de la ville (postes de travail, taux de traitement, etc.).\n\n" +
                    "• S’applique aux **nouveaux bâtiments**, pas aux bâtiments existants.\n" +
                    "• Pour les villes déjà en cours, supprime le bâtiment et repose-le pour voir les changements.\n" +
                    "• Si les réglages te conviennent, il suffit de charger ta ville.\n" +
                    "   Tu n’as besoin de cliquer sur **Apply New** que lorsque tu modifies à nouveau Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Tu vas appliquer tes changements personnalisés à de nombreux bâtiments de services.\n" +
                    "Es-tu sûr(e) de vouloir continuer ?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurer un nouveau Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOUTON POUR REPARTIR DE ZÉRO\n\n" +
                    "Remplace **ModsData/RealCity/Config.xml** par une nouvelle copie des presets originaux du mod.\n" +
                    "• À utiliser <uniquement> si ton fichier personnalisé est corrompu ou si tu veux repartir de zéro.\n\n" +
                    "• \"Restore new\" remplace le fichier existant : ferme d’abord le Config.xml dans ton éditeur."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Remplacer ModsData/RealCity/Config.xml par le fichier original ?\n\n" +
                    "Tes changements personnalisés seront perdus."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Choisir <[Use PRESETS]> (recommandé) pour utiliser les presets intégrés.\n" +
                    "Si tu choisis PRESETS, c’est terminé : joue.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 - Utilisateurs avancés\n" +
                    "Choisir <[Use CUSTOM Config.xml]> pour éditer tes propres valeurs.\n\n" +
                    "1. Clique sur <[OPEN Config folder]>.\n" +
                    "2. Ouvre, modifie et enregistre <Config.xml> avec ton éditeur de texte.\n" +
                    "3. Clique ensuite sur <[APPLY NEW Configuration Now]>.\n" +
                    "4. <Charge une ville> (ou recharge) pour voir les changements sur les **nouveaux** bâtiments."
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
                    "Journal détaillé (avancé)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Écrit beaucoup d’informations supplémentaires dans le fichier de log.\n" +
                    "<NON recommandé> pour une partie normale.\n" +
                    "Un log trop verbeux peut ralentir le jeu et créer des fichiers très volumineux.\n" +
                    "N’active cette option que temporairement pour collecter des données ou déboguer."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Exporter l’état des prefabs dans le log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Vérifie chaque prefab listé dans Config.xml et indique s’il est OK ou manquant.\n" +
                    "• À utiliser après une mise à jour du jeu pour voir quelles entrées de Config.xml ne correspondent plus.\n" +
                    "• Ignore les avertissements pour les prefabs de DLC que tu ne possèdes pas : c’est normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Ouvrir la page **Paradox Mods** de City Services Redux et de tes autres mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurer un nouveau Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Identique au bouton de l’onglet Actions : remplace <ModsData/RealCity/Config.xml> " +
                    "par une nouvelle copie des presets originaux.\n" +
                    "À utiliser si ton fichier personnalisé est cassé ou si tu veux repartir de zéro."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Remplacer <ModsData/RealCity/Config.xml> par le fichier de PRESETS original ?\n\n" +
                    "Tous tes changements personnalisés seront remplacés par un fichier neuf."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
