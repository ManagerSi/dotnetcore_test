using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 145. 二叉树的后序遍历
    /// https://leetcode-cn.com/problems/binary-tree-postorder-traversal/
    /// </summary>
    public class binary_tree_postorder_traversal
    {
        private List<int> orderList = null;
        public IList<int> PostorderTraversal(TreeNode root)
        {
            orderList = new List<int>();
            PostOrder(root);
            return orderList;
        }
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        private void PostOrder(TreeNode root)
        {
            if (root == null)
                return;

            if(root.left!=null)
                PostOrder(root.left);

            if (root.right != null)
                PostOrder(root.right);

            orderList.Add(root.val);
        }
    }
}
