using System;
using System.Collections.Generic;

namespace effectiveCSharp.Util
{
    public class SequenceFactory
    {
        /// <summary>
        /// 間隔Nの要素シーケンス
        /// </summary>
        /// <param name="numberOfElement">要素数</param>
        /// <param name="startAt">初期値</param>
        /// <param name="stepBy">間隔</param>
        /// <returns></returns>
        public static IEnumerable<int> StepBySequence(int numberOfElement, int startAt, int stepBy)
        {
            for (int i = 0; i < numberOfElement; i++)
            {
                yield return startAt + i * stepBy;
            }
        }
    }
}
