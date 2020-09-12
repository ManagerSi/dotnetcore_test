using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 637. 二叉树的层平均值
    /// https://leetcode-cn.com/problems/average-of-levels-in-binary-tree/
    /// </summary>
    public class average_of_levels_in_binary_tree
    {
        /// <summary>
        /// 层次遍历--递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels(TreeNode root)
        {
            result = new List<double>();

            List<TreeNode> treeList = new List<TreeNode>(){root};
            Leval(treeList);

            return result;
        }

        private List<double> result;

        private void Leval(List<TreeNode> treeList)
        {
            if (treeList == null|| treeList.Count==0)
                return;

            List<TreeNode> tempList = new List<TreeNode>();
            double levelSum = 0;
            foreach (var node in treeList)
            {
                levelSum += node.val;

                if(node.left!=null)
                    tempList.Add(node.left);
                if (node.right != null)
                    tempList.Add(node.right);
            }

            result.Add(levelSum/(double)treeList.Count);

            Leval(tempList);
        }


        /// <summary>
        /// 层次遍历--非递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels_V2(TreeNode root)
        {
            var result1 = new List<double>();
            if (root == null)
                return result1;

            List<TreeNode> treeList = new List<TreeNode>() { root };
            List<TreeNode> tempList = new List<TreeNode>();
            while (treeList.Count>0)
            {
                double levelSum = 0;
                foreach (var node in treeList)
                {
                    levelSum += node.val;

                    if (node.left != null)
                        tempList.Add(node.left);
                    if (node.right != null)
                        tempList.Add(node.right);
                }

                result1.Add(levelSum / (double)treeList.Count);

                treeList.Clear();
                treeList.AddRange(tempList);
                tempList = new List<TreeNode>();
            }

            return result1;
        }


        /// <summary>
        /// 层次遍历--非递归--队列
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels_V3(TreeNode root)
        {
            var result1 = new List<double>();
            if (root == null)
                return result1;

            Queue<TreeNode> treeQueue = new Queue<TreeNode>();
            treeQueue.Enqueue(root);

            double levelSum = 0;
            int count = 0;
            while (treeQueue.Count > 0)
            {
                levelSum = 0;
                count = treeQueue.Count;
                for (int i = 0; i < count; i++)
                {
                    var node = treeQueue.Dequeue();

                    levelSum += node.val;

                    if (node.left != null)
                        treeQueue.Enqueue(node.left);
                    if (node.right != null)
                        treeQueue.Enqueue(node.right);
                }

                result1.Add(levelSum / (double)count);
            }

            return result1;
        }

    }
}
