using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// IEnumerableとIQueryableを区別すること
    /// </summary>
    public class No42_KnowDifferenceBetweenIEnumerableAndIQueryable
    {
        public No42_KnowDifferenceBetweenIEnumerableAndIQueryable()
        {
            //目的：
            //IEnumerableとIQueryableの違いを把握し、データソースに適したアクセスを行う

            //概要：
            //--------------------------------------------------------------------------------------
            //IEnumerableはデリゲートで扱うのに対し、IQueryableは式ツリーとして扱う
            //これにより、IEnumerableはローカルで処理されるのに対し、IQueryableは式ツリーはクエリとして解釈されその結果を取得する
            //基本使用はIQueryableを推奨

            //例
            var allEmployees = new List<Employee>() { new Employee() { Name = "a", Age = 1, Salary = 1 }, new Employee() { Name = "b", Age = 2, Salary = 2 }, new Employee() { Name = "c", Age = 3, Salary = 3 }, };

            //別物
            var over1 = from e in allEmployees.AsEnumerable()
                        where e.Age > 1
                        where e.Salary > 1
                        select e;

            var over2 = from e in allEmployees.AsQueryable()
                        where e.Age > 1
                        where e.Salary > 1
                        select e;

            //IQueryableの場合、クエリに解釈されるのでクエリに変換できるメソッドのみLinq中で利用できる
            //動作する
            var over3 = from e in allEmployees.AsEnumerable()
                        where IsOverOneAge(e)
                        select e;
            //例外となる
            var over4 = from e in allEmployees.AsQueryable()
                        where IsOverOneAge(e)
                        select e;


        }

        private bool IsOverOneAge(Employee emp)
        {
            return emp.Age > 1;
        }
    }
}
