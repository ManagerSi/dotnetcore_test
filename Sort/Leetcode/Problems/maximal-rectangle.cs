using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 85. Maximal Rectangle
    /// https://leetcode-cn.com/problems/maximal-rectangle/
    /// </summary>
    public class maximal_rectangle
    {
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int[][] intLength = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                intLength[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j] == '1')
                        intLength[i][j] = j==0?1:intLength[i][j-1]+1;
                    else
                        intLength[i][j] = 0;
                }
            }

            //统计柱状图中最大的矩形

            int ret = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        continue;
                    }
                    int width = intLength[i][j];
                    int area = width;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        width = Math.Min(width, intLength[k][j]);
                        area = Math.Max(area, (i - k + 1) * width);
                    }
                    ret = Math.Max(ret, area);
                }
            }
            return ret;

        }

        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle_V2(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int[][] intLength = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                intLength[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '1')
                        intLength[i][j] = j == 0 ? 1 : intLength[i][j - 1] + 1;
                }
            }

            //单调栈 统计柱状图中最大的矩形

            int ret = 0;
            for (int j = 0; j < matrix[0].Length; j++)
            { 
                // 对于每一列，使用基于柱状图的方法
                int[] up=new int[matrix.Length], down= new int[matrix.Length];
                
                Stack<int> stk= new Stack<int>();
                for (int i = 0; i < matrix.Length; i++)
                {
                    while (stk.Count>0 && intLength[stk.Peek()][j] >= intLength[i][j])
                    {
                        stk.Pop();
                    }
                    up[i] = stk.Count==0 ? -1 : stk.Peek();
                    stk.Push(i);
                }

                stk = new Stack<int>();
                for (int i = matrix.Length - 1; i >= 0; i--)
                {
                    while (stk.Count>0 && intLength[stk.Peek()][j] >= intLength[i][j])
                    {
                        stk.Pop();
                    }
                    down[i] = stk.Count==0 ? matrix.Length : stk.Peek();
                    stk.Push(i);
                }

                for (int i = 0; i < matrix.Length; i++)
                {
                    int height = down[i] - up[i] - 1;
                    int area = height * intLength[i][j];
                    ret = Math.Max(ret, area);
                }
            }
            return ret;

        }
    }
}
