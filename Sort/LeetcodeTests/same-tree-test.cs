using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class same_tree_test
    {
        same_tree target = new same_tree();

        public static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(new TreeNode(),new TreeNode()).Returns(true);

            yield return new TestCaseData(
                new TreeNode(1, new TreeNode(2), new TreeNode(3)), 
                new TreeNode(1, new TreeNode(2), new TreeNode(3))).Returns(true);

            yield return new TestCaseData(
                new TreeNode(1, new TreeNode(2), null),
                new TreeNode(1, null, new TreeNode(2))).Returns(false);

            yield return new TestCaseData(
                new TreeNode(1, new TreeNode(1), new TreeNode(2)),
                new TreeNode(1, new TreeNode(2), new TreeNode(1))).Returns(false);

        }

        [Test]
        [TestCaseSource("Cases")]
        public bool test(TreeNode p, TreeNode q)
        {
            return target.IsSameTree(p, q);
        }

        [TestCaseSource("Cases")]
        public bool test_V2(TreeNode p, TreeNode q)
        {
            return target.IsSameTree_V2(p, q);
        }
    }
}
