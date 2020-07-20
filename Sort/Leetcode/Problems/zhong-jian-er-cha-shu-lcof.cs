using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 07. 重建二叉树
    /// https://leetcode-cn.com/problems/zhong-jian-er-cha-shu-lcof/
    ///
    /// 前序遍历 preorder = [3,9,20,15,7]
    /// 中序遍历 inorder = [9, 3, 15, 20, 7]
    /// </summary>
    public class zhong_jian_er_cha_shu_lcof
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0)
                return null;

            var tree = new TreeNode();
            return buildSubTree(preorder, inorder,0,0,preorder.Length-1 );

            return tree;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <param name="root">前序的根索引</param>
        /// <param name="start">中序</param>
        /// <param name="end">中序</param>
        /// <returns></returns>
        private TreeNode buildSubTree(int[] preorder, int[] inorder,int root, int start, int end)
        {
            if (start > end)
                return null;
            TreeNode node = new TreeNode(preorder[root]);

            //查找root所在位置
            int index = start;
            while (index < end && preorder[root] != inorder[index]) index++;

            /// 前序遍历 preorder = [3,9,20,15,7]
            /// 中序遍历 inorder = [9, 3, 15, 20, 7]
            node.left = buildSubTree(preorder, inorder, root + 1, start, index - 1); //中序中根左边部份
            node.right = buildSubTree(preorder, inorder, root + 1 + index - start, index + 1, end); // 中序中根右边部份
            
            return node;
        }
    }
}
