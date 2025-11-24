// LocaleFR.cs
// French fr-FR City Services Redux.

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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Options – en choisir une" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Comment utiliser Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nom affiché de ce mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numéro de version actuel."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PRÉRÉGLAGES CONSEILLÉS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Démarrage rapide** – applique tous les préréglages recommandés.\n" +
                    "Mode FACILE : un clic et c’est parti !\n\n" +
                    "Recommandé pour la plupart des joueurs – comprend déjà des réglages pensés à la main " +
                    "(nombre de travailleurs/salaires, etc.) différents des valeurs de base du jeu."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "CONFIG perso (Config.xml)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**JOUEURS AVANCÉS**\n" +
                    "Permet d’utiliser un fichier <ModsData/RealCity/Config.xml> perso au lieu des préréglages intégrés.\n" +
                    "• Pour ceux qui veulent des réglages différents par sauvegarde ou par PC.\n\n" +
                    "**ASTUCES**\n" +
                    "Clique sur le bouton « OUVRIR le dossier Config ».\n" +
                    "• Affiche l’emplacement de Config.xml dans ModsData/RealCity, où tu peux modifier le nombre de travailleurs ou d’autres champs.\n" +
                    "• Ne mets **jamais** le nombre d’emplois à 0 – utilise de petites valeurs positives pour un service très léger.\n" +
                    "• Après avoir enregistré tes changements, clique sur le bouton **APPLIQUER la nouvelle config** pour mettre à jour la mod.\n\n" +
                    "Utilise <Réinitialiser Config.xml> **uniquement** si tu as cassé ton fichier ou si tu veux repartir de zéro – le fichier actuel sera remplacé.\n" +
                    "Tu peux revenir à **PRÉRÉGLAGES CONSEILLÉS** à tout moment."
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
                    "Pas obligatoire – utilise ceci seulement si tu veux modifier les préréglages fournis par la mod.\n" +
                    "• Ouvre le dossier <ModsData/RealCity/> qui contient **Config.xml**.\n" +
                    "1. Édite ce fichier avec ton éditeur de texte préféré (par ex. <Notepad++>).\n\n" +
                    "2. Exemple de chemin (Windows) :\n" +
                    "C:/Users/TonNom/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APPLIQUER la nouvelle config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit ton fichier <ModsData/RealCity/Config.xml> perso et applique les nouvelles valeurs aux bâtiments de service " +
                    "(emplois, traitement, etc.).\n\n" +
                    "• S’applique aux **nouveaux bâtiments**, pas à ceux déjà construits.\n" +
                    "• Dans une ville existante, détruire l’ancien bâtiment et en reconstruire un nouveau pour voir les changements.\n" +
                    "• Si les réglages te conviennent, tu peux simplement charger une ville.\n" +
                    "   Tu n’as besoin de cliquer **APPLIQUER la nouvelle config** que lorsque tu modifies à nouveau Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Appliquer tes nouveaux réglages personnalisés à de nombreux bâtiments de service.\n" +
                    "Continuer ?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Réinitialiser Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOUTON REPARTIR À ZÉRO\n\n" +
                    "Remplace **ModsData/RealCity/Config.xml** par une nouvelle copie des préréglages d’origine de la mod.\n" +
                    "• À utiliser **seulement** si ton fichier est cassé ou si tu veux recommencer proprement.\n\n" +
                    "• « Réinitialiser Config.xml » remplace le fichier existant – pense à fermer Config.xml dans l’éditeur avant."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Remplacer ModsData/RealCity/Config.xml par le fichier d’origine ?\n\n" +
                    "Tous tes changements seront perdus."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Choisir <[PRÉRÉGLAGES CONSEILLÉS]> pour utiliser les presets intégrés.\n" +
                    "Si tu prends les PRÉRÉGLAGES, c’est bon – joue.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 – joueurs avancés\n" +
                    "Choisir <[CONFIG perso (Config.xml)]> pour éditer tes propres valeurs.\n\n" +
                    "1. Clique sur <[OUVRIR le dossier Config]>.\n" +
                    "2. Ouvre, modifie et enregistre <Config.xml> avec ton éditeur préféré.\n" +
                    "3. Clique ensuite sur <[APPLIQUER la nouvelle config]>.\n" +
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
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "Journal détaillé (avancé)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Écrit beaucoup d’informations supplémentaires dans le fichier de log.\n" +
                    "<NON recommandé> pour une partie normale.\n" +
                    "Trop de log peut ralentir le jeu et créer des fichiers très volumineux.\n" +
                    "N’active ce mode que temporairement pour collecter des données ou déboguer."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Exporter l’état des prefabs dans le log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**JOUEURS AVANCÉS**\n" +
                    "Vérifie chaque prefab listé dans Config.xml et indique dans le log s’il est OK ou manquant.\n" +
                    "• À utiliser après un patch pour voir quelles entrées de Config.xml ne correspondent plus au jeu.\n" +
                    "• Ignore les avertissements pour des bâtiments de DLC que tu ne possèdes pas – c’est normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Ouvre la page **Paradox Mods** pour City Services Redux et tes autres mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Réinitialiser Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Comme le bouton dans l’onglet Actions : remplace <ModsData/RealCity/Config.xml> par une nouvelle copie " +
                    "des préréglages d’origine de la mod.\n" +
                    "À utiliser si ton fichier est cassé ou si tu veux repartir à zéro."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Remplacer <ModsData/RealCity/Config.xml> par le fichier de PRÉRÉGLAGES d’origine ?\n\n" +
                    "Tous les changements perso seront remplacés par un nouveau fichier."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
