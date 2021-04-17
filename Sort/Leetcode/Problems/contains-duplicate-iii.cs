using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 220. 存在重复元素 III
    /// https://leetcode-cn.com/problems/contains-duplicate-iii/
    /// </summary>
    public class contains_duplicate_iii
    {
        /// <summary>
        /// 暴力遍历--超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if ((nums == null || nums.Length == 0))
                return false;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs((long)nums[i] - (long)nums[j]) <= t && Math.Abs(i - j) <= k)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 滑动窗口---二进制搜索树
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate_V2(int[] nums, int k, int t)
        {
            SortedSet<long> sl = new SortedSet<long>();
            for (int j = 0; j < nums.Length; j++)
            {
                if (sl.GetViewBetween((long)nums[j] - (long)t, (long)nums[j] + (long)t).Any())
                    return true;
                sl.Add(nums[j]);
                if (sl.Count() > k)
                    sl.Remove(nums[j - k]);
            }
            return false;
        }

        /// <summary>
        /// 桶排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate_V3(int[] nums, int k, int t)
        {
            if (nums.Length == 0)
                return false;

            if (t < 0 || k <= 0)
                return false;

            int bulk = t + 1;
            Dictionary<long, long> dict = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k)
                {
                    dict.Remove(getID(nums[i - k - 1], bulk));
                    Console.WriteLine("remove:" + (i - k - 1));
                }

                int id = getID(nums[i], bulk);
                if (dict.ContainsKey(id))
                    return true;
                dict[id] = nums[i];
                if (dict.ContainsKey(id - 1) && Math.Abs(dict[id - 1] - dict[id]) <= t)
                    return true;
                if (dict.ContainsKey(id + 1) && Math.Abs(dict[id + 1] - dict[id]) <= t)
                    return true;
            }
            return false;
        }

        int getID(int i, int w)
        {
            if (i >= 0)
                return i / w;
            return (i + 1) / w - 1;
        }
    }
}
