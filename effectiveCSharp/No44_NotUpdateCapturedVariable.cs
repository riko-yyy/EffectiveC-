using System;
using System.Collections.Generic;

namespace effectiveCSharp
{
    /// <summary>
    /// 束縛した変数を変更しないこと
    /// </summary>
    public class No44_NotUpdateCapturedVariable
    {
        public No44_NotUpdateCapturedVariable()
        {
            //目的：
            //クロージャに渡すローカル変数を外で変更してはならない

            //概要：
            //--------------------------------------------------------------------------------------
            //遅延実行とコンパイルが相まって予期しないエラーが発生する可能性がある

            //悪い例
            var index = 0;
            Func<IEnumerable<int>> sequence = () => Generate(30, () => index++);

            index = 20;
            foreach (int n in sequence())
            {
                Console.WriteLine(n);   //20~50
            }

            index = 100;
            foreach (int n in sequence())
            {
                Console.WriteLine(n);   //100~130
            }

            //遅延実行なので、走査直前のindexが採用される


        }

        /// <summary>
        /// ジェネレータ
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="num"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        private static IEnumerable<TResult> Generate<TResult>(int num, Func<TResult> generator)
        {
            for (var i = 0; i < num; i++)
            {
                yield return generator();
            }
        }
    }
}
