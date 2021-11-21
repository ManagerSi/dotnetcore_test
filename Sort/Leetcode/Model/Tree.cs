using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Model
{
    /// <summary>
    /// Definition for a Tree Node.
    /// </summary>
    public class Tree
    {
        public int val;
        public IList<Tree> children;

        public Tree() { }

        public Tree(int _val)
        {
            val = _val;
        }

        public Tree(int _val, IList<Tree> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
