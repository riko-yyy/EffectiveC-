using System;
using System.Collections.Generic;
using System.IO;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// ストリームからモデルを作成するデリゲート型
    /// </summary>
    /// <typeparam name="T">モデル</typeparam>
    /// <param name="reader">ストリーム</param>
    /// <returns>作成されたモデル</returns>
    public delegate T CreateFromStream<T>(TextReader reader);

    /// <summary>
    /// ストリームをもとにコレクションを作成する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputCollection<T>
    {
        private List<T> thingsRead = new List<T>();

        private readonly CreateFromStream<T> readFunc;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="readFunc">ストリームからモデル作成する実処理</param>
        public InputCollection(CreateFromStream<T> readFunc)
        {
            this.readFunc = readFunc;
        }

        /// <summary>
        /// ストリームをもとにモデルを生成し、コレクションに追加
        /// </summary>
        /// <param name="reader"></param>
        public void ReadFromStream(TextReader reader) => thingsRead.Add(readFunc(reader));


        /// <summary>
        /// コレクションのゲッター
        /// </summary>
        public IEnumerable<T> Values => thingsRead;
    }
}
