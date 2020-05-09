using System;
namespace effectiveCSharp
{
    /// <summary>
    /// カルチャ固有の文字列より、FormattableStringを使用する
    /// </summary>
    public class No05_UseFormattableStringThanCultureString
    {
        public No05_UseFormattableStringThanCultureString()
        {
            //前提：
            //システムにグローバル対応が求められる場合

            //目的：
            //①文字列補完をFormattableString型の変数に代入することで、グローバル化がしやすい

            //例：
            //--------------------------------------------------------------------------------------
            //1)グローバル化しやすい

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット①：カルチャーを後から付与しやすい

            //これではただのstring
            string v1 = $"今日は{DateTime.Now.Month}月{DateTime.Now.Day}日です";
            var v2 = $"今日は{DateTime.Now.Month}月{DateTime.Now.Day}日です";

            //FormattableString
            FormattableString v3 = $"今日は{DateTime.Now.Month}月{DateTime.Now.Day}日です";

            //変換メソッドで変換
            var german = ToGerman(v3);
        }


        private static string ToGerman(FormattableString src)
        {
            return string.Format(null, System.Globalization.CultureInfo.CreateSpecificCulture("de-de"), src.Format, src.GetArguments());

        }
    }
}
