using System;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// ループよりもクエリ構文を使用すること
    /// </summary>
    public class No30_UseQuerySyntaxThanLoop
    {
        public No30_UseQuerySyntaxThanLoop()
        {
            //目的：
            //①命令的な記述をさけ、宣言的に記述することで可読性をあげる
            //②クエリ遅延実行で組み合わせたクエリを１度のみ操作できる

            //概要：
            //--------------------------------------------------------------------------------------
            //forなどで実装するとまあわかりにくいことがある
            //クエリ構文を利用していくことで読みやすくなる

            //利用時
            //例１
            //NG
            Loop.ExportSqueared();

            //OK
            QuerySyntax.ExportSqueared();

            //例２
            //NG
            Loop.Indices();

            //いまいち
            QuerySyntax.MethodIndices();
            //OK
            QuerySyntax.QueryIndices();

            //クエリかメソッドかはケースによって異なる
            //速度が遅いならAsParallelを利用する手もある
        }
    }
}
