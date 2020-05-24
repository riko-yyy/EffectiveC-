using System;
using System.IO;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// Disposeパターンを実装するベースクラスの派生クラス
    /// </summary>
    public class DerivedResourceHog : AbstractResourceHog
    {
        //親が保持している物とは別のマネージドリソース
        private Stream _streamAaaaaaaaa;
        //親が保持している物とは別のアンマネージドリソース
        private IntPtr _handleAaaaaaaaa;

        //破棄済みかを検証するフラグ
        private bool _disposed = false;

        //ヘルパーメソッドをオーバーライドし、子のリソース破棄後、親のリソース破棄を行う
        protected override void Dispose(bool disposing)
        {
            //すでに破棄されていたら終了
            if (!_disposed)
            {
                return;
            }
            if (disposing)
            {
                //マネージリソースの破棄
                _streamAaaaaaaaa.Dispose();
            }

            //アンマネージリソースの破棄
            //★★★★★★★アンマネージドリソースがあるときだけ
            _handleAaaaaaaaa = IntPtr.Zero;

            //破棄済み検証フラグの更新
            _disposed = true;

            //親クラスよりリソース開放
            base.Dispose(disposing);

        }

        //ファイナライザ
        //★★★★★★★アンマネージドリソースがあるときだけ
        ~DerivedResourceHog()
        {
            Dispose(false);
        }

    }
}
