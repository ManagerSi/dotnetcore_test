using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 724. 寻找数组的中心索引
    /// </summary>
    public class find_pivot_index
    {
        /// <summary>
        /// 暴力法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int preTotal = 0;
                for (int j = i - 1; j >=0; j--)
                {
                    preTotal += nums[j];
                }

                int tailTotal = 0;
                for (int k = i+1; k < nums.Length; k++)
                {
                    tailTotal += nums[k];
                }
                if (preTotal == tailTotal)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 使用公式化简，两次便利，O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex_V2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return 0;

            int total = nums.Sum();
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == total - leftSum - nums[i])
                    return i;

                leftSum += nums[i];
            }

            return -1;
        }


        /// <summary>
        /// 分别统计前后的sum到两个数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex_V3(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return 0;

            int[] preSum = new int[nums.Length];
            int[] tailSum = new int[nums.Length];

            for (int i = 1; i < nums.Length; i++)
            {
                preSum[i] = preSum[i-1] + nums[i-1];
            }

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                tailSum[i] = tailSum[i + 1] + nums[i + 1];
            }

            for (int i = 0; i < preSum.Length; i++)
            {
                if (preSum[i] == tailSum[i])
                    return i;
            }
            return -1;
        }

    }
}
