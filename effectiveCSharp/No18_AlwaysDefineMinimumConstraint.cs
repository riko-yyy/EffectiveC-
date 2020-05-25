using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 最低限必須となる制約を常に定義すること
    /// </summary>
    public class No18_AlwaysDefineMinimumConstraint
    {
        private const string V = "aaaa";

        public No18_AlwaysDefineMinimumConstraint()
        {
            //目的：
            //①実行時の検証ではなくコンパイル時に検証可能

            //概要：
            //--------------------------------------------------------------------------------------
            //ジェネリクスに型引数として渡り得る型に制約を設けることで、コンパイル時にエラーを発見する
            //ただし、制約をかけすぎると使いにくいメソッドとなるため、最小限に止める

            //利用時
            Constraint.AreEqual(1,1);
            Constraint.AreEqual2(1, 1);
            Constraint.AreEqual3(1, 1);
            Constraint.AreEqual4(1, 1);

            IEnumerable<int> a = new List<int>() { 1, 2, 3 };
            a.FirstOrDefault(v => v == 1);

            Constraint.Factory<MyClass>(() => { return new MyClass(); });
        }
    }
}
