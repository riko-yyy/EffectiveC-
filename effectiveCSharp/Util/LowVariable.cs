using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class LowVariable
    {
        public IEnumerable<int> MakeSequence()
        {
            var counter = 0;
            var numbers = Generate(30, () => counter++);
            return numbers;
        }
        //コンパイル時には以下のようなコードが生成される
        //private class Closure
        //{
        //    public int generatedCounter;
        //    public int generatorFunc() => generatedCounter++;
        //}
        //public IEnumerable<int> MakeSequence()
        //{
        //    var c = new Closure();
        //    c.generatedCounter = 0;
        //    var sequence = Generate(30, new Func<int>(c.generatorFunc));
        //    return sequence;
        //}

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
