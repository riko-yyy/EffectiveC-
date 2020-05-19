using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class MyClass
    {
        private List<int> coll;
        private readonly string name;

        //これ3つめのコンストラクタを呼び出し
        public MyClass() : this(0, "")
        {
        }

        //これ3つめのコンストラクタを呼び出し
        public MyClass(int initialCount) : this(initialCount, string.Empty)
        {
        }

        public MyClass(int initialCount, string name)
        {
            coll = (initialCount > 0) ? new List<int>(initialCount) : new List<int>();
            this.name = name;
        }


    }
}
