// Localization/LocaleKO.cs
// Korean ko-KR for Config-XML.

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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "옵션 - 하나 선택" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "작업" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 사용법" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "이 모드의 표시 이름." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "현재 버전 번호." },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "빠른 시작 프리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<빠른 시작> - 내장 프리셋을 자동으로 적용합니다.\n" +
                    "쉬움 모드:  한 번 클릭으로 끝!\n\n" +
                    "대부분의 플레이어에게 추천.\n" +
                    "직원(근로자) 수를 늘리고, 필요한 교육 수준도 약간 조정합니다.\n" +
                    "프리셋 / 사용자 파일은 언제든지 전환 가능.\n" +
                    "프리셋 파일과 ModsData 사용자 파일은 서로 분리되어 있습니다."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "사용자 파일 사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<고급 사용자>\n" +
                    "로컬 사용자 파일 사용: <ModsData/ConfigXML/Config.xml>\n" +
                    "모드 기본 프리셋 대신 이 파일을 씁니다.\n" +

                    "<팁>\n" +
                    "**Config 폴더 열기**\n" +
                    "• **Config.xml**을 텍스트 편집기(Notepad++)로 수정\n" +
                    "• 직원을 0으로 두지 마세요(작은 값 사용).\n" +
                    "• 수정 후 저장하고 <새 config 적용> 클릭\n\n" +
                    "<기본값으로 재설정>은 기존 사용자 파일을 덮어씁니다.\n" +
                    "언제든지 프리셋으로 돌아갈 수 있어요(파일 분리)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Config 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "선택 사항\n" +
                    "• **Config.xml**이 있는 <ModsData/ConfigXML/> 폴더를 엽니다.\n" +
                    "1. 선호하는 편집기(Notepad++)로 수정.\n\n" +
                    "2. 예시 경로(Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "새 config 적용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "<ModsData/ConfigXML/Config.xml>을 읽고 서비스 프리팹(예: 직원 수)에 새 값을 적용합니다.\n" +
                    "• **새로 지은 건물**에만 적용(기존 건물 X).\n" +
                    "• 기존 도시는 건물을 교체해야 변경이 보입니다.\n" +
                    "• Config.xml 수정+저장 후 **적용**을 다시 누르세요."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "새로 지은 서비스 건물에 변경을 적용할까요?\n " +
                    "확인?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "기본 Config.xml로 재설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**처음부터** 버튼.\n\n" +
                    "**ModsData/ConfigXML/Config.xml**을 기본 파일(모드 프리셋)로 덮어씁니다.\n" +
                    "• 사용자 파일이 깨졌거나 초기화가 필요할 때 사용.\n\n" +
                    "• 재설정 전에 열려있는 Config.xml을 닫아주세요."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml을 기본(프리셋) 파일로 덮어쓸까요?\n\n" +
                    "새 파일이 기존 파일을 대체합니다."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<옵션 1 - 빠른 시작>\n" +
                    "**[빠른 시작 프리셋]** 선택.\n" +
                    "끝 - 플레이!"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<옵션 2 - 고급 사용자>\n" +
                    "**[사용자 파일 사용]**으로 커스텀 설정.\n\n" +
                    "1. **[Config 폴더 열기]** 클릭\n" +
                    "2. **Config.xml** 수정 후 저장(Notepad++)\n" +
                    "3. **[새 config 적용]** 클릭\n" +
                    "4. 새 서비스 건물을 지어 변경 확인\n" +
                    "5. 변경 후 <적용>만 누르면 재시작 없이 1-4 반복 가능\n\n" +

                    "마이그레이션 안내:\n" +
                    "ModsData/RealCity/Config.xml이 있으면 **ModsData/ConfigXML/Config.xml**로 복사됩니다.\n" +
                    "Logs/ConfigXML.log 확인.\n" +
                    "이전 파일을 무시하려면: ModsData/RealCity 삭제(선택), 게임 시작 후\n" +
                    "**[기본값으로 재설정]** 사용"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "프리팹 상태를 로그로 출력"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**고급 사용자**\n" +
                    "1회용 체크: Config.xml의 각 프리팹이 OK인지 누락인지 로그에 기록합니다.\n" +
                    "• 패치 후 확인용.\n" +
                    "• 소유하지 않은 DLC 프리팹 경고는 정상입니다.\n" +
                     "로그 파일: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "자세한 로그 (오른쪽 경고 읽기)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<일반 플레이용 아님.>\n" +
                    "자세한 로그는 게임이 느려지고 로그 파일이 커질 수 있어요.\n" +
                    "디버깅할 때만 **잠깐** 켜세요.\n" +
                    "<잘 모르겠으면 꺼두는 게 좋습니다.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "작성자 모드의 **Paradox Mods** 페이지 열기."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "기본값으로 재설정 (새 Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "작업 탭의 재설정과 동일\n" +
                    "<ModsData/ConfigXML/Config.xml>을 기본 파일로 덮어씀" +
                    "파일이 깨졌거나 초기화/새 버전 적용이 필요할 때 사용(업데이트로 건물이 늘 수도 있음)."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml>을 기본 파일로 덮어쓸까요?\n" +
                    "사용자 변경 내용이 대체됩니다."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
