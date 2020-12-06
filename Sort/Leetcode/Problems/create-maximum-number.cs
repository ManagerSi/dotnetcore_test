using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Extend;

namespace Leetcode.Problems
{
    /// <summary>
    /// 321. 拼接最大数
    /// https://leetcode-cn.com/problems/create-maximum-number/
    /// </summary>
    public class create_maximum_number
    {
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int[] maxRes = new int[0];
            for (int i = 0; i < k+1; i++)
            {
                int[] n1Max = PickMax(nums1, i);
                int[] n2Max = PickMax(nums2, k-i);
                int[] res = Merge(n1Max, n2Max);

                if (res.Length > maxRes.Length 
                    || (res.Length == maxRes.Length && Compare(res, 0, maxRes, 0)))
                    maxRes = res;
            }

            return maxRes;
        }

        private int[] PickMax(int[] num, int k)
        {
            if (num==null || k <= 0)
                return new int[] { };

            if (k >= num.Length)
                return num;

            int drop = num.Length - k;
            Stack<int> stack = new Stack<int>();
            foreach (var n in num)
            {
                while (stack.Count > 0 && n > stack.Peek() && drop > 0)
                {
                    stack.Pop();
                    drop--;
                }

                stack.Push(n);
            }

            for (int i = 0; i < drop; i++)
            {
                stack.Pop();
            }

            int[] res = new int[stack.Count];
            int index = res.Length - 1;
            while (stack.Count > 0)
            {
                res[index--] = stack.Pop();
            }

            return res;
        }

        private int[] Merge(int[] nums1, int[] nums2)
        {
            int x = nums1.Length, y = nums2.Length;
            if (x == 0)
            {
                return nums2;
            }
            if (y == 0)
            {
                return nums1;
            }
            
            int[] res = new int[x + y];
            int p1 = 0;
            int p2 = 0;
            // 这里原来两个数组未必有序，为了让大的元素尽可能往前放，比较的时候若当前元素相等还要往后比较
            for (int i = 0; i < res.Length; i++)
            {
                if (Compare(nums1, p1, nums2, p2))
                {
                    res[i] = nums1[p1++];
                }
                else
                {
                    res[i] = nums2[p2++];
                }
            }
            return res;
        }

        // 相当于把数组组成的数字左对齐后比较大小
        private bool Compare(int[] nums1, int p1, int[] nums2, int p2)
        {
            if (p2 >= nums2.Length) return true;
            if (p1 >= nums1.Length) return false;
            if (nums1[p1] > nums2[p2]) return true;
            if (nums1[p1] < nums2[p2]) return false;
            return Compare(nums1, p1 + 1, nums2, p2 + 1);
        }
    }
}
