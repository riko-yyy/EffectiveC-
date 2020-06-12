using System;
namespace effectiveCSharp.Util
{
    public class GenericsAndOverLoad
    {
        public static void WriteMessage(MyBase b)
        {
            Console.WriteLine("①");
        }

        public static void WriteMessage<T>(T obj)
        {
            Console.WriteLine("②");
        }

        public static void WriteMessage(IMessageWriter obj)
        {
            Console.WriteLine("③");
            obj.WriteMessage();
        }
    }

    public class MyBase
    {

    }

    public interface IMessageWriter
    {
        void WriteMessage();
    }

    public class MyDerived : MyBase, IMessageWriter
    {
        public void WriteMessage()
        {
            Console.WriteLine("MyDerived.WriteMessageの中");
        }
    }

    public class AnotherType : IMessageWriter
    {
        public void WriteMessage()
        {
            Console.WriteLine("AnotherType.WriteMessageの中");
        }
    }



}
