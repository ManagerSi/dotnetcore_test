using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    public class maximum_depth_of_binary_tree
    {
        public int MaxDepth(TreeNode root)
        {
            return NodeDepth(root, 0);
        }
        private int NodeDepth(TreeNode root, int depth)
        {
            if (root == null)
                return depth;
            depth++;
            var leftDepth = NodeDepth(root.left, depth);
            var rightDepth = NodeDepth(root.right, depth);

            return leftDepth > rightDepth ? leftDepth : rightDepth;
        }



        //方法2，使用公共变量，减少内存
        private int iMaxDepth=0;
        public int MaxDepth_V2(TreeNode root)
        {
            NodeDepth_V2(root, 0);
            return iMaxDepth;
        }

        private void NodeDepth_V2(TreeNode root, int depth)
        {
            if (root == null)
                return;

            depth++;

            iMaxDepth = depth > iMaxDepth ? depth : iMaxDepth;

            NodeDepth_V2(root.left, depth);
            NodeDepth_V2(root.right, depth);
        }
    }
}
