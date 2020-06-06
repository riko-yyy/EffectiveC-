using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// ジェネリックの共変性と反変性をサポートする
    /// </summary>
    public class No22_SupportCovarianceAndContravarianceInGenerics
    {
        public No22_SupportCovarianceAndContravarianceInGenerics()
        {
            //目的：
            //①共変性の実装：アップキャストの実装
            //②反変性の実装：親の実行でポリモーフィズムできるように実装

            //概要：
            //--------------------------------------------------------------------------------------
            IEnumerable<Asteroid> asteroids = new List<Asteroid>() {  new Asteroid() { Name = "a", Mass = 3 }
                                                                    , new Asteroid() { Name = "b", Mass = 2 }
                                                                    , new Asteroid() { Name = "c", Mass = 1 }};

            //共変性:IEnumerable<out T>が共変性をout修飾子によって実装しているおかげで、暗黙的にアップキャストできる
            //      IEnumerable<out T>はoutによって、強い型を返却することを許している
            Variance.CovariantGeneric(asteroids);

            //反変性:Comparison<in T>が反変性をin修飾子によって実装しているおかげで、ポリモーフィズムを実行できる
            //      Comparison<in T>はinによって、弱い型を受領することを許している
            Variance.ContravariantGeneric();

            //不変性:IList<T>は修飾子がないため、厳密に同じ型のみ許す
            //Variance.InVariantGeneric(asteroids);

            //したがって、自身が定義したジェネリクスクラスに、IEnumerableのような自然なアップキャストを実装したければout修飾子を用いる            
            //また、IComparer<T>とSortedSet<T>のような、自身が定義したジェネリクスクラスを引数にポリモーフィズムを実行するメソッドを実装したければin修飾子を用いる

        }
    }
}
