using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class minimum_absolute_difference_in_bst_test
    {
        minimum_absolute_difference_in_bst target = new minimum_absolute_difference_in_bst();

        [Test]
        public void test()
        {
            TreeNode tree = new TreeNode(5,new TreeNode(4),new TreeNode(7));
            var res = target.GetMinimumDifference(tree);
            Assert.True(res == 1);

            tree = new TreeNode(1, null, new TreeNode(3, new TreeNode(2)));
            res = target.GetMinimumDifference(tree);
            Assert.True(res == 1);
        }

        [Test]
        public void test_V2()
        {
            TreeNode tree = new TreeNode(5, new TreeNode(4), new TreeNode(7));
            var res = target.GetMinimumDifference_V2(tree);
            Assert.True(res == 1);

            tree = new TreeNode(1, null, new TreeNode(3, new TreeNode(2)));
            res = target.GetMinimumDifference_V2(tree);
            Assert.True(res == 1);
        }

        [Test]
        public void test_V3()
        {
            TreeNode tree = new TreeNode(5, new TreeNode(4), new TreeNode(7));
            var res = target.GetMinimumDifference_V3(tree);
            Assert.True(res == 1);

            tree = new TreeNode(1, null, new TreeNode(3, new TreeNode(2)));
            res = target.GetMinimumDifference_V3(tree);
            Assert.True(res == 1);

            tree = new TreeNode(1, null, new TreeNode(5, new TreeNode(3)));
            res = target.GetMinimumDifference_V3(tree);
            Assert.True(res == 2);

            tree = new TreeNode(1, null, new TreeNode(2));
            res = target.GetMinimumDifference_V3(tree);
            Assert.True(res == 1);
        }
    }
}
