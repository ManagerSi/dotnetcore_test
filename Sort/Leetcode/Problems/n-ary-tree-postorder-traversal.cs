using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    public class n_ary_tree_postorder_traversal
    {

        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public IList<int> Postorder(Node root)
        {
            if (root == null) return new List<int>();

            List<int> list = new List<int>();
            DFS(root, ref list);
            return list.ToArray();
        }

        public void DFS(Node root, ref List<int> list)
        {
            if (root == null) return;

            if (root.children != null)
            {
                foreach (var child in root.children)
                {
                    DFS(child, ref list);
                }
            }
            list.Add(root.val);
        }
    }
}
