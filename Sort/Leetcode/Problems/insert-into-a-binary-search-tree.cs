using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 701. 二叉搜索树中的插入操作
    /// https://leetcode-cn.com/problems/insert-into-a-binary-search-tree/
    /// </summary>
    public class insert_into_a_binary_search_tree
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            DFS(root,val);

            return root;
        }

        private bool DFS(TreeNode root, int val)
        {
            //退出条件
            if (root == null) return false;


            //判断
            if (root.val > val)
            {
                //退出条件
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                    return true;
                }
                else
                {
                    return DFS(root.left, val);
                }
            }

            //判断
            if (root.val < val)
            {
                //退出条件
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                    return true;
                }
                else
                {
                    return DFS(root.right, val);
                }
            }

            return false;
        }

        public TreeNode InsertIntoBST_V2(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);

            var tempNode = root;
            while (tempNode != null)
            {
                //判断
                if (tempNode.val > val)
                {
                    //退出条件
                    if (tempNode.left == null)
                    {
                        tempNode.left = new TreeNode(val);
                        break;
                    }

                    tempNode = tempNode.left;
                }
                else if (tempNode.val < val)
                {
                    //退出条件
                    if (tempNode.right == null)
                    {
                        tempNode.right = new TreeNode(val);
                        break;
                    }
                    tempNode = tempNode.right;
                }
            }

            return root;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST_V3(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (root.val < val)
            {
                root.right = InsertIntoBST_V3(root.right, val);
            }
            else
            {
                root.left = InsertIntoBST_V3(root.left, val);
            }
            return root;
        }
    }
}
