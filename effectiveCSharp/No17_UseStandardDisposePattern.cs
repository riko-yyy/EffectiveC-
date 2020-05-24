using System;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 標準的なDisposeパターンを実装する
    /// </summary>
    public class No17_UseStandardDisposePattern
    {
        public No17_UseStandardDisposePattern()
        {
            //目的：
            //①リソースを保持するオブジェクトを適切に破棄する

            //概要：
            //--------------------------------------------------------------------------------------
            //リソースの破棄が必要な場合、標準的ないDisposeパターンを実装する
            //以下のいずれかの場合、必要
            //1)該当クラスがマネージリソース（IDisposableを実装する他のオブジェクト）を保持する場合
            //2)該当クラスがアンマネージリソース（.NETの外の世界のオブジェクト）を保持する場合

            //利用時
            using (var abs = new AbstractResourceHog())
            {
                //処理
                //usingを抜けるタイミングでDispose()が呼び出される
            }

            using (var dev = new DerivedResourceHog())
            {
                //処理
                //usingを抜けるタイミングでDispose()が呼び出される
            }


        }
    }
}
