using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 628. 三个数的最大乘积
    /// </summary>
    public class maximum_product_of_three_numbers
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int index = nums.Length - 1;
            return Math.Max(nums[index] * nums[index - 1] * nums[index - 2], nums[0] * nums[1] * nums[index]);
        }
    }
}
