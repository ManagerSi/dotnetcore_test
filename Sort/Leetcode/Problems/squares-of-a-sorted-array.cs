using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 977. 有序数组的平方
    /// https://leetcode-cn.com/problems/squares-of-a-sorted-array/
    /// </summary>
    public class squares_of_a_sorted_array
    {
        /// <summary>
        /// 使用函数
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] A)
        {
            if (A == null) return null;

            var res = A.Select(i => i * i).ToArray();
            Array.Sort(res);

            return res;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortedSquares_V1(int[] A)
        {
            if (A == null) return null;

            int[] res = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                var temp = A[i] * A[i];

                var index = i;
                while (index > 0 && res[index - 1] > temp)
                {
                    res[index] = res[index - 1];
                    index--;
                }
                res[index] = temp;
            }
           

            return res;
        }
    }
}
