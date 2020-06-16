using System;
namespace effectiveCSharp.Util
{
    /// <summary>
    /// Comparableインタフェースに対して、拡張メソッドを利用して機能を拡張する
    /// </summary>
    public static class Comparable
    {
        //ジェネリクスインタフェースに対する拡張メソッドは、
        //対象のインタフェースを実装していることをジェネリクスの制約によって制限する

        //CompareToをわかりやすい命名のメソッドへ

        public static bool LessThan<T>(this T left, T right) where T : IComparable<T> => left.CompareTo(right) < 0;

        public static bool GreaterThan<T>(this T left, T right) where T : IComparable<T> => left.CompareTo(right) > 0;

        public static bool LessThanEqual<T>(this T left, T right) where T : IComparable<T> => left.CompareTo(right) <= 0;

        public static bool GreaterThanEqual<T>(this T left, T right) where T : IComparable<T> => left.CompareTo(right) >= 0;
    }
}
