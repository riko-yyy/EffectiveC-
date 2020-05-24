using System;
using System.IO;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// Disposeパターンを実装するベースクラス
    /// </summary>
    public class AbstractResourceHog : IDisposable
    {
        //マネージドリソース
        private Stream _stream;
        //アンマネージドリソース
        private IntPtr _handle;

        //破棄済みかを検証するフラグ
        private bool _disposedValue = false;

        // IDisposableの実装
        // マネージドリソースとアンマネージドリソースの破棄
        public void Dispose()
        {
            //マネージドリソースの破棄
            Dispose(true);

            //ファイナライザー実行の抑止
            //★★★★★★★アンマネージドリソースがあるときだけ
            GC.SuppressFinalize(this);
        }

        //ファイナライザ
        //★★★★★★★アンマネージドリソースがあるときだけ
        ~AbstractResourceHog()
        {
            Dispose(false);
        }

        //ヘルパーメソッド
        //リソース破棄の実処理
        protected virtual void Dispose(bool disposing)
        {
            //すでに破棄されていたら終了
            if (!_disposedValue)
            {
                return;
            }

            if (disposing)
            {
                //マネージリソースの破棄
                _stream.Dispose();
            }

            //アンマネージリソースの破棄
            //★★★★★★★アンマネージドリソースがあるときだけ
            _handle = IntPtr.Zero;


            //破棄済み検証フラグの更新
            _disposedValue = true;
        }

        //実処理で利用する業務用メソッド
        public void Method()
        {
            //Dispose後にメソッド呼び出ししようとするとエラーへ
            if (_disposedValue)
            {
                throw new ObjectDisposedException(nameof(this.GetType), "破棄済みのオブジェクトでMethodが呼ばれました");
            }

            //実処理


        }

    }
}
