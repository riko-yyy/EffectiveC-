using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace effectiveCSharp.Util
{

    /// <summary>
    /// 顧客
    /// </summary>
    public class CustomerForCompare : IComparable<CustomerForCompare>, IComparable
    {
        /// <summary>
        /// 氏名
        /// </summary>
        public string name { get; }

        /// <summary>
        /// 所得
        /// </summary>
        public double revenue { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public CustomerForCompare(string name, double revenue)
        {
            this.name = name;
            this.revenue = revenue;
        }


        //-----------------------------------------------IComparable<Customer>の実装
        //インスタンスの並べ替えを目的とする型固有の汎用比較メソッドをサポートするインタフェース(ジェネリクス)

        /// <summary>
        /// 比較メソッド(ジェネリクス)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CustomerForCompare other) => name.CompareTo(other.name);


        //-----------------------------------------------IComparableの実装
        //インスタンスの並べ替えを目的とする型固有の汎用比較メソッドをサポートするインタフェース(非ジェネリクス)

        /// <summary>
        /// 比較メソッド(非ジェネリクス)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            //引数がobjectでありボックス化のオーバヘッドが生じるため、なるべく使用は避けたい
            //そこでメソッドを明示的に実装し、呼び出しも明示的でないとできないようにする
            if (!(obj is CustomerForCompare))
            {
                throw new ArgumentException("引数はCustomer型ではありません", nameof(obj));
            }
            var otherCustomer = obj as CustomerForCompare;
            return this.CompareTo(otherCustomer);

        }

        //-----------------------------------------------関係演算子(<,>,<=,>=)のオーバーロード
        public static bool operator <(CustomerForCompare left, CustomerForCompare right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(CustomerForCompare left, CustomerForCompare right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(CustomerForCompare left, CustomerForCompare right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(CustomerForCompare left, CustomerForCompare right)
        {
            return left.CompareTo(right) >= 0;
        }

        //-----------------------------------------------他メンバ変数の比較メソッド実装(Comparison利用)
        //自作クラスに対して内部に定義して利用

        /// <summary>
        /// 比較メソッド()
        /// </summary>
        public static Comparison<CustomerForCompare> CompareByRevenue => (left, right) => left.revenue.CompareTo(right.revenue);

        //-----------------------------------------------他メンバ変数の比較メソッド実装(IComparer利用)
        //.NET内で定義された、ソースコードにアクセスできないクラスに対して、下記のクラスのみ定義して利用

        /// <summary>
        /// revenue比較のためだけの内部クラス
        /// </summary>
        private class RevenueComparer : IComparer<CustomerForCompare>
        {
            //-----------------------------------------------IComparable<Customer>の実装
            //インスタンスの並べ替えを目的とする型固有の汎用比較メソッドをサポートするインタフェース(ジェネリクス)

            /// <summary>
            /// 比較
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            int IComparer<CustomerForCompare>.Compare(CustomerForCompare left, CustomerForCompare right) => left.revenue.CompareTo(right.revenue);
        }

        /// <summary>
        /// 遅延実行用にデリゲートを登録
        /// Valueが呼び出された時だけ実行
        /// </summary>
        private static Lazy<RevenueComparer> revenueComparer = new Lazy<RevenueComparer>(() => new RevenueComparer());

        /// <summary>
        /// 外部公開用のインタフェース
        /// </summary>
        public static IComparer<CustomerForCompare> RevenueCompare => revenueComparer.Value;

        



    }
}
