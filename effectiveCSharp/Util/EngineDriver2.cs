using System;
namespace effectiveCSharp.Util
{
    //型引数のインスタンスをメンバ変数にもち、かつ型引数がIDisposableを実装する場合

    //IDisposableを実装した可能性のある型への参照を保持するため、このジェネリッククラスでDispose可能にする必要あり
    public sealed class EngineDriver2<T> : IDisposable where T : IEngine, new()
    {
        //アンマネージリソースだから遅いと仮定し、遅延実行
        private Lazy<T> driver = new Lazy<T>(() => new T());

        //メソッドは特に変化なし。ただ使うだけ
        public void GetThingsDone() => driver.Value.DoWork();

        //実装
        public void Dispose()
        {
            //複数呼び出し可能なように、メンバ変数のインスタンスが作成されている時のみ、Disposeする
            if (driver.IsValueCreated)
            {
                var resouce = driver.Value as IDisposable;

                resouce?.Dispose();
            }
        }
    }

    //もしくは内部でnewせず外から与え、外でDisposeする
    public sealed class EngineDriver3<T> where T : IEngine
    {
        private T driver;

        //コンストラクタで外から与える
        public EngineDriver3(T driver)
        {
            this.driver = driver;
        }

        //メソッドは特に変化なし。ただ使うだけ
        public void GetThingsDone() => driver.DoWork();
    }
}
