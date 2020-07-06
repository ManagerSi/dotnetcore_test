using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 572. 另一个树的子树
    /// https://leetcode-cn.com/problems/subtree-of-another-tree/
    /// </summary>
    public class subtree_of_another_tree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if (s != null && t == null) return true;
            if (s == null && t != null) return false;

            return CheckNode(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }
        private  bool CheckNode(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;
            if (s == null || t == null)
                return false;
            if (s.val == t.val && CheckNode(s.left, t.left) && CheckNode(s.right, t.right))
                return true;

            return false;
        }
    }

}
