using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 230. 二叉搜索树中第K小的元素
    /// https://leetcode-cn.com/problems/kth-smallest-element-in-a-bst/
    /// </summary>
    public class kth_smallest_element_in_a_bst
    {
        /// <summary>
        /// 中序遍历得到有序数组
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            step = 0;
            return checkKValue(root, k);

        }
        private int step = 0;
        private int checkKValue(TreeNode node, int k)
        {
            if (node == null)
                return int.MinValue;

            //检查左元素
            var res = checkKValue(node.left, k);
            if (res != int.MinValue)
                return res;

            ++step;
            if (k == step)
                return node.val;

            //检查右元素
            res = checkKValue(node.right, k);
            if (res != int.MinValue)
                return res;

            return int.MinValue;
        }


        /// <summary>
        /// 中序遍历得到有序数组
        /// 使用stack存储
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest_V2(TreeNode root, int k)
        {
            return -1;
        }
    }
}
