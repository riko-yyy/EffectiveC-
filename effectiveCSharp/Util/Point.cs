using System;
using System.IO;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// 座標
    /// </summary>
    public class Point
    {
        /// <summary>
        /// x
        /// </summary>
        public double X { get; }
        /// <summary>
        /// y
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// コンストラクタ
        /// txtみたいなストリーム(csvの１行分みたいなイメージ)を受け取って同じように初期化する
        /// </summary>
        public Point(TextReader reader)
        {
            string line = reader.ReadLine();
            string[] fields = line.Split(',');

            //x,yのフォーマットでないならエラー
            if (fields.Length != 2)
            {
                throw new InvalidOperationException("入力形式が不正です");
            }

            double value;
            if (!double.TryParse(fields[0], out value))
            {
                throw new InvalidOperationException("Xの値を解析できません");
            }
            else
            {
                this.X = value;
            }

            if (!double.TryParse(fields[1], out value))
            {
                throw new InvalidOperationException("Yの値を解析できません");
            }
            else
            {
                this.Y = value;
            }

        }

    }
}
