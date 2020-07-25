using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Model
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

       
        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <returns></returns>
        public string ToPreorderString()
        {
            var list = PreOrder(this);
            return string.Join(',', list);
        }

        public List<int> PreOrder(TreeNode node)
        {
            List<int> list = new List<int>();
            //根
            list.Add(node.val);

            if (node.left != null)
                list.AddRange(PreOrder(node.left));

            if (node.right != null)
                list.AddRange(PreOrder(node.right));

            return list;
        }


        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <returns></returns>
        public string ToInorderString()
        {
            var list = Inorder(this);
            return string.Join(',', list);
        }

        public List<int> Inorder(TreeNode node)
        {
            List<int> list = new List<int>();

            if (node.left != null)
                list.AddRange(Inorder(node.left));

            list.Add(node.val);

            if (node.right != null)
                list.AddRange(Inorder(node.right));

            return list;
        }


        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <returns></returns>
        public string ToPostorderString()
        {
            var list = Postorder(this);
            return string.Join(',', list);
        }

        public List<int> Postorder(TreeNode node)
        {
            List<int> list = new List<int>();

            if (node.left != null)
                list.AddRange(Postorder(node.left));

            if (node.right != null)
                list.AddRange(Postorder(node.right));

            list.Add(node.val);

            return list;
        }
    }
}
