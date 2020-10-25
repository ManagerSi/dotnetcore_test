using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 53. 最大子序和
    /// https://leetcode-cn.com/problems/maximum-subarray/
    /// </summary>
    public class maximum_subarray
    {
        /// <summary>
        /// pd 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0) return int.MinValue;

            int pre = 0, max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                pre = Math.Max(pre + nums[i], nums[i]);
                max = Math.Max(pre, max);
            }

            return max;
        }


        /// <summary>
        /// 分治法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray_V1(int[] nums)
        {
            if (nums == null || nums.Length == 0) return int.MinValue;
         
            //todo 分治法实现
            return -1;
        }
    }
}
