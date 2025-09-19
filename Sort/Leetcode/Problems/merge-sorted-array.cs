using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 88. 合并两个有序数组
    /// https://leetcode.cn/problems/merge-sorted-array/description/
    /// </summary>
    public class merge_sorted_array
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;

            if (m == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    nums1[i] = nums2[i];
                }
                return;
            }

            int[] temp = new int[m];
            for (int i = 0; i < m; i++)
            {
                temp[i] = nums1[i];
            }
            int min = m < n ? m : n;
            int tempM = 0;
            int tempN = 0;

            for (int i = 0; i < m + n; i++)
            {
                if (temp[tempM] <= nums2[tempN])
                {
                    nums1[i] = temp[tempM];
                    tempM++;
                }
                else
                {
                    nums1[i] = nums2[tempN];
                    tempN++;
                }
                //Console.WriteLine(nums1[i]);
                if (tempM == m)
                {
                    for (i++; i < m + n; i++)
                    {
                        nums1[i] = nums2[tempN];
                        tempN++;
                    }
                    break;
                }
                if (tempN == n)
                {
                    for (i++; i < m + n; i++)
                    {
                        nums1[i] = temp[tempM];
                        tempM++;
                    }
                    break;
                }
            }


        }
    }
}
