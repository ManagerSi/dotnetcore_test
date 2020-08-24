using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 03. 数组中重复的数字
    /// </summary>
    public class shu_zu_zhong_zhong_fu_de_shu_zi_lcof
    {
        public int FindRepeatNumber(int[] nums)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    return nums[i];
                }
                set.Add(nums[i]);
            }
            return -1;
        }

        /// <summary>
        /// 先排序，两两对比
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindRepeatNumber_V2(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[i+1])
                {
                    return nums[i];
                }
            }
            return -1;
        }
    }
}
