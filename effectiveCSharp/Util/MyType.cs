using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class MyType
    {
        //良い例
        private List<int> labels = new List<int>();
        public MyType()
        {
        }

        //悪い例①
        private int num = 0;
        private string line = null;

        //悪い例②
        private List<int> list1 = new List<int>();
        public MyType(int size)
        {
            list1 = new List<int>(size);
        }

        //悪い例(こういうことしたいなら)③
        private string line1;
        public MyType(string moji)
        {
            try
            {
                if (moji.Length >= 10)
                {
                    line1 = moji;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {
                line1 = "10文字以上じゃないとだめよ";
            }
        }

        public string MyMethodUpdate()
        {
            return default(string);
        }

        public void MagicMethod()
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaa");
        }
    }
}
