using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 239. 滑动窗口最大值
    /// 
    /// </summary>
    public class sliding_window_maximum
    {
        /// <summary>
        /// 双重循环
        /// 数组太大，运行超出时限了，需要优化。。。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            List<int> res = new List<int>();
            
            for (int i = k-1; i < nums.Length; i++)
            {
                int maxValue = nums[i];
                for (int j = i; j >= i-k+1; j--)
                {
                    if (nums[j] > maxValue)
                        maxValue = nums[j];
                }
                res.Add(maxValue);
            }

            return res.ToArray();
        }

        /// <summary>
        /// v1 的优化版本
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow_V2(int[] nums, int k)
        {
            int[] ans = new int[nums.Length - k + 1];
            int maxIndex = -1;
            int j = 0;
            for (int i = 0; i <= nums.Length - k; i++)
            {
                if (i <= maxIndex && maxIndex < i + k)
                {
                    if (nums[maxIndex] <= nums[i + k - 1])
                    {
                        maxIndex = i + k - 1;
                    }
                }
                else
                {
                    maxIndex = i;
                    for (int m = i; m <= i + k - 1; m++)
                    {
                        if (nums[maxIndex] < nums[m]) maxIndex = m;
                    }
                }
                ans[j++] = nums[maxIndex];
            }
            return ans;
        }

    }
}
