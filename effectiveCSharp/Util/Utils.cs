using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class Utils
    {
        public static T Max<T>(T left, T right) => Comparer<T>.Default.Compare(left, right) < 0 ? right : left;
        public static double Max(double left, double right) => Math.Max(left, right);
    }

    public class UtilsBad<T>
    {
        public static T Max(T left, T right) => Comparer<T>.Default.Compare(left, right) < 0 ? right : left;
    }
}
