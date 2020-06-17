using System;
using System.Collections.Generic;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 構築された型に対する拡張メソッドを検討すること
    /// </summary>
    public class No28_AddExtensionMethodForConstructedGenericType
    {
        public No28_AddExtensionMethodForConstructedGenericType()
        {
            //目的：
            //①さらにジェネリクスの利便性を高める

            //概要：
            //--------------------------------------------------------------------------------------
            //特定の型引数が指定されたジェネリクス型（構築された型）に対して、特化したメソッドを定義したい場合、
            //その構築された型にする拡張メソッドを定義する

            //例えばSystem.Linq.Enumerableとかそう
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            list.Sum();//これはIEnumerable<int>に対する拡張メソッド

            //利用時
            //良い例
            var customers = new List<CustomerForGenerics>() { new CustomerForGenerics(), new CustomerForGenerics() , new CustomerForGenerics() };
            //メソッドチェーン
            //名前が「aaaa」の人にだけ５０％OFFクーポンを送る
            customers.Where(v => v.Name == "aaaa").SendEmailCoupons("50%OFF!");
            //30日間以上注文ない人たち
            customers.LostProspects();
            //インスタンス化しなくても利用可能
            ConstructedGenericType.SendEmailCoupons(customers, "50%OFF!");

            //悪い例
            //ストレージモデルList<CustomerForGenerics>が必須
            var customerlist = new CustomerList();
            customerlist.Where(v => v.Name == "aaaa").SendEmailCoupons("50%OFF!");
            customerlist.LostProspects();
            //インスタンス化必須
            //(No31)イテレータメソッドとの組み合わせが不可能
        }
    }
}
