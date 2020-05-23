using System;
namespace effectiveCSharp.Util
{
    public class Derived : Abstract
    {
        private readonly string msg = "子の初期化子だよ";

        public Derived(string msg)
        {
            this.msg = msg;
        }

        protected override void Func()
        {
            Console.WriteLine(msg);
        }

        public static void MainDerived()
        {
            var d = new Derived("子のMainコンストラクタだよ");
        }
    }
}
