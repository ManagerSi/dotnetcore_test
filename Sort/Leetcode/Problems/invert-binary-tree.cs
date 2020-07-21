using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 226. 翻转二叉树
    /// https://leetcode-cn.com/problems/invert-binary-tree/
    ///
    /// 同er_cha_shu_de_jing_xiang_lcof
    /// </summary>
    public class invert_binary_tree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            changeNode(root);

            return root;
        }

        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <param name="node"></param>
        private void changeNode(TreeNode node)
        {
            if (node == null)
                return;

            var temp = node.left;
            node.left = node.right;
            node.right = temp;

            changeNode(node.left);
            changeNode(node.right);
        }
    }
}
