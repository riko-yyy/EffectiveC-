﻿using System;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// コンストラクタ内では仮想メソッドを呼ばないこと
    /// </summary>
    public class No16_NotUseVirtualMethodInConstructor
    {
        public No16_NotUseVirtualMethodInConstructor()
        {
            //目的：
            //①すごい不安定な実装を避ける

            //概要：
            //--------------------------------------------------------------------------------------
            //親：コンストラクタ内でオーバーライド可能な仮想メソッドを呼び出しているクラス
            //子：親を継承し、仮想メソッドをオーバーライド。初期化子でメンバ変数を初期化。コンストラクタでメンバ変数を初期化。

            //呼び出し
            Derived.MainDerived();

            //どうなるか
            //1)"親だよ"
            //2)"子の初期化子だよ"
            //3)"子のMainコンストラクタだよ"

            //正解は2
            //No14_MinimizeDuplicationOfInitializeLogicより、実行順序は順に以下の通り
            //6)変数のオブジェクト初期化子（子クラスのmsgを初期化子で初期化）
            //7)親クラスのコンストラクタ（親のコンストラクタ実行。この時Func()を呼び出すが、呼び出すFuncはオーバーライドされた子のFunc()）
            //8)コンストラクタ（子のコンストラクタ実行。msgに値がセットされる）

            //ここで生じてるわかりにくさは２つ
            //1)親クラスのコンストラクタが実行されてるくせに、そのなかで呼び出す仮想メソッドは子クラスのもの
            //2)子クラスのメンバ変数がreadonlyなのに、書き換えられている

            //これらを回避するための実装は
            //「親クラスのコンストラクタに仮想メソッドの呼び出しが含み、子クラスは引数なしのコンストラクタのみ用意し全てのメンバ変数を初期化子で初期化する」
            //こんなのやりたくない
        }
    }
}
