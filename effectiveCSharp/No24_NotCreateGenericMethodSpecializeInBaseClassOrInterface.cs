using System;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// 親クラスやインタフェース用に特化したジェネリックメソッドを作成しないこと
    /// </summary>
    public class No24_NotCreateGenericMethodSpecializeInBaseClassOrInterface
    {
        public No24_NotCreateGenericMethodSpecializeInBaseClassOrInterface()
        {
            //目的：
            //①利用者が混乱する挙動を避ける

            //概要：
            //--------------------------------------------------------------------------------------
            //ジェネリクスメソッドを先に公開し、それに特定の親クラスやインタフェースに特化した処理をさせたいという目的で
            //もとのジェネリクスメソッドをオーバーロードする形でメソッドを実装してはならない
            //コンパイラはジェネリクスメソッドを優先して採用するため、意識して親クラスやインタフェースにパースしないと
            //オーバーロードメソッドを使用することができない。これは利用者に対して混乱を招く
            //どうしてもやりたいなら、親クラス・インタフェース・継承するクラス・実装するクラス全てに対してオーバーロードメソッドを用意する
            //そうすれば厳密に型一致するのでオーバーロードメソッドを利用できる

            //実際の振る舞い
            var d = new MyDerived();
            var a = new AnotherType();

            //②が実行される
            GenericsAndOverLoad.WriteMessage(d);
            GenericsAndOverLoad.WriteMessage(a);
            //③が実行される
            GenericsAndOverLoad.WriteMessage((IMessageWriter)d);
            GenericsAndOverLoad.WriteMessage((IMessageWriter)a);
            //①が実行される
            GenericsAndOverLoad.WriteMessage((MyBase)d);

            //厳密な型一致が優先され、ジェネリクスメソッドが優先される
        }
    }
}
