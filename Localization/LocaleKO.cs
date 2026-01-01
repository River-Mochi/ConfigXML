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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "작업" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "하나 선택" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 사용법" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "디버그" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "추천 프리셋" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**추천** - 내장 **프리셋**을 적용합니다.\n" +
                    "쉬움(EASY) 모드: 1번 클릭이면 끝!\n\n" +
                    "• 대부분의 플레이어에게 가장 좋음(직원 수 ↑).\n" +
                    "• 언제든 <프리셋> / <커스텀 파일>로 전환 가능.\n" +
                    "  (프리셋 파일과 ModsData 커스텀 파일은 서로 분리되어 있습니다.)"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "커스텀 파일 사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**고급 사용자**\n" +
                    "로컬 커스텀 파일: <ModsData/ConfigXML/Config.xml>\n" +
                    "을 사용합니다(모드 프리셋 대신).\n" +

                    "<단계>\n" +
                    "**[CONFIG 폴더 열기]** 클릭\n" +
                    "• 텍스트 편집기(Notepad++)로 **Config.xml** 편집 + 저장\n" +
                    "• 그다음 **[새 설정 지금 적용]** 클릭\n\n" +
                    "• 참고: 직원을 0으로 설정하지 마세요.\n" +
                    "• 언제든 기본 프리셋으로 되돌릴 수 있음(파일 분리)."
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIG 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• **Config.xml** 파일이 있는 폴더를 엽니다.\n" +
                    "1. 텍스트 편집기(**Notepad++**)로 파일을 편집합니다.\n\n" +
                    "2. 예시 경로(Windows):\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "새 설정 지금 적용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "**Config.xml**을 읽고 서비스 prefab(예: 건물 직원 수)에 새 값을 적용합니다\n" +
                    "• **새로 건설한 건물**에만 적용(기존 건물에는 적용되지 않음).\n" +
                    "• 새 값을 보려면 기존 건물을 교체하세요.\n" +
                    "• Config.xml을 편집 + 저장한 뒤 **적용**을 클릭하세요.\n" +
                    "• 게임 재시작 시에도 선택한 config 파일이 적용됩니다.\n" +
                    "• 이 기능은 <ModsData/ConfigXML/Config.xml> 파일에 적용됩니다."
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "모든 *새* 서비스 건물에 변경사항을 적용할까요?\n " +
                    "확실합니까?"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "기본 설정으로 재설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**다시 시작** 버튼.\n\n" +
                    "**Config.xml을 덮어쓰기**: 새 기본 파일로 교체합니다(모든 프리셋 포함).\n" +
                    "• 커스텀 파일이 손상되었거나 깔끔한 재설정이 필요할 때 사용.\n\n" +
                    "• 재설정 전에 열려 있는 Config.xml을 모두 닫아주세요.\n" +
                    "• 새 파일 위치: <ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml 을 기본(프리셋) 파일로 덮어쓸까요?\n\n" +
                    "새 파일이 기존 파일을 대체합니다."
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<추천> 기본값(직원 ↑↑) - 끝, 게임하세요 :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**옵션 2 - 고급 사용자**\n" +
                    "<[커스텀 파일 사용]> 으로 원하는 값으로 설정.\n\n" +
                    "1. <[CONFIG 폴더 열기]> 클릭\n" +
                    "2. <**Config.xml** 편집 + 저장>.\n" +
                    "3. <[새 설정 지금 적용]> 클릭\n" +
                    "4. 1-3 단계는 재시작 없이 반복 가능합니다.\n\n" +
                    "<--------------------------->\n" +
                    "이전 모드에서 마이그레이션:\n" +
                    "• 예전 </RealCity/Config.xml> 이 있으면 새 <ModsData/ConfigXML/Config.xml> 로 복사됩니다.\n" +
                    "• 확인: Logs/ConfigXML.log\n" +
                    "• 옛 파일을 무시하려면: RealCity 폴더 삭제(선택) → 게임 시작 →\n" +
                    "• 그리고 <[기본 설정으로 재설정]> 으로 최신 버전을 받으세요."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "이 모드의 표시 이름." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "현재 버전 번호." },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "작성자의 **Paradox Mods** 웹페이지를 엽니다."
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab 상태를 로그로 덤프"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "고급 사용자\n" +
                    "• **일회성 점검**: Config.xml에 있는 각 prefab이 OK인지 Missing인지 로그로 남깁니다.\n" +
                    "• 게임 패치 후, 어떤 항목이 더 이상 매칭되지 않는지 확인할 때 유용.\n" +
                    "• 구매하지 않은 DLC 건물 prefab 경고는 정상입니다(무시 가능).\n\n" +
                    "• 로그 파일: <C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "기본값으로 재설정 (새 Config.xml 생성)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**같은** 재설정 버튼(작업 탭에도 있음).\n" +
                    "**Config.xml을** 기본 파일로 덮어씁니다.\n" +
                    "• 커스텀 파일이 깨졌거나, 새로 시작하거나, 새 모드 파일이 필요할 때(업데이트로 건물 추가 가능).\n" +
                    "• 여기로 복사됨: <ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> 을 기본 파일로 덮어쓸까요?\n" +
                    "모든 커스텀 변경사항이 대체됩니다."
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "자세한 로그 (사용 전 오른쪽 경고 읽기)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<일반 플레이에서는 사용하지 마세요.>\n" +
                    "• 자세한 로그는 게임을 느리게 하고 큰 파일을 만들 수 있습니다.\n" +
                    "• **임시 디버깅**용으로 몇 분만 켜세요.\n" +
                    "• <이게 뭔지 잘 모르겠으면 꺼두는 게 좋습니다.>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
