using System;
namespace effectiveCSharp.Util
{
    public static class ExampleDelegateConstraint
    {
        /// <summary>
        /// 引数に型とデリゲートを渡す
        /// 実処理は引数の型を引数に引数のデリゲートを実行
        /// </summary>
        /// <typeparam name="T">型引数</typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="AddFunc">Addデリゲート</param>
        /// <returns></returns>
        public static T Add<T>(T left, T right, Func<T, T, T> AddFunc) => AddFunc(left, right);
    }
}
