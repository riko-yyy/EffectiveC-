using System;
namespace effectiveCSharp.Util
{
    public static class UseHighFrequencyVariable
    {
        //static変数を用意する
        private static Font arial;
        public static Font Arial
        {
            get
            {
                //生成も、初回のみ行うように実装
                if (arial == null)
                {
                    arial = new Font();
                }
                return arial;
            }

        }



        public class Font
        {
        }
    }
}
