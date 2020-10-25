using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 530. 二叉搜索树的最小绝对差
    /// https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/
    /// </summary>
    public class minimum_absolute_difference_in_bst
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference(TreeNode root)
        {
            treeList = new List<int>();

            Inorder(root);

            int minGap = int.MaxValue;
            for (int i = 0; i < treeList.Count-1; i++)
            {
                var gap = Math.Abs(treeList[i] - treeList[i + 1]);
                minGap = Math.Min(minGap, gap);
            }

            return minGap;
        }
        private List<int> treeList ;
        private void Inorder(TreeNode root)
        {
            if (root == null)
                return;

            if (root.left!=null)
                Inorder(root.left);

            //按序加入列表
            treeList.Add(root.val);

            if (root.right != null)
                Inorder(root.right);
        }

        /// <summary>
        /// 中序遍历-去除abs函数
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference_V2(TreeNode root)
        {
            treeList = new List<int>();

            Inorder(root);

            int minGap = int.MaxValue;
            for (int i = 0; i < treeList.Count - 1; i++)
            {
                //改良， i+1 的值一定> i 的值
                var gap = treeList[i+1] - treeList[i];
                minGap = Math.Min(minGap, gap);
            }

            return minGap;
        }


        /// <summary>
        /// 中序遍历-优化-去除List变量
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference_V3(TreeNode root)
        {
            result_V3 = int.MaxValue;
            pre_V3 = -1;

            Inorder_V3(root);

            return result_V3;
        }

        private int result_V3;
        private int pre_V3;
        private void Inorder_V3(TreeNode root)
        {
            if (root == null)
                return;

            Inorder_V3(root.left);

            if(pre_V3 != -1)
                result_V3 = Math.Min(result_V3, root.val - pre_V3);
            pre_V3 = root.val;

            Inorder_V3(root.right);
        }
    }
}
