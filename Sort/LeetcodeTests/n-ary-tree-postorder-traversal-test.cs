using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetcodeTests
{
    public class n_ary_tree_postorder_traversal_test
    {
        n_ary_tree_postorder_traversal target = new n_ary_tree_postorder_traversal();

        static IEnumerable<TestCaseData> GetTestCase()
        {
            yield return new TestCaseData( new n_ary_tree_postorder_traversal.Node(1, new List<n_ary_tree_postorder_traversal.Node>()
                {
                    new n_ary_tree_postorder_traversal.Node(3,new List<n_ary_tree_postorder_traversal.Node>()
                    {
                        new n_ary_tree_postorder_traversal.Node(5),
                        new n_ary_tree_postorder_traversal.Node(6),
                    }),
                    new n_ary_tree_postorder_traversal.Node(2),
                    new n_ary_tree_postorder_traversal.Node(4)
                })).Returns("5,6,3,2,4,1");
        }

        [Test]
        [TestCaseSource("GetTestCase")]
        public string test(n_ary_tree_postorder_traversal.Node root)
        {
            var result = target.Postorder(root);
            return string.Join(',',result);
        }
    }
}
