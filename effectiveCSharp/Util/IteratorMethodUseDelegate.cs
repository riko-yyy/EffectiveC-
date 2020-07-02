using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class IteratorMethodUseDelegate
    {
        #region Predicate   
        /// <summary>
        /// フィルタ
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="sequence">シーケンス</param>
        /// <param name="filterFunc">フィルタPredicate</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(IEnumerable<T> sequence, Predicate<T> filterFunc)
        {
            if (sequence == null)
            {
                throw new ArgumentException("シーケンスをnullにできません", nameof(sequence));
            }

            if (filterFunc == null)
            {
                throw new ArgumentException("述語をnullにできません", nameof(filterFunc));
            }

            foreach (T item in sequence)
            {
                if (filterFunc(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// シーケンスのN番目ごとの要素を返す
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="sequence">シーケンス</param>
        /// <param name="period">N</param>
        /// <returns></returns>
        public static IEnumerable<T> EveryNthItem<T>(IEnumerable<T> sequence, int period)
        {
            if (sequence == null)
            {
                throw new ArgumentException("シーケンスをnullにできません", nameof(sequence));
            }

            if (period > 0)
            {
                throw new ArgumentException("Nは0より大きい整数である必要があります", nameof(period));
            }

            var count = 0;

            foreach (T item in sequence)
            {
                if (++count % period == 0)
                {
                    yield return item;
                }

            }
        }
        #endregion

        #region Action
        /// <summary>
        /// シーケンスの各要素に対して処理を実行する
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="sequence">シーケンス</param>
        /// <param name="action">処理</param>
        public static void ForEach<T>(IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null)
            {
                throw new ArgumentException("シーケンスをnullにできません", nameof(sequence));
            }

            if (action == null)
            {
                throw new ArgumentException("処理をnullにできません", nameof(action));
            }

            foreach (T item in sequence)
            {
                action(item);
            }
        }
        #endregion

        #region Func       
        /// <summary>
        /// シーケンスの各要素を加工し、そのシーケンスを返す
        /// </summary>
        /// <typeparam name="Tin">加工前の要素の型</typeparam>
        /// <typeparam name="Tout">加工後の要素の型</typeparam>
        /// <param name="sequence">シーケンス</param>
        /// <param name="method">加工メソッド</param>
        /// <returns></returns>
        public static IEnumerable<Tout> Select<Tin,Tout>(IEnumerable<Tin> sequence, Func<Tin,Tout> method)
        {
            if (sequence == null)
            {
                throw new ArgumentException("シーケンスをnullにできません", nameof(sequence));
            }

            if (method == null)
            {
                throw new ArgumentException("関数をnullにできません", nameof(method));
            }

            foreach(Tin item in sequence)
            {
                yield return method(item);
            }
        }
        #endregion


        public bool IsTrue(int num)
        {
            return true;
        }
    }
}
