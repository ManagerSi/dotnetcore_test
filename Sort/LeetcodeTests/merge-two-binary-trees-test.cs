using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class merge_two_binary_trees_test
    {
        merge_two_binary_trees target = new merge_two_binary_trees();

        [Test]
        public void test()
        {
            var t1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            var t2 = new TreeNode(2,new TreeNode(1,null,new TreeNode(4)),new TreeNode(3,null,new TreeNode(7)));
            var result = target.MergeTrees(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "5,4,4,3,5,7");

            t1 = null;
            t2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            result = target.MergeTrees(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "1,4,2,3,7");

            t1 = null;
            t2 = null;
            result = target.MergeTrees(t1, t2);
            Assert.IsTrue(result?.ToInorderString() == null);
        }

        [Test]
        public void test_V2()
        {
            var t1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            var t2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            var result = target.MergeTrees_V2(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "5,4,4,3,5,7");

            t1 = null;
            t2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            result = target.MergeTrees_V2(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "1,4,2,3,7");

            t1 = null;
            t2 = null;
            result = target.MergeTrees_V2(t1, t2);
            Assert.IsTrue(result?.ToInorderString() == null);
        }

        [Test]
        public void test_V3()
        {
            var t1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            var t2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            var result = target.MergeTrees_V3(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "5,4,4,3,5,7");

            t1 = null;
            t2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            result = target.MergeTrees_V3(t1, t2);
            Assert.IsTrue(result.ToInorderString() == "1,4,2,3,7");

            t1 = null;
            t2 = null;
            result = target.MergeTrees_V3(t1, t2);
            Assert.IsTrue(result?.ToInorderString() == null);
        }
    }
}
