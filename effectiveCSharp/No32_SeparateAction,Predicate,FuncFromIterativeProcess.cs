using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 反復処理をAction,Predicate,Funcと分離する
    /// </summary>
    public class No32_SeparateAction_Predicate_FuncFromIterativeProcess
    {
        public No32_SeparateAction_Predicate_FuncFromIterativeProcess()
        {
            //目的：
            //①delegateを用いて、処理と走査を切り離し再利用可能なメソッドを定義する

            //概要：
            //--------------------------------------------------------------------------------------
            //イテレータメソッド（yield return）は各要素を走査するものと各要素に処理を実行する２パターンに分類される
            //delegateを利用することで任意の走査、処理を外部から与えることのできるメソッドを作成する

            //利用時
            var list = new List<int>() { 1, 2, 3, 4, 4, 6, 7, 2, 2, 7, 3, 4, 4, 5 };

            //Predicate
            var result1 = IteratorMethodUseDelegate.Where(list, v => v % 2 == 0);
            var result2 = IteratorMethodUseDelegate.EveryNthItem(list, 3);

            //Action
            IteratorMethodUseDelegate.ForEach(list, v => Console.WriteLine(v));

            //Func
            var result3 = IteratorMethodUseDelegate.Select(list, v => v * v);


            //delegateでもおk
            //自クラスのメソッドを利用する場合
            Predicate<int> predicate = IsTrue;
            var result4 = IteratorMethodUseDelegate.Where(list, predicate);
            //他クラスのメソッドを利用する場合
            var a = new IteratorMethodUseDelegate();
            predicate = a.IsTrue;
            var result5 = IteratorMethodUseDelegate.Where(list, predicate);

        }

        public bool IsTrue(int item)
        {
            return true;
        }
    }
}
