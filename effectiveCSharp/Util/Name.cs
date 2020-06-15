using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace effectiveCSharp.Util
{
    public class Name : IComparable<Name>, IEquatable<Name>, IComparable
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }

        /// <summary>
        /// IComparable<Name>の実装
        /// 順序性のサポート
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] Name other)
        {
            //同じ場合
            if (Object.ReferenceEquals(this, other))
            {
                return 0;
            }
            //比較対象がnullの場合
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            //stringの比較を用いる
            //First=>Middleの順
            int rVal = Comparer<string>.Default.Compare(First, other.First);
            if (rVal != 0)
            {
                return rVal;
            }
            else
            {
                return Comparer<string>.Default.Compare(Middle, other.Middle);
            }
        }

        /// <summary>
        /// IComparableの実装
        /// Sort()に対して
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj.GetType() != typeof(Name))
            {
                throw new ArgumentException("引数はNAmeオブジェクトではありません");
            }
            //実処理はIComparable<T>.CompareTo()
            return this.CompareTo(obj as Name);
        }

        /// <summary>
        /// IEquatable<Name>の実装
        /// 同値性のサポート
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Name other)
        {
            //インスタンスとして同じ場合
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            //nullの場合
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            //インスタンス別で同じ場合
            return Last == other.Last
                && First == other.First
                && Middle == other.Middle;
        }

        /// <summary>
        /// 比較メソッドが外部ライブラリに存在し、それがSystem.Object.Equalsを利用している場合があるので
        /// 作成するエンティティ側でオーバーライドし、実処理をIEquatable<Name>の実装とする
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //派生クラスの場合、親クラスを同一とみなさないようにチェックする
            if (obj.GetType() == typeof(Name))
            {
                return this.Equals(obj as Name);
            }
            return false;
        }

        /// <summary>
        /// System.Object.Equalsのオーバーライドに併せて
        /// 意味的に同一ならHashCodeは同一となるべきなので
        /// .NET ver 1.x 向け
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            //XOR
            int hashCode = 0;
            if (Last != null)
            {
                hashCode ^= Last.GetHashCode();
            }
            if (First != null)
            {
                hashCode ^= First.GetHashCode();
            }
            if (Middle != null)
            {
                hashCode ^= Middle.GetHashCode();
            }
            return hashCode;
        }

        /// <summary>
        /// 演算子（==）
        /// 外部ライブラリで比較に==を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Name left, Name right)
        {
            if (left == null)
            {
                return right == null;
            }
            return left.Equals(right);
        }

        /// <summary>
        /// 演算子（!=）
        /// 外部ライブラリで比較に!=を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Name left, Name right)
        {
            if (left == null)
            {
                return right != null;
            }
            return !left.Equals(right);
        }

        /// <summary>
        /// 演算子（<）
        /// 外部ライブラリで比較に<を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Name left, Name right)
        {
            if (left == null)
            {
                return right != null;
            }
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// 演算子（>）
        /// 外部ライブラリで比較に>を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Name left, Name right)
        {
            if (left == null)
            {
                return false;
            }
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// 演算子（<=）
        /// 外部ライブラリで比較に<=を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Name left, Name right)
        {
            if (left == null)
            {
                return true;
            }
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// 演算子（>=）
        /// 外部ライブラリで比較に>=を利用しているところに対して
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Name left, Name right)
        {
            if (left == null)
            {
                return right == null;
            }
            return left.CompareTo(right) >= 0;
        }

    }
}
