using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    public class convert_bst_to_greater_tree
    {
        /// <summary>
        /// 1. 遍历获取所有节点值 放在list中
        /// 2. 遍历所有节点，计算大于其节点的和，更新节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null)
                return root;
            
            //1. get all tree value into list
            List<int> nodeList = new List<int>();
            Stack<TreeNode> nodeStack = new Stack<TreeNode>(new List<TreeNode>(){root});
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                nodeList.Add(node.val);
                if(node.left!=null)
                    nodeStack.Push(node.left);
                if (node.right != null)
                    nodeStack.Push(node.right);
            }

            //2. re-calculate the node value
            nodeStack.Push(root);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                var sum = nodeList.Where(i => i > node.val).Sum();
                node.val = node.val + sum;

                if (node.left != null)
                    nodeStack.Push(node.left);
                if (node.right != null)
                    nodeStack.Push(node.right);
            }

            return root;
        }

        /// <summary>
        /// 二叉排序树，大于当前节点的就根和右子树
        /// 先求和，在中序
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST_V2(TreeNode root)
        {
            if (root == null)
                return root;

            int sumofTree = 0;
            TreeNode res = root;
            Stack<TreeNode> nodeStack = new Stack<TreeNode>(new List<TreeNode>() { res });
            while (nodeStack.Count>0)
            {
                var node = nodeStack.Pop();
                sumofTree += node.val;

                if (node.left != null)
                    nodeStack.Push(node.left);
                if (node.right != null)
                    nodeStack.Push(node.right);
            }

            nodeStack.Clear();
            while (nodeStack.Count > 0 || res!=null)
            {
                if (res != null)
                {
                    nodeStack.Push(res);
                    res = res.left;
                }
                else
                {
                    var node = nodeStack.Pop();
                    sumofTree -= node.val;
                    node.val += sumofTree;
                    res = node.right;
                }
                
            }

            return root;
        }

        /// <summary>
        /// 二叉排序树，大于当前节点的就根和右子树
        /// 本题中要求我们将每个节点的值修改为原来的节点值加上所有大于它的节点值之和。
        /// 这样我们只需要反序中序遍历该二叉搜索树，记录过程中的节点值之和，并不断更新当前遍历到的节点的节点值，即可得到题目要求的累加树。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST_V3(TreeNode root)
        {
            if (root == null)
                return null;

            ConvertBST_V3(root.right);

            sum += root.val;
            root.val = sum;

            ConvertBST_V3(root.left);
            
            return root;
        }

        public int sum = 0;

        /// <summary>
        /// 二叉排序树，大于当前节点的就根和右子树
        /// V3的非递归版
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST_V3_V2(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            TreeNode res = root;
            int pre = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.right;
                }
                root = stack.Pop();
                root.val += pre;
                pre = root.val;
                root = root.left;
            }
            return res;
        }
    }
}
