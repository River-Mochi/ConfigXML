// LocalePT_BR.cs
// Portuguese (pt-BR) City Services Redux.

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

            // Show "City Services Redux 0.5.3" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número de versão atual." },

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
                    "**Início rápido** – aplica todas as predefinições recomendadas\n" +
                    "Modo FÁCIL: 1 clique e pronto!\n\n" +
                    "Recomendado para a maioria dos jogadores – já vem com ajustes afinados (ex.: número de funcionários/salários e mais) " +
                    "diferentes dos valores padrão do jogo."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "USAR ARQUIVO PERSONALIZADO"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Quando ativado, usa um arquivo local personalizado <ModsData/RealCity/Config.xml> em vez das predefinições do mod.\n" +
                    "• Para quem quer configurações diferentes por save ou por máquina.\n\n" +
                    "**DICAS**\n" +
                    "Clique no botão Abrir pasta de config.\n" +
                    "• Mostra a pasta com o Config.xml em ModsData/RealCity; aí você pode ajustar funcionários e outros campos.\n" +
                    "• **Nunca** coloque o número de trabalhadores em 0; use valores positivos pequenos se quiser pouco pessoal.\n" +
                    "• Depois das mudanças, salve o arquivo e use o botão **APPLY** para aplicar as alterações no mod.\n\n" +
                    "Use <Reset new> apenas se estragar o arquivo ou quiser um Config.xml completamente novo – substitui o arquivo atual.\n" +
                    "Você pode voltar às **PREDEFINIÇÕES** a qualquer momento. "
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
                    "Não é obrigatório – use apenas se quiser alterar as predefinições padrão do mod.\n" +
                    "• Abre a pasta <ModsData/RealCity/> que contém **Config.xml**.\n" +
                    "1. Edite o arquivo com seu editor de texto favorito (ex.: <Notepad++>).\n\n" +
                    "2. Caminho de exemplo no Windows:\n" +
                    "C:/Users/SeuNome/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "APLICAR nova configuração agora"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê seu <ModsData/RealCity/Config.xml> local e aplica os novos valores aos prédios de serviços " +
                    "(vagas de trabalho, taxas de processamento etc.).\n\n" +
                    "• Aplica-se apenas a **novos edifícios**, não aos já construídos.\n" +
                    "• Em cidades existentes, remova o prédio antigo e construa outro para ver as mudanças.\n" +
                    "• Se estiver satisfeito com as configurações, basta carregar uma cidade.\n" +
                    "   Só é preciso clicar em **Aplicar nova** quando você editar o Config.xml de novo."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Suas novas alterações personalizadas serão aplicadas a muitos prédios de serviços da cidade.\n " +
                    "Tem certeza?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Restaurar novo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "BOTÃO PARA RECOMEÇAR\n\n" +
                    "Substitui **ModsData/RealCity/Config.xml** por uma cópia nova das predefinições originais do mod.\n" +
                    "• Use apenas se seu arquivo personalizado estiver corrompido ou se quiser começar do zero.\n\n" +
                    "• **Restaurar novo** substitui o arquivo existente – feche o Config.xml antigo no editor antes."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Substituir ModsData/RealCity/Config.xml pelo arquivo original?\n\n" +
                    "As alterações personalizadas serão perdidas e trocadas por uma cópia nova."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "Opção 1\n" +
                    "Selecione <[PREDEFINIÇÕES RECOMENDADAS]> para usar as configurações prontas do mod.\n" +
                    "Se escolher PREDEFINIÇÕES, pronto – é só jogar.\n\n" +
                    "<--------------------------->\n\n" +
                    "Opção 2 – Usuários avançados\n" +
                    "Selecione <[USAR ARQUIVO PERSONALIZADO]> para editar seu próprio Config.xml.\n\n" +
                    "1. Clique em <[ABRIR pasta Config]>.\n" +
                    "2. Abra, edite e salve <Config.xml> com um editor de texto (ex.: Notepad++).\n" +
                    "3. Clique em <[APLICAR nova configuração agora]> – aplica as alterações do arquivo.\n" +
                    "4. <Carregue a cidade> (ou recarregue) para ver as mudanças em **novos** edifícios.\n" +
                    "5. Você pode repetir os passos 1–4 sem reiniciar o jogo, desde que clique em <APPLY> após cada mudança."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "Logs detalhados (leia os avisos à direita antes de usar)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "Escreve muitas informações extras no arquivo de log.\n" +
                    "<NÃO use> para jogatina normal.\n" +
                    "Logs demais podem deixar o jogo mais lento e criar arquivos enormes.\n" +
                    "Ative isso apenas temporariamente para coletar dados ou depurar problemas.\n" +
                    "Se você não tem certeza do que é, melhor deixar DESATIVADO."
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
                    "• Use após um patch do jogo para ver quais entradas de Config.xml não batem mais com o jogo.\n" +
                    "• Ignore avisos sobre prefabs de DLC que você não possui – isso é normal."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abre a página do **Paradox Mods** para City Services Redux e outros mods."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Restaurar novo Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Igual ao botão da aba Ações: substitui <ModsData/RealCity/Config.xml> por uma cópia nova " +
                    "das predefinições originais do mod.\n" +
                    "Use se seu arquivo personalizado estiver quebrado ou se quiser recomeçar do zero."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Substituir <ModsData/RealCity/Config.xml> pelo arquivo de PREDEFINIÇÕES original do mod?\n\n" +
                    "Todas as alterações personalizadas serão trocadas por um novo arquivo."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
