using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public static class Constraint
    {

        //悪い例：メソッド中で利用したいメソッドが利用可能か、isを用いた検証処理が必要
        public static bool AreEqual<T>(T left, T right)
        {
            //nullなら両方nullか
            if (left == null)
            {
                return right == null;
            }

            //leftがIComparable<T>を実装しているか検証
            if (left is IComparable<T>)
            {
                //キャスト
                IComparable<T> lval = left as IComparable<T>;

                //rightがIComparable<T>を実装しているか検証
                if (right is IComparable<T>)
                {
                    return lval.CompareTo(right) == 0;
                }
                else
                {
                    throw new ArgumentException("IComparable<T>が実装されていない型です", nameof(right));
                }

            }
            else
            {
                throw new ArgumentException("IComparable<T>が実装されていない型です", nameof(left));
            }
        }

        //良い例：制約でTがIComparable<T>を実装していることを保証している
        public static bool AreEqual2<T>(T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) == 0;
        }


        //制約を利用するか悩む例
        //制約なし
        public static bool AreEqual3<T>(T left, T right) => left.Equals(right);
        //制約あり
        public static bool AreEqual4<T>(T left, T right) where T : IEquatable<T> => left.Equals(right);

        //Tに応じて、IEquatable<T>.Equals()もしくはSystem.Object.Equals()が使用される
        //値型の場合、ボックス化が実行されオーバーヘッドが生じ得る。
        //回避するためにIEquatable<T>の制約するのも良いが、このメソッドを利用するクラス全てがIEquatable<T>の実装を強制される
        //そこであえて「悪い例」のように型チェックごとに内部で利用するメソッドを変えてもOK




        //new制約の取り扱い
        //制約は最小限に留めたいため、避けれられるものは避けたい。
        //デフォルトコンストラクタはdefault()によって回避できる可能性がある
        //default
        public static T FirstOrDefault<T>(this IEnumerable<T> sequence, Predicate<T> test)
        {
            foreach (T value in sequence)
            {
                if (test(value))
                {
                    return value;
                }
            }

            return default;
        }

        //new制約
        public delegate T FactoryFunc<T>();
        public static T Factory<T>(FactoryFunc<T> makeANewT) where T : new()
        {
            T rVal = makeANewT();
            if (rVal ==null)
            {
                return new T();
            }
            else
            {
                return rVal;
            }

        }

    }
}
