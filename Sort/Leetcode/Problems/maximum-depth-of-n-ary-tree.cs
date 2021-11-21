using System;
using System.Collections.Generic;
using System.Text;
using Node = Leetcode.Model.Tree;

namespace Leetcode.Problems
{
    
    public class maximum_depth_of_n_ary_tree
    {
        private int _maxDepth = 0;
        public int MaxDepth(Node root)
        {
            _maxDepth = 0;

            DFS(root, 0);

            return _maxDepth;
        }

        /// <summary>
        /// 深度优先遍历（递归）
        /// </summary>
        /// <param name="root"></param>
        /// <param name="v"></param>
        private void DFS(Node root, int v)
        {
            if (root != null)
            {
                v++;
                if (v > _maxDepth)
                    _maxDepth = v;

                if (root.children != null)
                {
                    foreach (var child in root.children)
                    {
                        DFS(child, v);
                    }
                }
            }
        }
    }
}
