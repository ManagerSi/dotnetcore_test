using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 26. 删除排序数组中的重复项
    /// 
    /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
    /// </summary>
    public class remove_duplicates_from_sorted_array
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length ==0)
                return 0;

            int i = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    nums[++i] = nums[j];
                }
            }

            return ++i;
        }
    }
}
