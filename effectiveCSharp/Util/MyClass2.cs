using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class MyClass2
    {
        private List<int> coll;
        private string name;

        //これ２つめのコンストラクタを呼び出し
        //ジェネリクス中で利用可能にするため、newを使えるように引数なしコンストラクタは必要
        public MyClass2() : this(0, string.Empty)
        {
        }

        //デフォルト引数の用意でさらにオーバーロードコンストラクタを少なくできる
        public MyClass2(int initialCount = 0, string name = "")
        {
            coll = (initialCount > 0) ? new List<int>(initialCount) : new List<int>();
            this.name = name;
        }
    }
}
