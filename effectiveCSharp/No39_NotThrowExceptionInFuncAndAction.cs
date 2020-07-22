using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// FuncやAction内では例外をスローしないこと
    /// </summary>
    public class No39_NotThrowExceptionInFuncAndAction
    {
        public No39_NotThrowExceptionInFuncAndAction()
        {
            //目的：
            //①Func、Actionを引き渡すとき、それが例外を吐かないようにする

            //概要：
            //--------------------------------------------------------------------------------------
            //シーケンスに対してFuncやActionを実行するとき、それは要素をトレースしない
            //したがってロールバック不可であるため、そもそも例外を吐かないように実装する
            //基本的に、参照は問題なく値の変更をする場合に問題が発生する

            //例
            var allEmployees = new List<Employee>() { new Employee() { Name = "a", Age = 1, Salary = 1 }, new Employee() { Name = "b", Age = 2, Salary = 2 }, new Employee() { Name = "c", Age = 3, Salary = 3 }, };

            //NG
            //給料を２倍にする
            allEmployees.ForEach(v => v.Salary *= 2);
            //このコードが例外を吐くと、どこまで２倍が完了しているのかわからなくなる

            //対策
            //①例外がおこりうる要素を集合から外す
            //２倍になるのは３年目から
            allEmployees.FindAll(v => v.Age > 2).ForEach(v => v.Salary *= 2);

            //②例外が起こりうる要素群を、新しいシーケンスとして作成する（拡張メソッドや通常メソッド）
            allEmployees = GradeUp(allEmployees).ToList();
        }

        public IEnumerable<Employee> GradeUp(IEnumerable<Employee> seq)
        {
            foreach (var v in seq)
            {
                v.Salary *= 2;
            }

            return seq;
        }

    }
}
