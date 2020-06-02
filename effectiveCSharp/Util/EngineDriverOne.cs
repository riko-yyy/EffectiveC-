using System;
namespace effectiveCSharp.Util
{
    public class EngineDriverOne<T> where T : IEngine, new()
    {
        //悪い例：
        public void GetThingsDone1()
        {
            //TがIDisposableを実装する場合、リソースリークする
            T driver = new T();
            driver.DoWork();
        }

        //良い例：
        public void GetThingsDone2()
        {
            //IDisposableにキャストし、using(Dispose()実行)
            T driver = new T();
            using (driver as IDisposable)
            {
                driver.DoWork();
            }                
        }
    }
}
