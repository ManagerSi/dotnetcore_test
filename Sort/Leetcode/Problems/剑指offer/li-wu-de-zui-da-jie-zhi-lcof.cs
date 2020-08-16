using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 47. 礼物的最大价值
    /// https://leetcode-cn.com/problems/li-wu-de-zui-da-jie-zhi-lcof
    /// </summary>
    public class li_wu_de_zui_da_jie_zhi_lcof
    {
        /// <summary>
        /// 动态规划 dp(dynamic programming
        ///
        /// 新建数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            //状态： dp[i,j]表示在i,j这个点所能拿到的最多价值的礼物
            int[,] dp = new int[rows + 1, cols + 1];

            for (int i = 1; i < rows+1; i++)
            {
                for (int j = 1; j < cols+1; j++)
                {
                    dp[i,j] = Math.Max(dp[i - 1,j], dp[i,j - 1]) + grid[i - 1][j - 1];
                }
            }

            return dp[rows,cols];
        }

        /// <summary>
        /// 动态规划 dp(dynamic programming
        ///
        /// 原数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue_V1(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (i == 0)
                        grid[i][j] = grid[i][j] + grid[i][j - 1];
                    else if (j == 0)
                        grid[i][j] = grid[i][j] + grid[i - 1][j];
                    else
                        grid[i][j] = Math.Max(grid[i - 1][j], grid[i][j - 1]) + grid[i][j];
                }
            }

            return grid[rows - 1][cols - 1];
        }

        /// <summary>
        /// 最基础的dp题，转移方程：
        /// f(i, j) = max{f(i - 1, j), f(i, j - 1)} + grid[i][j]
        /// 然后可以用滚动数组的技巧把空间复杂度优化成O(N)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue_V2(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int[] dp = new int[n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1]) + grid[i - 1][j - 1];
                }
            }

            return dp[n];
        }
    }
}
