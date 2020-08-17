using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 110. Balanced Binary Tree
    /// https://leetcode-cn.com/problems/balanced-binary-tree/
    /// </summary>
    public class balanced_binary_tree
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;

            var leftL = TreeHeight(root.left, 0);
            if (leftL == int.MaxValue) return false;

            var rightL = TreeHeight(root.right, 0);
            if (rightL == int.MaxValue) return false;

            return Math.Abs(leftL - rightL) <= 1;
        }

        private int TreeHeight(TreeNode node, int v)
        {
            if (node == null)
                return v;
            var leftL = TreeHeight(node.left, v + 1);
            if (leftL == int.MaxValue) return leftL;

            var rightL = TreeHeight(node.right, v + 1);
            if (rightL == int.MaxValue) return rightL;

            if (Math.Abs(leftL - rightL) > 1)
                return int.MaxValue;

            return leftL > rightL ? leftL : rightL;
        }
    }
}
