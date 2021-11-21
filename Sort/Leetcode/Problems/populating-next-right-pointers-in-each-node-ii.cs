using System;
using System.Collections.Generic;
using System.Text;
using Node = Leetcode.Problems.populating_next_right_pointers_in_each_node_ii.Node;
namespace Leetcode.Problems
{ 
    /// <summary>
    /// 117. 填充每个节点的下一个右侧节点指针 II
    /// https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/
    /// </summary>
    public class populating_next_right_pointers_in_each_node_ii
    {
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }
            public Node(int _val, Node _left, Node _right)
            {
                val = _val;
                left = _left;
                right = _right;
            }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }


        /// <summary>
        /// BFS 层次遍历法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            Queue<Node> stack = new Queue<Node>();
            stack.Enqueue(root);
            while (stack.Count>0)
            {
                var index = stack.Count;
                var rightNode = stack.Dequeue();

                if (rightNode.right != null)
                    stack.Enqueue(rightNode.right);
                if (rightNode.left != null)
                    stack.Enqueue(rightNode.left);

                while (index-- > 0)
                {
                    var node = stack.Dequeue();
                    node.next = rightNode;
                    rightNode = node;

                    if(node.right!=null)
                        stack.Enqueue(node.right);
                    if (node.left != null)
                        stack.Enqueue(node.left);
                }

            }

            return root;
        }

        /// <summary>
        /// BFS 层次遍历法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect_V1(Node root)
        {
            if (root == null)
                return null;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                while (size-- > 0)
                {
                    var node = queue.Dequeue();
                    if(size>0)
                        node.next = queue.Peek();

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

            }

            return root;
        }

        public Node Connect_V3(Node root)
        {
            if (root == null)
            {
                return null;
            }
            if (root.left != null)
            {
                if (root.right != null)
                {
                    // 若右子树不为空，则左子树的 next 即为右子树
                    root.left.next = root.right;
                }
                else
                {
                    // 若右子树为空，则右子树的 next 由根节点的 next 得出
                    root.left.next = nextNode(root.next);
                }
            }
            if (root.right != null)
            {
                // 右子树的 next 由根节点的 next 得出
                root.right.next = nextNode(root.next);
            }
            // 先确保 root.right 下的节点的已完全连接，因 root.left 下的节点的连接
            // 需要 root.left.next 下的节点的信息，若 root.right 下的节点未完全连
            // 接（即先对 root.left 递归），则 root.left.next 下的信息链不完整，将
            // 返回错误的信息。可能出现的错误情况如下图所示。此时，底层最左边节点将无
            // 法获得正确的 next 信息：
            //                   o root
            //                 /   \
            //     root.left  o —— o  root.right
            //               /      / \
            //              o —— o   o
            //             /        / \
            //            o        o   o
            Connect_V3(root.right);
            Connect_V3(root.left);
            return root;
        }

        private Node nextNode(Node node)
        {
            while (node != null)
            {
                if (node.left != null)
                {
                    return node.left;
                }
                if (node.right != null)
                {
                    return node.right;
                }
                node = node.next;
            }
            return null;
        }


        public Node connect_V4(Node root)
        {
            if (root == null)
                return root;
            //cur我们可以把它看做是每一层的链表
            Node cur = root;
            while (cur != null)
            {
                //遍历当前层的时候，为了方便操作在下一
                //层前面添加一个哑结点（注意这里是访问
                //当前层的节点，然后把下一层的节点串起来）
                Node dummy = new Node(0);
                //pre表示访下一层节点的前一个节点
                Node pre = dummy;
                //然后开始遍历当前层的链表
                while (cur != null)
                {
                    if (cur.left != null)
                    {
                        //如果当前节点的左子节点不为空，就让pre节点
                        //的next指向他，也就是把它串起来
                        pre.next = cur.left;
                        //然后再更新pre
                        pre = pre.next;
                    }
                    //同理参照左子树
                    if (cur.right != null)
                    {
                        pre.next = cur.right;
                        pre = pre.next;
                    }
                    //继续访问这一行的下一个节点
                    cur = cur.next;
                }
                //把下一层串联成一个链表之后，让他赋值给cur，
                //后续继续循环，直到cur为空为止
                cur = dummy.next;
            }
            return root;
        }
    }
}
