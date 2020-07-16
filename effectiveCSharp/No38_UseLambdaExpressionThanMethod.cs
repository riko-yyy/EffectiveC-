using System;
using System.Collections.Generic;
using effectiveCSharp.Util;
using System.Linq;

namespace effectiveCSharp
{
    /// <summary>
    /// メソッドよりもラムダ式を使用すること
    /// </summary>
    public class No38_UseLambdaExpressionThanMethod
    {
        public No38_UseLambdaExpressionThanMethod()
        {
            //目的：
            //①ラムダ式をつかいなさい

            //概要：
            //--------------------------------------------------------------------------------------
            //ラムダ式を利用して、意味のあるコードブロックをメソッドとして定義して再利用する
            //条件部をメソッドとして抽出する方法はLinqToSQLなどIQueryableで実行できないためコードブロックとして切り出す

            //例
            var allEmployees = new List<Employee>() { new Employee() { Name = "a", Age = 1, Salary = 1 }, new Employee() { Name = "b", Age = 2, Salary = 2 }, new Employee() { Name = "c", Age = 3, Salary = 3 }, };

            //複数whereは&&でもOK
            var over1 = from e in allEmployees
                        where e.Age > 1
                        where e.Salary > 1
                        select e;

            var over2 = from e in allEmployees
                        where e.Age > 1
                        where e.Salary > 2
                        select e;

            //こういう場合、よく利用する集合を返却するメソッドを作成すればよい
            //クローズジェネリックの拡張メソッドを定義すると、さらにLINQで利用できる
            //この際IEnumerable<T>,IQueryable<T>を定義するとLINQtoObject、LINQtoSQL両方をサポートできる

            var over3 = from e in allEmployees.OverOneAge()
                        where e.Salary > 3
                        select e;

        }
    }
}
