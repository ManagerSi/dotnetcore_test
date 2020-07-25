using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 28. 对称的二叉树
    /// </summary>
    public class dui_cheng_de_er_cha_shu_lcof
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null )
                return true;

            if (root.left?.val != root.right?.val)
                return false;

            return CheckNodes(root.left, root.right);
        }

        private bool CheckNodes(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if (left?.val == right?.val)
            {
                var res1 = CheckNodes(left.left, right.right);
                var res2 = CheckNodes(left.right, right.left);

                return res2 && res1;
            }

            return false;
        }
    }
}
