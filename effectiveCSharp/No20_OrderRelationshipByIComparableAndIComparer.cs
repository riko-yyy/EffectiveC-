using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// IComparable<T>とIComparer<T>により順序関係を実装する
    /// </summary>
    public class No20_OrderRelationshipByIComparableAndIComparer
    {
        public No20_OrderRelationshipByIComparableAndIComparer()
        {
            //目的：
            //①コレクションをソートする際の順序関係を定義する

            //概要：
            //--------------------------------------------------------------------------------------
            //順序関係の判断を拡張し、自作のソート機能を提供する

            //利用時
            var customers = new List<CustomerForCompare>();
            customers.Add(new CustomerForCompare("B", 1000));
            customers.Add(new CustomerForCompare("A", 800));
            customers.Add(new CustomerForCompare("D", 700));
            customers.Add(new CustomerForCompare("C", 900));
            customers.Add(new CustomerForCompare("F", 600));

            customers.ForEach(v => { Console.WriteLine($"name:{v.name},revenue:{v.revenue}"); });

            //CompareTo
            var resultNameInt = customers[0].CompareTo(customers[1]);

            //CompareToを利用したオーバーロード比較演算子
            var resultNameBool = customers[0] < customers[1];

            //ソート
            //CompareToはList<T>.Sort()やSortedList<T>.Addなどで標準的に呼ばれる
            customers.Sort();
            customers.ForEach(v => { Console.WriteLine($"name:{v.name},revenue:{v.revenue}"); });

            //revenueで比較（自作クラス向け）
            var resultRevenueInt1 = CustomerForCompare.CompareByRevenue(customers[0], customers[1]);
            //revenueでソート
            customers.Sort(CustomerForCompare.CompareByRevenue);
            customers.ForEach(v => { Console.WriteLine($"name:{v.name},revenue:{v.revenue}"); });

            //revenueで比較（.NET標準クラス向け）
            var resultRevenueInt2 = CustomerForCompare.RevenueCompare.Compare(customers[0], customers[1]);
            //revenueでソート
            customers.Sort(CustomerForCompare.RevenueCompare); 
            customers.ForEach(v => { Console.WriteLine($"name:{v.name},revenue:{v.revenue}"); });
        }
    }
}
