// LocaleZH_HANT.cs
// Traditional Chinese zh-Hant for Config-XML.

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
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "除錯" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "選項（擇一）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 使用方式" },
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
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推薦預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**快速開始** - 套用所有推薦預設\n" +
                    "簡單模式：一鍵完成！\n\n" +

                    "適合大多數玩家，已包含精選調整（如工人數量、薪資等）。"
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自訂檔案" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**進階玩家**\n" +
                    "啟用後，將使用 <ModsData/ConfigXML/Config.xml> 取代內建預設。\n" +
                    "• 適合想要為不同存檔或電腦使用不同服務設定的玩家。\n\n" +
                    "**提示**\n" +
                    "點擊「開啟 Config 資料夾」\n" +
                    "• 編輯 ModsData/ConfigXML 中的 Config.xml 以調整工人數或其他欄位。\n" +
                    "• **不要** 將工人數設為 0；需要低人力時請使用小的正數。\n" +
                    "• 修改後請儲存，並點擊 **APPLY** 套用變更。\n\n" +
                    "只有在檔案損壞或想完全重來時才使用 <Reset new>。\n" +
                    "隨時可以切回 **PRESETS**。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "開啟 Config 資料夾" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "一般情況不需要使用，只有在要修改預設時才用。\n" +
                    "• 會開啟包含 **Config.xml** 的 <ModsData/ConfigXML/> 資料夾。\n" +
                    "1. 使用文字編輯器（例如 <Notepad++>）編輯。\n\n" +
                    "2. 開啟的路徑範例（Windows）：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "立即套用新 Config"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "讀取本機的 <ModsData/ConfigXML/Config.xml>，並套用到服務建築。" +
                    "• 只會影響 **新建築**。\n" +
                    "• 現有城市需刪除並重建建築。\n" +
                    "• 如果設定沒問題，直接載入城市即可。\n" +
                    "   只有在再次修改 Config.xml 時才需要點擊 **Apply New**。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "將套用變更到多個服務建築。\n" +
                    "確定要繼續嗎？"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "重設 Config.xml 為預設"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "重新開始\n\n" +
                    "使用原始模組預設，覆蓋任何自訂的 **ModsData/ConfigXML/Config.xml**。\n" +
                    "• 僅在檔案損壞或想重新開始時使用。\n\n" +
                    "• 此操作會取代現有檔案，請先關閉 Config.xml。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "要用預設檔案覆蓋 ModsData/ConfigXML/Config.xml 嗎？\n\n" +
                    "所有自訂內容將被取代。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "方式 1\n" +
                    "選擇 <[推薦預設]>。\n" +
                    "完成，直接遊戲。\n\n" +
                    "<--------------------------->\n\n" +
                    "方式 2 - 進階玩家\n" +
                    "選擇 <[使用自訂檔案]>。\n\n" +
                    "1. 點擊 <[開啟 Config 資料夾]>\n" +
                    "2. 編輯並儲存 <Config.xml>。\n" +
                    "3. 點擊 <[APPLY 新 Config]>。\n" +
                    "4. <載入城市> 查看 <新> 建築的變化。\n" +
                    "5. 點擊 <APPLY NEW> 可無需重啟重複操作。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "詳細記錄（使用前請閱讀警告）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "會寫入大量額外記錄。\n" +
                    "<一般遊戲時請勿使用>\n" +
                    "可能降低效能並產生大型記錄檔。\n" +
                    "僅在除錯或收集資料時 **暫時** 啟用。\n" +
                    "<若不清楚用途，請保持關閉。>"
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "輸出預製物件狀態到記錄"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**進階玩家**\n" +
                    "檢查 Config.xml 中的所有預製物件，並將結果寫入記錄。\n" +
                    "• 遊戲更新後可用來檢查不再匹配的項目。\n" +
                    "• 未擁有的 DLC 項目警告可忽略。"
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "開啟 **Config-XML** 的 Paradox Mods 網頁。"
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "重設新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "與操作頁籤相同功能。\n" +
                    "用原始模組預設覆蓋本機 <ModsData/ConfigXML/Config.xml>。"
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "要用原始模組預設覆蓋 <ModsData/ConfigXML/Config.xml> 嗎？\n\n" +
                    "所有自訂變更將被取代。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
