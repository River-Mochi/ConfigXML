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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Options - choisir une" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Comment utiliser Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Préréglages - démarrage rapide" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Démarrage rapide> - applique automatiquement les préréglages intégrés.\n" +
                    "Mode FACILE :  1 clic et TERMINÉ !\n\n" +
                    "Recommandé pour la plupart des joueurs.\n" +
                    "Augmente les travailleurs (et d'autres petits ajustements des niveaux d'éducation requis pour un emploi).\n" +
                    "Bascule possible entre Préréglages et Fichier personnalisé à tout moment.\n" +
                    "Le fichier Préréglages et le fichier ModsData personnalisé sont séparés."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Utiliser un fichier personnalisé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<UTILISATEURS AVANCÉS>\n" +
                    "Utilise un fichier local personnalisé : <ModsData/ConfigXML/Config.xml>\n" +
                    "au lieu des préréglages fournis par le mod.\n" +

                    "<ASTUCES>\n" +
                    "Cliquer sur **Ouvrir le dossier Config**\n" +
                    "• Modifier **Config.xml** avec un éditeur de texte (Notepad++)\n" +
                    "• Ne pas mettre les travailleurs à 0 (utiliser de petites valeurs pour peu de travailleurs).\n" +
                    "• Après modifications : enregistrer le fichier, puis cliquer sur <APPLIQUER la nouvelle config>\n\n" +
                    "<Réinitialiser par défaut> remplace le fichier personnalisé existant.\n" +
                    "Retour aux Préréglages possible à tout moment (fichiers séparés)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "OUVRIR le dossier Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Optionnel\n" +
                    "• Ouvre le dossier <ModsData/ConfigXML/> qui contient **Config.xml**.\n" +
                    "1. Modifier avec l'éditeur de texte préféré (Notepad++).\n\n" +
                    "2. Exemple de chemin (Windows) :\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APPLIQUER la nouvelle config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lit <ModsData/ConfigXML/Config.xml> et applique les nouvelles valeurs aux prefabs de services (ex : travailleurs)\n" +
                    "• S'applique aux **nouveaux bâtiments** (pas aux existants).\n" +
                    "• Pour une ville existante, remplacer l'ancien bâtiment pour voir les nouvelles valeurs.\n" +
                    "• Cliquer à nouveau sur **APPLIQUER** après modification + enregistrement de Config.xml."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Appliquer les changements aux nouveaux bâtiments de service ?\n " +
                    "Confirmer ?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Réinitialiser Config.xml par défaut" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Bouton **RECOMMENCER**.\n\n" +
                    "Écrase **ModsData/ConfigXML/Config.xml** avec une copie par défaut (préréglages inclus dans le mod).\n" +
                    "• À utiliser si le fichier personnalisé est corrompu ou si une remise à zéro est nécessaire.\n\n" +
                    "• Fermer tout Config.xml ouvert avant de réinitialiser."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Écraser ModsData/ConfigXML/Config.xml avec le fichier par défaut (préréglages) ?\n\n" +
                    "Le nouveau fichier REMPLACE l'existant."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Option 1 - Démarrage rapide>\n" +
                    "Sélectionner **[Préréglages - démarrage rapide]** pour les préréglages intégrés.\n" +
                    "Terminé - jouer."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Option 2 - Utilisateurs avancés>\n" +
                    "**[Utiliser un fichier personnalisé]** pour créer des réglages personnalisés.\n\n" +
                    "1. Cliquer sur **[OUVRIR le dossier Config]**\n" +
                    "2. Modifier et enregistrer **Config.xml** (Notepad++).\n" +
                    "3. Cliquer sur **[APPLIQUER la nouvelle config]**\n" +
                    "4. Construire un nouveau bâtiment de service pour voir les nouvelles valeurs.\n" +
                    "5. Répéter 1-4 sans redémarrage en cliquant <APPLIQUER> après les changements.\n\n" +

                    "Note de migration :\n" +
                    "Si ModsData/RealCity/Config.xml existait, il a été copié vers **ModsData/ConfigXML/Config.xml**.\n" +
                    "Vérifier Logs/ConfigXML.log pour confirmer.\n" +
                    "Pour ignorer l'ancien fichier : supprimer ModsData/RealCity (optionnel), démarrer le jeu, puis\n" +
                    "utiliser **[Réinitialiser par défaut]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Écrire l'état des prefabs dans le log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**UTILISATEURS AVANCÉS**\n" +
                    "Vérification unique : indique dans le log si chaque prefab de Config.xml est OK ou manquant.\n" +
                    "• Utile après les mises à jour du jeu pour voir ce qui ne correspond plus.\n" +
                    "• Ignorer les avertissements pour les prefabs de DLC non possédés - c'est normal.\n" +
                     "Fichier log : C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Logs verbeux (lire les avertissements à droite)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<PAS pour jouer normalement.>\n" +
                    "Les logs verbeux peuvent ralentir le jeu et créer de gros fichiers.\n" +
                    "Activer uniquement **temporairement** pour le debug.\n" +
                    "<Si cela n'est pas clair, laisser DÉSACTIVÉ.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Ouvrir la page **Paradox Mods** des mods de l'auteur."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Réinitialiser (créer un nouveau Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Identique au bouton Actions\n" +
                    "Écrase <ModsData/ConfigXML/Config.xml> avec le fichier par défaut.\n" +
                    "À utiliser si le fichier est cassé, pour repartir de zéro, ou pour récupérer la nouvelle version (certaines mises à jour ajoutent des bâtiments)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Écraser <ModsData/ConfigXML/Config.xml> avec le fichier par défaut ?\n" +
                    "Toutes les modifications seront remplacées."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
