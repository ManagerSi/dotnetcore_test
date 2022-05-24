using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 965. 单值二叉树
    /// https://leetcode.cn/problems/univalued-binary-tree/
    /// </summary>
    public class univalued_binary_tree
    {
        /// <summary>
        /// 深度优先遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsUnivalTree(TreeNode root)
        {
            return CheckNodeValue(root, root.val);
        }

        /// <summary>
        /// 深度优先遍历 dts
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool CheckNodeValue(TreeNode root, int val)
        {
            if (root.val != val)
                return false;

            if (root.left != null)
            {
                if (!CheckNodeValue(root.left, val))
                    return false;
            }

            if (root.right != null)
                if (!CheckNodeValue(root.right, val))
                    return false;

            return true;
        }
    }
}
