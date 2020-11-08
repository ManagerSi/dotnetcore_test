using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 122. 买卖股票的最佳时机 II
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/
    /// </summary>
    public class best_time_to_buy_and_sell_stock_ii
    {
        /// <summary>
        /// 暴力回溯 -- 超时
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            result_V1 = 0;
            Dfs(prices, 0, false, 0);

            return result_V1;
        }

        private int result_V1 = 0;
        /// <summary>
        /// 回溯法
        /// </summary>
        /// <param name="prices">价钱波动</param>
        /// <param name="index">当前天</param>
        /// <param name="isBuy">是否持有</param>
        /// <param name="buyPrice">买入价格</param>
        /// <param name="res">收入</param>
        private void Dfs(int[] prices, int index, bool isBuy, int res)
        {
            //退出条件
            if (index>=prices.Length)
            {
                this.result_V1 = Math.Max(this.result_V1, res);
                return;
            }
            
            Dfs(prices, index + 1, isBuy, res);//继续维持

            if (isBuy)
            {
                //如果持有，则卖出
                Dfs(prices, index + 1, false, res + prices[index]);
            }
            else
            {
                //如果未持有，则买入
                Dfs(prices, index + 1, true, res - prices[index]);
            }



        }

        /// <summary>
        ///  动态规划的思路
        /// dp[i][0] 表示第i天持有股票时的现金收入(可能为负数，因为买股票需要成本)
        /// dp[i][1] 表示第i天不持有股票时的现金收入
        /// 则状态转移分析如下：
        /// dp[i][0] 是第i天持有股票的情况，这个股票可能时前一天就持有，也可能是前一天没有，但是今天刚买入的
        /// dp[i][1] 是第i天不持有股票的情况，这个情况可能是前一天就没有股票，然后保持到今天，也可能是今天把前一天持有的股票都卖掉了
        /// 因此能够得到状态转移方程
        /// dp[i][0] = max(dp[i-1][0], dp[i-1][1]-prices[i])
        /// dp[i][1] = max(dp[i-1][1], dp[i-1][0]+prices[i])
        /// 注意初始条件，当i=1时，dp[1][0]=-prices[0],dp[1][1]=0
        /// 表示第一天如果持有，只能是当天就买入，如果第一天不持有，也就是第一天没有买
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit_V2(int[] prices)
        {
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            int[][] dp = new int[prices.Length+1][];
            dp[0] = new int[2];

            dp[1] = new int[2];
            dp[1][0] = -prices[0];
            dp[1][1] = 0;
            for (int i = 2; i <= prices.Length; i++)
            {
                dp[i] = new int[2];
                dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] - prices[i-1]);
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + prices[i-1]);
            }

            return dp[prices.Length][1];
        }

    }
}
