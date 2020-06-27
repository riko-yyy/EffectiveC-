using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// シーケンス用の組み合わせ可能なAPIを作成する
    /// </summary>
    public class No31_DefineApiConbinableSequence
    {
        public No31_DefineApiConbinableSequence()
        {
            //目的：
            //①遅延実行で組み合わせたクエリを１度のみ操作できる

            //概要：
            //--------------------------------------------------------------------------------------
            //イテレータメソッド（yield return）を実装することで、
            //再利用可能な遅延実行メソッドを実装できる

            //利用時
            var nums = new List<int>() { 1, 1, 2, 3, 3, 4, 5, 6, 7, 8 };
            var list = new List<string>() { "a", "b", "a", "d", "c", "d", "j", "i", "d", "j", };

            //NG
            //処理が１つに内包されていて、再利用不可能
            ProduceMethod.UniqueWrite(nums);

            //OK
            //イテレータメソッドとすることで再利用可能に
            IteratorMethod.UniqueWrite(nums);

            //さらにジェネリクスにすることで再利用可能に
            var res = IteratorMethod.Unique(list);
        }
    }
}
