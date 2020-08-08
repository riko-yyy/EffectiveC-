using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    public class No43_ExpressQueryResultUsingSingleOrFirst
    {
        /// <summary>
        /// クエリに期待する意味をSingle()やFirst()を使用して表現すること
        /// </summary>
        public No43_ExpressQueryResultUsingSingleOrFirst()
        {
            //目的：
            //単一の結果が欲しい場合、Single()やFirst()をクエリ中で用いる

            //概要：
            //--------------------------------------------------------------------------------------
            //意図した結果とならない場合、例外をスローするので早期発見に繋がる

            //例
            var allEmployees = new List<Employee>() { new Employee() { Name = "a", Age = 1, Salary = 1 }, new Employee() { Name = "b", Age = 2, Salary = 2 }, new Employee() { Name = "c", Age = 3, Salary = 3 }, };

            //複数いるorいないと例外
            var nameIsA = (from e in allEmployees.AsEnumerable()
                           where e.Name == "a"
                           select e).Single();
            //複数いると例外
            nameIsA = (from e in allEmployees.AsEnumerable()
                       where e.Name == "a"
                       select e).SingleOrDefault();

            //いないと例外
            var saralyIs1 = (from e in allEmployees.AsEnumerable()
                             where e.Salary == 1
                             select e).First();
            //例外なし
            saralyIs1 = (from e in allEmployees.AsEnumerable()
                         where e.Salary == 1
                         select e).FirstOrDefault();

            //２番目とか
            //これやるなら、ToList()してインデックスで指定するような形も選択肢としてある
            saralyIs1 = (from e in allEmployees.AsEnumerable()
                         where e.Salary == 1
                         select e).Skip(1).First();
        }
    }
}
