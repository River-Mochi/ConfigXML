// Localization/LocalePT_BR.cs
// Portuguese (Brazil) pt-BR for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "Debug" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opções - escolha uma" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Como usar Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número da versão atual." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "Presets de Início rápido" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<Início rápido> - aplica os presets do mod automaticamente.\n" +
                    "Modo FÁCIL:  1 clique e PRONTO!\n\n" +
                    "Recomendado para a maioria dos jogadores.\n" +
                    "Aumenta os trabalhadores (e pequenos ajustes de educação exigida).\n" +
                    "Você pode alternar entre Presets e Arquivo personalizado a qualquer momento.\n" +
                    "O arquivo de Presets e o arquivo ModsData são separados."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar arquivo personalizado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<USUÁRIOS AVANÇADOS>\n" +
                    "Usa um arquivo local: <ModsData/ConfigXML/Config.xml>\n" +
                    "em vez dos presets do mod.\n" +

                    "<DICAS>\n" +
                    "Clique em **Abrir pasta Config**\n" +
                    "• Edite **Config.xml** com um editor (Notepad++)\n" +
                    "• Não coloque trabalhadores em 0 (use valores pequenos).\n" +
                    "• Depois de editar: salve e clique <APLICAR nova config>\n\n" +
                    "<Restaurar padrões> substitui o arquivo personalizado.\n" +
                    "Volte para Presets quando quiser (arquivos separados)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR pasta Config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Opcional\n" +
                    "• Abre a pasta <ModsData/ConfigXML/> que contém **Config.xml**.\n" +
                    "1. Edite com seu editor (Notepad++).\n\n" +
                    "2. Caminho de exemplo (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR nova config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê <ModsData/ConfigXML/Config.xml> e aplica os novos valores nos prefabs de serviços (ex.: trabalhadores)\n" +
                    "• Vale para **novos prédios** (não existentes).\n" +
                    "• Em cidades existentes, substitua o prédio para ver o efeito.\n" +
                    "• Clique **APLICAR** de novo após editar + salvar Config.xml."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar mudanças aos novos prédios de serviço?\n " +
                    "Confirmar?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Restaurar Config.xml para padrões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**COMEÇAR DE NOVO**.\n\n" +
                    "Sobrescreve **ModsData/ConfigXML/Config.xml** com uma cópia padrão (presets do mod).\n" +
                    "• Use se o arquivo estiver corrompido ou para reset limpo.\n\n" +
                    "• Feche Config.xml aberto antes de restaurar."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sobrescrever ModsData/ConfigXML/Config.xml com o arquivo padrão (presets)?\n\n" +
                    "O novo arquivo SUBSTITUI o existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<Opção 1 - Início rápido>\n" +
                    "Selecione **[Presets de Início rápido]**.\n" +
                    "Pronto - jogar."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<Opção 2 - Usuários avançados>\n" +
                    "**[Usar arquivo personalizado]** para ajustes próprios.\n\n" +
                    "1. Clique **[ABRIR pasta Config]**\n" +
                    "2. Edite e salve **Config.xml** (Notepad++).\n" +
                    "3. Clique **[APLICAR nova config]**\n" +
                    "4. Construa um novo prédio de serviço para ver os novos valores.\n" +
                    "5. Repita 1-4 sem reiniciar clicando <APLICAR> após mudanças.\n\n" +

                    "Nota de migração:\n" +
                    "Se existia ModsData/RealCity/Config.xml, foi copiado para **ModsData/ConfigXML/Config.xml**.\n" +
                    "Confira Logs/ConfigXML.log.\n" +
                    "Para ignorar o antigo: apague ModsData/RealCity (opcional), inicie o jogo e\n" +
                    "use **[Restaurar padrões]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Registrar status dos prefabs no log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Checagem única: registra se cada prefab do Config.xml está OK ou faltando.\n" +
                    "• Útil após patches.\n" +
                    "• Ignore avisos de prefabs DLC que você não possui - normal.\n" +
                     "Log: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Logs detalhados (leia avisos à direita)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<NÃO para jogo normal.>\n" +
                    "Logs detalhados podem deixar o jogo mais lento e criar arquivos grandes.\n" +
                    "Ative só **temporariamente** para debug.\n" +
                    "<Se não souber o que é, deixe DESLIGADO.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir a página **Paradox Mods** dos mods do autor."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar padrões (novo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual ao reset em Ações\n" +
                    "Sobrescreve <ModsData/ConfigXML/Config.xml> com o arquivo padrão" +
                    "Use se o arquivo estiver quebrado, quiser reset, ou quiser a nova versão (alguns updates têm mais prédios)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sobrescrever <ModsData/ConfigXML/Config.xml> com o arquivo padrão?\n" +
                    "Suas mudanças serão substituídas."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
