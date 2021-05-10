using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 872. 叶子相似的树
    /// https://leetcode-cn.com/problems/leaf-similar-trees/
    /// </summary>
    public class leaf_similar_trees
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            string list1 = GetLeafs(root1);
            string list2 = GetLeafs(root2);

            return list1 == list2;
        }

        private string GetLeafs(TreeNode treeNode)
        {
            if (treeNode == null) return null;

            List<int> sb = new List<int>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(treeNode);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.left == null && node.right == null)
                    sb.Add(node.val);

                if(node.right!=null)
                    stack.Push(node.right);

                if (node.left != null)
                    stack.Push(node.left);
            }

            var res = string.Join(',', sb);
            Console.WriteLine(res);
            return res;
        }
    }
}
