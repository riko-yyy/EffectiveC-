using System;
using System.Collections.Generic;
using effectiveCSharp.Util;

namespace effectiveCSharp
{
    /// <summary>
    /// 関数引数を使用して役割を分離する
    /// </summary>
    public class No34_SeparateRoleUsingFunctionArguments
    {
        public No34_SeparateRoleUsingFunctionArguments()
        {
            //目的：
            //①デリゲートを引数として渡すようにして、再利用性を高める

            //概要：
            //--------------------------------------------------------------------------------------
            //利用する側が利用したいメソッドをデリゲートで渡すようなことが可能な関数を用意することで、利用までの機能実装量を下げることができる
            //他にもインタフェースや抽象クラスを利用する方法があるが以下のバランスを鑑みて何を採用するかを判断する必要がある
            //①関数引数     ：利用までの実装量は少ないが、エラーハンドリングを提供者が考慮する必要あり
            //②抽象クラス　　：デフォルトのメソッドが用意でき実装量は少ないが、クラス結合が強く再利用性は損なわれる
            //③インタフェース：メソッド全てを利用者が実装する必要があるが、抽象クラスと比較して再利用性は高い

            //使い分の視点としては、提供しようとしているメソッドが型に固有のものか否か

            //利用時
            var first = new List<string>() { "a", "b", "c", "d", "e" };
            var second = new List<string>() { "f", "g", "h", "i", "j" };

            //string
            var result1 = FuncArg.Zip(first, second);
            //generics
            var result2 = FuncArg.Zip(first, second, (one, two) => $"{one} {two}");

            var startAt = 0;
            var nextValue = 5;
            var result3 = FuncArg.CreateSequence(1000, () => startAt += nextValue);

            //sum
            var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var result4 = 0;
            result4 = FuncArg.Sum(nums, result4, (sum, num) => sum + num);

            //fold
            var employees = new List<Employee>() { new Employee() { Salary = 1 }, new Employee() { Salary = 2 }, new Employee() { Salary = 3 } };
            var reasult5 = FuncArg.Fold(employees, 0M, (emp, sum) => sum + emp.Salary);


        }
    }
}
