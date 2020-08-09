using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 35. 搜索插入位置
    /// https://leetcode-cn.com/problems/search-insert-position/
    /// </summary>
    public class search_insert_position
    {
        /// <summary>
        /// 暴力破解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null ) return -1;
            if (nums.Length == 0) return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target) continue;
                if (nums[i] == target)
                {
                    return i;
                }
                if (nums[i] > target)
                {
                    //var arr = new int[nums.Length + 1];
                    //for (int j = 0; j < i; j++)
                    //{
                    //    arr[j] = nums[j];
                    //}
                    //arr[i] = target;
                    //for (int k = i; k < nums.Length; k++)
                    //{
                    //    arr[i + 1] = arr[i];
                    //}
                    return i;
                }
            }
            return nums.Length;
        }

        public int SearchInsert_V2(int[] nums, int target)
        {
            if (nums == null) return -1;
            if (nums.Length == 0) return 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target) continue;
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert_V3(int[] nums, int target)
        {
            int left = 0, right = nums.Length;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] > target)
                {
                    right = mid;
                }
                if (nums[mid] == target) return mid;
                if (nums[mid] < target)
                {
                    left = mid+1;
                }
            }
            return left;
        }
    }
}
