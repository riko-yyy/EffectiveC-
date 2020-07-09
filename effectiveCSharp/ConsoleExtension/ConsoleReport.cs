using System;
using effectiveCSharp.Util;
namespace effectiveCSharp.ConsoleExtension
{
    /// <summary>
    /// 悪い例
    /// </summary>
    public static class ConsoleReport
    {
        public static string Format(this Employee target)
        {
            return $"{target.Salary}円";
        }
    }
}
