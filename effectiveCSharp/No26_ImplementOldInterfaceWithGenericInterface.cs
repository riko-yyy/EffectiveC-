using System;
using System.Collections.Generic;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// ジェネリックインタフェースとともに古いインタフェースを実装すること
    /// </summary>
    public class No26_ImplementOldInterfaceWithGenericInterface
    {
        public No26_ImplementOldInterfaceWithGenericInterface()
        {
            //目的：
            //①古いものもサポートすることで利便性を高める

            //概要：
            //--------------------------------------------------------------------------------------
            //新しく自分で何か作る時、ジェネリクスは協力な武器になる。
            //別の機能で利用したサードパーティ製のライブラリがジェネリクスをサポートしているとは限らない。
            //可能な範囲で非ジェネリクスな領域も実装することで利便性を高める

            //利用時
            //サードパーティ製のメソッドとして仮定
            var a = new Name() { First = "aaaa", Middle = "bbbb", Last = "cccc" };
            var b = new Name() { First = "aaaa", Middle = "bbbb", Last = "cccc" };

            //エンティティ側がSystem.Object.Equalsをオーバーライド
            Checker.CheckEquality(a, b);
            //演算子をオーバーライド
            var isEqual = a == b;

            var list = new List<Name>() { a, b };
            //非ジェネリクスIComparerを実装
            list.Sort();
        }
    }
}
