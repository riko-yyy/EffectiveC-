using System;
using System.Collections.Generic;
using System.Linq;

namespace effectiveCSharp.Util
{
    //Loopで普通に記述
    public class Loop
    {
        /// <summary>
        /// 例①:0~99までの2乗を出力
        /// </summary>
        public static void ExportSqueared()
        {
            //生成
            var foo = new int[100];
            for (var num = 0; num < 100; num++)
            {
                foo[num] = num * num;
            }
            //出力
            foreach (int i in foo)
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// 例②:0~99までの値をもつペア（x,y）のうち、和が１００未満のもの原点からの距離の逆順で返却
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Tuple<int, int>> Indices()
        {
            var storage = new List<Tuple<int, int>>();
            for (var x = 0; x < 100; x++)
            {
                for (var y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                    {
                        storage.Add(Tuple.Create(x, y));
                    }
                }
            }

            storage.Sort((point1, point2) => (point2.Item1 * point2.Item1 + point2.Item2 * point2.Item2).CompareTo(point1.Item1 * point1.Item1 + point1.Item2 * point1.Item2));

            return storage;
        }

    }

    //Linqのクエリ構文で記述
    public class QuerySyntax
    {
        /// <summary>
        /// 例①:0~99までの2乗を出力
        /// </summary>
        public static void ExportSqueared()
        {
            //生成
            var foo = (from n in Enumerable.Range(0, 100)
                       select n * n).ToList();
            //出力
            foo.ForEach(n => Console.WriteLine(n));
        }

        /// <summary>
        /// 例②:0~99までの値をもつペア（x,y）のうち、和が１００未満のもの原点からの距離の逆順で返却(クエリ構文)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Tuple<int, int>> QueryIndices()
        {
            return from x in Enumerable.Range(0, 100)
                   from y in Enumerable.Range(0, 100)
                   where x + y < 100
                   orderby (x * x + y * y) descending
                   select Tuple.Create(x, y);
        }

        /// <summary>
        /// 例②:0~99までの値をもつペア（x,y）のうち、和が１００未満のもの原点からの距離の逆順で返却(メソッド構文)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Tuple<int, int>> MethodIndices()
        {
            return Enumerable.Range(0, 100).SelectMany(x => Enumerable.Range(0, 100), (x, y) => Tuple.Create(x, y))
                                           .Where(pt => pt.Item1 + pt.Item2 < 100)
                                           .OrderByDescending(pt => pt.Item1 * pt.Item1 + pt.Item2 * pt.Item2);
        }
    }
}
