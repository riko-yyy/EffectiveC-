using System;
using System.Collections.Generic;
using effectiveCSharp.Util;
namespace effectiveCSharp
{
    /// <summary>
    /// 型引数がインスタンスのフィールドではない場合にはジェネリックメソッドとして定義すること
    /// </summary>
    public class No25_DefineGenericMethodWhenTypeParameterUsedClassField
    {
        public No25_DefineGenericMethodWhenTypeParameterUsedClassField()
        {
            //目的：
            //①メソッドの追加が後からしやすい
            //②より適切な処理をオーバ〜ロードで実装できる

            //概要：
            //--------------------------------------------------------------------------------------
            //ジェネリクスの利用はその型引数がジェネリクスクラスのメンバ変数となるような、内部の状態を表現する場合を除き
            //ジェネリクスメソッドとして利用するのがよい

            //利用時

            //悪い例
            //型引数がいちいち必要
            double dMax = UtilsBad<double>.Max(1.5, 2.3);

            //良い例
            //型があればオーバーロードが採用される
            double max = Utils.Max(1.5, 2.3);
            //ないならジェネリクス
            string sMax = Utils.Max("aaaaa", "bbbbb");


            //staticでないクラスについても同じ
            var builder = new CommaSeparatedListBuilder();

            var slist = new List<string>() { "a", "b", "c" };
            var ilist = new List<int>() { 1, 2, 3 };
            var blist = new List<bool>() { true, false, true };

            //内部的にはToString()あとのでコレクションに追加されているため、
            //別の型同士でも同じコレクションに格納していける
            builder.Add<string>(slist);
            builder.Add<int>(ilist);
            builder.Add<bool>(blist);

            var s = builder.ToString();

            //もし、ジェネリクスクラスとしていると、同じ型のみのコレクションしかできない
        }
    }
}
