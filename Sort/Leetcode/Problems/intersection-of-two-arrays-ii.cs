using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 350. 两个数组的交集 II
    /// 
    /// https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
    /// </summary>
    public class intersection_of_two_arrays_ii
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0)
                return null;

            return nums1.Intersect(nums2)?.ToArray();
        }
    }
}
