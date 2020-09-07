using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 347. 前 K 个高频元素
    /// https://leetcode-cn.com/problems/top-k-frequent-elements/
    /// notes:
    /// 你可以假设给定的 k 总是合理的，且 1 ≤ k ≤ 数组中不相同的元素的个数。
    /// 你的算法的时间复杂度必须优于 O(n log n) , n 是数组的大小。
    /// 题目数据保证答案唯一，换句话说，数组中前 k 个高频元素的集合是唯一的。
    /// 你可以按任意顺序返回答案。 
    /// </summary>
    public class top_k_frequent_elements
    {
        /// <summary>
        /// 暴力题解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int,int> countDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (countDic.ContainsKey(nums[i]))
                    countDic[nums[i]]++;
                else
                    countDic.Add(nums[i],1);
            }

            return countDic.OrderByDescending(i => i.Value).Take(k).Select(i => i.Key).ToArray();
        }

        public int[] TopKFrequent_V1(int[] nums, int k)
        {
            return nums.GroupBy(r => r).OrderByDescending(r => r.Count()).Take(k).Select(r => r.Key).ToArray();
        }

        /// <summary>
        /// 最小堆
        /// 思路：
        /// https://leetcode-cn.com/problems/top-k-frequent-elements/solution/cban-ben-mei-you-priorityqueuezhi-neng-shi-yong-so/
        /// https://leetcode-cn.com/problems/top-k-frequent-elements/solution/heap-solution-from-leetcode-by-bao-mi-hua-9/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent_V2(int[] nums, int k)
        {
            return null;
        }
    }
}
