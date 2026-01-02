// File: Localization/LocaleZH_CN.cs
// Simplified Chinese zh-CN for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

    public class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "调试" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "选一个" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 怎么用" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推荐预设" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**快速开始** - 一键应用内置 **预设**。\n" +
                    "简单模式：点一下就搞定！\n\n" +
                    "• 大多数玩家用这个就行——精选调整（比如：员工/工资）。\n\n" +
                    "• 随时可在 <预设> 和 <自定义文件> 之间切换。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自定义文件" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**进阶玩家**\n" +
                    "使用自定义文件：<ModsData/ConfigXML/Config.xml>\n" +
                    "替代本 mod 的预设。\n\n" +
                    "<步骤>\n" +
                    "点击 **[打开 CONFIG 文件夹]**\n" +
                    "• 编辑并保存 **Config.xml**（Notepad++）\n" +
                    "• 然后点 **[立即应用新 CONFIG]**\n\n" +
                    "• 注意：别把员工设成 0。\n" +
                    "• 随时可切回预设（单独文件）。"
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "打开 CONFIG 文件夹" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• 打开包含 **Config.xml** 的文件夹。\n" +
                    "1. 用文本编辑器修改（**Notepad++**）。\n\n" +
                    "2. 示例路径（Windows）：\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立即应用新 CONFIG" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取 **Config.xml** 并把新数值应用到服务 prefab（比如：建筑员工）\n" +
                    "• 只对**新建建筑**生效（现有的不变）。\n" +
                    "• 想看到新数值就重建/替换建筑。\n" +
                    "• 重启也会应用你选的 config 文件。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "要把改动应用到任何*新建*服务建筑吗？\n确定？"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "重置为默认 config" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重新开始** 按钮。\n\n" +
                    "**用全新默认文件覆盖 Config.xml**（包含预设）。\n" +
                    "• 自定义文件损坏或想清空重来就用它。\n\n" +
                    "• Reset 前先关闭正在打开的 Config.xml。\n" +
                    "• 复制到：<ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用默认（预设）文件覆盖 <ModsData/ConfigXML/Config.xml>？\n\n新文件会替换现有文件。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<推荐> 默认就行 - 开玩 :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**选项 2 - 进阶玩家**\n" +
                    "<[使用自定义文件]> 来做你自己的设置。\n\n" +
                    "1. 点击 <[打开 CONFIG 文件夹]>\n" +
                    "2. <编辑 + 保存 **Config.xml**>。\n" +
                    "3. 点击 <[立即应用新 CONFIG]>\n" +
                    "4. 不用重启，重复 1-3 即可。\n\n" +
                    "<--------------------------->\n" +
                    "从旧 mod 迁移：\n" +
                    "• 旧 </RealCity/Config.xml>（如存在）已复制到 <ModsData/ConfigXML/Config.xml>。\n" +
                    "• 去 Logs/ConfigXML.log 看是否成功。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模组的显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "当前版本号。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开作者的 **Paradox Mods** 模组页面。"
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "导出 Prefab 状态（1次）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**进阶玩家**\n" +
                    "• 一次性检查：记录 Config.xml 里每个 prefab 是 OK 还是 Missing。\n" +
                    "• 补丁后用来看看哪些条目不匹配了。\n" +
                    "• 没买的 DLC 导致 Missing 很正常。\n\n" +
                    "• 输出文件：<ModsData/ConfigXML/PrefabStatus_PRESETS.txt> 或 <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "导出组件字段（1次）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "一次性导出 Config.xml 列出的 prefab 的 prefab + component 字段。\n" +
                    "输出：<ModsData/ConfigXML/ComponentFields_PRESETS.txt> 或 <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "警告：会生成很大的文件。\n\n位置：<ModsData/ConfigXML/ComponentFields_PRESETS.txt> 或 <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "重置为默认（重新生成 Config.xml）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "和“操作”页的 Reset **同一个**按钮。\n" +
                    "**用默认文件覆盖 Config.xml**。\n" +
                    "• 文件：<ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用默认文件覆盖 <ModsData/ConfigXML/Config.xml>？\n任何自定义修改都会被替换。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "详细日志（仅调试）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<正常游玩不要开。>\n" +
                    "• 可能拖慢游戏并生成很大的日志文件。\n" +
                    "• 只在调试时短时间开启。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
