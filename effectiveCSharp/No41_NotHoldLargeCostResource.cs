using System;
using System.IO;
using System.Linq;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// コストのかかるリソースを維持し続けないこと
    /// </summary>
    public class No41_NotHoldLargeCostResource
    {
        public No41_NotHoldLargeCostResource()
        {
            //目的：
            //遅延実行の挙動を理解し、高級なリソースの保持を避ける

            //概要：
            //--------------------------------------------------------------------------------------
            //遅延実行を利用する場合、そのメソッドに対してコンパイラはクロージャクラスを作成する
            //このときクロージャクラスのオブジェクトがメソッドの返却値として利用された場合、その返却値の利用者がいなくなるまで解放されない

            //①低級なローカル変数(プリミティブなど)
            var low = new LowVariable();
            var res = low.MakeSequence();

            //ここで走査が完了することでメソッド中のcounter,numbersをリソースからようやく解放できる
            foreach (var v in res)
            {
                Console.WriteLine(v);
            }

            //②高級なローカル変数(アンマネージリソース)
            //NG
            //走査時に実アクセスするため、usingを抜けた後にファイルアクセスを試みる
            using (var t = new StreamReader(File.OpenRead("TestFile.txt")))
            {
                var rowOfNumbers = HighVariable.ReadNumbersFromStream(t);
            }
            //OK
            //usingを閉じ込める
            var rowOfNumbers1 = HighVariable.ReadNumbersFromStream("TestFile.txt");

            //またこのとき、同じ変数に対して2回以上走査するとその都度Disposeされる
            foreach (var v in rowOfNumbers1)
            {
                Console.WriteLine(v);
            }
            foreach (var v in rowOfNumbers1)
            {
                Console.WriteLine(v);
            }
            //ここで2回目のDisposeでエラー

            //このようなアルゴリズムを実装したい場合、Disposeされる直前に走査するような実装になる
            var max = HighVariable.ProcessFile("TestFile.txt",(arrayOfNums)=> (from line in arrayOfNums
                                                                                         select line.Max()).Max());


        }
    }
}
