using System;
namespace effectiveCSharp.Util
{
    public class MyOtherType:MyType
    {
        public MyOtherType()
        {
        }

        //vertalをoverrideしているわけではないので、同名別メソッド
        public new void MagicMethod()
        {
            Console.WriteLine("1111111111111111");
        }

    }
}
