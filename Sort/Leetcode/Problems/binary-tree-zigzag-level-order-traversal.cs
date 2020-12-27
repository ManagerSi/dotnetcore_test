using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 103. 二叉树的锯齿形层序遍历
    /// https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/
    /// </summary>
    public class binary_tree_zigzag_level_order_traversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> resultList = new List<IList<int>>();
            if (root == null) return resultList;

            bool isRevers = false;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count>0)
            {
                List<TreeNode> nodelist = new List<TreeNode>();
                List<int> intlist = new List<int>();
                while (stack.Count>0)
                {
                    var node = stack.Pop();
                    intlist.Add(node.val);

                    if (isRevers)
                    {
                        if (node.right != null)
                            nodelist.Add(node.right);
                        if (node.left != null)
                            nodelist.Add(node.left);
                    }
                    else
                    {
                        if (node.left != null)
                            nodelist.Add(node.left);
                        if (node.right != null)
                            nodelist.Add(node.right);
                    }
                }

                resultList.Add(intlist);
                isRevers = !isRevers;

                if (nodelist.Count > 0)
                {
                    foreach (var treeNode in nodelist)
                    {
                        stack.Push(treeNode);
                    }

                }
            }

            return resultList;
        }

    }
}
