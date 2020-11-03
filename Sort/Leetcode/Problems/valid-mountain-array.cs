using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 941. 有效的山脉数组
    /// https://leetcode-cn.com/problems/valid-mountain-array/
    /// </summary>
    public class valid_mountain_array
    {
        public bool ValidMountainArray(int[] A)
        {
            if (A.Length<3) return false;

            if (A[0] >= A[1]) return false;//只降

            bool rise = true;

            for (int i = 0; i < A.Length-1; i++)
            {
                //先升
                if (rise && A[i] < A[i + 1])
                {
                    //只升
                    if (i == A.Length - 2)
                        return false;

                    continue;
                }

                rise = false;
                //后降
                if (A[i] <= A[i + 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 双指针
        /// 可以使用两种指针，一个从左边找最高山峰，一个从右边找最高山峰，最后判断找到的是不是同一个山峰
        /// </summary>
        /// <returns></returns>
        public bool ValidMountainArray_V2(int[] A)
        {
            if (A.Length < 3) return false;

            if (A[0] >= A[1]) return false;//只降

            int left=0, right = A.Length-1,length = A.Length;
            while (left+1< length && A[left] < A[left+1])
                left++;

            while (0 < right-1 && A[right-1] > A[right])
                right--;

            return left == right && left != 0 && left != A.Length-1;
        }
    }
}
