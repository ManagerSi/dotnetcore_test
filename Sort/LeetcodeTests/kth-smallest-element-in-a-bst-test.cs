using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class kth_smallest_element_in_a_bst_test
    {
        [Test]
        public void test()
        {
            var tClass = new kth_smallest_element_in_a_bst();

            var node = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
            var res = tClass.KthSmallest(node, 1);
            Assert.IsTrue(res == 1);


            node = new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1)), new TreeNode(4)), new TreeNode(6));
            res = tClass.KthSmallest(node, 3);
            Assert.IsTrue(res == 3);
        }
    }
}
