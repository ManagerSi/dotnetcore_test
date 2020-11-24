using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class count_complete_tree_nodes_test
    {
        count_complete_tree_nodes target = new count_complete_tree_nodes();

        static IEnumerable<TestCaseData> geTestCaseDatas()
        {

            yield return new TestCaseData(null).Returns(0);
            yield return new TestCaseData(new TreeNode(1)).Returns(1);
            yield return new TestCaseData(new TreeNode(1,new TreeNode(2,new TreeNode(4),new TreeNode(5)),new TreeNode(3,new TreeNode(6)))).Returns(6);
        }

        [Test]
       [TestCaseSource("geTestCaseDatas")]
        public int test(TreeNode n)
        {
            return target.CountNodes(n);
        }


        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public int test_V2(TreeNode n)
        {
            return target.CountNodes_v2(n);
        }
    }
}
