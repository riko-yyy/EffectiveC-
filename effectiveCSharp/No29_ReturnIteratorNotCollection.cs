using System;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// コレクションを返すメソッドではなくイテレータを返すメソッドとすること
    /// </summary>
    public class No29_ReturnIteratorNotCollection
    {
        public No29_ReturnIteratorNotCollection()
        {
            //目的：
            //①シーケンス（IEnumerable<T>）の初期化・作成を便利に実現し、利用者に選択肢を与える

            //概要：
            //--------------------------------------------------------------------------------------
            //集合を生成するメソッドを作成する場合、コレクション(List,Dictionary)でなく
            //シーケンス（IEnumerable）返すメソッドをイテレータメソッドとして実装する
            //そうすることで、利用者が任意のタイミングでコレクション化でき、性能劣化を引き起こさない

            //利用時
            foreach (var alph in Alphabets.Generate())
            {
                Console.WriteLine(alph);
            }

            //作成時にチェックを入れる
            var sequence = Alphabets.GenerateSubSet('c', 'r');

            //ここでエラーがでる
            //var sequence = Alphabets.GenerateSubSet('c', 'a');

            foreach (var alph in sequence)
            {
                Console.WriteLine(alph);
            }

        }
    }
}
