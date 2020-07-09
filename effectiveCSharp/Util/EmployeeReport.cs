using System;
using System.Xml.Linq;

namespace effectiveCSharp.Util
{
    /// <summary>
    /// 良い例
    /// </summary>
    public static class EmployeeReport
    {
        public static string FormatAsText(Employee target)
        {
            return $"{target.Salary}円";
        }

        public static string FormatAsXml(Employee target)
        {
            return new XElement("Employee", new XElement("Salary", target.Salary)).ToString();
        }
    }
}
