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

            // Show "City Services Redux 0.5.3" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Options - en choisir une" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Comment utiliser Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nom affiché de ce mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numéro de version actuel." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PRÉRÉGLAGES RECOMMANDÉS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Démarrage rapide** – applique tous les préréglages recommandés.\n" +
                    "Mode FACILE : 1 clic et c’est fait !\n\n" +
                    "Recommandé pour la plupart des joueurs – inclut déjà des réglages affinés (ex. nombre de travailleurs/salaires " +
                    "et plus) différents des valeurs par défaut du jeu."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "FICHIER PERSO"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Permet d’utiliser un fichier local personnalisé <ModsData/RealCity/Config.xml> à la place des préréglages intégrés.\n" +
                    "• Pour ceux qui veulent des réglages différents par sauvegarde ou par machine.\n\n" +
                    "**ASTUCES**\n" +
                    "Clique sur le bouton Ouvrir le dossier Config.\n" +
                    "• Affiche l’emplacement de Config.xml dans ModsData/RealCity, ensuite tu peux ajuster les employés ou d’autres champs.\n" +
                    "• Ne mets **jamais** le nombre d’emplois à 0 ; utilise de petites valeurs positives si tu veux peu de personnel.\n" +
                    "• Après tes modifications, sauvegarde le fichier puis utilise le bouton **APPLY** pour que le mod prenne les changements en compte.\n\n" +
                    "Utilise <Reset new> uniquement si tu as cassé ton fichier ou si tu veux un Config.xml complètement neuf – remplace le fichier existant.\n" +
                    "Tu peux revenir aux **PRÉRÉGLAGES** à tout moment. "
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "OUVRIR dossier Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Pas obligatoire – utilise ceci seulement si tu veux modifier les préréglages fournis par le mod.\n" +
                    "• Ouvre le dossier <ModsData/RealCity/> qui contient **Config.xml**.\n" +
                    "1. Édite le fichier avec ton éditeur préféré (par ex. <Notepad++>).\n\n" +
                    "2. Exemple de chemin sous Windows :\n" +
                    "C:/Users/TonNom/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APPLIQUER la nouvelle config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit ton fichier local <ModsData/RealCity/Config.xml> et applique les nouvelles valeurs aux bâtiments de services " +
                    "(emplois, taux de traitement, etc.).\n\n" +
                    "• S’applique uniquement aux **nouveaux bâtiments**, pas à ceux déjà placés.\n" +
                    "• Pour une ville existante : supprime l’ancien bâtiment et place-en un nouveau pour voir les changements.\n" +
                    "• Si les réglages te conviennent, il suffit de charger une ville.\n" +
                    "   Tu n’as besoin de cliquer sur **Appliquer nouvelle** que lorsque tu modifies à nouveau Config.xml."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Appliquer tes nouveaux réglages personnalisés à de nombreux bâtiments de services.\n " +
                    "Tu es sûr ?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurer un nouveau Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOUTON « REPARTIR DE ZÉRO »\n\n" +
                    "Remplace **ModsData/RealCity/Config.xml** par une copie neuve des préréglages d’origine du mod.\n" +
                    "• À utiliser seulement si ton fichier perso est cassé ou si tu veux repartir à zéro.\n\n" +
                    "• **Restaurer nouveau** remplace le fichier existant – pense à fermer l’ancien Config.xml dans l’éditeur."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Remplacer ModsData/RealCity/Config.xml par le fichier d’origine ?\n\n" +
                    "Tes modifications personnalisées seront écrasées par une nouvelle copie."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Option 1\n" +
                    "Choisir <[PRÉRÉGLAGES RECOMMANDÉS]> pour utiliser les préréglages intégrés.\n" +
                    "Si tu prends les PRÉRÉGLAGES, c’est bon – tu peux jouer.\n\n" +
                    "<--------------------------->\n\n" +
                    "Option 2 – Utilisateurs avancés\n" +
                    "Choisir <[FICHIER PERSO]> pour éditer ton propre Config.xml.\n\n" +
                    "1. Clique sur <[OUVRIR dossier Config]>.\n" +
                    "2. Ouvre, modifie et sauvegarde <Config.xml> avec un éditeur de texte (par ex. Notepad++).\n" +
                    "3. Clique sur <[APPLIQUER la nouvelle config]> – applique les changements du fichier.\n" +
                    "4. <Charger une ville> (ou recharger) pour voir les changements sur les **nouveaux** bâtiments.\n" +
                    "5. Tu peux répéter les étapes 1–4 sans redémarrer le jeu, tant que tu cliques sur <APPLY> après chaque modification."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Logs verbeux (lire les avertissements à droite avant)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Écrit beaucoup d’informations supplémentaires dans le fichier de log.\n" +
                    "<À ne pas utiliser> pour une partie normale.\n" +
                    "Trop de logs peuvent ralentir le jeu et créer de gros fichiers.\n" +
                    "À activer seulement temporairement pour collecter des données ou déboguer.\n" +
                    "Si tu ne sais pas vraiment à quoi ça sert, laisse-le DÉSACTIVÉ."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Exporter l’état des prefabs dans le log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Vérifie chaque prefab listé dans Config.xml et note s’il est OK ou manquant.\n" +
                    "• À utiliser après un patch du jeu pour voir quelles entrées de Config.xml ne correspondent plus.\n" +
                    "• Ignore les avertissements pour les bâtiments de DLC que tu ne possèdes pas – c’est normal."
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
                    "Restaurer un nouveau Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Même chose que le bouton dans l’onglet Actions : remplace <ModsData/RealCity/Config.xml> par une copie neuve " +
                    "des préréglages d’origine du mod.\n" +
                    "À utiliser si ton fichier perso est cassé ou si tu veux repartir de zéro."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Remplacer <ModsData/RealCity/Config.xml> par le fichier de PRÉRÉGLAGES d’origine du mod ?\n\n" +
                    "Toutes tes modifications perso seront remplacées par un nouveau fichier."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
