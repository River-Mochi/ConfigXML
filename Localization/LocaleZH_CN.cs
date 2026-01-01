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
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "二选一" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml 使用说明" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "调试" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推荐预设" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**推荐** - 使用模组内置 **预设**。\n" +
                    "简单模式（EASY）：一键搞定！\n\n" +
                    "• 适合大多数玩家：提高建筑员工数量。\n" +
                    "• 可随时在 <预设> 与 <自定义文件> 之间切换。\n" +
                    "  （预设文件与 ModsData 自定义文件互不影响、彼此独立。）"
                },

                // UseLocalConfig
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "使用自定义文件" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**高级用户**\n" +
                    "使用本地自定义文件：<ModsData/ConfigXML/Config.xml>\n" +
                    "来替代模组自带预设。\n" +

                    "<步骤>\n" +
                    "点击 **[打开 Config 文件夹]**\n" +
                    "• 用文本编辑器（Notepad++）编辑并保存 **Config.xml**\n" +
                    "• 然后点击 **[立即应用新配置]**\n\n" +
                    "• 注意：不要把员工数量设为 0。\n" +
                    "• 随时可切回默认预设（文件分开）。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "打开 Config 文件夹" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• 打开包含 **Config.xml** 的文件夹。\n" +
                    "1. 用文本编辑器（**Notepad++**）编辑文件。\n\n" +
                    "2. 示例路径（Windows）：\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                // ApplyConfiguration button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "立即应用新配置" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取 **Config.xml** 并将新数值应用到服务类预制体（Prefab）（例如：建筑员工数量）。\n" +
                    "• 只对 **新建建筑** 生效（不影响已存在建筑）。\n" +
                    "• 想看到新数值：请拆除/替换旧建筑后再建。\n" +
                    "• 每次编辑并保存 Config.xml 后，请再点一次 **立即应用新配置**。\n" +
                    "• 重启游戏也会按你当前选择的配置文件生效。\n" +
                    "• 本按钮读取文件：<ModsData/ConfigXML/Config.xml>。"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "将更改应用到所有 *新建* 的服务建筑？\n" +
                    "确定要继续吗？"
                },

                // ResetLocalConfig (Actions tab)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "重置为默认配置" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**重新开始** 按钮。\n\n" +
                    "**用全新默认文件覆盖 Config.xml**（包含所有预设）。\n" +
                    "• 自定义文件损坏，或需要干净重置时使用。\n\n" +
                    "• 重置前请关闭正在打开的 Config.xml。\n" +
                    "• 会复制新文件到：<ModsData/ConfigXML/Config.xml>"
                },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用默认（预设）文件覆盖 ModsData/ConfigXML/Config.xml？\n\n" +
                    "新文件会替换旧文件。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)),
                    "<推荐> 使用默认值（员工 ↑↑）- 完成，开始玩 :)"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**选项 2 - 高级用户**\n" +
                    "<[使用自定义文件]> 来自定义设置。\n\n" +
                    "1. 点击 <[打开 Config 文件夹]>\n" +
                    "2. <编辑并保存 **Config.xml**>\n" +
                    "3. 点击 <[立即应用新配置]>\n" +
                    "4. 可重复 1-3，无需重启。\n\n" +
                    "<--------------------------->\n" +
                    "从旧版模组迁移：\n" +
                    "• 如果以前存在 </RealCity/Config.xml>，会复制到新的 <ModsData/ConfigXML/Config.xml>。\n" +
                    "• 查看 Logs/ConfigXML.log 以确认\n" +
                    "• 想忽略旧文件：删除 RealCity 文件夹（可选）→ 启动游戏 →\n" +
                    "• 然后使用 <[重置为默认配置]> 获取最新版默认文件。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模组的显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "当前版本号。" },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开作者的 **Paradox Mods** 页面。"
                },

                // --------------------------------------
                // Debug tab: status, reset, VerboseLogs
                // --------------------------------------

                // DumpPrefabStatus button
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "将预制体状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "高级用户\n" +
                    "• **一次性检查**：将 Config.xml 里每个预制体（Prefab）的状态写入日志（正常/缺失）。\n" +
                    "• 游戏更新后很有用：看看哪些条目不再匹配。\n" +
                    "• 没有购买的 DLC 建筑出现相关警告属于正常情况，可忽略。\n\n" +
                    "• 日志文件：<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/Logs/ConfigXML.log>"
                },

                // Debug tab reset button (duplicate)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "重置为默认（生成新 Config.xml）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "**与“操作”页相同** 的重置按钮。\n" +
                    "**用默认文件覆盖 Config.xml**。\n" +
                    "• 文件损坏 / 想重新开始 / 想获取新版本默认文件（部分更新会新增建筑）时使用。\n" +
                    "• 重置后文件位置：<ModsData/ConfigXML/Config.xml>"
                },
                // Warning Prompt
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用默认文件覆盖 <ModsData/ConfigXML/Config.xml>？\n" +
                    "你的自定义修改会被替换。"
                },

                // VerboseLogs (strong warning about performance)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)),
                    "详细日志（启用前先读右侧警告）"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<不要在正常游戏中使用。>\n" +
                    "• 详细日志会拖慢游戏并产生很大的日志文件。\n" +
                    "• 仅用于 **临时排查**（建议只开几分钟）。\n" +
                    "• <如果你不清楚这是什么，建议保持关闭。>"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
