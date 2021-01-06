using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 297. 二叉树的序列化与反序列化
    /// https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/
    /// </summary>
    public class serialize_and_deserialize_binary_tree
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "x";
            var left = serialize(root.left);
            var right = serialize(root.right);
            return $"{ root.val},{left},{right}";
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            List<string> list = data.Split(',').ToList();
            return buildNode(list);
        }

        private TreeNode buildNode(List<string> list)
        {
            var rootValue = list[0];
            list.RemoveAt(0);
            if (rootValue == "x") return null;

            var root = new TreeNode(int.Parse(rootValue));
            root.left = buildNode(list);
            root.right = buildNode(list);
            return root;
        }

        // Your Codec object will be instantiated and called as such:
        // Codec ser = new Codec();
        // Codec deser = new Codec();
        // TreeNode ans = deser.deserialize(ser.serialize(root));
    }
}
