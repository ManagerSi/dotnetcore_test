using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 746. 使用最小花费爬楼梯
    /// https://leetcode.cn/problems/min-cost-climbing-stairs/
    /// </summary>
    public class min_cost_climbing_stairs
    {
        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n + 1];
            dp[0] = 0; dp[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }
            return dp[n];
        }
    }
}
