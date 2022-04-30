using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{

    /// <summary>
    /// 908. Smallest Range I
    /// https://leetcode-cn.com/problems/smallest-range-i/
    /// </summary>
    public class smallest_range_i
    {
        /// <summary>
        /// 数学法，最终归结为数组最大最小值之间的差值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRangeI(int[] nums, int k)
        {
            var min = nums[0];
            var max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }
            Console.WriteLine($"max:{max}, min:{min}");
            if (min + k >= max - k)
                return 0;
            return (max - k) - (min + k);
        }

        /// <summary>
        /// 使用内置方法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRangeI_V2(int[] nums, int k)
        {
            var max = nums.Max();
            var min = nums.Min();
            //Console.WriteLine($"max:{max}, min:{min}");
            if (min + k >= max - k)
                return 0;
            return (max - k) - (min + k);
        }

    }
}