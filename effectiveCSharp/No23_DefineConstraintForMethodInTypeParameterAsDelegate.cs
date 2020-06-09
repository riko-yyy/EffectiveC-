using System;
using effectiveCSharp.Util;
using System.Linq;
using System.IO;

namespace effectiveCSharp
{
    /// <summary>
    /// 型パラメータにおけるメソッドの制約をデリゲートとして定義する
    /// </summary>
    public class No23_DefineConstraintForMethodInTypeParameterAsDelegate
    {
        public No23_DefineConstraintForMethodInTypeParameterAsDelegate()
        {
            //目的：
            //①制約の拡張

            //概要：
            //--------------------------------------------------------------------------------------
            //ジェネリクスの制約はインタフェース、クラス、引数なしコンストラクタなど限られている
            //デリゲートを使うことでその制約を拡張し、動的に手軽に使えるジェネリクスクラスを作成する

            //利用時
            //引数にラムダ式を渡して、メソッドの実処理として実行してもらう
            //こうすることで、ジェネリクスクラスを用意する側も利用する側も少量のコードで済む
            int sum = ExampleDelegateConstraint.Add(6, 7, (x, y) => x + y);

            //これを実装した標準機能がSystem.Linq.Enumerable.Zip
            //2つのシーケンシャルなコレクションに対して、順に結合したコレクションを返却する
            //下記の場合、IEnumerable<Point>が返却される
            double[] xValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] yValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var values1 = Enumerable.Zip(xValues, yValues, (x, y) => new Point(x, y));

            //クラスのメンバ変数にデリゲートをセットし、そのあとで実処理を実行。DI
            TextReader inputStream = default;
            var holder = new InputCollection<Point>((inputStream) => new Point(inputStream));
            var values2 = holder.Values;

        }
    }
}
