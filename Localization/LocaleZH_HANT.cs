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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "選項 - 選一個" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 怎麼用" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模組的顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "目前版本號。" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "快速開始預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<快速開始> - 自動套用內建預設。\n" +
                    "簡單模式：一鍵搞定！\n\n" +
                    "大多數玩家推薦。\n" +
                    "提高員工數（以及一些小的教育需求調整）。\n" +
                    "隨時可在 預設 / 自訂檔案 之間切換。\n" +
                    "預設檔與 ModsData 自訂檔是分開的。"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自訂檔案" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<進階玩家>\n" +
                    "使用本機自訂檔：<ModsData/ConfigXML/Config.xml>\n" +
                    "取代模組提供的預設。\n" +

                    "<提示>\n" +
                    "點 **開啟 Config 資料夾**\n" +
                    "• 用文字編輯器(Notepad++)編輯 **Config.xml**\n" +
                    "• 不要把員工設為 0（用小數值）。\n" +
                    "• 修改後：儲存，然後點 <立刻套用新 config>\n\n" +
                    "<恢復預設> 會覆蓋目前自訂檔。\n" +
                    "想切回預設隨時都可以（檔案分開）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "開啟 Config 資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "可選\n" +
                    "• 開啟包含 **Config.xml** 的 <ModsData/ConfigXML/> 資料夾。\n" +
                    "1. 用你喜歡的編輯器修改（Notepad++）。\n\n" +
                    "2. 範例路徑（Windows）：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立刻套用新 config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "讀取 <ModsData/ConfigXML/Config.xml> 並把新數值套用到服務 prefab（例如員工）\n" +
                    "• 只對 **新建建築** 生效（不影響既有建築）。\n" +
                    "• 舊存檔需要拆掉再蓋才會看到變化。\n" +
                    "• 每次編輯+儲存 Config.xml 後，再點一次 **套用新**。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "把變更套用到新建的服務建築？\n " +
                    "確定嗎？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "恢復預設 Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重來** 按鈕。\n\n" +
                    "用預設檔（模組預設）覆蓋 **ModsData/ConfigXML/Config.xml**。\n" +
                    "• 自訂檔壞掉或想清空重設時用。\n\n" +
                    "• 恢復前先關掉正在開著的 Config.xml。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用預設(預設檔)覆蓋 ModsData/ConfigXML/Config.xml？\n\n" +
                    "新檔會取代舊檔。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<選項 1 - 快速開始>\n" +
                    "選 **[快速開始預設]**。\n" +
                    "完成 - 開玩。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<選項 2 - 進階玩家>\n" +
                    "**[使用自訂檔案]** 來做自訂設定。\n\n" +
                    "1. 點 **[開啟 Config 資料夾]**\n" +
                    "2. 編輯並儲存 **Config.xml**（Notepad++）\n" +
                    "3. 點 **[立刻套用新 config]**\n" +
                    "4. 新建一個服務建築查看新數值\n" +
                    "5. 不用重啟：改完後點 <套用新> 就能重複 1-4\n\n" +

                    "遷移說明：\n" +
                    "如果有 ModsData/RealCity/Config.xml，會複製到 **ModsData/ConfigXML/Config.xml**。\n" +
                    "查看 Logs/ConfigXML.log。\n" +
                    "不想用舊檔：刪除 ModsData/RealCity（可選），啟動遊戲，然後\n" +
                    "用 **[恢復預設]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "把 Prefab 狀態寫入日志"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**進階玩家**\n" +
                    "一次性檢查：記錄 Config.xml 裡每個 prefab 是 OK 還是缺失。\n" +
                    "• 遊戲更新後很好用。\n" +
                    "• 沒有 DLC 的 prefab 警告可忽略 - 正常。\n" +
                    "日誌檔：C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "詳細日誌（先看右側警告）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<不建議日常遊玩開啟。>\n" +
                    "詳細日誌會拖慢遊戲並產生很大的日誌檔。\n" +
                    "只在排查問題時 **臨時** 開啟。\n" +
                    "<不懂就別開。>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打開作者的 **Paradox Mods** 頁面。"
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "恢復預設（生成新 Config.xml）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "同「操作」分頁的重置\n" +
                    "用預設檔覆蓋 <ModsData/ConfigXML/Config.xml>\n" +
                    "檔案壞了/想重來/想拿到新版本預設值時用（有些更新會增加建築）。"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用預設檔覆蓋 <ModsData/ConfigXML/Config.xml>？\n" +
                    "你的自訂修改會被取代。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
