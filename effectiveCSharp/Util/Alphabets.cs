using System;
using System.Collections;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// イテレータメソッドによる実装
    /// </summary>
    public class Alphabets
    {
        /// <summary>
        /// 小文字でa~zまで作成する
        /// シュガーシンタックス
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<char> Generate()
        {
            var letter = 'a';
            while (letter <= 'z')
            {
                yield return letter;
                letter++;
            }
        }

        /// <summary>
        /// 小文字でa~zまでの部分集合を作成する
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<char> GenerateSubSet(char first, char last)
        {
            //エラー
            if (first < 'a')
            {
                throw new ArgumentException("1文字目はa以降にする必要があります", nameof(first));
            }

            if (first > 'z')
            {
                throw new ArgumentException("1文字目はz以前にする必要があります", nameof(first));
            }

            if (last < first)
            {
                throw new ArgumentException("最後の文字は1文字目より後方になければいけません", nameof(last));
            }

            if (first > 'z')
            {
                throw new ArgumentException("最後の文字はz以前にする必要があります", nameof(last));
            }

            //実際には上記のチェックはメソッド実行時にはされず、Iteratorによるアクセスを行った時にチェックされるため、
            //foreachなどでアクセスした箇所でエラーをはく

            //var letter = first;
            //while (letter <= 'Z')
            //{
            //    yield return letter;
            //    letter++;
            //}

            //そこでyieldブロックをローカル関数として切り出す
            return GenerateSubsetImpl(first, last);
        }

        /// <summary>
        /// ローカル関数
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        private static IEnumerable<char> GenerateSubsetImpl(char first, char last)
        {
            var letter = first;
            while (letter <= last)
            {
                yield return letter;
                letter++;
            }
        }

    }

    /// <summary>
    /// 上記のクラスからコンパイラが作成するクラス
    /// Iteratorパターン（IEnumerableの実装）を自動生成している
    /// </summary>
    public class EmbeddedIterator : IEnumerable<char>
    {
        /// <summary>
        /// メソッドの呼び出し
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<char> Generate() => new EmbeddedIterator();

        /// <summary>
        /// IEnumerable<char>の実装
        /// </summary>
        /// <returns></returns>
        public IEnumerator<char> GetEnumerator() => new LetterEnumerator();

        /// <summary>
        /// IEnumerableの実装
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => new LetterEnumerator();

        /// <summary>
        /// Enumeratorの本体
        /// </summary>
        private class LetterEnumerator : IEnumerator<char>
        {
            /// <summary>
            /// letter
            /// </summary>
            private char letter = (char)('a' - 1);

            /// <summary>
            /// IEnumerator<char>の実装
            /// Current
            /// </summary>
            public char Current => letter;

            /// <summary>
            /// IEnumeratorの実装
            /// Current
            /// </summary>
            object IEnumerator.Current => letter;

            /// <summary>
            /// IEnumerator<char>の実装
            /// MovableNext
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                letter++;
                return letter <= 'z';
            }

            /// <summary>
            /// IEnumerator<char>の実装
            /// Reset
            /// </summary>
            public void Reset()
            {
                letter = (char)('a' - 1);
            }

            /// <summary>
            /// IEnumerator<char>の実装
            /// Dispose
            /// </summary>
            public void Dispose()
            {

            }


        }
    }


}
