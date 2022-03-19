using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class construct_string_from_binary_tree_test
    {
        construct_string_from_binary_tree target = new construct_string_from_binary_tree();
        
        static IEnumerable<TestCaseData> geTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(new TreeNode(1,new TreeNode(2, new TreeNode(4)),new TreeNode(3))).Returns("1(2(4))(3)");
                yield return new TestCaseData(new TreeNode(1, new TreeNode(2,null, new TreeNode(4)), new TreeNode(3))).Returns("1(2()(4))(3)");
            }
        }

        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public string test(TreeNode root)
        {
            return  target.Tree2str(root);
        }

        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public string test_V2(TreeNode root)
        {
            return target.Tree2str_V2(root);
        }
    }
}
