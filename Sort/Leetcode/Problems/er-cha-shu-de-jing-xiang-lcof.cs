using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 27. 二叉树的镜像
    /// https://leetcode-cn.com/problems/er-cha-shu-de-jing-xiang-lcof/
    /// </summary>
    public class er_cha_shu_de_jing_xiang_lcof
    {
        public TreeNode MirrorTree(TreeNode root)
        {
            changeNode(root);

            return root;
        }

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
