using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// クエリ式とメソッド呼び出しの対応を把握する
    /// </summary>
    public class No36_GraspCorrespondenceBetweenQueryAndMethod
    {
        public No36_GraspCorrespondenceBetweenQueryAndMethod()
        {
            //目的：
            //①クエリ式を独自に実装する場合に備えて、クエリ式とメソッドの対応を把握する

            //概要：
            //--------------------------------------------------------------------------------------
            //LINQのクエリ式はコンパイル時にメソッドに変換されるシュガーシンタックスである
            //このことは、クエリ式を独自の実装する際に必要であるため、抑えておく

            //前提としてクエリ式→メソッドへの変換は、コンパイル時に型バインディングやオーバーロードの解決より前に行われる

            var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var numbers1 = new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            var employees = new List<Employee>() { new Employee() { Name = "a", Age = 1, Salary = 1 }, new Employee() { Name = "b", Age = 2, Salary = 2 }, new Employee() { Name = "c", Age = 3, Salary = 3 }, };

            //where
            //クエリ
            var smallNumbers = from n in numbers
                               where n < 5
                               select n;
            //メソッド
            numbers.Where(n => n < 5);


            //select
            //入出力シーケンスを比較して、同一となるかどうかでselectは省略される
            //クエリ式1
            smallNumbers = from n in numbers
                           where n < 5
                           select n;
            //メソッド1
            numbers.Where(n => n < 5);

            //クエリ式2
            var allNumbers = from n in numbers
                             select n;
            //メソッド2
            numbers.Select(n => n);

            //クエリ式3
            var squares = from n in numbers
                          select new { Number = n, Square = n * n };
            //メソッド3
            numbers.Select(n => new { Number = n, Square = n * n });


            //orderby
            //クエリ式
            var people = from e in employees
                         where e.Age > 2
                         orderby e.Name, e.Age, e.Salary descending
                         select e;
            //メソッド
            employees.Where(e => e.Age > 2)
                     .OrderBy(e => e.Name)
                     .ThenBy(e => e.Age)
                     .ThenByDescending(e => e.Salary);


            //groupby
            //クエリ式
            var res = from e in employees
                      group e by e.Age into d
                      select new { Key = d.Key, Employees = d.AsEnumerable() };
            //メソッド
            employees.GroupBy(e => e.Age)
                     .Select(d => new { Key = d.Key, Employees = d.AsEnumerable() });


            //複数のfrom(cross join)
            //クエリ式
            var pair = from n in numbers
                       from n1 in numbers1
                       select new { n, n1, Sum = n + n1 };
            //メソッド
            numbers.SelectMany(n => numbers1, (n, n1) => new { n, n1, Sum = n + n1 });


            //join
            //クエリ式1
            var query = from n in numbers
                        join e in employees on n equals e.Age
                        select new { n, e };
            //メソッド1
            numbers.Join(employees, n => n, e => e.Age, (n, e) => new { n, e });

            //クエリ式2(グループ化してシーケンスを返却)
            var query1 = from n in numbers
                    join e in employees on n equals e.Age
                    into es
                    select new { n, es };
            //メソッド2
            numbers.GroupJoin(employees, n => n, e => e.Age, (n, es) => new { n, es });
        }
    }
}
