using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 566. 重塑矩阵
    /// https://leetcode-cn.com/problems/reshape-the-matrix
    /// </summary>
    public class reshape_the_matrix
    {
        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            int rows = nums.Length;
            int cols = nums[0].Length;

            if (rows * cols != r * c || rows==r) return nums;

            int tempC = 0, tempR =0;
            int[][] result = new int[r][];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new int[c];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[tempR][tempC++] = nums[i][j];
                    if (tempC == c)
                    {
                        ++tempR;
                        tempC = 0;
                    }
                }
            }

            return result;
        }
    }
}
