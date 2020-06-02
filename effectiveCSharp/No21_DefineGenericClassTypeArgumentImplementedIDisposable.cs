using System;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 破棄可能な型引数をサポートするようにジェネリック型を作成すること
    /// </summary>
    public class No21_DefineGenericClassTypeArgumentImplementedIDisposable
    {
        public No21_DefineGenericClassTypeArgumentImplementedIDisposable()
        {
            //目的：
            //①型引数がIDisposableを実装する可能性があるときのジェネリッククラスの作り方に注意する

            //概要：
            //--------------------------------------------------------------------------------------

            //型引数をローカル変数で利用する場合
            var a1 = new EngineDriverOne<Engine>();
            //悪い例
            a1.GetThingsDone1();
            //良い例：IDisposableへキャストし、using
            a1.GetThingsDone2();


            //型引数をメンバ変数で利用する場合
            //パターン１：ジェネリッククラスそのものにIDisposableを実装
            var a2 = new EngineDriver2<Engine>();
            a2.GetThingsDone();

            //パターン２：Disposeの責務を呼び出し元に委ねる
            using (Engine needDispose = new Engine())
            {
                var a3 = new EngineDriver3<Engine>(needDispose);
                a3.GetThingsDone();
            }
                
        }
    }
}
