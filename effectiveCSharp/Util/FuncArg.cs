using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class FuncArg
    {

        /// <summary>
        /// ２つのシーケンスをマージして新たなシーケンスを返却する(string限定版)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<string> Zip(IEnumerable<string> first, IEnumerable<string> second)
        {
            using (var firstSec = first.GetEnumerator())
            {
                using (var secondSec = second.GetEnumerator())
                {
                    while (firstSec.MoveNext() && secondSec.MoveNext())
                    {
                        yield return $"{firstSec.Current} {secondSec.Current}";
                    }
                }
            }
        }

        /// <summary>
        /// ２つのシーケンスをマージして新たなシーケンスを返却する(ジェネリクス版)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Zip<T1, T2, TResult>(IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TResult> zipper)
        {
            using (var firstSec = first.GetEnumerator())
            {
                using (var secondSec = second.GetEnumerator())
                {
                    while (firstSec.MoveNext() && secondSec.MoveNext())
                    {
                        yield return zipper(firstSec.Current, secondSec.Current);
                    }
                }
            }
        }

        /// <summary>
        /// 与えた条件に応じたシーケンスを返却する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> CreateSequence<T>(int numberOfElement, Func<T> generator)
        {
            for (int i = 0; i < numberOfElement; i++)
            {
                yield return generator();
            }
        }

        /// <summary>
        /// 合計値を返却する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Sum<T>(IEnumerable<T> sequence, T total, Func<T, T, T> accumulator)
        {
            foreach (T item in sequence)
            {
                total = accumulator(total, item);
            }
            return total;
        }

        /// <summary>
        /// 合計値を返却する(返却値とシーケンスの型を別でもOK)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static TResult Fold<T, TResult>(IEnumerable<T> sequence, TResult total, Func<T, TResult, TResult> accumulator)
        {
            foreach (T item in sequence)
            {
                total = accumulator(item, total);
            }
            return total;
        }
    }
}
