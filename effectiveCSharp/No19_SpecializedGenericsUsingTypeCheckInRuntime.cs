using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 実行時の型チェックを使用してジェネリックアルゴリズムを特化する
    /// </summary>
    public class No19_SpecializedGenericsUsingTypeCheckInRuntime
    {
        public No19_SpecializedGenericsUsingTypeCheckInRuntime()
        {
            //目的：
            //①ジェネリクスを取り扱う型に応じて、処理の記述を変えることで結果的にアルゴリズムをより良いものにする

            //概要：
            //--------------------------------------------------------------------------------------
            //ジェネリクスを利用する型（IEnumerable,ICollection.IListなど）に応じて、型チェックを行い処理を分岐させる
            //結果的に外からみたら呼び出し方だが、中身は型に対して特化していて、別処理で性能が出ている状態を作る

            //利用時
            var array = new[] { 1, 2, 3, 4 };
            var enumerable = array as IEnumerable<int>;
            var collection = array as ICollection<int>;
            var list = array as IList<int>;
            var str = "1234";

            //IEnumerable
            var reversedEnumerable = new ReverseEnumerable<int>(enumerable);
            foreach (var item in reversedEnumerable)
            {
                Console.WriteLine(item);
            }

            //ICollection
            var reversedCollection = new ReverseEnumerable<int>(collection);
            foreach (var item in reversedCollection)
            {
                Console.WriteLine(item);
            }

            //IList
            var reversedList = new ReverseEnumerable<int>(list);
            foreach (var item in reversedList)
            {
                Console.WriteLine(item);
            }

            //IEnumerable<char>
            var reversedString = new ReverseEnumerable<char>(str);
            foreach (var item in reversedString)
            {
                Console.WriteLine(item);
            }
        }
    }
}
