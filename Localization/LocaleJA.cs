// File: Localization/LocaleJA.cs
// Japanese ja-JP for Config-XML.

namespace ConfigXML
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
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
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Tab titles
                { m_Setting.GetSettingsLocaleID(), title },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.kDebugSection), "デバッグ" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kButtonGroup), "アクション" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kToggleGroup), "どっちか選んでね" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kConfigUsageGroup), "Config.xml の使い方" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kInfoGroup), " " },   // No Info section title
                { m_Setting.GetOptionGroupLocaleID(Setting.kDebugGroup), "DEBUG" },

                // -----------------------------
                // Actions tab: Options toggles
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseModPresets)), "おすすめプリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseModPresets)),
                    "**クイックスタート** - 内蔵の **プリセット** を全部適用。\n" +
                    "EASYモード: 1クリックで完了！\n\n" +
                    "• ほとんどの人はこれでOK（例: 労働者/賃金の調整）。\n\n" +
                    "• いつでも <プリセット> と <カスタムファイル> を切り替えできます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UseLocalConfig)), "カスタムファイルを使う" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UseLocalConfig)),
                    "**上級者向け**\n" +
                    "カスタムファイル: <ModsData/ConfigXML/Config.xml>\n" +
                    "を使います（mod のプリセットではなく自分の設定）。\n\n" +
                    "<手順>\n" +
                    "**[CONFIG フォルダを開く]** をクリック\n" +
                    "• **Config.xml** を編集して保存（Notepad++）\n" +
                    "• そのあと **[新しい config を今すぐ適用]**\n\n" +
                    "• 注意: 労働者を 0 にしないでね。\n" +
                    "• いつでもプリセットに戻せます（別ファイル）。"
                },

                // -----------------------------
                // Actions tab: Buttons (custom only)
                // -----------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenConfigFile)), "CONFIG フォルダを開く" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenConfigFile)),
                    "• **Config.xml** があるフォルダを開きます。\n" +
                    "1. テキストエディタで編集（**Notepad++**）。\n\n" +
                    "2. 例のパス（Windows）:\n\n" +
                    "<C:/Users/YourName/AppData/LocalLow/Colossal Order/Cities Skylines II/ModsData/ConfigXML/Config.xml>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ApplyConfiguration)), "新しい config を今すぐ適用" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ApplyConfiguration)),
                    "**Config.xml** を読み込み、サービス系 prefab に新しい値を適用します（例: 建物の労働者）。\n" +
                    "• **新しく建てる建物** に反映（既存は変わりません）。\n" +
                    "• 新しい値を見たいなら建て替えてね。\n" +
                    "• 再起動でも選んだ config ファイルが適用されます。"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ApplyConfiguration)),
                    "*新しい* サービス建物に変更を適用する？\n本当にOK？"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfig)), "デフォルト Config にリセット" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfig)),
                    "**最初から** ボタン。\n\n" +
                    "**Config.xml を上書き** して、まっさらなデフォルトファイルに戻します（プリセット入り）。\n" +
                    "• カスタムが壊れた/きれいにリセットしたい時に。\n\n" +
                    "• Reset 前に開いてる Config.xml は閉じてね。\n" +
                    "• コピー先: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfig)),
                    "<ModsData/ConfigXML/Config.xml> をデフォルト（プリセット）ファイルで上書きする？\n\n新しいファイルは既存ファイルを置き換えます。"
                },

                // ----------------------------------
                // Actions tab: How to use Config.xml
                // ----------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PresetUsageSteps)), "<おすすめ> デフォルトでOK - あとは遊ぶだけ :)" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PresetUsageSteps)), " " },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CustomUsageSteps)),
                    "**オプション 2 - 上級者向け**\n" +
                    "<[カスタムファイルを使う]> で自分用に調整。\n\n" +
                    "1. <[CONFIG フォルダを開く]>\n" +
                    "2. <**Config.xml** を編集 + 保存>\n" +
                    "3. <[新しい config を今すぐ適用]>\n" +
                    "4. 1-3 を再起動なしで繰り返しOK。\n\n" +
                    "<--------------------------->\n" +
                    "旧modからの移行:\n" +
                    "• 旧 </RealCity/Config.xml>（あれば）は <ModsData/ConfigXML/Config.xml> にコピー済み。\n" +
                    "• 確認は Logs/ConfigXML.log を見てね。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CustomUsageSteps)), " " },

                // Debug tab: Info group
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.NameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.NameDisplay)), "このmodの表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VersionDisplay)), "現在のバージョン番号。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxModsButton)), "Paradox Mods" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxModsButton)),
                    "作者の **Paradox Mods** ページを開きます。"
                },

                // --------------------------------------
                // Debug tab: status, dumps, reset, verbose
                // --------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpPrefabStatus)), "Prefab ステータスをログに出力" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpPrefabStatus)),
                    "**上級者向け**\n" +
                    "• 1回だけチェック: Config.xml の各 prefab が OK / Missing かをログに出します。\n" +
                    "• パッチ後に、合わなくなった項目の確認に便利。\n" +
                    "• 未所持DLCの Missing は普通です。\n\n" +
                    "• 出力ファイル: <ModsData/ConfigXML/PrefabStatus_PRESETS.txt> または <PrefabStatus_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DumpComponentFields)), "コンポーネント項目をダンプ（1回）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DumpComponentFields)),
                    "Config.xml に載ってる prefab の prefab + component フィールドを1回だけ出力します。\n" +
                    "出力: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> または <ComponentFields_CUSTOM.txt>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.DumpComponentFields)),
                    "注意: 大きいファイルが出ます。\n\n場所: <ModsData/ConfigXML/ComponentFields_PRESETS.txt> または <ComponentFields_CUSTOM.txt>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetLocalConfigDebug)), "デフォルトにリセット（Config.xml再作成）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "アクションタブの Reset と**同じ**ボタン。\n" +
                    "**Config.xml をデフォルトで上書き**します。\n" +
                    "• ファイル: <ModsData/ConfigXML/Config.xml>"
                },
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetLocalConfigDebug)),
                    "<ModsData/ConfigXML/Config.xml> をデフォルトファイルで上書きする？\nカスタム変更は置き換えになります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VerboseLogs)), "詳細ログ（デバッグ用）" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.VerboseLogs)),
                    "<普段のプレイでは使わないでね。>\n" +
                    "• 重くなったりログが巨大になります。\n" +
                    "• デバッグの時だけ短時間ON。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
