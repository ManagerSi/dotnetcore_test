using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 783. 二叉搜索树节点最小距离
    /// https://leetcode-cn.com/problems/minimum-distance-between-bst-nodes/
    /// </summary>
    public class minimum_distance_between_bst_nodes
    {
        /// <summary>
        /// 广度优先遍历--需再次排序
        /// bfs
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST(TreeNode root)
        {
            var diff = int.MaxValue;
            List<int> list = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                list.Add(t.val);

                if (t.left != null)
                {
                    //diff = Math.Min(diff, t.val - t.left.val);
                    queue.Enqueue(t.left);
                }

                if (t.right != null)
                {
                    //右子节点和夫节点差值未考虑
                    //diff = Math.Min(diff, t.right.val - t.val);
                    queue.Enqueue(t.right);
                }
            }

            //右子节点和夫节点差值未考虑,需要排序
            list = list.OrderBy(i => i).ToList();
            for (int i = 1; i < list.Count(); i++)
            {
                diff = Math.Min(diff, list[i] - list[i - 1]);
            }

            return diff;
        }

        /// <summary>
        /// dfs 中序遍历-有序（递归）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST_V2(TreeNode root)
        {
            var list = new List<int>();

            DFS(root, list);//递归

            var diff = int.MaxValue;
            for (int i = 1; i < list.Count(); i++)
            {
                diff = Math.Min(diff, list[i] - list[i - 1]);
            }

            return diff;
        }

        private void DFS(TreeNode root, List<int> list)
        {
            if (root == null) return;

            DFS(root.left,list);
            list.Add(root.val);
            DFS(root.right, list);
        }


        ///// <summary>
        ///// dfs 中序遍历-有序（栈模拟）
        ///// </summary>
        ///// <param name="root"></param>
        ///// <returns></returns>
        //public int MinDiffInBST_V3(TreeNode root)
        //{

        //    int ans = int.MaxValue;
        //    TreeNode prev = null;
        //    // 栈模拟
        //    Queue<TreeNode> d = new Queue<TreeNode>();
        //    while (root != null || d.Count==0)
        //    {
        //        while (root != null)
        //        {
        //            d.Enqueue(root);
        //            root = root.left;
        //        }
        //        root = d.Dequeue();
        //        if (prev != null)
        //        {
        //            ans = Math.Min(ans, Math.Abs(prev.val - root.val));
        //        }
        //        prev = root;
        //        root = root.right;
        //    }


        //    return ans;
        //}
    }
}
