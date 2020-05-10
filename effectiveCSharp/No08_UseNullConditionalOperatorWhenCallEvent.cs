using System;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// イベント呼び出し時にnull条件演算子を使う
    /// </summary>
    public class No08_UseNullConditionalOperatorWhenCallEvent
    {
        public No08_UseNullConditionalOperatorWhenCallEvent()
        {
            //目的：
            //①スレッドセーフな記述
            //②可読性、冗長なヘルパーメソッドの作成の回避

            //例：
            //--------------------------------------------------------------------------------------
            //1)スレッドセーフな記述

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット①：１行で簡単に記述できる

            //実装はeffectiveCSharp.Util.EventSourceを参照

            //使う時はこんな感じ
            //メソッドをイベントハンドラー化
            var aaa = new EventHandler<int>(newFunc);

            //イベント待ち受けクラスをインスタンス化
            //デリゲート登録
            EventSource eventSource = new EventSource(aaa);

            //登録したデリゲードを実行
            eventSource.RaiseUpdates();

        }

        //実際に動かさせたいメソッド
        private void newFunc(object sender, int e)
        {
            Console.WriteLine(e);
        }
    }
}
