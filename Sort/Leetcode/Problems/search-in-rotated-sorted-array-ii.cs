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
        /// 
        /// 2,5,6,0,0,1,2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search_V2(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            int mid = (l + r) / 2;

            while (l<=r)
            {
                if (nums[l] == target || nums[mid] == target || nums[r] == target) return true;
                else if (nums[l] < nums[mid] && nums[mid] > target && target > nums[l]) r = mid - 1;//左边有序，且 target<mid 在左边
                else if (nums[mid] < nums[r] && nums[mid] < target && target < nums[r]) l = mid + 1;//右边有序，且 target>mid 在右边
                else { l++; r--;}

                mid = (l + r) / 2;
            }

            return false;
        }
    }
}
