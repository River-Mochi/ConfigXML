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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "액션" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "디버그" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "옵션 - 하나 선택" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "액션" },
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
                    "EASY 모드:  1번 클릭이면 끝!\n\n" +
                    "대부분의 플레이어에게 추천.\n" +
                    "근로자 수를 늘립니다(그리고 직업에 필요한 교육 수준 등 소소한 조정 포함).\n" +
                    "프리셋/커스텀 파일은 언제든 전환 가능.\n" +
                    "프리셋 파일과 ModsData 커스텀 파일은 서로 분리되어 있습니다."
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "커스텀 파일 사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<고급 사용자>\n" +
                    "로컬 커스텀 파일을 사용합니다: <ModsData/ConfigXML/Config.xml>\n" +
                    "모드 기본 프리셋 대신 적용됩니다.\n" +

                    "<팁>\n" +
                    "**Config 폴더 열기** 클릭\n" +
                    "• 텍스트 편집기(Notepad++)로 **Config.xml** 수정\n" +
                    "• 근로자 수를 0으로 두지 마세요(적은 인원은 작은 값 사용).\n" +
                    "• 수정 후: 저장하고 <새 config 지금 적용> 클릭\n\n" +
                    "<기본값으로 재설정> 은 기존 커스텀 파일을 교체합니다.\n" +
                    "언제든 프리셋으로 돌아갈 수 있습니다(파일 분리)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Config 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "선택 사항\n" +
                    "• **Config.xml** 이 들어있는 <ModsData/ConfigXML/> 폴더를 엽니다.\n" +
                    "1. 원하는 편집기(Notepad++)로 수정.\n\n" +
                    "2. 예시 경로 (Windows):\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "새 config 지금 적용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "<ModsData/ConfigXML/Config.xml> 을 읽고 서비스 프리팹(예: 건물 근로자)에 새 값을 적용합니다\n" +
                    "• **새로 지은 건물**에만 적용(기존 건물은 제외).\n" +
                    "• 기존 도시에서는 건물을 교체/재건설해서 변경값을 확인하세요.\n" +
                    "• Config.xml 수정+저장 후 다시 **새로 적용**을 누르세요."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "새로 지은 서비스 건물에 변경사항을 적용할까요?\n " +
                    "확인?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "기본값으로 재설정 (Config.xml)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**처음부터** 버튼.\n\n" +
                    "**ModsData/ConfigXML/Config.xml** 을 새 기본 복사본(모드 포함 프리셋)으로 덮어씁니다.\n" +
                    "• 커스텀 파일이 깨졌거나 깔끔한 리셋이 필요할 때 사용.\n\n" +
                    "• 재설정 전에 열려 있는 Config.xml 파일을 닫아주세요."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml 을 기본(프리셋) 파일로 덮어쓸까요?\n\n" +
                    "새 파일이 기존 파일을 교체합니다."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<옵션 1 - 빠른 시작>\n" +
                    "**[빠른 시작 프리셋]** 을 선택하세요.\n" +
                    "끝 - 게임 시작."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<옵션 2 - 고급 사용자>\n" +
                    "**[커스텀 파일 사용]** 으로 내 설정을 만듭니다.\n\n" +
                    "1. **[Config 폴더 열기]** 클릭\n" +
                    "2. **Config.xml** 수정 후 저장 (Notepad++)\n" +
                    "3. **[새 config 지금 적용]** 클릭\n" +
                    "4. 새 서비스 건물을 지어서 변경값 확인\n" +
                    "5. 변경 후 <새로 적용>을 누르면 재시작 없이 반복 가능\n\n" +

                    "마이그레이션 안내:\n" +
                    "ModsData/RealCity/Config.xml 이 있었다면 **ModsData/ConfigXML/Config.xml** 로 복사됩니다.\n" +
                    "Logs/ConfigXML.log 에서 확인.\n" +
                    "옛 파일을 무시하려면: ModsData/RealCity 삭제(선택) → 게임 시작 →\n" +
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
                    "1회 체크: Config.xml에 있는 각 프리팹이 OK인지/누락인지 로그에 남깁니다.\n" +
                    "• 게임 패치 후, 어떤 항목이 바뀌었는지 확인할 때 유용.\n" +
                    "• 소유하지 않은 DLC 프리팹 경고는 정상입니다(무시 가능).\n" +
                    "로그 파일: C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "자세한 로그 (오른쪽 경고 확인)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<일반 플레이에는 비추천.>\n" +
                    "자세한 로그는 게임을 느리게 하고 로그 파일이 커질 수 있습니다.\n" +
                    "디버깅할 때만 **잠깐** 켜세요.\n" +
                    "<잘 모르겠으면 꺼두는 게 좋아요.>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "작성자의 **Paradox Mods** 페이지를 엽니다."
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "기본값으로 재설정 (새 Config.xml)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "액션 탭의 재설정과 동일\n" +
                    "<ModsData/ConfigXML/Config.xml> 을 기본 파일로 덮어씁니다.\n" +
                    "커스텀 파일이 깨졌거나, 새로 시작하거나, 새 버전 기본값(업데이트로 건물이 늘어날 수 있음)이 필요할 때 사용."
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> 을 기본 파일로 덮어쓸까요?\n" +
                    "모든 커스텀 변경사항이 교체됩니다."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
