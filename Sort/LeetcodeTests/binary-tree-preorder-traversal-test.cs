using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class binary_tree_preorder_traversal_test
    {
        private binary_tree_preorder_traversal target = new binary_tree_preorder_traversal();

        static IEnumerable<TestCaseData> geTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new TreeNode(1,null,new TreeNode(2,new TreeNode(3)))).Returns("1,2,3");
                yield return new TestCaseData(null).Returns("");
            }
        }


        [Test]
        [TestCaseSource("geTestCaseDatas")]
        //[TestCase(new TreeNode(2), ExpectedResult = null)]
        public string test(TreeNode root)
        {
            var res = target.PreorderTraversal(root);

            return string.Join(',',res);
        }



        public class testcasedate
        {
            static IEnumerable<TestCaseData> geTestCaseDatas
            {
                get
                {
                    yield return new TestCaseData(new TreeNode(1, null, new TreeNode(2, new TreeNode(3)))).Returns("1,2,3");
                    yield return new TestCaseData(null).Returns("");
                }
            }
        }
        [Test]
        [TestCaseSource(typeof(testcasedate), "geTestCaseDatas")]
        //[TestCase(new TreeNode(2), ExpectedResult = null)]
        public string test_V2(TreeNode root)
        {
            var res = target.PreorderTraversal_V2(root);

            return string.Join(',', res);
        }
    }
}
