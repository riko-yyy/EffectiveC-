using System;
namespace effectiveCSharp.Util
{
    public class MySingleton
    {
        //オブジェクト初期化子で初期化
        private static readonly MySingleton theOneAndOnly = new MySingleton();

        //外からstaticメンバを取得する用のpublicメソッド
        public static MySingleton TheOnly { get { return theOneAndOnly; } }

        //通常コンストラクタをprivate化
        private MySingleton()
        {
        }
    }
}
