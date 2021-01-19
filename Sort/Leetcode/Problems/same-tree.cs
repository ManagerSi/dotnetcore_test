using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 100. 相同的树
    /// https://leetcode-cn.com/problems/same-tree/
    /// </summary>
    public class same_tree
    {
        /// <summary>
        /// 深度优先搜索
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if(p?.val == q?.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            return false;
        }

        /// <summary>
        /// 广度优先遍历
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree_V2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p == null || q == null) return false;

            Queue<TreeNode> Q1 = new Queue<TreeNode>();
            Queue<TreeNode> Q2 = new Queue<TreeNode>();
            Q1.Enqueue(p);
            Q2.Enqueue(q);
            while (Q1.Count>0 && Q2.Count>0)
            {
                var node1 = Q1.Dequeue();
                var node2 = Q2.Dequeue();

                if (node1.val != node2.val) return false;

                if ((node1.left == null) ^ (node2.left == null))
                    return false;

                if ((node1.right == null) ^ (node2.right == null))
                    return false;

                if(node1.left!=null)//same as node2
                { 
                    Q1.Enqueue(node1.left);
                    Q2.Enqueue(node2.left);
                }
                if (node1.right != null)//same as node2
                {
                    Q1.Enqueue(node1.right);
                    Q2.Enqueue(node2.right);
                }
            }

            return Q1.Count == Q2.Count;
        }
    }
}
