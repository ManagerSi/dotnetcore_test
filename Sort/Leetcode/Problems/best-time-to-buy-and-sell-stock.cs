using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 121. 买卖股票的最佳时机
    /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    public class best_time_to_buy_and_sell_stock
    {
        /// <summary>
        /// 暴力 双for 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            var maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i+1; j < prices.Length; j++)
                {
                    var gap = prices[j] - prices[i];
                    if (gap < maxProfit) continue;

                    maxProfit = Math.Max(maxProfit, gap);
                }
            }

            return Math.Max(maxProfit, 0); ;
        }

        /// <summary>
        /// 暴力优化，记录历史最低，一次遍历
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit_V1(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            var minPrice = prices[0];
            var maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (minPrice > prices[i])
                    minPrice = prices[i];

                if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }

            return maxProfit;
        }

        /// <summary>
        /// 单调栈 -- 无法使用
        /// 这个题本质就是要求某个数与其右边最大的数的差值，
        /// 这符合了单调栈的应用场景 当你需要高效率查询某个位置左右两侧比他大（或小）的数的位置的时候
        ///
        /// 貌似不行，无法计算栈底元素和各个元素的差值，这个主要是计算相邻或临近几个元素的差或特性
        /// 解法可参考
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/solution/c-li-yong-shao-bing-wei-hu-yi-ge-dan-diao-zhan-tu-/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit_V2(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            var tempArr = new int[prices.Length + 1]; //add 0 at end of array 
            prices.CopyTo(tempArr,0);

            var stack = new Stack<int>();
            var maxProfit = 0;
            var topValue = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                //维护单调增栈，遇到比栈底元素小的，则全弹出
                while (stack.Count > 0 && stack.Peek() > prices[i])
                {
                    //这里无法拿到栈底的最小元素
                    stack.Pop();
                }
                //入栈
                stack.Push(prices[i]);
            }

            return maxProfit;
        }

        /// <summary> 
        /// 动态规划做题步骤
        /// 
        /// 1,明确 dp(i)dp(i) 应该表示什么（二维情况：dp(i)(j)dp(i)(j)）；
        /// 2,根据 dp(i)dp(i) 和 dp(i-1)dp(i−1) 的关系得出状态转移方程；
        /// 3,确定初始条件，如 dp(0)dp(0)。
        ///
        /// 实际上v1是v3的优化版，即不需要保存所有的结果
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit_V3(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            var res = new int[prices.Length];
            var minPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                res[i] = Math.Max(res[i - 1], prices[i] - minPrice);
            }

            return res[res.Length - 1];
        }

        /// <summary>
        /// 拆分数组
        /// 
        /// diff[1] = prices[2] - prices[1]
        /// diff[2] + diff[1] = prices[3] - prices[2] + (prices[2] - prices[1]) =  prices[3] - prices[1]
        /// diff[3] + diff[2] + diff[1] = (diff[4] - diff[3]) + (prices[3] - prices[2]) + (prices[2] - prices[1]) =  prices[4] - prices[1]
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit_V4(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            // 差分数组比原始数组的长度少 1
            int[] diff = new int[prices.Length - 1];
            for (int i = 0; i < prices.Length - 1; i++)
            {
                diff[i] = prices[i + 1] - prices[i];
            }

            // dp[i] 以 diff[i] 结尾的子序列的和的最大值
            int[] dp = new int[prices.Length - 1];
            dp[0] = diff[0];
            for (int i = 1; i < prices.Length - 1; i++)
            {
                dp[i] = Math.Max(diff[i], dp[i - 1] + diff[i]);
            }

            // 还是要考虑到 [7 , 6, 5, 4, 3] 这种不交易的情况
            // 初值应该赋值成 0
            int res = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;

        }
    }
}
