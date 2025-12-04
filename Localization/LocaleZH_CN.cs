// LocaleZH_CN.cs
// Chinese Simplified (zh-HANS) City Services Redux.

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

            // Show "City Services Redux 0.5.3" title
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
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "选项 - 请选择其一" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "如何使用 Config.xml" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "此模组在游戏中显示的名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "当前版本号。" },

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
                    "**快速开始** —— 一键应用所有推荐预设\n" +
                    "简单模式：点一次就搞定！\n\n" +
                    "推荐给大多数玩家 —— 已经为你手工调好诸如工作岗位/工资等参数，" +
                    "和游戏原版默认值不一样，更适合城市运营。"
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)),
                    "使用自定义文件"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**进阶玩家**\n" +
                    "启用后，将使用本地自定义文件 <ModsData/RealCity/Config.xml>，而不是模组自带的预设。\n" +
                    "• 适合希望按存档或按电脑区分服务设置的玩家。\n\n" +
                    "**提示**\n" +
                    "点击“打开配置文件夹”按钮。\n" +
                    "• 会打开 ModsData/RealCity 中的 Config.xml，你可以在里面调整工作岗位等字段。\n" +
                    "• **不要**把岗位设置为 0；如果想要很少的员工，请用一个很小的正数。\n" +
                    "• 修改后保存文件，然后点 **APPLY** 按钮，让模组加载新配置。\n\n" +
                    "如果文件弄坏了，或者想要一个全新的 Config.xml，可以使用 <Reset new> —— 会替换现有文件。\n" +
                    "你可以随时切回 **推荐预设**。 "
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
                    "不是必需操作 —— 只有在你想修改模组预设配置时才需要。\n" +
                    "• 打开 <ModsData/RealCity/> 文件夹，其中包含 **Config.xml**。\n" +
                    "1. 使用你喜欢的文本编辑器编辑文件（例如 <Notepad++>）。\n\n" +
                    "2. Windows 示例路径：\n" +
                    "C:/Users/你的用户名/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/RealCity/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "立即应用新配置"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "读取本地 <ModsData/RealCity/Config.xml>，并将新的数值应用到城市服务 Prefab " +
                    "（工作岗位、处理速度等）。\n\n" +
                    "• 只对**新建建筑**生效，已存在的建筑不会自动更新。\n" +
                    "• 对已有城市，拆除旧建筑并重新放置一个新的，才能看到变化。\n" +
                    "• 如果已经对配置满意，只需要正常载入城市即可。\n" +
                    "   只有在再次修改 Config.xml 时才需要点击 **应用新配置**。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "将你新的自定义设置应用到大量城市服务建筑。\n " +
                    "确认继续？"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "“重新开始”按钮\n\n" +
                    "用模组原始预设的全新副本覆盖 **ModsData/RealCity/Config.xml**。\n" +
                    "• 仅在自定义文件损坏或想从头再来时使用。\n\n" +
                    "• **Reset new** 会替换现有文件 —— 记得先在编辑器中关闭旧的 Config.xml。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "用原始文件覆盖 ModsData/RealCity/Config.xml？\n\n" +
                    "你对该文件做的所有自定义修改都会被新的副本替换。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // (only shown when UseLocalConfig is enabled)
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "方案一\n" +
                    "选择 <[推荐预设]> 使用模组自带配置。\n" +
                    "如果你选择预设，就可以直接开始游戏了。\n\n" +
                    "<--------------------------->\n\n" +
                    "方案二 —— 进阶玩家\n" +
                    "选择 <[使用自定义文件]> 编辑你自己的 Config.xml。\n\n" +
                    "1. 点击 <[打开 Config 文件夹]>。\n" +
                    "2. 使用文本编辑器（如 Notepad++）打开、编辑并保存 <Config.xml>。\n" +
                    "3. 点击 <[立即应用新配置]> —— 让模组重新加载该文件。\n" +
                    "4. <载入城市>（或重新载入）以在**新建建筑**上看到改动。\n" +
                    "5. 在不重启游戏的情况下，你可以重复步骤 1–4，只要每次修改后都点击 <APPLY>。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)),
                    "详细日志（使用前先看右侧警告）"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "向日志文件写入大量额外信息。\n" +
                    "普通游玩时<请勿开启>。\n" +
                    "过多日志会拖慢游戏并产生非常大的日志文件。\n" +
                    "只在需要收集数据或调试问题时短暂开启。\n" +
                    "如果你不确定它是做什么的，最好保持关闭。"
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "导出 Prefab 状态到日志"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**进阶玩家**\n" +
                    "检查 Config.xml 中列出的每一个 Prefab，并记录其状态是 OK 还是缺失。\n" +
                    "• 游戏更新后使用它，可以查看 Config.xml 中哪些条目已不再匹配游戏。\n" +
                    "• 对于你没有购买的 DLC 建筑，Prefab 缺失的警告是正常的，可以忽略。"
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "打开 **Paradox Mods** 页面，查看 City Services Redux 和其他模组。"
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "恢复新的 Config.xml"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "和“操作”选项卡里的按钮相同：用模组原始预设的全新副本覆盖 <ModsData/RealCity/Config.xml>。\n" +
                    "当你的自定义文件坏掉，或者只想重置配置时使用。"
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "用模组原始预设文件覆盖 <ModsData/RealCity/Config.xml>？\n\n" +
                    "所有自定义更改都会被新文件替换。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
