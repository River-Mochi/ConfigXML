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
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "如何使用 Config.xml" },
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
                    "推薦大多數玩家。\n" +
                    "提高 workers（以及一些小的教育需求調整）。\n" +
                    "可隨時在 預設 / 自訂檔案 之間切換。\n" +
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
                    "• 用文字編輯器(Notepad++)修改 **Config.xml**\n" +
                    "• 不要把 workers 設成 0（用小數值）。\n" +
                    "• 修改後：存檔，然後點 <套用新的 config>\n\n" +
                    "<還原預設> 會覆蓋現有自訂檔。\n" +
                    "想回預設隨時都可以（檔案分開）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "開啟 Config 資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "可選\n" +
                    "• 開啟包含 **Config.xml** 的 <ModsData/ConfigXML/> 資料夾。\n" +
                    "1. 用 Notepad++ 修改。\n\n" +
                    "2. 範例路徑（Windows）：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "套用新的 config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "讀取 <ModsData/ConfigXML/Config.xml> 並把新數值套用到服務 prefab（例如 workers）\n" +
                    "• 只影響 **新建建築**（不影響已存在的）。\n" +
                    "• 舊存檔要替換建築才會看到改變。\n" +
                    "• 每次修改+存檔後再點一次 **套用**。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "將變更套用到新建的服務建築？\n " +
                    "確定嗎？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "還原預設 Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重新開始** 按鈕。\n\n" +
                    "用預設檔（模組預設）覆蓋 **ModsData/ConfigXML/Config.xml**。\n" +
                    "• 自訂檔損壞或需要重置時使用。\n\n" +
                    "• 還原前請先關閉正在開啟的 Config.xml。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用預設(預設值)檔覆蓋 ModsData/ConfigXML/Config.xml？\n\n" +
                    "新檔會取代舊檔。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // 
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<選項 1 - 快速開始>\n" +
                    "選擇 **[快速開始預設]**。\n" +
                    "完成 - 開玩。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<選項 2 - 進階玩家>\n" +
                    "**[使用自訂檔案]** 來自訂設定。\n\n" +
                    "1. 點 **[開啟 Config 資料夾]**\n" +
                    "2. 修改並存檔 **Config.xml**（Notepad++）\n" +
                    "3. 點 **[套用新的 config]**\n" +
                    "4. 新建一個服務建築來看到新數值\n" +
                    "5. 不用重啟：改完後點 <套用> 就能重複 1-4\n\n" +

                    "遷移說明：\n" +
                    "若存在 ModsData/RealCity/Config.xml，會複製到 **ModsData/ConfigXML/Config.xml**。\n" +
                    "查看 Logs/ConfigXML.log。\n" +
                    "不想用舊檔：刪除 ModsData/RealCity（可選），啟動遊戲，然後\n" +
                    "使用 **[還原預設]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------
        
                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "輸出 Prefab 狀態到日誌"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**進階玩家**\n" +
                    "一次性檢查：記錄 Config.xml 內每個 prefab 是 OK 還是缺失。\n" +
                    "• 遊戲更新後很有用。\n" +
                    "• 沒有 DLC 的 prefab 警告可忽略 - 正常。\n" +
                     "日誌：C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "詳細日誌（先看右側警告）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<不建議日常遊玩開啟。>\n" +
                    "詳細日誌可能拖慢遊戲並產生很大的檔案。\n" +
                    "只在除錯時 **暫時** 開啟。\n" +
                    "<不懂就別開。>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "開啟作者模組的 **Paradox Mods** 頁面。"
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "還原預設（建立新 Config.xml）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "同操作頁的還原\n" +
                    "用預設檔覆蓋 <ModsData/ConfigXML/Config.xml>" +
                    "檔案壞了/想重來/想拿到新版本預設值時使用（有些更新會增加建築）。"
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
