using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    public class Has_Path_Sum_Test
    {
        [Test]
        public void test1()
        {
            var tree = new TreeNode(5, new TreeNode(4, new TreeNode(11)), new TreeNode(8, new TreeNode(13), new TreeNode(4)));
            var target = 17;

            var res = new Has_Path_Sum().HasPathSum(tree, target);

            Assert.IsTrue(res);
        }

        [Test]
        public void test2()
        {
            TreeNode tree = null;
            var target = 0;

            var res = new Has_Path_Sum().HasPathSum(tree, target);

            Assert.IsFalse(res);
        }
    }
}
