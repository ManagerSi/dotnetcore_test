using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 113. 路径总和 II
    /// https://leetcode-cn.com/problems/path-sum-ii/
    /// </summary>
    public class path_sum_ii
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            resultList = new List<IList<int>>();
            path = new List<int>();

            DFS(root, sum);

            return resultList;
        }
        private IList<IList<int>> resultList = null;
        private List<int> path = null;

        private void DFS(TreeNode root, int sum)
        {
            //退出条件
            if (root == null) return;

            //计算根,加入path
            var subtraction = sum - root.val;
            path.Add(root.val);

            //加入结果
            if (root.left == null && root.right == null && subtraction == 0)
            {
                resultList.Add(path.GetRange(0, path.Count));
            }

            //计算左子树
            DFS(root.left, subtraction);

            //计算右子树
            DFS(root.right, subtraction);

            //恢复-删除自己
            path.RemoveAt(path.Count - 1);
        }
    }
}
