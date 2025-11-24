// LocaleZH_CN.cs
// Simplified chinese zh-HANS City Services Redux.

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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "选项 – 选择一种" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "如何使用 Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "本模组的显示名称。"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "当前版本号。"
                },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)),
                    "推荐预设"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**快速开始** – 一键应用所有推荐预设。\n" +
                    "简单模式：点一次就能开玩！\n\n" +
                    "推荐给大多数玩家 – 已经手工调整了很多参数，例如员工数量、工资等，" +
                    "和游戏默认值不一样。"
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "使用自定义 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**高级玩家**\n" +
                    "启用后将使用本地 <ModsData/RealCity/Config.xml>，而不是内置预设。\n" +
                    "• 适合想按存档或按电脑分别调整服务参数的玩家。\n\n" +
                    "**提示**\n" +
                    "点击“打开 Config 文件夹”按钮。\n" +
                    "• 打开 ModsData/RealCity 中的 Config.xml，你可以在里面修改员工数量等字段。\n" +
                    "• **不要**把工作岗位设为 0；如果想要很少的人手，请使用小的正数。\n" +
                    "• 保存后，点击 **立即应用新配置** 按钮，让模组加载新参数。\n\n" +
                    "只有在文件损坏或想完全重新开始时，才使用 <恢复新的 Config.xml>，这会覆盖现有文件。\n" +
                    "你可以随时切回 **推荐预设**。"
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
                    "非必需操作 – 仅当你要修改模组预设时使用。\n" +
                    "• 打开 <ModsData/RealCity/> 文件夹，其中包含 **Config.xml**。\n" +
                    "1. 用你喜欢的文本编辑器编辑（例如 <Notepad++>）。\n\n" +
                    "2. 示例路径（Windows）：\n" +
                    "C:/Users/你的用户名/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "立即应用新配置"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取本地 <ModsData/RealCity/Config.xml>，并将新数值应用到城市服务建筑 " +
                    "（工作岗位、处理量等）。\n\n" +
                    "• 只影响**新建建筑**，不会改变已经存在的建筑。\n" +
                    "• 在已有城市中，请拆除旧建筑并重新放置，以看到变化。\n" +
                    "• 如果你对设置满意，只需加载城市即可。\n" +
                    "   只有在再次修改 Config.xml 之后，才需要重新点击 **立即应用新配置**。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "将新的自定义配置应用到大量城市服务建筑。\n" +
                    "确定要继续吗？"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "【重新开始】按钮\n\n" +
                    "用模组自带的预设覆盖 **ModsData/RealCity/Config.xml**，生成一份全新的 Config.xml。\n" +
                    "• 仅在你的自定义文件损坏或想完全重置时使用。\n\n" +
                    "• “恢复新的 Config.xml” 会替换现有文件 – 使用前请先在编辑器中关闭这个文件。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "要用原始文件覆盖 ModsData/RealCity/Config.xml 吗？\n\n" +
                    "你之前做的所有自定义更改都会丢失。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "方式 1\n" +
                    "选择 <[推荐预设]> 使用模组自带的预设设置。\n" +
                    "如果选择推荐预设，就可以直接开始游戏。\n\n" +
                    "<--------------------------->\n\n" +
                    "方式 2 – 高级玩家\n" +
                    "选择 <[使用自定义 Config.xml]>，自己调整参数。\n\n" +
                    "1. 点击 <[打开 Config 文件夹]>。\n" +
                    "2. 用你喜欢的文本编辑器打开、编辑并保存 <Config.xml>。\n" +
                    "3. 然后点击 <[立即应用新配置]>。\n" +
                    "4. <加载城市>（或重新加载），即可在**新建建筑**上看到变化。"
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
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "详细日志（高级）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "向日志文件写入大量额外信息。\n" +
                    "普通游戏中 <不推荐> 启用。\n" +
                    "过多日志会拖慢游戏，并生成很大的日志文件。\n" +
                    "只在收集数据或排查问题时短暂开启。"
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "将 Prefab 状态写入日志"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**高级玩家**\n" +
                    "检查 Config.xml 中的每个 Prefab，并在日志中标记为 OK 或 MISSING。\n" +
                    "• 在游戏打补丁后使用，可以看到哪些 Config.xml 条目已不再匹配游戏。\n" +
                    "• 对于你没购入的 DLC 建筑 Prefab，出现缺失警告是正常的。"
                },

                // Paradox Mods button (Debug tab, Info group)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开 **Paradox Mods** 页面，查看 City Services Redux 和你的其他模组。"
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "与“操作”页中的按钮相同：用新的预设文件覆盖 <ModsData/RealCity/Config.xml>。\n" +
                    "当文件损坏或想重置时使用。"
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用原始预设文件覆盖 <ModsData/RealCity/Config.xml>？\n\n" +
                    "所有自定义改动都会被新的文件替换。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
