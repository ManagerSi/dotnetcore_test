using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class find_mode_in_binary_search_tree_test
    {
        find_mode_in_binary_search_tree target = new find_mode_in_binary_search_tree();

        [Test]
        public void test()
        {
            var root = new TreeNode(1,null,new TreeNode(2,new TreeNode(2)));
            var res = target.FindMode(root);
            Assert.IsTrue(string.Join(',',res) == "2");

            root = null;
            res = target.FindMode(root);
            Assert.IsTrue(res.Length==0);

            root = new TreeNode(1, null, new TreeNode(2));
            res = target.FindMode(root);
            Assert.IsTrue(string.Join(',', res) == "1,2");
        }

        [Test]
        public void test_v2()
        {
            var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(2)));
            var res = target.FindMode_V2(root);
            Assert.IsTrue(string.Join(',', res) == "2");

            root = null;
            res = target.FindMode_V2(root);
            Assert.IsTrue(res.Length == 0);

            root = new TreeNode(1, null, new TreeNode(2));
            res = target.FindMode_V2(root);
            Assert.IsTrue(string.Join(',', res) == "1,2");
        }

        [Test]
        public void test_v3()
        {
            var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(2)));
            var res = target.FindMode_V3(root);
            Assert.IsTrue(string.Join(',', res) == "2");

            root = null;
            res = target.FindMode_V3(root);
            Assert.IsTrue(res.Length == 0);

            root = new TreeNode(1, null, new TreeNode(2));
            res = target.FindMode_V3(root);
            Assert.IsTrue(string.Join(',', res) == "1,2");
        }
    }
}
