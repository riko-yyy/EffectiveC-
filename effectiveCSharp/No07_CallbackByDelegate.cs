using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// デリゲートを利用してコールバックを表現する
    /// </summary>
    public class No07_CallbackByDelegate
    {
        //delegateはメソッドを格納する変数のイメージ
        delegate void Calculate(string a);

        public No07_CallbackByDelegate()
        {
            //目的：
            //①コールバックの実現
            //②インタフェース間に「has a」関係ほどの密結合を与えない

            //概要：
            //--------------------------------------------------------------------------------------
            //メソッドの型が上で与えられているから、これでメソッドをインスタンス化
            Calculate aaaaa = new Calculate(Console.WriteLine);
            //実際に使う
            aaaaa("hogohogo");

            //匿名でも可能
            Calculate bbbbb = delegate (string s) { Console.WriteLine(s); };

            //ラムダ式でも可能
            Calculate ccccc = (string s) => Console.WriteLine(s);

            //例：
            //--------------------------------------------------------------------------------------
            //1)コールバックの実現

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //①：Linqでの実装

            //Linqは標準で、delegateを用いたコールバックが組み込まれている
            //実装されているdelegateは３つ
            //Predicate<T>  :引数ジェネリクス、返り値boolのデリゲート
            //Action<T>     :引数ジェネリクス、返り値voidのデリゲート
            //Func<T>       :引数ジェネリクス、返り値ジェネリクスのデリゲート

            List<int> numbers = Enumerable.Range(1, 200).ToList();

            //Predicate<int>のデリゲートを引数に受け取るFind()、TrueForAll()、RemoveAll()
            //bool判定をして、その結果をコールバックで返している
            var oddNumbers = numbers.Find(n => n % 2 == 1);
            var test = numbers.TrueForAll(n => n < 50);
            numbers.RemoveAll(n => n % 2 == 0);

            //Action<int>のデリゲートを引数に受け取るForeach()
            //要素に対して引数のActionを実行
            numbers.ForEach(item => Console.WriteLine(item));

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //②：自前でやってみる
            Callback callback = new Callback("田中");
            callback.Method1(() => true).Method1(() => false);


            //--------------------------------------------------------------------------------------
            //②疎結合なメソッドの実行
            //概要と同じ
            Calculate method = (string s) => Console.WriteLine(s);

            //追加もできる（マルチキャスト）
            method += new Calculate(MyMethod);
            //実行するともともとあったのと、追加したものを合わせて実行
            method("test");

            //削除もできる
            method -= new Calculate(MyMethod);

            //※返り値ジェネリクスのデリゲートを複数追加した場合、最終的な返り値は最後に追加したもので、他は無視される
            //きちんと両方が利用されるには、その二つのデリゲートに登録されたメソッドを明示的に呼び出すメソッドを定義する

        }

        public void MyMethod(string s)
        {
            Console.WriteLine($"MyMethod!! catch:{s}");
        }
    }

}
