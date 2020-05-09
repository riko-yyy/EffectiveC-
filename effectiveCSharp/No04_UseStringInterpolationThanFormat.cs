using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// string.Format()より$"xxxxxx{ vatiable }"を使う
    /// </summary>
    public class No04_UseStringInterpolationThanFormat
    {
        public No04_UseStringInterpolationThanFormat()
        {
            //目的：
            //①可読性の向上
            //②コンパイラによる型チェックの実施
            //③記述の変更容易性

            //例：
            //--------------------------------------------------------------------------------------
            //1)可読性

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット①：みやすい
            var name1 = "田中";
            var name2 = "鈴木";
            //順番を間違える可能性
            var foo = string.Format("1人目：{0}、2人目：{1}", name1, name2);
            //間違えない
            var bar = $"1人目：{name1}、2人目：{name2}";

            //--------------------------------------------------------------------------------------
            //3)変更容易性
            var pi = $"円周率は{Math.PI}";

            //ボックス化（primitive=>object）するため、オーバーヘッドが生じる。
            //避けるため文字列に変換する
            var pi1 = $"円周率は{Math.PI.ToString()}";

            //文字列の書式も指定できる
            var pi2 = $"円周率は{Math.PI.ToString("F2")}";

            //簡略化
            //コンパイラは「:」が存在すると、標準だと書式指定文字列だと認識する
            var pi3 = $"円周率は{Math.PI:F2}";

            //三項演算子だと認識させるには、式であることを明示する
            var round = true;
            var pi4 = $@"円周率は{(round ? Math.PI.ToString("F2") : Math.PI.ToString())}";

            //null合体演算子も記述できる
            var c = new Customer() { ContactName = "田中" };
            var name = $"顧客名は{ c?.ContactName ?? "名前が見つかりません。" }";

            //補完文字列の引数式に補完文字列を利用可能
            //既定値の割当（stringならnull）
            string result = default(string);
            int index = default(int);
            var records = new Dictionary<int, string>();
            //存在すればresultにvalueを、ないなら存在しない旨のメッセージ
            var record = $"レコードは{(records.TryGetValue(index, out result) ? result : $"インデックス{index}のレコードは存在しません")}";

            //Linqクエリ結果に補完文字列を織り交ぜることもできる（よみにくい）
            //Razorの仕組みもこれ（@以降のビューヘルパーの記述とかまさに）
            var output = $"最初の５項目は:{records.Take(5).Select(n => $"項目{n.Value}").Aggregate((c, a) => $"{c}{Environment.NewLine}{a}")}";

        }
    }
}
