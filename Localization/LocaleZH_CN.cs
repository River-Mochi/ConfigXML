// LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) City Services Redux.

namespace RealCity
{
    using System.Collections.Generic;
    using Colossal;

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

            // Show "City Services Redux 0.5.0" title
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " " + Mod.ModVersion;
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "调试" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "选项 - 二选一" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "如何使用 Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模组"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)),
                    "此模组的名称。"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)),
                    "当前版本号。"
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "推荐预设（PRESETS）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**快速开始** —— 一键应用推荐设置。\n" +
                    "简单模式：点一次就完成！\n\n" +
                    "推荐给大多数玩家：已为你手工调整了许多参数，" +
                    "例如不同于原版的工作人员数量 / 工资等。"
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "使用自定义 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**高级玩家**\n" +
                    "启用后，将使用本地自定义文件 <ModsData/RealCity/Config.xml>，而不是模组自带预设。\n" +
                    "• 适合想要针对不同存档或不同电脑设置不同服务参数的玩家。\n\n" +
                    "**提示**\n" +
                    "点击“OPEN Config folder”按钮。\n" +
                    "• 打开 ModsData/RealCity 中的 Config.xml 所在位置，然后你可以调整工作人员数量等字段。\n" +
                    "• **不要**把工作岗位设置为 0；如需极少人员，请使用一个很小的正数。\n" +
                    "• 修改完成后保存文件，然后点击 **APPLY** 按钮将更改应用到模组。\n\n" +
                    "只有当你把配置搞坏了或想完全重置时，才使用 <Restore new> 来获取一个全新的 Config.xml（会覆盖现有文件）。\n" +
                    "你可以随时切回 **[Use PRESETS]**。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)),
                    "打开 Config 文件夹"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "不是必需的——只有在你打算修改模组默认预设时才需要。\n" +
                    "• 打开包含 **Config.xml** 的 <ModsData/RealCity/> 文件夹。\n" +
                    "1. 用你喜欢的文本编辑器（例如 <Notepad++>）编辑该文件。\n\n" +
                    "2. 示例路径（Windows）：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "立即应用新的配置"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取本地 <ModsData/RealCity/Config.xml>，并将新的数值应用到城市服务建筑的 prefab 上" +
                    "（工作岗位、处理速度等）。\n\n" +
                    "• 只对**新建的建筑**生效，不影响现有建筑。\n" +
                    "• 在已有城市中，删除旧建筑并重新放置一个新建筑即可看到变化。\n" +
                    "• 如果你已经满意当前配置，只需要加载城市即可。\n" +
                    "   只有在你再次修改 Config.xml 后，才需要再次点击 **Apply New**。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "将把你的自定义更改应用到大量城市服务建筑。\n" +
                    "确定要继续吗？"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "“重新开始”按钮\n\n" +
                    "使用模组自带预设的新副本覆盖 **ModsData/RealCity/Config.xml**。\n" +
                    "• 仅在你的自定义文件损坏，或想彻底重来时使用。\n\n" +
                    "• “Restore new” 会替换现有文件——请先在编辑器中关闭原来的 Config.xml。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "要用原始文件覆盖 ModsData/RealCity/Config.xml 吗？\n\n" +
                    "你对该文件做的自定义更改都会被新的副本替换。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "方案 1\n" +
                    "选择 <[Use PRESETS]>（推荐），使用内置预设。\n" +
                    "如果选择 PRESETS，就已经完成——直接开始游戏。\n\n" +
                    "<--------------------------->\n\n" +
                    "方案 2 - 高级玩家\n" +
                    "选择 <[Use CUSTOM Config.xml]> 自己编辑参数。\n\n" +
                    "1. 点击 <[OPEN Config folder]>。\n" +
                    "2. 使用文本编辑器打开、编辑并保存 <Config.xml>。\n" +
                    "3. 然后点击 <[APPLY NEW Configuration Now]>。\n" +
                    "4. <加载城市>（或重新加载），就能在**新建建筑**上看到变化。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)),
                    " "
                },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "详细日志（高级）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "在日志文件中写入大量额外信息。\n" +
                    "普通游戏时 <不建议> 启用。\n" +
                    "大量日志会拖慢游戏并生成很大的日志文件。\n" +
                    "只在需要收集数据或调试问题时临时开启。"
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "将 prefab 状态写入日志"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**高级玩家**\n" +
                    "检查 Config.xml 中列出的每个 prefab，并记录它是正常还是缺失。\n" +
                    "• 游戏更新后使用，可查看哪些 Config.xml 条目不再匹配游戏。\n" +
                    "• 对于你没有购买的 DLC 建筑，对应 prefab 缺失警告是正常的，可以忽略。"
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开 **Paradox Mods** 上的 City Services Redux 页面以及你的其他模组。"
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "与“操作”选项卡中的按钮相同：用预设的新副本覆盖 <ModsData/RealCity/Config.xml>。\n" +
                    "当自定义文件损坏或你想重新开始时使用。"
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "要用模组预设的原始文件覆盖 <ModsData/RealCity/Config.xml> 吗？\n\n" +
                    "你之前的所有自定义更改都会被新文件替换。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
