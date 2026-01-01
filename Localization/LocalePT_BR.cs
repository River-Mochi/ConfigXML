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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Escolha um" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Como usar o Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRESETS RECOMENDADOS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**RECOMENDADO** - aplica **presets** internos.\n" +
                    "MODO FÁCIL:  1 clique e PRONTO!\n\n" +
                    "• Melhor para a maioria: aumentar trabalhadores.\n" +
                    "• Dá para alternar entre <Presets> e <Arquivo personalizado> a qualquer hora.\n" +
                    "  (O arquivo de presets e o arquivo ModsData personalizado são separados.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar arquivo personalizado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Usa um arquivo local personalizado: <ModsData/ConfigXML/Config.xml>\n" +
                    "em vez dos presets do mod.\n" +

                    "<Passos>\n" +
                    "Clique **[ABRIR PASTA DO CONFIG]**\n" +
                    "• Edite e salve **Config.xml** num editor de texto (Notepad++)\n" +
                    "• Depois clique **[APLICAR NOVA CONFIG AGORA]**\n\n" +
                    "• Observação: não defina trabalhadores como 0.\n" +
                    "• Volte para os presets padrão quando quiser (arquivos separados)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR PASTA DO CONFIG" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Abre a pasta que contém o arquivo **Config.xml**.\n" +
                    "1. Edite o arquivo num editor de texto (**Notepad++**).\n\n" +
                    "2. Caminho de exemplo (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR NOVA CONFIG AGORA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê **Config.xml** e aplica os novos valores aos prefabs de serviços (ex.: trabalhadores do prédio)\n" +
                    "• Vale para **novos prédios** (não afeta os existentes).\n" +
                    "• Substitua os prédios antigos para ver os novos valores.\n" +
                    "• Clique **Aplicar** depois de editar + salvar o Config.xml.\n" +
                    "• Reiniciar o jogo também aplica o arquivo escolhido.\n" +
                    "• O botão **Aplicar** usa o arquivo <ModsData/ConfigXML/Config.xml>."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar mudanças para qualquer prédio de serviço *novo*?\n " +
                    "Confirmar?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Resetar para Config padrão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Botão **COMEÇAR DE NOVO**.\n\n" +
                    "**Sobrescreve o Config.xml** com um arquivo padrão novo (inclui todos os presets).\n" +
                    "• Use se o arquivo personalizado estiver corrompido ou se você quiser um reset limpo.\n\n" +
                    "• Feche qualquer Config.xml aberto antes de resetar.\n" +
                    "• Copia um arquivo novo para: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sobrescrever ModsData/ConfigXML/Config.xml com o arquivo padrão (presets)?\n\n" +
                    "O novo arquivo SUBSTITUI o existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<RECOMENDADO> padrões (trabalhadores ↑↑) - Pronto, jogar :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opção 2 - Usuários avançados**\n" +
                    "<[USAR ARQUIVO PERSONALIZADO]> para ajustar do seu jeito.\n\n" +
                    "1. Clique <[ABRIR PASTA DO CONFIG]>\n" +
                    "2. <Edite + salve **Config.xml**>.\n" +
                    "3. Clique <[APLICAR NOVA CONFIG AGORA]>\n" +
                    "4. Os passos 1-3 podem ser repetidos sem reiniciar.\n\n" +
                    "<--------------------------->\n" +
                    "Migração do mod antigo:\n" +
                    "• Se existia o antigo </RealCity/Config.xml>, ele foi copiado para o novo <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Verifique Logs/ConfigXML.log para confirmar\n" +
                    "• Para ignorar os arquivos antigos: apague a pasta RealCity (opcional), inicie o jogo,\n" +
                    "• e então use <[Resetar para Config padrão]> para obter a versão mais nova."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número da versão atual." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir a página **Paradox Mods** dos mods do autor."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Registrar status dos prefabs no log"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "USUÁRIOS AVANÇADOS\n" +
                    "• **Checagem única**: registra se cada prefab do Config.xml está OK ou faltando.\n" +
                    "• Útil após patches do jogo para ver quais entradas não batem mais.\n" +
                    "• Ignore avisos de prefabs de DLC que você não possui - é normal.\n\n" +
                    "• Log: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar padrões (criar novo Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Mesmo** botão Reset da aba Ações.\n" +
                    "**Sobrescreve o Config.xml** com o arquivo padrão.\n" +
                    "• Use se seu arquivo estiver quebrado, quiser começar do zero, ou quiser o novo arquivo do mod (algumas atualizações adicionam prédios).\n" +
                    "• Arquivo copiado aqui: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sobrescrever <ModsData/ConfigXML/Config.xml> com o arquivo padrão?\n" +
                    "Suas mudanças serão substituídas."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "Logs detalhados (leia os avisos à direita antes de usar)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NÃO use no gameplay normal.>\n" +
                    "• Logs detalhados podem deixar o jogo mais lento e criar arquivos grandes.\n" +
                    "• Ative só por alguns minutos para **debug temporário**.\n" +
                    "• <Se você não sabe o que é isso, melhor deixar DESATIVADO.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
