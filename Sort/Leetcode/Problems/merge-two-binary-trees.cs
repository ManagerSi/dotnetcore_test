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

        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees_V2(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;

            if (t2 == null) return t1;

            var newRoot = new TreeNode((t1?.val ?? 0) + (t2?.val ?? 0));

            newRoot.left = MergeTrees_V2(t1?.left, t2?.left);

            newRoot.right = MergeTrees_V2(t1?.right, t2?.right);

            return newRoot;
        }

        /// <summary>
        /// bfs 层次遍历
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees_V3(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            var stack = new Stack<TreeNode>(new List<TreeNode>(){t1,t2});
            while (stack.Count>0)
            {
                var node2 = stack.Pop();
                var node1 = stack.Pop();

                node1.val += node2.val; //直接使用t1

                //left
                if (node1.left == null && node2.left != null)
                {
                    node1.left = node2.left;
                }
                else if (node1.left != null && node2.left != null)
                {
                    stack.Push(node1.left);
                    stack.Push(node2.left);
                }

                //right
                if (node1.right == null && node2.right != null)
                {
                    node1.right = node2.right;
                }
                else if (node1.right != null && node2.right != null)
                {
                    stack.Push(node1.right);
                    stack.Push(node2.right);
                }
            }

            return t1;
        }
    }
}
