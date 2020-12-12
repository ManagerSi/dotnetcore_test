using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 217. 存在重复元素
    /// https://leetcode-cn.com/problems/contains-duplicate/
    /// </summary>
    public class contains_duplicate
    {

        //函数
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 1) return false;

            var count = nums.ToHashSet().Count();
            return count != nums.Length;
        }

        //排序
        public bool ContainsDuplicate_V1(int[] nums)
        {
            if (nums == null || nums.Length == 1) return false;

            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i-1])
                    return true;
            }
            return false;
        }

        //空间换时间
        public bool ContainsDuplicate_V2(int[] nums)
        {
            if (nums == null || nums.Length == 1) return false;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                    return true;
                set.Add(nums[i]);
            }
            return false;
        }

        //双指针 -- 超时
        public bool ContainsDuplicate_outTime(int[] nums)
        {
            if (nums == null || nums.Length == 1) return false;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }
            }

            return false;
        }
    }
}
