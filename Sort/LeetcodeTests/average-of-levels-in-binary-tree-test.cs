using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class average_of_levels_in_binary_tree_test
    {
        average_of_levels_in_binary_tree target = new average_of_levels_in_binary_tree();

        [Test]
        public void test()
        {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = target.AverageOfLevels(tree);
            Assert.True(res.Count == 3);
        }

        [Test]
        public void test_v2()
        {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = target.AverageOfLevels_V2(tree);
            Assert.True(res.Count == 3);
        }

        [Test]
        public void test_v3()
        {
            var tree = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            var res = target.AverageOfLevels_V3(tree);
            Assert.True(res.Count == 3);
        }
    }
}
