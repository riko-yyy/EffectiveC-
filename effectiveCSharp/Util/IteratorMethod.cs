using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// 普通のやつ
    /// </summary>
    public class ProduceMethod
    {
        public static void UniqueWrite(IEnumerable<int> nums)
        {
            var uniqueVals = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!uniqueVals.Contains(num))
                {
                    uniqueVals.Add(num);
                    Console.WriteLine(num * num);
                }
            }
        }
    }

    /// <summary>
    /// イテレータメソッド
    /// </summary>
    public class IteratorMethod
    {
        public static void UniqueWrite(IEnumerable<int> nums)
        {
            foreach (var num in Square(Unique(nums)))
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// 重複除去
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IEnumerable<T> Unique<T>(IEnumerable<T> nums)
        {
            var uniqueVals = new HashSet<T>();
            foreach (var num in nums)
            {
                if (!uniqueVals.Contains(num))
                {
                    uniqueVals.Add(num);
                    yield return num;
                }
            }
        }

        /// <summary>
        /// ２乗を返却
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IEnumerable<int> Square(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                yield return num * num;
            }
        }
    }


}
