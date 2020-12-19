using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 48. 旋转图像
    /// https://leetcode-cn.com/problems/rotate-image/
    /// </summary>
    public class rotate_image
    {
        /// <summary>
        /// 使用辅助数组 暴力直接做
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;
            if (matrix.Length != matrix[0].Length) return;

            var n = matrix.Length;

            var temp = new int[n][];
            for (int j = 0; j < n; j++)
            {
                var k = 0;
                temp[j] = new int[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    temp[j][k++] = matrix[i][j];
                }
            }

            //matrix = temp;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = temp[i];
            }
        }

        /// <summary>
        /// 原地旋转，分左上，右上，左下，右下 四个块操作
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate_V2(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;
            if (matrix.Length != matrix[0].Length) return;
            int n = matrix.Length;
            for (int i = 0; i < n / 2; ++i)
            {
                for (int j = 0; j < (n + 1) / 2; ++j)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - j - 1][i];
                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                    matrix[j][n - i - 1] = temp;
                }
            }
        }

        /// <summary>
        /// 原地旋转，先水平反转，在对角线反转
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate_V3(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return;
            if (matrix.Length != matrix[0].Length) return;
            
            int n = matrix.Length;
            //水平反转(上下反转)
            for (int i = 0; i < n/2; ++i)
            {
                var temp = matrix[i];
                matrix[i] = matrix[n - i - 1];
                matrix[n - i - 1] = temp;
            }

            //对角线反转
            for (int i = 0; i < n ; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    int temp = matrix[i][j];
                    
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

    }
}
