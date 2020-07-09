using System;
using effectiveCSharp.Util;
using effectiveCSharp.ConsoleExtension;
//using effectiveCSharp.XmlExtension;

namespace effectiveCSharp
{
    /// <summary>
    /// 拡張メソッドをオーバロードしないこと
    /// </summary>
    public class No35_NoMethodOverloadingExtensionMethod
    {
        public No35_NoMethodOverloadingExtensionMethod()
        {
            //目的：
            //①名前空間を変えて同名の拡張メソッドを定義しない

            //概要：
            //--------------------------------------------------------------------------------------
            //名前空間を変えて同じ名前の拡張メソッドを作成することで、
            //使用する名前空間を変えると様々なバージョンの拡張メソッドを定義できると考えられるがこれは間違い
            //実装者が名前空間を変えると振る舞いが変わるとは思わないのである

            //悪い例
            //usingする名前空間によってresultの値が変わる
            var emp = new Employee() { Salary = 100 };
            var result = emp.Format();

            //そもそも拡張メソッドはその型に存在しているのが自然なメソッドであるべきである
            //上記のメソッドは、Employeeを利用したい実装者側の都合のため、Employeeを利用する別の型に実装すべきである

            //良い例
            var result1 = EmployeeReport.FormatAsText(emp);
            var result2 = EmployeeReport.FormatAsXml(emp);
        }
    }
}
