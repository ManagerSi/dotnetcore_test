using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 129. 求根到叶子节点数字之和
    /// https://leetcode-cn.com/problems/sum-root-to-leaf-numbers/
    /// </summary>
    public class sum_root_to_leaf_numbers
    {
        /// <summary>
        /// DFS 深度优先遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            _result = 0;
            DFS(root,0);

            return _result;
        }

        private int _result = 0;
        private void DFS(TreeNode root, int depSum)
        {
            //出口
            if (root == null) return;

            //验证
            if (root.left == null && root.right == null)
            {
                _result += depSum * 10 + root.val;
                return;
            }

            //下一个循环
            DFS(root.left, depSum * 10 + root.val);
            DFS(root.right, depSum * 10 + root.val);
        }

    }
}
