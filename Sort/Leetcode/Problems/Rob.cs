using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 213. 打家劫舍 II
    /// https://leetcode-cn.com/problems/house-robber-ii/
    /// </summary>
    public class Rob
    {
        /// <summary>
        /// 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 --答案错误
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob_V1(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0],nums[1]);

            int n = nums.Length;

            var res1 = nums[0] + getValue(nums, (0 + 2) % n, new List<int>() {0});
            var res2 = nums[0] + getValue(nums, (0 + 3) % n, new List<int>() {0});

            var res3 = nums[1] + getValue(nums, (1 + 2) % n, new List<int>() {1});
            var res4 = nums[1] + getValue(nums, (1 + 3) % n, new List<int>() {1});

            return Math.Max(Math.Max(res1, res2), Math.Max(res3, res4));
        }

        public int getValue(int[] nums, int startIndex, List<int> endIndex)
        {
            var startIndex1 = startIndex == 0 ? nums.Length - 1 : (startIndex - 1) % nums.Length;
            var startIndex2 = (startIndex + 1) % nums.Length;
            if (endIndex.Any(i => i == startIndex || i == startIndex1 || i == startIndex2)) return 0;

            int res1 = nums[startIndex] + getValue(nums, (startIndex + 2) % nums.Length, endIndex);
            int res2 = nums[startIndex] + getValue(nums, (startIndex + 3) % nums.Length, endIndex);

            return res1 > res2 ? res1 : res2;
        }



        public int Rob_V2(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);


            var dp = new int[nums.Length];

            dp[1] = nums[1];
            dp[2] = Math.Max(nums[1], nums[2]);

            for (var i = 3; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < nums.Length - 1; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return Math.Max(dp[nums.Length - 1], dp[nums.Length - 2]);
        }
    }
}
