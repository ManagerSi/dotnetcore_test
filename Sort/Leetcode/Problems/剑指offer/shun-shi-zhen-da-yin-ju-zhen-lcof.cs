using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 29. 顺时针打印矩阵
    /// https://leetcode-cn.com/problems/shun-shi-zhen-da-yin-ju-zhen-lcof/
    /// </summary>
    public class shun_shi_zhen_da_yin_ju_zhen_lcof
    {
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new int[] { };

            var total = matrix.Length * matrix[0].Length; //元素总个数
            var result = new int[total];

            var flag = true;//横true: 或 竖false
            var order = true;//正向true 或反向 false
            int x = 0, y = 0;
            int count = 0;//遍历的元素个数
            while (count < total)
            {
                if (flag)
                {
                    if (order)
                    {
                        for (int i = x; i < matrix[y].Length - x; i++)
                        {
                            result[count++] = matrix[y][i];
                        }

                        x = matrix[y].Length - x-1;

                        //order = false; //顺序反转
                    }
                    else
                    {
                        for (int i = x-1; i >= matrix[y].Length - x-1; i--)
                        {
                            result[count++] = matrix[y][i];
                        }

                        x = matrix[y].Length - x-1;
                        //order = true; //顺序反转
                    }

                    flag = false; //横竖反转
                }
                else
                {
                    if (order)
                    {
                        for (int i = y+1; i <= matrix.Length - y-1; i++)
                        {
                            result[count++] = matrix[i][x];
                        }

                        y = matrix.Length - y - 1;

                        order = false; //顺序反转
                    }
                    else
                    {
                        for (int i = y-1; i >= matrix.Length - y; i--)
                        {
                            result[count++] = matrix[i][x];
                        }

                        x = x + 1;  //走完一圈，重新设置起始值
                        y = matrix.Length - y;

                        order = true; //顺序反转
                    }

                    flag = true; //横竖反转
                }
            }

            return result;
        }
    }
}
