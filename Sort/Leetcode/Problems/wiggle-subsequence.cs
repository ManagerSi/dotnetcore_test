using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 376. 摆动序列
    /// https://leetcode-cn.com/problems/wiggle-subsequence/
    /// </summary>
    public class wiggle_subsequence
    {
        public int WiggleMaxLength(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Length < 2) return nums.Length;

            int i = 1;
            while (i < nums.Length && nums[i - 1] == nums[i]) i++;
            if (i == nums.Length) return 1; //所有数都重复

            int res = 2;
            bool toggle = nums[i] > nums[i - 1];
            for (++i; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) continue;

                if (nums[i] > nums[i - 1] != toggle)
                {
                    res += 1;
                    toggle = !toggle;
                }
            }

            return res;
        }
    }
}
