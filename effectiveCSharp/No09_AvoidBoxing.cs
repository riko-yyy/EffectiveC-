using System;
using System.Collections;
using System.Collections.Generic;

namespace effectiveCSharp
{
    /// <summary>
    /// ボックス化およびボックス化解除を避ける
    /// </summary>
    public class No09_AvoidBoxing
    {
        public No09_AvoidBoxing()
        {
            //目的：
            //①バグを作り組む可能性回避
            //②リソースの無駄削減

            //概要：
            //--------------------------------------------------------------------------------------
            //ボックス化：値型をSystem.Objectのへラップする
            int primitive = 1;
            object obj = primitive;

            //実際にはこんなコード書かないが、暗黙的にこれが行われるシーンがある
            //例：補完文字列
            Console.WriteLine($"nuwaaaaaaa{primitive}");

            //こういうのを避ける


            //例：
            //--------------------------------------------------------------------------------------
            //1)バグを作り組む可能性回避

            //非ジェネリクスのコレクション(System.Collections.ArrayList)は使用しない
            var notUseList = new ArrayList();

            //これはSystem.Object型のコレクションなので、この値型の追加時点でボックス化される
            notUseList.Add(1);
            //取り出すとobject
            var objValue = notUseList[0];
            //で、内部的には取り出す際にコピーが作成されるため、これを参照型とみなして処理するとバグ発生
            //参照型だと思って、別の変数に取り出したものを値変えてから、もとのを出力しても変わると思って扱うとバグ
            objValue = 3;
            Console.WriteLine(notUseList[0]);

            //=>ジェネリクスのコレクション(System.Collections.Generic.List)を使う
            var uselist = new List<int>();


            //--------------------------------------------------------------------------------------
            //2)リソースの無駄削減
            //上記の例
            Console.WriteLine($"nuwaaaaaaa{primitive}");

            //System.Objectにラップされないように、既知の型へキャストしておく
            Console.WriteLine($"nuwaaaaaaa{primitive.ToString()}");

        }
    }
}
