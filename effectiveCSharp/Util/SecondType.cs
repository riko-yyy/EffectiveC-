using System;
namespace effectiveCSharp.Util
{
    public class SecondType
    {
        private MyType _value;

        public SecondType()
        {
        }

        /// <summary>
        /// ユーザー定義の変換演算子
        /// </summary>
        /// <param name="t"></param>
        public static implicit operator MyType(SecondType t)
        {
            return t._value;
        }

    }
}
