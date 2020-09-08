using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 77. 组合
    /// https://leetcode-cn.com/problems/combinations/
    /// </summary>
    public class combinations
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            result = new List<IList<int>>();

            var nums = Enumerable.Range(1, n).ToList();
            DFS(nums,new List<int>(), k);
            return result;
        }

        private List<IList<int>> result = new List<IList<int>>();
        private void DFS(List<int> nums, List<int> item, int k)
        {
            if (item.Count == k)
            {
                result.Add(new List<int>(item));
                return;
            }

            foreach (var n in nums)
            {
                if (item.Contains(n))
                    continue;
                if (item.Count>0 && n < item.Last())
                    continue;

                item.Add(n);

                //into loop
                DFS(nums,item,k);

                //reverse
                item.Remove(n);
            }

        }


        /// <summary>
        /// 回溯
        /// 巧妙剪枝
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> CombineV2(int n, int k)
        {
            result2 = new List<IList<int>>();

            var nums = Enumerable.Range(1, n).ToList();
            DFS_Index(nums, new List<int>(),0, k);
            return result2;
        }

        private List<IList<int>> result2 = new List<IList<int>>();
        private void DFS_Index(List<int> nums, List<int> item, int index, int k)
        {
            if (item.Count == k)
            {
                result2.Add(new List<int>(item));
                return;
            }

            // 只有这里 i <= n - (k - path.size()) + 1 与参考代码 1 不同
            for (int i = index; i < nums.Count - (k - item.Count) + 1; i++)
            {
                item.Add(nums[i]);

                //into loop
                DFS_Index(nums, item, i+1, k);

                //reverse
                item.Remove(nums[i]);
            }
        }
    }
}
