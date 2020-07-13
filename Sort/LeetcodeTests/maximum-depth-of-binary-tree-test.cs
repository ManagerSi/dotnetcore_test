using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class maximum_depth_of_binary_tree_test
    {
        [Test]
        public void test()
        {
            var root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = new maximum_depth_of_binary_tree().MaxDepth(root);

            Assert.IsTrue(res == 3);
        }

        [Test]
        public void test_V2()
        {
            var root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = new maximum_depth_of_binary_tree().MaxDepth_V2(root);

            Assert.IsTrue(res == 3);
        }
    }
}
