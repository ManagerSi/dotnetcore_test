using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 919. 完全二叉树插入器
    /// </summary>
    public class complete_binary_tree_inserter
    {
        private TreeNode _root = null;
        private TreeNode _nextNode=null;
        private List<TreeNode> _list = new List<TreeNode>();


        public complete_binary_tree_inserter(TreeNode root)
        {
            _root = root;
            if (root != null)
                SetNextNode(root);
        }

        public int Insert(int val)
        {
            var pVal = _nextNode.val;
            if (_nextNode.left == null)
                _nextNode.left = new TreeNode(val);
            else if (_nextNode.right==null)
            {
                _nextNode.right = new TreeNode(val);
                SetNextNode(_nextNode);
            }

            return pVal;
        }

        public TreeNode Get_root()
        {
            return _root;
        }


        #region private methods

        private void SetNextNode(TreeNode root)
        {
            if (_list.Count == 0 || _list.Last() == _nextNode)
            {
                ReIndex();
            }
            else
            {
                if (_nextNode.right == null) return;
                else
                {
                    var index = _list.FindIndex(c => c == _nextNode);
                    _nextNode = _list[index + 1];
                }
            }

        }

        private void ReIndex()
        {
            int leftHigh = 0;
            var root = _root;
            while (root.left != null)
            {
                leftHigh++;
                root = root.left;
            }

            int rightHigh = 0;
            root = _root;
            while (root.right != null)
            {
                rightHigh++;
                root = root.right;
            }

            int level = leftHigh > rightHigh ? rightHigh : leftHigh;
            if (level == 0)
            {
                _nextNode = root;
                _list.Add(root);
                return;
            }

            Queue<TreeNode> nodes = new Queue<TreeNode>((int)Math.Pow(2, level - 1));
            nodes.Enqueue(_root);
            while (level > 0)
            {
                while (nodes.Count>0)
                {
                    _list.Clear();
                    var n = nodes.Dequeue();
                    if (n.left != null) _list.Add(n.left);
                    if (n.right != null) _list.Add(n.right);
                }

                foreach (var treeNode in _list)
                {
                    nodes.Enqueue(treeNode);
                }

                level--;
            }

            _nextNode = _list[0];
        }

        #endregion
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(val);
 * TreeNode param_2 = obj.Get_root();
 */


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */