using System;
namespace effectiveCSharp.Util
{
    public class Abstract
    {
        protected Abstract()
        {
            Func();
        }

        protected virtual void Func()
        {
            Console.WriteLine("親だよ");
        }

    }
}
