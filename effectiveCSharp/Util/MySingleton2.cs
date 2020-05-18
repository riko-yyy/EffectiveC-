using System;
namespace effectiveCSharp.Util
{
    public class MySingleton2
    {
        //staticコンストラクタで初期化
        private static readonly MySingleton2 theOneAndOnly;        
        static MySingleton2()
        {
            theOneAndOnly = new MySingleton2();
        }

        //外からstaticメンバを取得する用のpublicメソッド
        public static MySingleton2 TheOnly { get { return theOneAndOnly; } }

        //通常コンストラクタをprivate化
        private MySingleton2()
        {
        }
    }
}
