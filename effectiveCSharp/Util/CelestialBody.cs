using System;
using System.Diagnostics.CodeAnalysis;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// 天体の抽象クラス
    /// </summary>
    abstract public class CelestialBody : IComparable<CelestialBody>
    {
        /// <summary>
        /// 質量
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 標準は名前でソート
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo([AllowNull] CelestialBody other)
        {
           return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// 質量でソート
        /// </summary>
        public static Comparison<CelestialBody> CompareByMass => (left, right) => left.Mass.CompareTo(right.Mass);
    }

    /// <summary>
    /// 惑星クラス
    /// </summary>
    public class Planet : CelestialBody
    {

    }

    /// <summary>
    /// 月クラス
    /// </summary>
    public class Moon : CelestialBody
    {

    }

    /// <summary>
    /// 小惑星クラス
    /// </summary>
    public class Asteroid : CelestialBody
    {

    }

}
