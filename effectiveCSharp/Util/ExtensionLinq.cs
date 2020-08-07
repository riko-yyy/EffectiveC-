using System;
using System.Collections.Generic;
using System.Linq;

namespace effectiveCSharp.Util
{
    //データソースに応じてどちらのメソッドを実装するかは決定する
    //両方実装する場合は以下のようにするとよい
    public static class ExtensionLinq
    {
        public static IEnumerable<Employee> OverOneAge(this IEnumerable<Employee> seq)
        {
            //AsQueryable()はシーケンスがIQueryableを実装している場合、シーケンスをIQueryableに変換して返却し
            //実装していない場合、IQueryableを実装するラッパーを返却する
            //つまりIQueryableが利用できれば利用し、できなければIEnumerableとして動作する
            return OverOneAge(seq.AsQueryable());
        }

        public static IQueryable<Employee> OverOneAge(this IQueryable<Employee> seq)
        {
            return from e in seq
                   where e.Age > 1
                   select e;
        }
    }
}
