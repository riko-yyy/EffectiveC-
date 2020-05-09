using System;
using System.ComponentModel;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 文字列指定のAPIを使用しない(nameof()を使う)
    /// </summary>
    public class No06_NotUseApiByString
    {
        public No06_NotUseApiByString()
        {
            //目的：
            //①型安全性確保
            //②名前を変更するとコンパイルエラーで気づける

            //例：
            //--------------------------------------------------------------------------------------
            //1)型安全性確保

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //メリット①：クラス名などを間違えずに文字列化できる

            //クラス名「MyType」を出力
            var name = nameof(MyType);

            //メソッド名「MyMethod」を出力
            var method = nameof(MyType.MyMethodUpdate);

            //ローカルの変数名「ssss」を出力
            var ssss = "aaaa";
            var localName = nameof(ssss);

            //使い道：
            //--------------------------------------------------------------------------------------
            //1)APIコール

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //2)例外メッセージでのクラス名
            string cantNull = null;
            ExceptionMessage(cantNull);

            //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //3)ルーティング（namespacw,Controller,Actionとかの名前からURL生成）            

        }

        public static void ExceptionMessage(object thisCantBeNullUpdate)
        {
            if (thisCantBeNullUpdate == null)
            {
                throw new ArgumentNullException(nameof(thisCantBeNullUpdate), $"{nameof(thisCantBeNullUpdate)}をnullにできません");
            }

        }
    }




}
