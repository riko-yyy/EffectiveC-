using System;
using System.Collections.Generic;
using System.Linq;

namespace effectiveCSharp
{
    /// <summary>
    /// クエリを即時評価ではなく遅延評価すること
    /// </summary>
    public class No37_UseLazyEvaluationThanEagerEvaluation
    {
        public No37_UseLazyEvaluationThanEagerEvaluation()
        {
            //目的：
            //①即評価と遅延評価をうまく使い分け、性能を担保する

            //概要：
            //--------------------------------------------------------------------------------------
            //遅延評価はシーケンスが実際に作成されるのは走査時であるため
            //一連のシーケンスの中間状態をメモリ上に確保しなくてよい

            //例
            //このときseq1は中間状態としてメモリ上に確保されることなく、
            //１度にseq2まで生成される
            var seq1 = Generate(10, () => DateTime.Now);
            var seq2 = from v in seq1
                       select v.ToUniversalTime();

            //この挙動を理解して使う
            //オーバーフローしない
            var ans = from n in AllNums()
                      select n;
            var taken = ans.Take(10);

            //実行順序に気をつける
            //先にフィルタして要素数減らしたほうが早い
            var bad = from n in AllNums().Take(100)
                      orderby n
                      where n < 50
                      select n;

            var good = from n in AllNums().Take(100)
                       where n < 50
                       orderby n                       
                       select n;


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

        /// <summary>
        /// 無限に整数シーケンス生成
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<int> AllNums()
        {
            var num = 0;
            while(num <int.MaxValue)
            {
                yield return num++;
            }
        }
    }
}
