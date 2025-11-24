// LocalePT_BR.cs
// Brazilian Portuguese (pt-BR) City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.0" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Como usar o Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),
                    "Nome deste mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),
                    "Número de versão atual."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PRESETS RECOMENDADOS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Início rápido** - aplica todas as configurações recomendadas.\n" +
                    "Modo FÁCIL: 1 clique e pronto!\n\n" +
                    "Recomendado para a maioria dos jogadores: já vem com ajustes feitos à mão, " +
                    "como número de trabalhadores/salários diferentes do padrão do jogo."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "USAR Config.xml PERSONALIZADO"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Quando ativado, permite usar um arquivo local personalizado " +
                    "<ModsData/RealCity/Config.xml> em vez dos presets do mod.\n" +
                    "• Para quem quer configurações diferentes de serviços por save ou por máquina.\n\n" +
                    "**DICAS**\n" +
                    "Clique no botão \"OPEN Config folder\".\n" +
                    "• Mostra o local do Config.xml em ModsData/RealCity; depois é só ajustar o número de trabalhadores ou outros campos.\n" +
                    "• **Nunca** coloque o número de vagas em 0; use valores pequenos se quiser pouco pessoal.\n" +
                    "• Depois de alterar, salve o arquivo e use o botão **APPLY** para aplicar as mudanças no mod.\n\n" +
                    "Use <Restore new> <APENAS> se estragar o arquivo ou quiser um Config.xml totalmente novo " +
                    "(substitui o arquivo existente).\n" +
                    "Você pode voltar para **[Use PRESETS]** a qualquer momento."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "ABRIR pasta Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Não é obrigatório; use apenas se pretende alterar os presets padrão do mod.\n" +
                    "• Abre a pasta <ModsData/RealCity/> que contém **Config.xml**.\n" +
                    "1. Edite com seu editor de texto preferido (por exemplo, <Notepad++>).\n\n" +
                    "2. Exemplo de caminho aberto (Windows):\n" +
                    "C:/Users/SeuNome/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nova configuração agora"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê seu arquivo local <ModsData/RealCity/Config.xml> e aplica os novos valores " +
                    "aos prefabs de serviços da cidade (vagas de trabalho, taxas de processamento, etc.).\n\n" +
                    "• Aplica-se a **novos prédios**, não aos já existentes.\n" +
                    "• Em cidades já iniciadas, exclua o prédio antigo e coloque um novo para ver as mudanças.\n" +
                    "• Se estiver satisfeito, basta carregar a cidade.\n" +
                    "   Só é preciso clicar em **Apply New** quando você alterar o Config.xml novamente."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar suas alterações personalizadas em muitos prédios de serviços.\n" +
                    "Tem certeza?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurar novo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÃO PARA RECOMEÇAR DO ZERO\n\n" +
                    "Substitui **ModsData/RealCity/Config.xml** por uma nova cópia dos presets originais do mod.\n" +
                    "• Use <apenas> se o arquivo personalizado estiver corrompido ou se quiser começar novamente.\n\n" +
                    "• \"Restore new\" substitui o arquivo existente – feche o Config.xml no editor antes."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Substituir ModsData/RealCity/Config.xml pelo arquivo original?\n\n" +
                    "As alterações personalizadas serão perdidas."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opção 1\n" +
                    "Selecione <[Use PRESETS]> (recomendado) para usar os presets incluídos.\n" +
                    "Se escolher PRESETS, acabou: é só jogar.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opção 2 - Usuários avançados\n" +
                    "Selecione <[Use CUSTOM Config.xml]> para editar seus próprios valores.\n\n" +
                    "1. Clique em <[OPEN Config folder]>.\n" +
                    "2. Abra, edite e salve <Config.xml> com seu editor de texto.\n" +
                    "3. Depois clique em <[APPLY NEW Configuration Now]>.\n" +
                    "4. <Carregue uma cidade> (ou recarregue) para ver as mudanças em **novos** prédios."
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
                    "Log detalhado (avançado)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escreve muitas informações extras no arquivo de log.\n" +
                    "<NÃO recomendado> para jogo normal.\n" +
                    "Logs muito grandes podem deixar o jogo mais lento e criar arquivos enormes.\n" +
                    "Ative apenas temporariamente quando estiver coletando dados ou depurando."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "Registrar status dos prefabs no log"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Verifica cada prefab listado em Config.xml e registra se está OK ou ausente.\n" +
                    "• Use isso após um patch do jogo para ver quais entradas do Config.xml não combinam mais.\n" +
                    "• Ignore avisos para prefabs de DLC que você não possui – isso é normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abrir a página do **Paradox Mods** para City Services Redux e seus outros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar novo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual ao botão da aba Ações: substitui <ModsData/RealCity/Config.xml> " +
                    "por uma nova cópia dos presets originais.\n" +
                    "Use se o arquivo personalizado estiver quebrado ou se quiser começar do zero."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Substituir <ModsData/RealCity/Config.xml> pelo arquivo de PRESETS original?\n\n" +
                    "Todas as alterações personalizadas serão substituídas por um novo arquivo."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
