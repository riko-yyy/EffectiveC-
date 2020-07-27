using System;
namespace effectiveCSharp
{
    /// <summary>
    /// 即時実行と遅延実行を区別すること
    /// </summary>
    public class No40_DistinguishImmediateExecutionFromDelayedExecution
    {
        public No40_DistinguishImmediateExecutionFromDelayedExecution()
        {
            //目的：
            //①アルゴリズムの実現に対して、データを引数とするかメソッドを引数とするかという視点をもつ

            //概要：
            //--------------------------------------------------------------------------------------
            //上記の視点でアルゴリズムを設計する。観点は以下
            //①入出力空間のサイズと計算結果出力コストのバランス
            //②計算コストとストレージコストのバランス

            //例:どっちを使用するか
            DoSomething(SubMethod());
            DoSomething(SubMethod);

            //①入出力空間のサイズ
            //入出力サイズが大きい（引数が大きい）場合、内部で必要な分だけ作成すれば良いので
            DoSomething(SubMethod);
            //入出力サイズが小さい（引数が小さい）場合、まあ渡せばいい
            DoSomething(SubMethod());

            //②計算コストとストレージコストのバランス
            //計算コストが低い場合、再計算すればリソース消費しないので
            DoSomething(SubMethod);
            //計算結果出力コストが高い場合、再計算よりメモリに保存した方が性能が良いので
            DoSomething(SubMethod());

        }

        private static void DoSomething(string arg)
        {
            Console.WriteLine(arg);
        }

        private static void DoSomething(Func<string> func)
        {
            Console.WriteLine(func);
        }

        private static string SubMethod()
        {
            return default;
        }

    }
}
