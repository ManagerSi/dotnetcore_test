using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 222. 完全二叉树的节点个数
    /// https://leetcode-cn.com/problems/count-complete-tree-nodes/
    /// </summary>
    public class count_complete_tree_nodes
    {
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return CountNodes(root.left) + CountNodes(root.right) + 1;
        }

        public int CountNodes_v2(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }
            int left = countLevel(root.left);
            int right = countLevel(root.right);
            if (left == right)
            {
                return CountNodes_v2(root.right) + (1 << left);
            }
            else
            {
                return CountNodes_v2(root.left) + (1 << right);
            }
        }
        private int countLevel(TreeNode root)
        {
            int level = 0;
            while (root != null)
            {
                level++;
                root = root.left;
            }
            return level;
        }

    }
}
