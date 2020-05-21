using System;
namespace effectiveCSharp.Util
{
    public class CalledHighFrequencyClass
    {
        public CalledHighFrequencyClass()
        {
        }

        //悪い例
        public void HighFrequencyMethod1()
        {
            //呼び出すごとにmyFontを生成・破棄している
            using (Font myFont = new Font())
            {
                //myFontを利用した処理
            }
        }

        //よい例
        private readonly Font myFont = new Font();
        public void HighFrequencyMethod2()
        {
            //ローカル変数をメンバ変数へ昇格

            //myFontを利用した処理
        }

        //よい例
        public void HighFrequencyMethod3()
        {
            //実際には変数に代入せずそのままつかう
            var myFont = UseHighFrequencyVariable.Arial;
            //myFontを利用した処理
        }


        private class Font:IDisposable
        {
            public Font()
            {
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
