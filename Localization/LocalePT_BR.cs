// LocalePT_BR.cs
// Brazilian Portuguese pt-BR. City Services Redux.

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

            // Show "City Services Redux 0.5.1" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "Opções – escolha uma" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Como usar o Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome exibido deste mod."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número da versão atual."
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "PREDEFINIÇÕES RECOMENDADAS"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Início rápido** – aplica todas as predefinições recomendadas.\n" +
                    "Modo FÁCIL: 1 clique e pronto!\n\n" +
                    "Recomendado para a maioria dos jogadores – já inclui ajustes pensados à mão, " +
                    "como número de trabalhadores/salários diferente do padrão do jogo."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "Config.xml personalizado"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Permite usar um <ModsData/RealCity/Config.xml> personalizado em vez das predefinições internas.\n" +
                    "• Para quem quer configurações diferentes por save ou por máquina.\n\n" +
                    "**DICAS**\n" +
                    "Clique no botão \"ABRIR pasta da Config\".\n" +
                    "• Mostra a pasta com o Config.xml em ModsData/RealCity, onde você pode alterar trabalhadores e outros campos.\n" +
                    "• **Nunca** configure os postos de trabalho como 0; use valores positivos pequenos para pouco staff.\n" +
                    "• Depois de salvar as alterações, use o botão **APLICAR nova configuração** para atualizar o mod.\n\n" +
                    "Use <Restaurar nova Config.xml> **apenas** se o arquivo estiver corrompido ou se quiser começar do zero – o arquivo atual será substituído.\n" +
                    "Você pode voltar para **PREDEFINIÇÕES RECOMENDADAS** a qualquer momento."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "ABRIR pasta da Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "Não é obrigatório – use isto somente se quiser alterar as predefinições do mod.\n" +
                    "• Abre a pasta <ModsData/RealCity/> que contém o **Config.xml**.\n" +
                    "1. Edite o arquivo com seu editor de texto preferido (por ex. <Notepad++>).\n\n" +
                    "2. Caminho de exemplo (Windows):\n" +
                    "C:/Users/SeuNome/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nova configuração"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê o seu <ModsData/RealCity/Config.xml> personalizado e aplica os novos valores aos prédios de serviços " +
                    "(vagas de trabalho, taxas de processamento, etc.).\n\n" +
                    "• Vale para **novos prédios**, não para os já construídos.\n" +
                    "• Em cidades existentes, demole o prédio antigo e construa outro para ver as mudanças.\n" +
                    "• Se estiver satisfeito com as configurações, basta carregar uma cidade.\n" +
                    "   Você só precisa clicar em **APLICAR nova configuração** quando editar o Config.xml novamente."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar suas novas alterações personalizadas a muitos prédios de serviço.\n" +
                    "Tem certeza?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurar nova Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÃO DE RECOMEÇAR\n\n" +
                    "Substitui **ModsData/RealCity/Config.xml** por uma nova cópia das predefinições originais do mod.\n" +
                    "• Use isto **apenas** se o seu arquivo estiver quebrado ou se quiser recomeçar limpo.\n\n" +
                    "• \"Restaurar nova Config.xml\" substitui o arquivo atual – feche o arquivo no editor antes de usar."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Substituir ModsData/RealCity/Config.xml pelo arquivo original?\n\n" +
                    "Todas as alterações personalizadas serão perdidas."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opção 1\n" +
                    "Selecione <[PREDEFINIÇÕES RECOMENDADAS]> para usar os presets do mod.\n" +
                    "Se você escolher PREDEFINIÇÕES, pronto – é só jogar.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opção 2 – usuários avançados\n" +
                    "Selecione <[Config.xml personalizado]> para editar seus próprios valores.\n\n" +
                    "1. Clique em <[ABRIR pasta da Config]>.\n" +
                    "2. Abra, edite e salve <Config.xml> com seu editor de texto preferido.\n" +
                    "3. Depois clique em <[APLICAR nova configuração]>.\n" +
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
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "Log detalhado (avançado)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escreve muitas informações extras no arquivo de log.\n" +
                    "<NÃO recomendado> para jogo normal.\n" +
                    "Muito log pode deixar o jogo mais lento e criar arquivos enormes.\n" +
                    "Ative apenas temporariamente quando precisar de dados ou estiver depurando."
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
                    "• Use depois de um patch para ver quais entradas em Config.xml não batem mais com o jogo.\n" +
                    "• Ignore avisos para prefabs de DLCs que você não possui – isso é normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abre a página da **Paradox Mods** para City Services Redux e seus outros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar nova Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Mesmo que o botão na aba Ações: substitui <ModsData/RealCity/Config.xml> por uma nova cópia " +
                    "das predefinições originais do mod.\n" +
                    "Use se o arquivo estiver quebrado ou se quiser recomeçar."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Substituir <ModsData/RealCity/Config.xml> pelo arquivo de PREDEFINIÇÕES original?\n\n" +
                    "Qualquer alteração personalizada será trocada por um novo arquivo."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
