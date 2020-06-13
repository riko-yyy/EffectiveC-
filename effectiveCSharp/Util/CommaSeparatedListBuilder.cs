using System;
using System.Collections.Generic;
using System.Text;

namespace effectiveCSharp.Util
{
    public class CommaSeparatedListBuilder
    {
        /// <summary>
        /// ホルダー
        /// </summary>
        private StringBuilder storage = new StringBuilder();

        /// <summary>
        /// ホルダーに追加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public void Add<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                if (storage.Length > 0)
                {
                    storage.Append(", ");
                }

                storage.Append(item.ToString());

            }
        }

        /// <summary>
        /// 文字列出力
        /// </summary>
        /// <returns></returns>
        public override string ToString() => storage.ToString();
    }
}
