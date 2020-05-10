using System;
namespace effectiveCSharp.Util
{
    /// <summary>
    /// イベント発生待ち受けクラス
    /// 外から実行する動作をデリゲート（イベントハンドラー）経由で登録しておき、RaiseUpdates()が実行されたタイミングで実行
    /// </summary>
    public class EventSource
    {
        //デリゲート格納
        private EventHandler<int> Updated;

        //呼び出し回数
        private int counter;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="func"></param>
        public EventSource(EventHandler<int> func)
        {
            Updated = func;
        }

        /// <summary>
        /// カウンターを加算して、そのカウンターを引数にデリゲード実行
        /// </summary>
        public void RaiseUpdates()
        {
            counter++;

            //×：イベントハンドラに値がない状態で実行するとNullReferenceException
            Updated(this, counter);

            //×：nullの検証後に別スレッドでデリゲートの削除が生じるとNullReferenceException
            if (Updated != null)
            {
                Updated(this, counter);
            }

            //△：検証後にデリゲート削除が生じても、別の変数に複製してるから影響を受けない
            //   ただし冗長で可読性にかける、一見して意味がわかりにくい
            var handler = Updated;
            if (handler != null)
            {
                handler(this, counter);
            }

            //○：null条件演算子を使用。nullなら実行しないし、nullでないなら実行
            //  検証＆実行も厳密に同じタイミング
            Updated?.Invoke(this, counter);

        }


    }
}
