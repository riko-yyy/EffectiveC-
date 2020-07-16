using System;
using System.Collections.Generic;
using System.Linq;

namespace effectiveCSharp.Util
{
    public static class ExtensionLinq
    {
        public static IEnumerable<Employee> OverOneAge(this IEnumerable<Employee> seq)
        {
            return from e in seq
                   where e.Age > 1
                   select e;
        }

        public static IQueryable<Employee> OverOneAge(this IQueryable<Employee> seq)
        {
            return from e in seq
                   where e.Age > 1
                   select e;
        }
    }
}
