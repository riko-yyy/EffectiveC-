using System;
namespace effectiveCSharp.Util
{
    //拡張メソッドでインタフェースに対して機能拡張しており、後から同名のメソッドを継承先で定義すると、
    //既存のコードで利用していた拡張メソッドが新たに追加したメソッドとして解釈されるようになるため注意

    public interface IFoo
    {
        int Marker { get; set; }
    }

    public static class FooExtensions
    {
        public static void NextMarker(this IFoo thing)
        {
            thing.Marker++;
        }
    }

    public class DerivedFoo : IFoo
    {
        public int Marker { get ; set; }

        //対象
        public void UpdateMarker() => this.NextMarker();

        //追加：こちらだとコンパイラは解釈する
        public void NextMarker() => this.Marker += 5;
    }

}
