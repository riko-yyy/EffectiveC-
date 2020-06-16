using System;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// 最小限に制限されたインタフェースを拡張メソッドにより機能拡張する
    /// </summary>
    public class No27_ExpandFunctionOfInterfaceRestrictedMinimumByExtensionMethod
    {
        public No27_ExpandFunctionOfInterfaceRestrictedMinimumByExtensionMethod()
        {
            //目的：
            //①インタフェースの利便性を高める

            //概要：
            //--------------------------------------------------------------------------------------
            //インタフェースは定義したメンバ変数やメソッドを実装することを強制する
            //そのため、あれば便利といったメソッドをインタフェース内に定義できない
            //そこで拡張メソッッドを用いて、インタフェースに対してあったら便利な機能を付与し、機能拡張する

            //利用時
            var a = 1;
            var b = 2;

            var result = a.GreaterThan(b); //false

            //注意
            var foo = new DerivedFoo();
            foo.UpdateMarker();
        }
    }
}
