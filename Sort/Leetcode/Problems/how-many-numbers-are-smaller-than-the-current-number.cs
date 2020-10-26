using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1365. 有多少小于当前数字的数字
    /// https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/
    /// </summary>
    public class how_many_numbers_are_smaller_than_the_current_number
    {
        /// <summary>
        /// 暴力1 用已有方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            if (nums == null|| nums.Length==0)
                return nums;

            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = nums.Count(n => n < nums[i]);
            }

            return res;
        }

        /// <summary>
        /// 暴力2 用已有方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent_V2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j == i) continue;

                    if (nums[i] > nums[j])
                        res[i]++;
                }
            }

            return res;
        }

        /// <summary>
        /// 计数排序
        /// 建立一个频次数组 cntcnt ，cnt[i]cnt[i] 表示数字 ii 出现的次数。那么对于数字 ii 而言，小于它的数目就为 cnt[0...i-1]cnt[0...i−1] 的总和。
        ///
        /// 时间复杂度：O(N + K)O(N+K)，其中 KK 为值域大小。需要遍历两次原数组，同时遍历一次频次数组 cntcnt 找出前缀和。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent_V3(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            var counts = new int[101];
            for (int i = 0; i < nums.Length; i++)
            {
                counts[nums[i]]++; //计数
            }

            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    res[i] += counts[j];
                }
            }

            return res;
        }

        /// <summary>
        /// sort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent_V4(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return nums;

            //记录数字原位置,相同的放一起
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                    dic[nums[i]].Add(i);
                else
                    dic.Add(nums[i], new List<int>() {i});
            }

            //排序
            Array.Sort(nums);

            var res = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                foreach (var index in dic[nums[i]])
                {
                    res[index] = i;
                }
            }


            return res;
        }

    }
}
