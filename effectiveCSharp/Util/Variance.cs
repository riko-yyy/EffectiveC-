using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class Variance
    {
        public Variance()
        {
        }

        /// <summary>
        /// 共変的でタイプセーフなメソッド
        /// </summary>
        /// <param name="baseItems"></param>
        public static void CoVariantArray(CelestialBody[] baseItems)
        {
            foreach (var thing in baseItems)
            {
                Console.WriteLine($"{thing.Name}の質量は{thing.Mass}kgです");
            }
        }

        /// <summary>
        /// 共変的だが例外となるメソッド
        /// </summary>
        /// <param name="baseItems"></param>
        public static void UnsafeVariantArray(CelestialBody[] baseItems)
        {
            //これがエラーとなるのは、要素のクラスにおいて共変性が成立する場合、配列単位でその共変性が成立しないといけないから
            //CelestialBody[]なら全ての要素がCelestialBodyで
            //これに対する共変性は全ての要素がAsteroidのAsteroid[]である
            baseItems[0] = new Asteroid { Name = "Hygiea", Mass = 8.85e19 };
        }

        /// <summary>
        /// ジェネリクスにおける共変性.上記の引数を配列にとるメソッドと同じことができる
        /// C#4.0以前はこれができなかった.可能なのはIEnumerable<out T>が共変性（強い型を返却する）を実装し、利用者側が自然にアップキャストできるため
        /// </summary>
        /// <param name="baseItems"></param>
        public static void CovariantGeneric(IEnumerable<CelestialBody> baseItems)
        {
            foreach (var thing in baseItems)
            {
                Console.WriteLine($"{thing.Name}の質量は{thing.Mass}kgです");
            }
        }

        /// <summary>
        /// ジェネリクスにおける不変性.IList<T>はout修飾子がないため、方が厳密に一致してないとダメ
        /// </summary>
        /// <param name="baseItems"></param>
        public static void InVariantGeneric(IList<CelestialBody> baseItems)
        {
            baseItems[0] = new Asteroid { Name = "Hygiea", Mass = 8.85e19 };
        }

        /// <summary>
        /// ジェネリクスにおける反変性.
        /// C#4.0以前はこれができなかった.可能なのはComparison<in T>が反変性（弱い型を受領する）を実装し、利用者側が自然にポリモーフィズムを実行できるため
        /// </summary>
        /// <param name="baseItems"></param>
        public static void ContravariantGeneric()
        {

            List<Asteroid> asteroids = new List<Asteroid>() { };
            asteroids.Add(new Asteroid() { Name = "a", Mass = 3 });
            asteroids.Add(new Asteroid() { Name = "b", Mass = 2 });
            asteroids.Add(new Asteroid() { Name = "c", Mass = 1 });

            asteroids.Sort(CelestialBody.CompareByMass);

        }
    }
}
