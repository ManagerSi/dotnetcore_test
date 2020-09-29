using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class binary_tree_postorder_traversal_test
    {
        public binary_tree_postorder_traversal target = new binary_tree_postorder_traversal();

        [Test]
        public void test()
        {
            TreeNode node = new TreeNode(1,null,new TreeNode(2,new TreeNode(3),null));
            var res = target.PostorderTraversal(node);
            Assert.IsTrue(string.Join(',',res) == node.ToPostorderString());

            node = null;
            res = target.PostorderTraversal(node);
            Assert.IsTrue(string.Join(',', res) == "");
        }
    }
}
