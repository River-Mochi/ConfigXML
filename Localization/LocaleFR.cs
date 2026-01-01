// Localization/LocaleFR.cs
// French fr-FR for Config-XML.

namespace ConfigXML
{
    using Colossal;
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRÉRÉGLAGES RECOMMANDÉS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**RECOMMANDÉ** - applique les **préréglages** intégrés.\n" +
                    "Mode FACILE :  1 clic et TERMINÉ !\n\n" +
                    "• Le mieux pour la plupart des joueurs : augmenter les travailleurs.\n" +
                    "• Tu peux basculer entre <Préréglages> et <Fichier personnalisé> à tout moment.\n" +
                    "  (Le fichier de préréglages et le fichier ModsData personnalisé sont séparés.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Utiliser un fichier personnalisé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**POWER USERS**\n" +
                    "Utilise un fichier local personnalisé : <ModsData/ConfigXML/Config.xml>\n" +
                    "au lieu des préréglages fournis par le mod.\n" +

                    "<Steps>\n" +
                    "Cliquer sur **[OUVRIR LE DOSSIER CONFIG]**\n" +
                    "• Modifier et enregistrer **Config.xml** avec un éditeur de texte (Notepad++)\n" +
                    "• Puis cliquer sur **[APPLIQUER LA NOUVELLE CONFIG MAINTENANT]**\n\n" +
                    "• Note : ne mets pas les travailleurs à 0.\n" +
                    "• Retour aux préréglages possible à tout moment (fichiers séparés)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OUVRIR LE DOSSIER CONFIG" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Ouvre le dossier qui contient **Config.xml**.\n" +
                    "1. Modifier le fichier avec un éditeur de texte (**Notepad++**).\n\n" +
                    "2. Exemple de chemin (Windows) :\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLIQUER LA NOUVELLE CONFIG MAINTENANT" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit **Config.xml** et applique les nouvelles valeurs aux prefabs de services (ex : travailleurs)\n" +
                    "• S'applique aux **nouveaux bâtiments** (pas aux existants).\n" +
                    "• Remplace l'ancien bâtiment pour voir les nouvelles valeurs.\n" +
                    "• Après édition + sauvegarde de Config.xml : cliquer **Appliquer**.\n" +
                    "• Redémarrer le jeu applique aussi le fichier choisi.\n" +
                    "• Apply utilise le fichier <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Appliquer les changements à tout *nouveau* bâtiment de service ?\n" +
                    "Confirmer ?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Réinitialiser la Config par défaut" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Bouton **RECOMMENCER**.\n\n" +
                    "**Écrase Config.xml** avec un nouveau fichier par défaut (inclut tous les préréglages).\n" +
                    "• À utiliser si le fichier personnalisé est corrompu ou si un reset propre est nécessaire.\n\n" +
                    "• Ferme tout Config.xml ouvert avant de réinitialiser.\n" +
                    "• Copie un nouveau fichier vers : <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Écraser ModsData/ConfigXML/Config.xml avec le fichier par défaut (préréglages) ?\n\n" +
                    "Le nouveau fichier REMPLACE l'existant."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<RECOMMANDÉ> pour les valeurs par défaut (travailleurs ↑↑) - Terminé, bon jeu :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Option 2 - Power Users**\n" +
                    "<[UTILISER UN FICHIER PERSONNALISÉ]> pour faire tes réglages.\n\n" +
                    "1. Cliquer <[OUVRIR LE DOSSIER CONFIG]>\n" +
                    "2. <Modifier + enregistrer **Config.xml**>.\n" +
                    "3. Cliquer <[APPLIQUER LA NOUVELLE CONFIG MAINTENANT]>\n" +
                    "4. Les étapes 1-3 peuvent être répétées sans redémarrage.\n\n" +
                    "<--------------------------->\n" +
                    "Migration depuis l'ancien mod :\n" +
                    "• Si l'ancien </RealCity/Config.xml> existait, il a été copié vers <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Vérifie Logs/ConfigXML.log pour confirmation\n" +
                    "• Pour ignorer les anciens fichiers : supprimer le dossier RealCity (optionnel), démarrer le jeu,\n" +
                    "• puis utiliser <[RÉINITIALISER PAR DÉFAUT]> pour obtenir la version la plus récente."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nom affiché de ce mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Numéro de version actuel." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Ouvrir la page **Paradox Mods** des mods de l'auteur."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Écrire l'état des prefabs dans le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "POWER USERS\n" +
                    "• **Vérification unique** : indique dans le log si chaque prefab de Config.xml est OK ou manquant.\n" +
                    "• Utile après les mises à jour du jeu pour voir ce qui ne correspond plus.\n" +
                    "• Ignorer les avertissements pour les prefabs de DLC non possédés - c'est normal.\n\n" +
                    "• Fichier log : <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Réinitialiser par défaut (nouveau Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Même** bouton Reset que dans l'onglet Actions.\n" +
                    "**Écrase Config.xml** avec le fichier par défaut.\n" +
                    "• À utiliser si ton fichier est cassé, si tu veux repartir de zéro, ou si tu veux le nouveau fichier du mod (certaines mises à jour ajoutent des bâtiments).\n" +
                    "• Fichier copié ici : <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Écraser <ModsData/ConfigXML/Config.xml> avec le fichier par défaut ?\n" +
                    "Toutes les modifications seront remplacées."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Logs verbeux (lire les avertissements à droite avant d'utiliser)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NE PAS utiliser en jeu normal.>\n" +
                    "• Les logs verbeux peuvent ralentir le jeu et créer de gros fichiers.\n" +
                    "• Activer seulement quelques minutes pour du **debug temporaire**.\n" +
                    "• <Si tu ne sais pas ce que c'est : mieux vaut laisser DÉSACTIVÉ.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
