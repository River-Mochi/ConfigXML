// Localization/LocaleZH_HANT.cs
// Traditional Chinese zh-HANT for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_HANT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "除錯" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "二選一" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 使用說明" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "除錯" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推薦預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**推薦** - 套用模組內建 **預設**。\n" +
                    "簡單模式（EASY）：一鍵搞定！\n\n" +
                    "• 最適合大多數玩家：增加建築員工數量。\n" +
                    "• 可隨時在 <預設> 與 <自訂檔案> 之間切換。\n" +
                    "  （預設檔與 ModsData 自訂檔互不影響、彼此獨立。）"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自訂檔案" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**進階玩家**\n" +
                    "使用本機自訂檔：<ModsData/ConfigXML/Config.xml>\n" +
                    "來取代模組提供的預設。\n" +

                    "<步驟>\n" +
                    "點擊 **[開啟 Config 資料夾]**\n" +
                    "• 用文字編輯器（Notepad++）編輯並儲存 **Config.xml**\n" +
                    "• 然後點擊 **[立即套用新設定]**\n\n" +
                    "• 注意：不要把員工數量設為 0。\n" +
                    "• 隨時可切回預設（檔案分開）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "開啟 Config 資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• 開啟包含 **Config.xml** 的資料夾。\n" +
                    "1. 用文字編輯器（**Notepad++**）編輯檔案。\n\n" +
                    "2. 範例路徑（Windows）：\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立即套用新設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "讀取 **Config.xml** 並將新數值套用到服務類預製體（Prefab）（例如：建築員工）。\n" +
                    "• 只對 **新建建築** 生效（不影響既有建築）。\n" +
                    "• 想看到新數值：請拆除/替換舊建築後再建。\n" +
                    "• 每次編輯並儲存 Config.xml 後，請再點一次 **立即套用新設定**。\n" +
                    "• 重新啟動遊戲也會套用你目前選擇的設定檔。\n" +
                    "• 本按鈕讀取檔案：<ModsData/ConfigXML/Config.xml>。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "把變更套用到所有 *新建* 的服務建築？\n" +
                    "確定要繼續嗎？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "重設為預設設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重新開始** 按鈕。\n\n" +
                    "**用全新的預設檔覆寫 Config.xml**（包含所有預設）。\n" +
                    "• 自訂檔損壞，或需要乾淨重設時使用。\n\n" +
                    "• 重設前請先關閉正在開啟的 Config.xml。\n" +
                    "• 會複製新檔到：<ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用預設（預設檔）覆寫 ModsData/ConfigXML/Config.xml？\n\n" +
                    "新檔會取代舊檔。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<推薦> 使用預設值（員工 ↑↑）- 完成，開始玩 :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**選項 2 - 進階玩家**\n" +
                    "<[使用自訂檔案]> 來自訂設定。\n\n" +
                    "1. 點擊 <[開啟 Config 資料夾]>\n" +
                    "2. <編輯並儲存 **Config.xml**>\n" +
                    "3. 點擊 <[立即套用新設定]>\n" +
                    "4. 可重複 1-3，不用重啟。\n\n" +
                    "<--------------------------->\n" +
                    "從舊版模組遷移：\n" +
                    "• 若之前存在 </RealCity/Config.xml>，會複製到新的 <ModsData/ConfigXML/Config.xml>。\n" +
                    "• 請查看 Logs/ConfigXML.log 以確認\n" +
                    "• 想忽略舊檔：刪除 RealCity 資料夾（可選）→ 啟動遊戲 →\n" +
                    "• 然後使用 <[重設為預設設定]> 取得最新版預設檔。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模組的顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "目前版本號。" },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "開啟作者的 **Paradox Mods** 頁面。"
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "將預製體狀態寫入日誌" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "進階玩家\n" +
                    "• **一次性檢查**：把 Config.xml 內每個預製體（Prefab）的狀態寫入日誌（正常/缺失）。\n" +
                    "• 遊戲更新後很實用：看看哪些條目已不再匹配。\n" +
                    "• 未購買的 DLC 建築出現相關警告屬正常情況，可忽略。\n\n" +
                    "• 日誌檔：<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "重設為預設（產生新 Config.xml）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**與「操作」頁相同** 的重設按鈕。\n" +
                    "**用預設檔覆寫 Config.xml**。\n" +
                    "• 檔案壞掉 / 想重來 / 想取得新版本預設檔（部分更新會新增建築）時使用。\n" +
                    "• 重設後檔案位置：<ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用預設檔覆寫 <ModsData/ConfigXML/Config.xml>？\n" +
                    "你的自訂修改會被取代。"
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "詳細日誌（啟用前先讀右側警告）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<不要在正常遊戲中使用。>\n" +
                    "• 詳細日誌會拖慢遊戲並產生很大的日誌檔。\n" +
                    "• 僅用於 **暫時除錯**（建議只開幾分鐘）。\n" +
                    "• <如果你不清楚這是什麼，建議保持關閉。>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
