using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 766. 托普利茨矩阵
    /// https://leetcode-cn.com/problems/toeplitz-matrix/
    /// </summary>
    public class toeplitz_matrix
    {
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 按对角线读取
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool IsToeplitzMatrix_V2(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int row = m, col = n;
            while (col-- > 0)
            {
                for (int i = 0, j = col, val = matrix[i++][j++]; i < m && j < n; i++, j++)
                {
                    if (matrix[i][j] != val) return false;
                }
            }
            while (row-- > 0)
            {
                for (int i = row, j = 0, val = matrix[i++][j++]; i < m && j < n; i++, j++)
                {
                    if (matrix[i][j] != val) return false;
                }
            }
            return true;
        }

    }
}
