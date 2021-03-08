using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 303. 区域和检索 - 数组不可变
    /// https://leetcode-cn.com/problems/range-sum-query-immutable/
    /// </summary>
    public class range_sum_query_immutable
    {
        /// <summary>
        /// 暴力解题
        /// </summary>
        public class NumArray
        {
            public NumArray(int[] nums)
            {
                _nums = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    _nums[i] = nums[i];
                }
            }

            private int[] _nums;
            public int SumRange(int i, int j)
            {
                int sum = 0;
                for (int k = i; k <= j; k++)
                {
                    sum += _nums[k];
                }

                return sum;
            }
        }

        /// <summary>
        /// 前缀和
        /// </summary>
        public class NumArray_V2
        {
            public NumArray_V2(int[] nums)
            {
                _sums = new int[nums.Length+1];
                _sums[0] = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    _sums[i+1] = _sums[i] + nums[i];
                }
            }

            private int[] _sums;
            public int SumRange(int i, int j)
            {
               return _sums[j+1] - _sums[i];
            }
        }
    }
}
