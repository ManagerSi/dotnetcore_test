using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class complete_binary_tree_inserter_test
    {
        private complete_binary_tree_inserter target = null;
        
        [Test]
        public void test()
        {
            target = new complete_binary_tree_inserter(new TreeNode(1, new TreeNode(2)));
            target.Insert(3);
            target.Insert(4);
            target.Insert(5);
            target.Insert(6);
            var root = target.Get_root();
        }
    }
}
