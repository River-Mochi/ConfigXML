// Localization/LocaleZH_CN.cs
// Simplified Chinese zh-HANS for Config-XML.

namespace ConfigXML
{
    using Colossal;
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "选项 - 选一个" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "如何使用 Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模组的显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "当前版本号。" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "快速开始预设" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "<快速开始> - 自动应用内置预设。\n" +
                    "简单模式：一键搞定！\n\n" +
                    "推荐大多数玩家使用。\n" +
                    "提高员工数量（以及一些小的教育要求调整）。\n" +
                    "可随时在 预设 / 自定义文件 之间切换。\n" +
                    "预设文件与 ModsData 自定义文件是分开的。"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自定义文件" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "<高级用户>\n" +
                    "使用本地自定义文件：<ModsData/ConfigXML/Config.xml>\n" +
                    "替代模组自带的预设。\n" +

                    "<提示>\n" +
                    "点击 **打开 Config 文件夹**\n" +
                    "• 用文本编辑器(Notepad++)编辑 **Config.xml**\n" +
                    "• 不要把员工设为 0（用小数值）。\n" +
                    "• 修改后：保存，然后点击 <立即应用新 config>\n\n" +
                    "<恢复默认> 会覆盖现有自定义文件。\n" +
                    "随时可切回预设（文件分开）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "打开 Config 文件夹" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "可选\n" +
                    "• 打开包含 **Config.xml** 的 <ModsData/ConfigXML/> 文件夹。\n" +
                    "1. 用你喜欢的编辑器修改（Notepad++）。\n\n" +
                    "2. 示例路径(Windows)：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立即应用新 config" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取 <ModsData/ConfigXML/Config.xml> 并把新数值应用到服务类 prefab（例如员工）\n" +
                    "• 只对 **新建建筑** 生效（不影响已有建筑）。\n" +
                    "• 老存档要替换建筑才会看到变化。\n" +
                    "• 每次编辑+保存 Config.xml 后再点一次 **应用新**。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "将更改应用到新建的服务建筑？\n " +
                    "确定吗？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "恢复默认 Config.xml" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重来** 按钮。\n\n" +
                    "用默认文件（模组预设）覆盖 **ModsData/ConfigXML/Config.xml**。\n" +
                    "• 自定义文件损坏或需要重置时使用。\n\n" +
                    "• 恢复前请先关闭正在打开的 Config.xml。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用默认(预设)文件覆盖 ModsData/ConfigXML/Config.xml？\n\n" +
                    "新文件会替换旧文件。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                //
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<选项 1 - 快速开始>\n" +
                    "选择 **[快速开始预设]**。\n" +
                    "完成 - 开玩。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "<选项 2 - 高级用户>\n" +
                    "**[使用自定义文件]** 来自定义设置。\n\n" +
                    "1. 点击 **[打开 Config 文件夹]**\n" +
                    "2. 编辑并保存 **Config.xml**（Notepad++）\n" +
                    "3. 点击 **[立即应用新 config]**\n" +
                    "4. 新建一个服务建筑查看新数值\n" +
                    "5. 不用重启：改完后点 <应用新> 即可重复 1-4\n\n" +

                    "迁移说明：\n" +
                    "如果存在 ModsData/RealCity/Config.xml，会复制到 **ModsData/ConfigXML/Config.xml**。\n" +
                    "查看 Logs/ConfigXML.log。\n" +
                    "不想用旧文件：删除 ModsData/RealCity（可选），启动游戏，然后\n" +
                    "使用 **[恢复默认]**"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: status, logging, reset
                // -----------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "输出 Prefab 状态到日志"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**高级用户**\n" +
                    "一次性检查：记录 Config.xml 里每个 prefab 是 OK 还是缺失。\n" +
                    "• 游戏更新后很有用。\n" +
                    "• 没有 DLC 的 prefab 警告可忽略 - 正常。\n" +
                    "日志文件：C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log"
                },

                // Verbos Logging (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "详细日志（先看右侧警告）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "<不建议日常游玩开启。>\n" +
                    "详细日志会拖慢游戏并产生很大的日志文件。\n" +
                    "只在排查问题时 **临时** 开启。\n" +
                    "<不懂就别开。>"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开作者的 **Paradox Mods** 页面。"
                },

                // Debug tab duplicate reset button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "恢复默认（生成新 Config.xml）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "与操作页的重置相同\n" +
                    "用默认文件覆盖 <ModsData/ConfigXML/Config.xml>\n" +
                    "文件坏了/想重来/想拿到新版本默认值时用（有些更新会增加建筑）。"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用默认文件覆盖 <ModsData/ConfigXML/Config.xml>？\n" +
                    "你的自定义修改会被替换。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
