// File: Localization/LocalePT_BR.cs
// Portuguese (Brazil) pt-BR for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "PRESETS RECOMENDADOS" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**Início rápido** - aplica todas as configurações de **preset** embutidas.\n" +
                    "Modo FÁCIL: 1 clique e pronto!\n\n" +
                    "• Melhor pra maioria — ajustes selecionados (ex.: trabalhadores/salários).\n\n" +
                    "• Dá pra alternar entre <Presets> e <Arquivo personalizado> a qualquer hora."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "Usar arquivo personalizado" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "Usa um arquivo personalizado: <ModsData/ConfigXML/Config.xml>\n" +
                    "em vez dos presets do mod.\n\n" +
                    "<Passos>\n" +
                    "Clique **[ABRIR PASTA DO CONFIG]**\n" +
                    "• Edite e salve o **Config.xml** (Notepad++)\n" +
                    "• Depois clique **[APLICAR NOVO CONFIG AGORA]**\n\n" +
                    "• Obs.: não coloque trabalhadores como 0.\n" +
                    "• Volte pros presets quando quiser (arquivo separado)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "ABRIR PASTA DO CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• Abre a pasta com o **Config.xml**.\n" +
                    "1. Edite o arquivo com um editor de texto (**Notepad++**).\n\n" +
                    "2. Exemplo de caminho (Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "APLICAR NOVO CONFIG AGORA" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Lê o **Config.xml** e aplica novos valores aos prefabs de serviços (ex.: trabalhadores do prédio)\n" +
                    "• Aplica em **prédios novos** (não muda os existentes).\n" +
                    "• Substitua o prédio pra ver os novos valores.\n" +
                    "• Reiniciar também aplica o arquivo config escolhido."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "Aplicar mudanças em qualquer prédio de serviço *novo*?\nTem certeza?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "Resetar para o config padrão" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**COMEÇAR DO ZERO**.\n\n" +
                    "**Sobrescreve o Config.xml** com um arquivo padrão novinho (inclui presets).\n" +
                    "• Use se o arquivo personalizado estiver corrompido ou se quiser um reset limpo.\n\n" +
                    "• Feche qualquer Config.xml aberto antes do Reset.\n" +
                    "• Copia para: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Sobrescrever <ModsData/ConfigXML/Config.xml> com o arquivo padrão (presets)?\n\nO novo arquivo SUBSTITUI o arquivo existente."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<RECOMENDADO> padrão - pronto, joga :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**Opção 2 - Usuários avançados**\n" +
                    "<[Usar arquivo personalizado]> pra fazer suas configurações.\n\n" +
                    "1. Clique <[ABRIR PASTA DO CONFIG]>\n" +
                    "2. <Editar + salvar **Config.xml**>.\n" +
                    "3. Clique <[APLICAR NOVO CONFIG AGORA]>\n" +
                    "4. Repita 1-3 sem reiniciar.\n\n" +
                    "<--------------------------->\n" +
                    "Migração do mod antigo:\n" +
                    "• O antigo </RealCity/Config.xml> (se existir) foi copiado para <ModsData/ConfigXML/Config.xml>.\n" +
                    "• Veja Logs/ConfigXML.log pra confirmar."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "Nome exibido deste mod." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "Número da versão atual." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Abra a página **Paradox Mods** dos mods do autor."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Exportar status dos prefabs (1x)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**USUÁRIOS AVANÇADOS**\n" +
                    "• Checagem única: registra se cada prefab do Config.xml está OK ou Missing.\n" +
                    "• Útil após patches pra ver o que não bate mais.\n" +
                    "• Missing de DLC que você não tem é normal.\n\n" +
                    "• Arquivo de saída: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> ou <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "Exportar campos de componentes (1x)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Dump único dos campos de prefab + componentes para os prefabs listados no Config.xml.\n" +
                    "Saída: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> ou <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "Aviso: gera um arquivo grande.\n\nLocal: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> ou <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "Resetar para o padrão (novo Config.xml)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**Mesmo** botão Reset da aba Ações.\n" +
                    "**Sobrescreve o Config.xml** com o arquivo padrão.\n" +
                    "• Arquivo: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Sobrescrever <ModsData/ConfigXML/Config.xml> com o arquivo padrão?\nQualquer alteração personalizada será substituída."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "Logs detalhados (só debug)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<NÃO use no gameplay normal.>\n" +
                    "• Pode deixar o jogo mais lento e criar arquivos grandes.\n" +
                    "• Ative só por pouco tempo pra debugar."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
