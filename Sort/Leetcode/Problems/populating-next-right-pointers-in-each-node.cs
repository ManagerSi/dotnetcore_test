using System;
using System.Collections.Generic;
using System.Text;
using Node = Leetcode.Problems.populating_next_right_pointers_in_each_node_ii.Node;

namespace Leetcode.Problems
{
    /// <summary>
    /// 116. 填充每个节点的下一个右侧节点指针
    /// https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/
    /// </summary>
    public class populating_next_right_pointers_in_each_node
    {
        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null) return null;

            Stack<Node> stack   =new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                List<Node> florList = new List<Node>();
                while (stack.Count>0)
                {
                    var node = stack.Pop();
                    if(node.left!=null)
                        florList.Add(node.left);
                    if (node.right != null)
                        florList.Add(node.right);
                }

                for (int i = 0; i < florList.Count; i++)
                {
                    if (i + 1 < florList.Count)
                        florList[i].next = florList[i + 1];

                    stack.Push(florList[florList.Count - i -1]);
                }
            }

            return root;
        }

        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect_V1(Node root)
        {
            if (root == null) return null;

            Queue<Node> stack = new Queue<Node>();
            stack.Enqueue(root);
            while (stack.Count > 0)
            {
                Node pre = null;
                var count = stack.Count;
                while (count-- > 0)
                {
                    var node = stack.Dequeue();
                    if(count>0)
                        node.next = stack.Peek();

                    if (node.left != null)
                        stack.Enqueue(node.left);
                    if (node.right != null)
                        stack.Enqueue(node.right);
                }
            }

            return root;
        }
    }
}
