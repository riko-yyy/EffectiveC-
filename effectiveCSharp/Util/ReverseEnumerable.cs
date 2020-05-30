using System;
using System.Collections;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// 反復処理をサポートする列挙子(IEnumerator)を公開する
    /// イテレータが降順になっているため、逆順で返すようになる
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ReverseEnumerable<T> : IEnumerable<T>
    {
        /// <summary>
        /// 反復処理をサポート
        /// </summary>
        private class ReverseEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// イテレータが指す現在の要素のインデックス
            /// </summary>
            int currentIndex;

            /// <summary>
            /// 走査対象のコレクション
            /// </summary>
            IList<T> collection;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="srcCollection"></param>
            public ReverseEnumerator(IList<T> srcCollection)
            {
                collection = srcCollection;
                currentIndex = collection.Count;
            }

            //-----------------------------------------------IEnumerator<T>の実装
            //反復処理をサポートするインタフェース(ジェネリック)
            //型情報を加えることでコンパイラが認知でき、タイプセーフになる
            public T Current => collection[currentIndex];

            //-----------------------------------------------IDisposableの実装
            //アンマネージリソースを解放をサポートするインタフェース

            public void Dispose()
            {
                //空
            }

            //-----------------------------------------------IEnumeratorの実装
            //反復処理をサポートするインタフェース(非ジェネリック)

            /// <summary>
            /// イテレータが指す現在の要素を取得
            /// </summary>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// イテレータを次の要素へ移動
            /// </summary>
            /// <returns></returns>
            public bool MoveNext() => --currentIndex >= 0;

            /// <summary>
            /// イテレータを初期位置にリセット
            /// </summary>
            public void Reset() => currentIndex = collection.Count;
        }


        //④：stringはIEnumerable<char>の実装のため、シーケンシャルにコピー
        //　=>string特化のEnumeratorを用意

        /// <summary>
        /// string用ReverseEnumerator
        /// </summary>
        private sealed class ReverseStringEnumerator : IEnumerator<char>
        {
            int currentIndex;
            string sourceSequence;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="source"></param>
            public ReverseStringEnumerator(string source)
            {
                sourceSequence = source;
                currentIndex = source.Length;
            }

            //-----------------------------------------------IEnumerator<T>の実装
            public char Current => sourceSequence[currentIndex];

            //-----------------------------------------------IDisposableの実装
            public void Dispose()
            {
                //空
            }

            //-----------------------------------------------IEnumeratorの実装
            object IEnumerator.Current => this.Current;

            public bool MoveNext() => --currentIndex >= 0;

            public void Reset() => currentIndex = sourceSequence.Length;
        }

        /// <summary>
        /// ソースコレクション
        /// </summary>
        IEnumerable<T> sourceSequence;

        /// <summary>
        /// オリジナルコレクション
        /// </summary>
        IList<T> originalSequence;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReverseEnumerable(IEnumerable<T> sequence)
        {
            sourceSequence = sequence;

            //①：ソースコレクションがランダムアクセスをサポートしていた場合、GetEnumerator()でシーケンシャルにコピーするのは性能が悪い
            //　=>ランダムアクセス可能ならこの時点でコピー
            //　=>コピーできなくてもnullになるだけなので、あとでシーケンシャルにコピーされる
            //②：コンパイル時にキャスト可能か挙動を確定したい
            originalSequence = sequence as IList<T>;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReverseEnumerable(IList<T> sequence)
        {
            //②：コンパイル時にキャスト可能か挙動を確定したい
            //　=>引数IList<T>のオーバーロードメソッドを用意
            //　=>引数が静的にIList<T>ならコンパイル時にIList<T> コンストラクタが、動的にIList<T>なら実行時にIEnumerable<T> コンストラクタが選択される
            sourceSequence = sequence;
            originalSequence = sequence;
        }

        //-----------------------------------------------IEnumerable<T>の実装
        //反復処理をサポートする列挙子(IEnumerator<T>)を公開する(ジェネリック)

        /// <summary>
        /// ReverseEnumeratorを返却
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            //④：stringはIEnumerable<char>の実装のため、シーケンシャルにコピー
            //　=>stringならstringようEnumeratorを呼び出し、メソッドに合わせてダウンキャストして返却
            if (sourceSequence is string)
            {
                return new ReverseStringEnumerator(sourceSequence as string) as IEnumerator<T>;
            }

            //①：IEnumerableはランダムアクセスをサポートしていないため、シーケンシャルにコピー
            //③：ICollectionはランダムアクセスをサポートしていないため、シーケンシャルにコピー
            //④：stringはIEnumerable<char>の実装のため、シーケンシャルにコピー
            if (originalSequence == null)
            {

                if (sourceSequence is ICollection<T>)
                {
                    //③：ICollectionはランダムアクセスをサポートしていないため、シーケンシャルにコピー
                    //　=>ICollectionならその要素数をサポートしているため、その要素数で初期化する
                    //　=>Listの初期化で必要十分なストレージを確保する。ストレージ追加のオーバーヘッドが生じない
                    var source = sourceSequence as ICollection<T>;
                    originalSequence = new List<T>(source.Count);
                }
                else
                {
                    originalSequence = new List<T>();
                }
      
                foreach (T item in sourceSequence)
                {
                    originalSequence.Add(item);
                }
            }
            return new ReverseEnumerator(originalSequence);
        }

        //-----------------------------------------------IEnumerableの実装
        //反復処理をサポートする列挙子(IEnumerator)を公開する(非ジェネリック)

        /// <summary>
        /// ReverseEnumeratorを返却
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
