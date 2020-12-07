using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class serialize_and_deserialize_binary_tree_test
    {
        serialize_and_deserialize_binary_tree target = new serialize_and_deserialize_binary_tree();
        [Test]
        public void test()
        {
            TreeNode tree = new TreeNode(1,
                    new TreeNode(2, new TreeNode(4)),
                    new TreeNode(3, null, new TreeNode(5)));
            var str = target.serialize(tree);
            var node = target.deserialize(str);
            Assert.IsNotNull(str);
            Assert.IsNotNull(node);
        }
    }
}
