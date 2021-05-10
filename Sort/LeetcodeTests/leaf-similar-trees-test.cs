using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class leaf_similar_trees_test
    {
        private leaf_similar_trees target = new leaf_similar_trees();

        static IEnumerable<TestCaseData> geTestCaseDatas()
        {
            yield return new TestCaseData(new TreeNode(1), new TreeNode(1)).Returns(true);
            yield return new TestCaseData(new TreeNode(1), new TreeNode(2)).Returns(false);
            yield return new TestCaseData(new TreeNode(1,new TreeNode(2)), new TreeNode(2,null,new TreeNode(2))).Returns(true);
            yield return new TestCaseData(
                new TreeNode(1, new TreeNode(2), new TreeNode(3)),
                new TreeNode(1, new TreeNode(3), new TreeNode(2))
                ).Returns(false);
            yield return new TestCaseData(
                new TreeNode(3, new TreeNode(5,new TreeNode(6),new TreeNode(71)), new TreeNode(1,new TreeNode(4,new TreeNode(2,new TreeNode(9),new TreeNode(8))))),
                new TreeNode(3, new TreeNode(5,new TreeNode(6),new TreeNode(2,new TreeNode(7),new TreeNode(14))), new TreeNode(1,new TreeNode(9),new TreeNode(8)))
            ).Returns(false);

        }

        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public bool test(TreeNode t1, TreeNode t2)
        {
            return target.LeafSimilar(t1, t2);
        }
    }
}
