using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 606. 根据二叉树创建字符串
    /// https://leetcode-cn.com/problems/construct-string-from-binary-tree/
    /// </summary>
    public class construct_string_from_binary_tree
    {
        private const string _left = "(";
        private const string _right = ")";

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Tree2str(TreeNode root)
        {
            var stringBuilder = new StringBuilder();
            ToPreOrder(root, stringBuilder);
            return stringBuilder.ToString();
        }

        private void ToPreOrder(TreeNode root, StringBuilder stringBuilder)
        {
            if (root == null)
                return;
            
            //1. add root
            stringBuilder.Append(root.val.ToString());

            if (root.left == null && root.right == null)
                return;


            //2. only left
            if (root.left != null && root.right == null)
            {
                //有子节点,添加括号
                stringBuilder.Append(_left);
                ToPreOrder(root.left, stringBuilder);
                //有子节点,添加括号
                stringBuilder.Append(_right);
            }

            //2. only right
            else if (root.left != null && root.right == null)
            {
                //空括号左节点
                stringBuilder.Append(_left);
                stringBuilder.Append(_right);

                ToPreOrder(root.left, stringBuilder);
            }

            //3. both exist
            else
            {
                //有子节点,添加括号
                stringBuilder.Append(_left);
                //左节点
                ToPreOrder(root.left, stringBuilder);
                //添加括号
                stringBuilder.Append(_right);

                //有子节点,添加括号
                stringBuilder.Append(_left);
                //右节点
                ToPreOrder(root.right, stringBuilder);
                //添加括号
                stringBuilder.Append(_right);
            }
        }

        /// <summary>
        /// 递归优化
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Tree2str_V2(TreeNode root)
        {
            if (root == null) return "";

            if(root.left != null && root.right != null)
                return new StringBuilder().Append(root.val.ToString())
                    .Append(_left)
                    .Append(Tree2str_V2(root.left))
                    .Append(_right)
                    .Append(_left)
                    .Append(Tree2str_V2(root.right))
                    .Append(_right)
                    .ToString();

            if (root.left == null && root.right != null)
                return new StringBuilder().Append(root.val.ToString())
                    .Append(_left)
                    .Append(_right)
                    .Append(_left)
                    .Append(Tree2str_V2(root.right))
                    .Append(_right)
                    .ToString();
            if (root.left != null && root.right == null)
                return new StringBuilder().Append(root.val.ToString())
                    .Append(_left)
                    .Append(Tree2str_V2(root.left))
                    .Append(_right)
                    .ToString();

            return root.val.ToString();
        }
    }
}
