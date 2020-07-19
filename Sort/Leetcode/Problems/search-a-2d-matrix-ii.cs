using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 240. 搜索二维矩阵 II
    /// https://leetcode-cn.com/problems/search-a-2d-matrix-ii/
    ///
    /// 每行的元素从左到右升序排列。
    /// 每列的元素从上到下升序排列。
    /// </summary>
    public class search_a_2d_matrix_ii
    {
        /// <summary>
        /// 从右上角开始向左下角走
        /// 或从左下角到右上角
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
                return false;

            var rowLen = matrix.GetLength(0);
            var colLen = matrix.GetLength(1);
            if (rowLen == 0 || colLen == 0)
                return false;

            //从右上角开始向左下角走
            for (int i = 0; i < rowLen; i++)
            {
                //每次都是从最右边开始，需要优化
                for (int j = colLen-1; j >= 0; j--)
                {
                    if (matrix[i, j] == target)
                        return true;

                    if (matrix[i, j] > target)
                        continue;

                    if (matrix[i, j] < target)
                        break;

                }
            }

            return false;
        }


        /// <summary>
        /// 从右上角开始向左下角走
        /// 或从左下角到右上角
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix_V2(int[,] matrix, int target)
        {
            if (matrix == null)
                return false;

            var rowLen = matrix.GetLength(0);
            var colLen = matrix.GetLength(1);
            if (rowLen == 0 || colLen == 0)
                return false;

            int i = 0, j = colLen-1;
            while (i<rowLen && j>=0)
            {
                if (matrix[i, j] == target)
                    return true;

                if (matrix[i, j] > target)
                    j--;
                else
                    i++;
            }

            return false;
        }


        /// <summary>
        /// 剑指 Offer 04. 二维数组中的查找
        /// https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof
        /// 从右上角开始向左下角走
        /// 或从左下角到右上角
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix_V3(int[][] matrix, int target)
        {
            if (matrix == null|| matrix.Length==0 || matrix[0].Length==0)
                return false;

            var rowLen = matrix.Length;
            var colLen = matrix[0].Length;
            if (rowLen == 0 || colLen == 0)
                return false;

            int i = 0, j = colLen - 1;
            while (i < rowLen && j >= 0)
            {
                if (matrix[i][ j] == target)
                    return true;

                if (matrix[i][ j] > target)
                    j--;
                else
                    i++;
            }

            return false;
        }
    }
}
