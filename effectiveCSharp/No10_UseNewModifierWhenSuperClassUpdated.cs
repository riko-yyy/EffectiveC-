using System;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// 親クラスの変更に応じる場合のみnew修飾子を使用する
    /// </summary>
    public class No10_UseNewModifierWhenSuperClassUpdated
    {
        public No10_UseNewModifierWhenSuperClassUpdated()
        {
            //目的：
            //①不安定なポリモーフィズムの回避

            //概要：
            //--------------------------------------------------------------------------------------
            //継承したクラスでnew修飾子を用いて親クラスのプロパティ、メソッドを定義すると別物として定義できる
            object o = new object();
            var my1 = o as MyType;
            var my2 = o as MyOtherType;

            my1.MagicMethod();
            my2.MagicMethod();

            //あくまで別メソッドかつ、動的インスタンスの型に応じて多態性を実行できるものではないため、使う側は混乱する
            //基本使わない

            //例：
            //--------------------------------------------------------------------------------------
            //1)使っていい例
            //サブクラスが定義していたものと同名のメソッドが親クラスにあとから追加された場合のみ

        }
    }
}
