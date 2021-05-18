using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    public class maximum_xor_of_two_numbers_in_an_array
    {
        // 字典树的根节点
        TreeNode root = new TreeNode();
        // 最高位的二进制位编号为 30
        const int HIGH_BIT = 30;

        /// <summary>
        /// 前缀 字典树
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            int result = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                // 将 nums[i-1] 放入字典树，此时 nums[0 .. i-1] 都在字典树中
                AddTreeNode(nums[i-1]);

                // 将 nums[i] 看作 ai，找出最大的 result 更新答案
                result = Math.Max(result, Check(nums[i]));
            }

            return result;
        }


        private void AddTreeNode(int num)
        {
            TreeNode current = root;
            for (int i = HIGH_BIT; i >= 0; i--)
            {
                int isOne = (num >> i) & 1;
                if (isOne == 0)
                {
                    if (current.left == null)
                        current.left = new TreeNode();

                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                        current.right = new TreeNode();

                    current = current.right;
                }
            }
        }

        private int Check(int num)
        {
            int res = 0;
            TreeNode current = root;

            for (int i = HIGH_BIT; i >= 0; i--)
            {
                int isOne = (num >> i) & 1;
                if (isOne == 0)
                {
                    // a_i 的第 i 个二进制位为 0，应当往表示 1 的子节点 right 走. (0 ^ 1)
                    if (current.right != null)
                    {
                        res =( res << 1 ) + 1;
                        current = current.right;
                    }
                    else
                    {
                        res = res << 1;
                        current = current.left;
                    }
                }
                else
                {
                    // a_i 的第 i 个二进制位为 1，应当往表示 0 的子节点 left 走. (0 ^ 1)
                    if (current.left != null)
                    {
                        res = (res << 1) + 1;
                        current = current.left;
                    }
                    else
                    {
                        res = res << 1;
                        current = current.right;
                    }
                }
            }

            return res;
        }
    }
}
