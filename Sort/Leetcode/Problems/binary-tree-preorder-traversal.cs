using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 144. 二叉树的前序遍历
    /// https://leetcode-cn.com/problems/binary-tree-preorder-traversal/
    /// </summary>
    public class binary_tree_preorder_traversal
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var res = new List<int>();
            if (root == null)
                return res;

            PreOrder(root, res);

            return res;
        }

        private void PreOrder(TreeNode root, List<int> res)
        {
            if (root == null)
                return;

            res.Add(root.val);

            PreOrder(root.left, res);
            PreOrder(root.right, res);
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal_V2(TreeNode root)
        {
            var res = new List<int>();
            if (root == null)
                return res;

            Stack<TreeNode> stack=new Stack<TreeNode>();
            var tempH = root;
            while (tempH != null || stack.Count>0)
            {
                while (tempH != null)
                {
                    res.Add(tempH.val);

                    stack.Push(tempH);

                    tempH = tempH.left;
                }

                var top = stack.Pop();
                tempH = top.right;
            }

            return res;
        }
    }
}
