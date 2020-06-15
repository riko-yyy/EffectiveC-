using System;
namespace effectiveCSharp.Util
{
    /// <summary>
    /// 比較
    /// </summary>
    public class Checker
    {
        //NG:参照の同値性をチェックしてしまう
        public static bool CheckEquality(object left, object right)
        {
            if (left == null)
            {
                return right == null;
            }
            else
            {
                return left.Equals(right);
            }
        }

        //OK:IEquatable<T>を実装したクラスのEqualsを利用できる
        public static bool CheckEquality<T>(T left, T right) where T : IEquatable<T>
        {
            if (left == null)
            {
                return right == null;
            }
            else
            {
                return left.Equals(right);
            }
        }
    }
}
