// LocaleJA.cs
// Japanese ja-JP for Config-XML.

namespace ConfigXML
{
    using Colossal;
    using System.Collections.Generic;

    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "デバッグ" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "オプション（どちらか選択）" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml の使い方" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },  // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "このModの表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "現在のバージョン番号。" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                // UseModPresets
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "推奨プリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**クイックスタート** - 推奨プリセットを一括適用\n" +
                    "EASYモード：1クリックで完了！\n\n" +

                    "ほとんどのプレイヤーにおすすめ。作業員数や賃金など、ゲーム標準とは異なる調整が含まれています。"
                },

                // UseLocalConfig
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "カスタムファイルを使用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**上級者向け**\n" +
                    "有効にすると、内蔵プリセットの代わりに <ModsData/ConfigXML/Config.xml> を使用します。\n" +
                    "• セーブごと、またはPCごとに異なるサービス設定を使いたい人向け。\n\n" +
                    "**ヒント**\n" +
                    "「Configフォルダを開く」をクリック\n" +
                    "• ModsData/ConfigXML 内の Config.xml を編集して、作業員数などを調整します。\n" +
                    "• 作業員数を 0 に設定しないでください。必要なら小さい正の値を使ってください。\n" +
                    "• 編集後は保存し、**APPLY** ボタンで反映します。\n\n" +
                    "<Reset new> は設定を壊した場合や、完全に新しくやり直したい場合のみ使用してください。\n" +
                    "いつでも **PRESETS** に戻せます。"
                },

                // -----------------------------
                // Actions tab: Buttons (local custom only)
                // -----------------------------

                // OpenConfigFile button (now: folder)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "Configフォルダを開く" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "通常は不要です。プリセットを変更したい場合のみ使用してください。\n" +
                    "• **Config.xml** が入っている <ModsData/ConfigXML/> フォルダを開きます。\n" +
                    "1. テキストエディタ（例：<Notepad++>）で編集します。\n\n" +
                    "2. 開かれるパス例（Windows）：\n" +
                    "C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml"
                },

                // ApplyConfiguration button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)),
                    "新しいConfigを適用"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "ローカルの <ModsData/ConfigXML/Config.xml> を読み込み、サービス建物に反映します。" +
                    "• **新しく建てた建物のみ** に適用されます。\n" +
                    "• 既存の都市では、建物を削除して建て直してください。\n" +
                    "• 設定に満足していれば、そのまま都市をロードするだけでOK。\n" +
                    "   Config.xml を変更したときだけ **Apply New** を押してください。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "多くのサービス建物に変更を適用します。\n" +
                    "本当によろしいですか？"
                },

                // ResetLocalConfig (Actions tab)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)),
                    "Config.xml を初期化"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "最初からやり直す\n\n" +
                    "カスタムの **ModsData/ConfigXML/Config.xml** を、元のプリセットで上書きします。\n" +
                    "• ファイルが壊れた場合や、最初からやり直したい時のみ使用してください。\n\n" +
                    "• 既存ファイルは置き換えられます。事前にConfig.xmlを閉じてください。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "ModsData/ConfigXML/Config.xml を初期ファイルで上書きしますか？\n\n" +
                    "現在のカスタム内容はすべて失われます。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ConfigUsageSteps)),
                    "方法 1\n" +
                    "<[推奨プリセット]> を選択。\n" +
                    "これだけで完了、すぐプレイ可能。\n\n" +
                    "<--------------------------->\n\n" +
                    "方法 2 - 上級者\n" +
                    "<[カスタムファイルを使用]> を選択。\n\n" +
                    "1. <[Configフォルダを開く]>\n" +
                    "2. <Config.xml> を編集・保存。\n" +
                    "3. <[APPLY 新しいConfig]> をクリック。\n" +
                    "4. <都市をロード> して <新しい> 建物を確認。\n" +
                    "5. 再起動なしで何度でも繰り返せます。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ConfigUsageSteps)), " " },

                // -----------------------------------
                // Debug tab: logging + status + reset
                // -----------------------------------

                // Logging (strong warning about performance)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Logging)), "詳細ログ（使用前に警告を読んでください）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Logging)),
                    "大量のログを書き出します。\n" +
                    "<通常プレイでは使用しないでください>\n" +
                    "ゲームが遅くなり、ログファイルが大きくなります。\n" +
                    "デバッグや調査時のみ **一時的に** 有効にしてください。\n" +
                    "<内容が分からない場合は、無効のままにしてください。>"
                },

                // DumpPrefabStatus button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "プレハブ状態をログに出力"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**上級者向け**\n" +
                    "Config.xml に記載されたすべてのプレハブを確認し、状態をログに出力します。\n" +
                    "• パッチ後に一致しない項目を確認するために使用します。\n" +
                    "• 所有していないDLCの警告は無視して問題ありません。"
                },

                // Paradox Mods button (Debug tab, Info group)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "**Config-XML** の Paradox Mods ページを開きます。"
                },

                // Debug tab duplicate reset button
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "新しいConfig.xmlにリセット"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "Actionsタブと同じ機能です。\n" +
                    "カスタム <ModsData/ConfigXML/Config.xml> を初期プリセットで上書きします。"
                },
                // Warning Prompt
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> を初期プリセットで上書きしますか？\n\n" +
                    "すべてのカスタム設定が置き換えられます。"
                },
            };
        }
        public void Unload()
        {
        }
    }
}
