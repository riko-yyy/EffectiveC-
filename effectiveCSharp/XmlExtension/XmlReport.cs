using System;
using System.Xml.Linq;
using effectiveCSharp.Util;
namespace effectiveCSharp.XmlExtension
{
    /// <summary>
    /// 悪い例
    /// </summary>
    public static class XmlReport
    {
        public static string Format(this Employee target)
        {
            return new XElement("Employee", new XElement("Salary", target.Salary)).ToString();
        }
    }
}
