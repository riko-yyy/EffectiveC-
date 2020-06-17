using System;
using System.Collections.Generic;
using System.Linq;

namespace effectiveCSharp.Util
{
    //良い例
    //拡張メソッドで追加
    public static class ConstructedGenericType
    {
        //CustomerForGenericsコレクションからSendEmailCoupons()が実行できる
        public static void SendEmailCoupons(this IEnumerable<CustomerForGenerics> cutstomers, string coupon)
        {
            //具体的な処理
        }

        //30日間注文がなかった顧客リストの取得
        public static IEnumerable<CustomerForGenerics> LostProspects(this IEnumerable<CustomerForGenerics> target)
        {
            return target.Where(v => DateTime.Now - v.LastOrderDate > TimeSpan.FromDays(30));
        }
    }

    //悪い例
    //派生クラスをつくる
    public class CustomerList : List<CustomerForGenerics>
    {
        public void SendEmailCoupons(string coupon)
        {
            //具体的な処理
        }

        public IEnumerable<CustomerForGenerics> LostProspects()
        { 
            return this.Where(v => DateTime.Now - v.LastOrderDate > TimeSpan.FromDays(30));
        }
    }


    public class CustomerForGenerics
    {
        public string Name { get; set; }
        public DateTime LastOrderDate { get; set; }
    }
}
