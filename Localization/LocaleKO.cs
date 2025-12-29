// LocaleKO.cs
// Korean ko-KR Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "동작" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "디버그" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "옵션 - 하나만 선택" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "동작" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 사용 방법" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "이 모드의 표시 이름입니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "현재 버전 번호입니다." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "추천 프리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**빠른 시작** - 추천 프리셋 전체 적용\n" +
                    "이지 모드: 클릭 한 번이면 끝!\n\n" +
                    "대부분의 플레이어에게 추천되는 설정입니다. 인원 수, 임금 등 게임 기본값과 다른 값으로 " +
                    "미리 손봐 둔 시 서비스 조정값이 포함되어 있습니다."
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "커스텀 파일 사용" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**고급 사용자용**\n" +
                    "이 옵션을 켜면 기본 프리셋 대신 로컬 커스텀 <ModsData/ConfigXML/Config.xml> 을 사용할 수 있습니다.\n" +
                    "• 세이브나 PC마다 다른 서비스 설정을 쓰고 싶은 고급 사용자용입니다.\n\n" +
                    "**팁**\n" +
                    "\"Config 폴더 열기\" 버튼을 클릭하세요.\n" +
                    "• 여기서 ModsData/ConfigXML 위치에 있는 Config.xml 을 열고 근로자 수 등 필드를 수정할 수 있습니다.\n" +
                    "• 근무 인원(workplaces)을 **절대** 0으로 두지 마세요. 정말 적게 쓰고 싶다면 작은 양의 양수로 설정하세요.\n" +
                    "• 수정 후 파일을 저장하고 **새 설정 지금 적용** 버튼을 눌러 변경 사항을 모드에 반영하세요.\n\n" +
                    "<Reset new> 는 설정을 망가뜨렸거나 완전히 새 Config.xml 이 필요할 때에만 사용하세요. 기존 파일을 덮어씁니다.\n" +
                    "언제든지 다시 **추천 프리셋** 으로 되돌릴 수 있습니다. "
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Config 폴더 열기" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "필수는 아니며, 모드가 제공하는 기본 프리셋을 직접 수정할 계획이 있을 때만 사용하세요.\n" +
                    "• **Config.xml** 이 들어 있는 <ModsData/ConfigXML/> 폴더를 엽니다.\n" +
                    "1. 원하는 텍스트 편집기(예: <Notepad++>)로 이 파일을 수정하세요.\n\n" +
                    "2. (Windows) 예시 경로:\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "새 설정 지금 적용"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "로컬 파일 <ModsData/ConfigXML/Config.xml> 을 읽고, 새로운 값을 시 서비스 프리팹에 적용합니다" +
                    "(근로자 수, 처리량 등).\n\n" +
                    "• **새로 짓는 건물**에만 적용되며 기존 건물에는 적용되지 않습니다.\n" +
                    "• 기존 도시에선 옛 건물을 지우고 다시 지으면 변경된 값을 볼 수 있습니다.\n" +
                    "• 설정이 마음에 들면 그냥 도시를 로드만 해도 됩니다.\n" +
                    "  Config.xml 을 다시 수정했을 때만 **새 설정 지금 적용** 을 눌러 주세요."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "여러 시 서비스 건물에 새 커스텀 설정을 적용합니다.\n " +
                    "정말 진행할까요?"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "새 Config.xml 복원"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "처음부터 다시 시작 버튼\n\n" +
                    "**ModsData/ConfigXML/Config.xml** 을 원래 모드 프리셋의 새 복사본으로 덮어씁니다.\n" +
                    "• 커스텀 파일이 깨졌거나 그냥 처음부터 다시 설정하고 싶을 때만 사용하세요.\n\n" +
                    "• **새 Config.xml 복원** 은 기존 파일을 교체합니다. 먼저 열려 있던 Config.xml 을 닫아 두세요."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml 을 원본 파일로 덮어쓸까요?\n\n" +
                    "지금까지 적용한 커스텀 변경 사항은 새 파일로 모두 대체됩니다."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "옵션 1\n" +
                    "<[추천 프리셋]> 을 선택해서 내장 프리셋을 사용합니다.\n" +
                    "추천 프리셋을 선택했다면 끝입니다 - 그냥 게임을 즐기세요.\n\n" +
                    "<--------------------------->\n\n" +
                    "옵션 2 - 고급 사용자\n" +
                    "직접 Config.xml 을 수정하려면 <[커스텀 파일 사용]> 을 선택하세요.\n\n" +
                    "1. <[Config 폴더 열기]> 를 클릭합니다.\n" +
                    "2. 텍스트 편집기(예: Notepad++)로 <Config.xml> 을 열어서 수정하고 저장합니다.\n" +
                    "3. <[새 설정 지금 적용]> 을 눌러 파일의 변경 사항을 적용합니다.\n" +
                    "4. <Load City> (또는 다시 로드) 해서 <새로 짓는> 건물에 적용된 변경을 확인합니다.\n" +
                    "5. <새 설정 지금 적용> 을 사용하면, 재시작 없이 1~4 단계를 반복할 수 있습니다."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "상세 로그 (사용 전 오른쪽 경고를 읽어 주세요)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "로그 파일에 추가 정보를 아주 많이 기록합니다.\n" +
                    "일반 플레이에는 <사용하지 마세요>.\n" +
                    "과도한 로깅은 게임을 느리게 만들고 로그 파일을 거대하게 만듭니다.\n" +
                    "데이터 수집이나 디버깅이 필요할 때만 잠깐 켜 두세요.\n" +
                    "이게 뭔지 잘 모르겠다면 비활성화 상태로 두는 편이 좋습니다."
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "프리팹 상태를 로그로 저장"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**고급 사용자용**\n" +
                    "Config.xml 에 나열된 모든 프리팹을 검사해서 정상인지, 누락됐는지를 로그에 기록합니다.\n" +
                    "• 게임 패치 후 어떤 Config.xml 항목이 더 이상 게임과 맞지 않는지 확인할 때 사용하세요.\n" +
                    "• 가지고 있지 않은 DLC 건물 프리팹에 대한 경고는 무시해도 됩니다. 정상입니다."
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "City Services Redux 및 다른 모드의 **Paradox Mods** 웹페이지를 엽니다."
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "새 Config.xml 복원"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Actions 탭에 있는 버튼과 동일합니다. 로컬 <ModsData/ConfigXML/Config.xml> 을 원래 모드 프리셋의 새 복사본으로 덮어씁니다.\n" +
                    "커스텀 파일이 깨졌거나 처음부터 다시 시작하고 싶을 때 사용하세요."
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> 을 원본 모드 추천 프리셋 파일로 덮어쓸까요?\n\n" +
                    "모든 커스텀 변경 사항은 새 파일로 대체됩니다."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
