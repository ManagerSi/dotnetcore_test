using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 617. 合并二叉树
    /// https://leetcode-cn.com/problems/merge-two-binary-trees/
    /// </summary>
    public class merge_two_binary_trees
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
           return DFS(t1, t2);
        }

        private TreeNode DFS(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }

            var newRoot = new TreeNode((t1?.val??0) + (t2?.val ?? 0));

            newRoot.left = DFS(t1?.left, t2?.left);

            newRoot.right = DFS(t1?.right, t2?.right);
            
            return newRoot;
        }


        public TreeNode MergeTrees_V2(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;

            if (t2 == null) return t1;

            var newRoot = new TreeNode((t1?.val ?? 0) + (t2?.val ?? 0));

            newRoot.left = MergeTrees_V2(t1?.left, t2?.left);

            newRoot.right = MergeTrees_V2(t1?.right, t2?.right);

            return newRoot;
        }
    }
}
