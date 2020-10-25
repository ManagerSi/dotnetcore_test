using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 845. 数组中的最长山脉
    /// https://leetcode-cn.com/problems/longest-mountain-in-array/
    /// </summary>
    public class longest_mountain_in_array
    {
        public int LongestMountain(int[] A)
        {
            if (A == null || A.Length < 3)
                return 0;

            int maxMountain = 0;
            int increasing = 0, decreasing = 0;
            for (int i = 1; i < A.Length;)
            {
                increasing = 0; decreasing = 0;

                while (i < A.Length && A[i-1] < A[i]) { increasing++; i++; };
                while (i < A.Length && A[i-1] > A[i]) { decreasing++; i++; };

                if (increasing >= 1 && decreasing >= 1)
                    maxMountain = Math.Max(maxMountain, increasing + decreasing + 1);
                
                while (i < A.Length && A[i - 1] == A[i])
                    i++;//避免出现相等的情况
            }

            return maxMountain;
        }
    }
}
