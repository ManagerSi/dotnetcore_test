using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 416. 分割等和子集
    /// https://leetcode-cn.com/problems/partition-equal-subset-sum/
    /// </summary>
    public class partition_equal_subset_sum
    {

        /// <summary>
        /// 背包问题：看数组中是否存在加起来为sum/2的数.
        /// 背包容量（V） = sum/2
        /// https://leetcode-cn.com/problems/partition-equal-subset-sum/solution/0-1-bei-bao-wen-ti-xiang-jie-zhen-dui-ben-ti-de-yo/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            if (nums == null || nums.Length < 2) return false;

            //奇数不能分为两份
            var sum = nums.Sum();
            if (sum % 2 == 1) return false;

            var target = sum / 2;//背包容量
            //行： 物品  / 列： 容量
            // 创建二维状态数组，行：物品索引，列：容量（包括 0）
            bool[,] dp = new bool[nums.Length, target + 1];

            //第一行（第一个物品），只能让容量为他自己的列装满（完全相等）
            if (nums[0] <= target)
            {
                dp[0, nums[0]] = true;
            }

            //遍历后续行（物品）
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    if (nums[i] == j)
                    {
                        dp[i, nums[i]] = true;
                        continue;
                    }

                    if (nums[i] < j)
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i]];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }

                }
            }

            return dp[(nums.Length - 1), target];
        }
    }
}
