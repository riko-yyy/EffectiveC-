using System;
using System.ComponentModel;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 要求に応じてシーケンスの要素を生成する
    /// </summary>
    public class No33_CreateSequenceComponentDependingOnRequest
    {
        public No33_CreateSequenceComponentDependingOnRequest()
        {
            //目的：
            //①イテレータメソッドの引数にシーケンスを渡さず、必要な要素のみをもつシーケンスを生成する

            //概要：
            //--------------------------------------------------------------------------------------
            //利用する側がシーケンスを生成してフィルタするより、要求を投げてそれに応じたシーケンスを生成するメソッドを作成する

            //利用時
            var suquence1 = SequenceFactory.StepBySequence(100, 0, 5);

            //コレクション変更時にイベント実行
            //BindingListのコンストラクタは引数のコレクションの参照コピーを行うので、ToList()でList<int>オブジェクトを生成する
            var sequence2 = new BindingList<int>(SequenceFactory.StepBySequence(100, 0, 5).ToList());

            //遅延実行により、途中で止めることも可能(要素の値が1000未満の場合のみ実行)
            var suquence3 = SequenceFactory.StepBySequence(10000, 0, 5).TakeWhile(num => num < 1000);

        }
    }
}
