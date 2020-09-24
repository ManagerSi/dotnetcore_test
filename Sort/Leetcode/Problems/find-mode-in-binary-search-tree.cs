using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 501. 二叉搜索树中的众数
    /// https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/
    /// </summary>
    public class find_mode_in_binary_search_tree
    {
        /// <summary>
        /// 暴力法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode(TreeNode root)
        {
            if (root == null)
                return new int[]{};

            Dictionary<int,int> countDic = new Dictionary<int, int>();
            //遍历tree，填充dict
            Stack<TreeNode> stack=new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count>0)
            {
                var node = stack.Pop();
                if (countDic.ContainsKey(node.val))
                    countDic[node.val]++;
                else
                    countDic.Add(node.val,1);

                if(node.left!=null)
                    stack.Push(node.left);
                if (node.right != null)
                    stack.Push(node.right);
            }

            var maxCount = countDic.Max(i => i.Value);
            return countDic.Where(i => i.Value == maxCount).Select(i => i.Key).ToArray();
        }

        /// <summary>
        /// 暴力循环,递归
        /// 中序遍历-->有序
        /// 重复出现的数字一定是一个连续出现的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode_V2(TreeNode root)
        {
            if (root == null)
                return new int[] { };

            //init
            currentVal = int.MinValue;
            currentCount = 0;
            maxCount = 0;
            result = new List<int>();

            //遍历tree
            DFS(root);

            return result.ToArray();
        }

        /// <summary>
        /// 深度优先，中序遍历
        /// </summary>
        /// <param name="root"></param>
        private void DFS(TreeNode root)
        {
            if (root == null)
                return;


            if (root.left != null)
            {
                DFS(root.left);
            }

            UpdateCount(root.val);

            if (root.right != null)
            {
                DFS(root.right);
            }
        }

        private int currentVal = int.MinValue;
        private int currentCount = 0;
        private int maxCount = 0;
        List<int> result = new List<int>();
        private void UpdateCount(int val)
        {
            if (val == currentVal)
            { currentCount++;}
            else
            {
                currentCount = 1;
                currentVal = val;
            }

            if (currentCount == maxCount)
            {
                result.Add(currentVal);
            }

            if (currentCount > maxCount)
            {
                result = new List<int>();
                result.Add(currentVal);
                maxCount = currentCount;
            }
        }

        /// <summary>
        /// 暴力循环,非递归
        /// 中序遍历-->有序
        /// 重复出现的数字一定是一个连续出现的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode_V3(TreeNode root)
        {
            if (root == null)
                return new int[] { };

            //init
            currentVal = int.MinValue;
            currentCount = 0;
            maxCount = 0;
            result = new List<int>();

            //非递归遍历tree
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root!=null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root); //根先进栈
                    root = root.left;
                }

                if (stack.Count > 0)
                {
                    root = stack.Pop();
                    UpdateCount(root.val);
                    root = root.right;
                }
            }

            return result.ToArray();
        }

    }
}
