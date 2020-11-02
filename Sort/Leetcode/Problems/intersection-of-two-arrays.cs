using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 349. 两个数组的交集
    /// https://leetcode-cn.com/problems/intersection-of-two-arrays/
    /// </summary>
    public class intersection_of_two_arrays
    {
        /// <summary>
        /// 默认函数
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0) return new int[]{};
            if (nums2 == null || nums2.Length == 0) return new int[] { };

            return nums1.Intersect(nums2).ToArray();
        }
    }
}
