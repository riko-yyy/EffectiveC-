using System;
using System.Text;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 不必要なオブジェクトの生成を避ける
    /// </summary>
    public class No15_AvoidCreateUnnecessaryInstance
    {
        public No15_AvoidCreateUnnecessaryInstance()
        {
            //目的：
            //①呼び出し頻度の多いメソッドにおける参照型オブジェクト生成→破棄の頻度を減らす

            //概要：
            //--------------------------------------------------------------------------------------
            //参照型オブジェクト生成・破棄頻度を減らす
            //方法は以下３つ
            //1)ローカル変数をメンバ変数に昇格させる
            //2)staticメンバ変数を利用する
            //3)stringBuilderを利用する

            //例：
            //--------------------------------------------------------------------------------------
            //1)ローカル変数をメンバ変数に昇格させる
            var a = new CalledHighFrequencyClass();
            a.HighFrequencyMethod1();
            a.HighFrequencyMethod2();

            //--------------------------------------------------------------------------------------
            //2)staticメンバ変数を利用する
            a.HighFrequencyMethod3();

            //--------------------------------------------------------------------------------------
            //3)stringBuilderを利用する

            //悪い例；インスタンスが毎回再生成される
            string msg = "aaaaa";
            msg += "aaaaa";
            msg += "aaaaa";

            //良い例；可変オブジェクトとして生成される
            StringBuilder msgBuilder = new StringBuilder("aaaaa");
            msgBuilder.Append("aaaaa");
            msgBuilder.Append("aaaaa");
            msgBuilder.ToString();

        }
    }
}
