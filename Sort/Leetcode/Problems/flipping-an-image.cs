using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 832. 翻转图像
    /// https://leetcode-cn.com/problems/flipping-an-image/
    /// </summary>
    public class flipping_an_image
    {
        public int[][] FlipAndInvertImage(int[][] A)
        {
            int[][] result = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                var length = A[i].Length;
                result[i] = new int[length];
                for (int j = length - 1; j >= 0; j--)
                {
                    result[i][length - j - 1] = A[i][j] == 0 ? 1 : 0;
                }
            }

            return result;
        }
    }
}
