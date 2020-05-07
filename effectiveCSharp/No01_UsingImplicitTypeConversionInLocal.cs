using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// ローカル変数は暗黙的型変換（var）を使用する
    /// </summary>
    public class No01_UsingImplicitTypeConversionInLocal
    {
        public No01_UsingImplicitTypeConversionInLocal()
        {
            //目的：
            //①開発者がロジックそのものに注力できる（型があっているかや変数の型といった不要な情報の排除）
            //②C#のvarは動的型でなく、右辺の式による暗黙的な型変換であるため、意図しない型が代入されることはない

            //例：
            //--------------------------------------------------------------------------------------
            //1)可読性

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット①：みやすい
            var foo = new MyType();

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット②：人が作り混むバグを回避できる
            var names1 = FindCustomerStartingWith_NG("a");
            var names2 = FindCustomerStartingWith_OK("a");

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //デメリット①：コンパイラの決定する型と開発者が予測する型に差異が生じる可能性
            var factory = new MyTypeFactory();

            //返り値が嘘つき
            var thing = factory.CreateMyType();

            //=>変数名でカバー
            var isSuccess = factory.CreateMyType();

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //デメリット②：数値に生じる暗黙的型変換と精度
            //宣言する型に応じて結果が変わる＆それが伝播する
            var f = GetMagicNumber();
            var total = 100 * f / 6;
            Console.WriteLine($"宣言された型：{total.GetType().Name},値：{total}");

            //変数宣言してなくても同じ
            var total1 = 100 * GetMagicNumber() / 6;
            Console.WriteLine($"宣言された型：{total1.GetType().Name},値：{total1}");

            //明示的に型を宣言しても同じ（GetMagicNumbe()がintなら四捨五入されて計算される）
            double total2 = 100 * GetMagicNumber() / 6;
            Console.WriteLine($"宣言された型：{total2.GetType().Name},値：{total2}");

            //=>型を利用した暗黙的型変換を利用
            decimal f1 = GetMagicNumber();
            var total3 = 100 * f1 / 6;
            Console.WriteLine($"宣言された型：{total3.GetType().Name},値：{total3}");


        }

        private int GetMagicNumber()
        {
            return 1;
        }

        private IEnumerable<string> FindCustomerStartingWith_NG(string start)
        {
            //DB接続
            DbMock db = new DbMock();

            //qはIEnumerable
            //=>このタイミングでサーバーから全件取得してしまう（内部加工方式）
            IEnumerable<string> q = db.Customers.Select(s => s.ContactName);

            //全件取得したコレクションに対してWhere
            return q.Where(s => s.StartsWith(start));
                
        }

        private IEnumerable<string> FindCustomerStartingWith_OK(string start)
        {
            //DB接続
            DbMock db = new DbMock();

            //qはIQueryable           
            var q = db.Customers.Select(s => s.ContactName);

            //=>サーバー絞り込んだ結果をここで取得する（外部クエリ方式）
            return q.Where(s => s.StartsWith(start));
        }
    }
}
