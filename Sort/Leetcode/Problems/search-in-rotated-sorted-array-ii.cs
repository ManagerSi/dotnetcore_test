using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 81. 搜索旋转排序数组 II
    /// https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/
    /// </summary>
    public class search_in_rotated_sorted_array_ii
    {
        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return true;
            }

            return false;
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search_V2(int[] nums, int target)
        {


            return false;
        }
    }
}
