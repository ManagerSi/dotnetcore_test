using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class univalued_binary_tree_test
    {
        private univalued_binary_tree target = new univalued_binary_tree();

        public static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(new TreeNode(1, new TreeNode(1), new TreeNode(1)))
                .Returns(true);

            yield return new TestCaseData(new TreeNode(1, new TreeNode(2), null))
                .Returns(false);

            yield return new TestCaseData(new TreeNode(2, null, new TreeNode(2)))
                .Returns(true);

            yield return new TestCaseData(new TreeNode(1, new TreeNode(2), new TreeNode(1)))
                .Returns(false);

        }

        [Test]
        [TestCaseSource("Cases")]
        public bool test(TreeNode p)
        {
            return target.IsUnivalTree(p);
        }
    }
}
