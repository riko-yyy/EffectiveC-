using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace effectiveCSharp.Util
{
    public static class HighVariable
    {
        public static int DefaultParse(this string input, int defaultValue)
        {
            int answer;
            return (int.TryParse(input, out answer)) ? answer : defaultValue;
        }

        //NG
        public static IEnumerable<string> ReadLines(this TextReader reader)
        {
            var txt = reader.ReadLine();
            while (txt != null)
            {
                yield return txt;
                txt = reader.ReadLine();
            }
        }
        public static IEnumerable<IEnumerable<int>> ReadNumbersFromStream(TextReader reader)
        {
            var allLines = from line in reader.ReadLines()
                           select line.Split(',');
            var matrixOfValues = from line in allLines
                                 select from item in line
                                        select item.DefaultParse(0);
            return matrixOfValues;
        }

        //OK
        public static IEnumerable<string> ParseFile(string path)
        {
            using (var r = new StreamReader(File.OpenRead(path)))
            {
                var txt = r.ReadLine();
                while (txt != null)
                {
                    yield return txt;
                    txt = r.ReadLine();
                }
            }
        }
        public static IEnumerable<IEnumerable<int>> ReadNumbersFromStream(string path)
        {
            var allLines = from line in ParseFile(path)
                           select line.Split(',');
            var matrixOfValues = from line in allLines
                                 select from item in line
                                        select item.DefaultParse(0);
            return matrixOfValues;
        }

        //Dispose緒然でロジックを実行する
        public delegate TResult ProcessElementsFromFile<TResult>(IEnumerable<IEnumerable<int>>);
        public static TResult ProcessFile<TResult>(string filePath, ProcessElementsFromFile<TResult> action)
        {
            var allLines = from line in ParseFile(path)
                           select line.Split(',');
            var matrixOfValues = from line in allLines
                                 select from item in line
                                        select item.DefaultParse(0);
            return action(matrixOfValues);
        }

    }
}
