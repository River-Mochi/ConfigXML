// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese zh-Hant for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "選一個" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 怎麼用" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推薦預設" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**快速開始** - 一鍵套用內建 **預設**。\n" +
                    "簡單模式：按一下就搞定！\n\n" +
                    "• 大多數玩家用這個就行——精選調整（例如：員工/薪資）。\n\n" +
                    "• 隨時可在 <預設> 與 <自訂檔案> 之間切換。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自訂檔案" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**進階玩家**\n" +
                    "使用自訂檔案：<ModsData/ConfigXML/Config.xml>\n" +
                    "取代本 mod 的預設。\n\n" +
                    "<步驟>\n" +
                    "點 **[開啟 CONFIG 資料夾]**\n" +
                    "• 編輯並儲存 **Config.xml**（Notepad++）\n" +
                    "• 然後點 **[立刻套用新 CONFIG]**\n\n" +
                    "• 注意：別把員工設成 0。\n" +
                    "• 隨時可切回預設（獨立檔案）。"
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "開啟 CONFIG 資料夾" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• 開啟包含 **Config.xml** 的資料夾。\n" +
                    "1. 用文字編輯器修改（**Notepad++**）。\n\n" +
                    "2. 範例路徑（Windows）：\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立刻套用新 CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "讀取 **Config.xml** 並把新數值套用到服務 prefab（例如：建築員工）\n" +
                    "• 只對**新建建築**生效（現有的不變）。\n" +
                    "• 想看到新數值就重建/替換建築。\n" +
                    "• 重新啟動也會套用你選的 config 檔。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "要把變更套用到任何*新建*服務建築嗎？\n確定？"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "重設為預設 config" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重新開始** 按鈕。\n\n" +
                    "**用全新的預設檔覆蓋 Config.xml**（包含預設）。\n" +
                    "• 自訂檔壞掉或想清空重來就用它。\n\n" +
                    "• Reset 前先關掉正在開著的 Config.xml。\n" +
                    "• 複製到：<ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用預設（預設集）檔覆蓋 <ModsData/ConfigXML/Config.xml>？\n\n新檔案會取代現有檔案。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<推薦> 預設就好 - 開玩 :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**選項 2 - 進階玩家**\n" +
                    "<[使用自訂檔案]> 來做你自己的設定。\n\n" +
                    "1. 點 <[開啟 CONFIG 資料夾]>\n" +
                    "2. <編輯 + 儲存 **Config.xml**>。\n" +
                    "3. 點 <[立刻套用新 CONFIG]>\n" +
                    "4. 不用重啟，重複 1-3 即可。\n\n" +
                    "<--------------------------->\n" +
                    "從舊 mod 遷移：\n" +
                    "• 舊 </RealCity/Config.xml>（若存在）已複製到 <ModsData/ConfigXML/Config.xml>。\n" +
                    "• 去 Logs/ConfigXML.log 看有沒有成功。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模組的顯示名稱。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "目前版本號。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "開啟作者的 **Paradox Mods** 模組頁面。"
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "輸出 Prefab 狀態（1次）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**進階玩家**\n" +
                    "• 一次性檢查：記錄 Config.xml 內每個 prefab 是 OK 或 Missing。\n" +
                    "• 更新補丁後用來看哪些條目不再匹配。\n" +
                    "• 沒買的 DLC 導致 Missing 很正常。\n\n" +
                    "• 輸出檔：<ModsData/ConfigXML/PrefabStatus_PRESETS.txt> 或 <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "輸出元件欄位（1次）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "一次性輸出 Config.xml 列出的 prefab 的 prefab + component 欄位。\n" +
                    "輸出：<ModsData/ConfigXML/ComponentFields_PRESETS.txt> 或 <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "警告：會輸出很大的檔案。\n\n位置：<ModsData/ConfigXML/ComponentFields_PRESETS.txt> 或 <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "重設為預設（重建 Config.xml）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "和「操作」分頁的 Reset **同一個**按鈕。\n" +
                    "**用預設檔覆蓋 Config.xml**。\n" +
                    "• 檔案：<ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用預設檔覆蓋 <ModsData/ConfigXML/Config.xml>？\n任何自訂修改都會被取代。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "詳細日誌（僅除錯）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<一般遊玩不要開。>\n" +
                    "• 可能讓遊戲變慢，還會產生很大的檔案。\n" +
                    "• 只在除錯時短時間開啟。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
