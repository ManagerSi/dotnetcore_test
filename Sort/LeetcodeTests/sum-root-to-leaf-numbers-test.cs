using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class sum_root_to_leaf_numbers_test
    {
        sum_root_to_leaf_numbers target = new sum_root_to_leaf_numbers();

        private static class TestCasesProvider
        {
            public static IEnumerable<TestCaseData> Cases()
            {
                yield return new TestCaseData(new TreeNode()).Returns(0);
                yield return new TestCaseData(new TreeNode()).Returns(0);
                yield return new TestCaseData(new TreeNode(1,new TreeNode(2),new TreeNode(3))).Returns(25);
                yield return new TestCaseData(new TreeNode(4,
                    new TreeNode(9,new TreeNode(5),new TreeNode(1)),
                    new TreeNode(0))).Returns(1026);
            }
        }

        [Test,TestCaseSource(typeof(TestCasesProvider), nameof(TestCasesProvider.Cases))]
        public int test(TreeNode node)
        {
            return target.SumNumbers(node);
        }
    }
}
