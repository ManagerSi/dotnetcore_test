using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 112. 路径总和
    /// https://leetcode-cn.com/problems/path-sum/
    /// </summary>
    public class Has_Path_Sum
    {
        /// <summary>
        /// 思路：深度优先遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.left == null && root.right == null)
                return sum - root.val == 0;

            if (HasPathSum(root.left, sum - root.val))
                return true;

            if (HasPathSum(root.right, sum - root.val))
                return true;

            return false;
        }
    }
}
