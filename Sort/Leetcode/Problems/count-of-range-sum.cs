using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 327. 区间和的个数
    /// https://leetcode-cn.com/problems/count-of-range-sum/
    /// </summary>
    public class count_of_range_sum
    {
        /// <summary>
        /// 暴力解法--超出时间限制
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            if (nums == null || nums.Length == 0) return 0;

            int count = 0;
            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = nums[i];
                if (sum >= lower && sum <= upper)
                    count++;

                for (int j = i+1; j < nums.Length; j++)
                {
                    //检查溢出
                    //if(nums[j]<0 && sum<0 && nums[j] < int.MinValue - sum 
                    //   || 
                    //   nums[j] > 0 && sum > 0 && nums[j] >int.MaxValue- sum) 
                    //    continue;
                    
                    sum += nums[j];
                    if (sum >= lower && sum <= upper)
                        count++;
                }
            }

            return count;
        }


        /// <summary>
        /// 首先求出PreSum数组，我们需要的是PreSum中任意两点i<j，其中后面PreSum[j] - PreSum[i]在区间内，差的顺序很重要!
        /// 已知，如果从两个单独的顺序序列各任意取一个点来实现差在区间内，很容易实现
        /// 那么假如把PreSum分成两个数组，两个数组都是有序的，然后从两个数组各取一个点，实现差值在范围内，那么这个也是容易实现的
        /// 回到题目，我们需要从PreSum任意取两点，因此，除了3中提到的情况外，还有另外两种情况：
        ///     1.两个点都在前半段中
        ///     2.两个点都在后半段中
        /// 因此通过递归实现4中的两种情况，并且每次递归完成3的情况后，使用归并合并两个有序数组为一个有序数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int CountRangeSum_V2(int[] nums, int lower, int upper)
        {
            //首先求出PreSum数组
            long[] sum = new long[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sum[i + 1] = sum[i] + nums[i];
            }
            return CountRangeSumRecursive(sum, lower, upper, 0, sum.Length - 1);
        }

        public int CountRangeSumRecursive(long[] sum, int lower, int upper, int left, int right)
        {
            if (left == right)
            {
                return 0;
            }
            else
            {
                int mid = (left + right) / 2;
                int n1 = CountRangeSumRecursive(sum, lower, upper, left, mid); //先统计左半边数量
                int n2 = CountRangeSumRecursive(sum, lower, upper, mid + 1, right);//再统计右半边数量
                int ret = n1 + n2;

                // 统计下标对的数量(两段各取一个点)
                int i = left;
                int l = mid + 1;
                int r = mid + 1;
                while (i <= mid)
                {
                    while (l <= right && sum[l] - sum[i] < lower)
                    {
                        l++;
                    }
                    while (r <= right && sum[r] - sum[i] <= upper)
                    {
                        r++;
                    }
                    ret += r - l;
                    i++;
                }

                // 随后合并两个排序数组
                int[] sorted = new int[right - left + 1];
                int p1 = left, p2 = mid + 1;
                int p = 0;
                while (p1 <= mid || p2 <= right)
                {
                    if (p1 > mid)
                    {
                        sorted[p++] = (int)sum[p2++];
                    }
                    else if (p2 > right)
                    {
                        sorted[p++] = (int)sum[p1++];
                    }
                    else
                    {
                        if (sum[p1] < sum[p2])
                        {
                            sorted[p++] = (int)sum[p1++];
                        }
                        else
                        {
                            sorted[p++] = (int)sum[p2++];
                        }
                    }
                }
                for (int j = 0; j < sorted.Length; j++)
                {
                    sum[left + j] = sorted[j];
                }
                return ret;
            }
        }


    }
}
