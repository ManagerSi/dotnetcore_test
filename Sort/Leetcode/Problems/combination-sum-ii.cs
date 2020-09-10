using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 40. 组合总和 II
    /// https://leetcode-cn.com/problems/combination-sum-ii/
    /// </summary>
    public class combination_sum_ii
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            if(candidates==null || candidates.Length==0)
                return new List<IList<int>>();

            // 关键步骤:不重复就需要按 顺序 搜索， 在搜索的过程中检测分支是否会出现重复结果 。
            Array.Sort(candidates);

            List<int> oneResults = new List<int>();
            DFS(candidates, target, 0, oneResults);
            return result;
        }


        private List<IList<int>> result = new List<IList<int>>();
        private void DFS(int[] candidates, int target,int index, List<int> oneResults)
        {
            //退出条件
            if (oneResults.Sum() == target)
            {
                result.Add(new List<int>(oneResults));
                return;
            }

            //遍历
            for (int i = index; i < candidates.Length; i++)
            {
                //if(oneResults.Contains(candidates[i])&& oneResults.Count(n => n == candidates[i]) == candidates.Count(n => n == candidates[i])-1)
                //    continue;

                if (oneResults.Sum() + candidates[i] > target)
                {
                    break;
                }
                // 小剪枝：同一层相同数值的结点，从第 2 个开始，候选数更少，结果一定发生重复，因此跳过，用 continue
                if (i > index && candidates[i] == candidates[i - 1])
                {
                    continue;
                }

                oneResults.Add(candidates[i]);
                DFS(candidates, target , i + 1, oneResults);

                //reverse
                oneResults.Remove(candidates[i]);
                //target += candidates[i];
            }
        }
    }
}
