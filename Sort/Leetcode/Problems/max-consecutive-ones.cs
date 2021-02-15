using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 485. 最大连续1的个数
    /// https://leetcode-cn.com/problems/max-consecutive-ones/
    /// </summary>
    public class max_consecutive_ones
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int consecutiveNumb = 0;
            int lastIndex = nums.Length - 1;
            bool preIsOne = false;
            for (int i = lastIndex; i >= 0; i--)
            {
                if (preIsOne && nums[i] == 1)
                {
                    continue;
                }

                if (nums[i] == 0)
                {
                    if (preIsOne)
                    {
                        var tempGap = lastIndex - i;
                        consecutiveNumb = tempGap > consecutiveNumb ? tempGap : consecutiveNumb;
                    }

                    preIsOne = false;
                    lastIndex = i;
                }
                else
                {
                    preIsOne = true;
                    lastIndex = i;
                }
            }

            if (preIsOne)
            {
                var tempGap = lastIndex - 0 + 1;
                consecutiveNumb = tempGap > consecutiveNumb ? tempGap : consecutiveNumb;
            }

            return consecutiveNumb;
        }

        public int FindMaxConsecutiveOnes_V2(int[] nums)
        {

            var maxCount = 0;
            var currentCount = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    currentCount++;
                    maxCount = Math.Max(maxCount, currentCount);
                }
                else
                {
                    currentCount = 0;
                }
            }

            return maxCount;
        }
    }
}
