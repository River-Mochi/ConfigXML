// File: Localization/LocaleKO.cs
// Korean ko-KR for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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

            // Show "Config-XML 0.6.2" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "디버그" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "작업" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "하나만 골라줘" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 사용법" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "추천 프리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**빠른 시작** - 내장 **프리셋** 설정을 전부 적용.\n" +
                    "쉬움 모드: 클릭 1번이면 끝!\n\n" +
                    "• 대부분의 플레이어에게 추천(예: 직원/임금 튜닝).\n\n" +
                    "• 언제든 <프리셋> 과 <커스텀 파일> 을 바꿀 수 있어요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "커스텀 파일 사용" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**고급 사용자**\n" +
                    "커스텀 파일: <ModsData/ConfigXML/Config.xml>\n" +
                    "을 사용합니다(프리셋 대신).\n\n" +
                    "<단계>\n" +
                    "**[CONFIG 폴더 열기]** 클릭\n" +
                    "• **Config.xml** 편집 + 저장 (Notepad++)\n" +
                    "• 그다음 **[새 config 지금 적용]**\n\n" +
                    "• 참고: 직원을 0으로 설정하지 마세요.\n" +
                    "• 언제든 프리셋으로 돌아갈 수 있어요(별도 파일)."
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIG 폴더 열기" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• **Config.xml** 이 들어있는 폴더를 엽니다.\n" +
                    "1. 텍스트 편집기로 수정 (**Notepad++**).\n\n" +
                    "2. 예시 경로(Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "새 config 지금 적용" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "**Config.xml** 을 읽어서 서비스 prefab 값에 적용(예: 건물 직원)\n" +
                    "• **새로 짓는 건물** 에만 적용(기존 건물은 그대로).\n" +
                    "• 새 값 보려면 건물을 교체/재건축하세요.\n" +
                    "• 재시작해도 선택한 config 파일이 적용됩니다."
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "*새로 지을* 서비스 건물에 변경을 적용할까요?\n진짜로요?"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "기본 Config 로 리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**처음부터** 버튼.\n\n" +
                    "**Config.xml 을 덮어쓰기** 해서 새 기본 파일로 되돌립니다(프리셋 포함).\n" +
                    "• 커스텀 파일이 깨졌거나 깔끔하게 리셋하고 싶을 때.\n\n" +
                    "• Reset 전에 열려있는 Config.xml 은 닫아주세요.\n" +
                    "• 복사 위치: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "<ModsData/ConfigXML/Config.xml> 을 기본(프리셋) 파일로 덮어쓸까요?\n\n새 파일이 기존 파일을 교체합니다."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<추천> 기본값이면 끝 - 게임 하자 :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**옵션 2 - 고급 사용자**\n" +
                    "<[커스텀 파일 사용]> 으로 내 입맛대로 설정.\n\n" +
                    "1. <[CONFIG 폴더 열기]>\n" +
                    "2. <**Config.xml** 편집 + 저장>\n" +
                    "3. <[새 config 지금 적용]>\n" +
                    "4. 재시작 없이 1-3 반복 OK.\n\n" +
                    "<--------------------------->\n" +
                    "이전 모드에서 마이그레이션:\n" +
                    "• 예전 </RealCity/Config.xml> (있다면) 을 <ModsData/ConfigXML/Config.xml> 로 복사해뒀어요.\n" +
                    "• 확인은 Logs/ConfigXML.log 를 보세요."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "이 모드의 표시 이름." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "현재 버전 번호." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "작성자의 **Paradox Mods** 페이지를 엽니다."
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab 상태를 로그로 덤프" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**고급 사용자**\n" +
                    "• 1회 체크: Config.xml 의 각 prefab 이 OK / Missing 인지 로그로 남깁니다.\n" +
                    "• 패치 후 어떤 항목이 안 맞는지 볼 때 유용.\n" +
                    "• 없는 DLC 때문에 Missing 뜨는 건 정상입니다.\n\n" +
                    "• 출력 파일: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> 또는 <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "컴포넌트 필드 덤프(1회)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Config.xml 에 있는 prefab 목록의 prefab + component 필드를 한 번만 덤프합니다.\n" +
                    "출력: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> 또는 <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "경고: 큰 파일이 생성됩니다.\n\n위치: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> 또는 <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "기본값으로 리셋(Config.xml 새로 만들기)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "작업 탭의 Reset 과 **같은** 버튼입니다.\n" +
                    "**Config.xml 을 기본 파일로 덮어쓰기** 합니다.\n" +
                    "• 파일: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> 을 기본 파일로 덮어쓸까요?\n커스텀 변경사항은 교체됩니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "상세 로그(디버그 전용)" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<일반 플레이에선 절대 쓰지 마세요.>\n" +
                    "• 게임이 느려지고 로그 파일이 커질 수 있어요.\n" +
                    "• 디버깅할 때만 잠깐 켜세요."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
