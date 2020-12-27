using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class binary_tree_zigzag_level_order_traversal_test
    {
        binary_tree_zigzag_level_order_traversal target = new binary_tree_zigzag_level_order_traversal();

        [Test]
        public void test()
        {
            var tree = new TreeNode(1,
                            new TreeNode(2,new TreeNode(4)),
                            new TreeNode(3,null,new TreeNode(5))
                            );
            var res = target.ZigzagLevelOrder(tree);
            Assert.IsTrue(res.Count == 3);
            Assert.IsTrue(ListExtent.ToString(res[1]) == "3,2");
            Assert.IsTrue(ListExtent.ToString( res[2]) == "4,5");

        }
    }
}
