using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class maximum_depth_of_n_ary_tree_test
    {
        private maximum_depth_of_n_ary_tree target = new maximum_depth_of_n_ary_tree();

        static IEnumerable<TestCaseData> geTestCaseDatas
        {
            get
            {
                yield return new TestCaseData(null).Returns(0);

                yield return new TestCaseData(new Tree(1, new List<Tree>()
                {
                    new Tree(3,new List<Tree>()
                    {
                        new Tree(5)
                        ,new Tree(6)
                    }),
                    new Tree(2),
                    new Tree(4)
                })).Returns(3);

                yield return new TestCaseData(new Tree(1, new List<Tree>()
                {
                    new Tree(2),
                    new Tree(3,new List<Tree>()
                    {
                        new Tree(5)
                        ,new Tree(6,new List<Tree>(){new Tree(11,new List<Tree>(){new Tree(14)})})
                    }),
                    new Tree(4,new List<Tree>()
                    {
                        new Tree(8,new List<Tree>(){new Tree(12)})
                    }),
                    new Tree(5,new List<Tree>()
                    {
                        new Tree(5)
                        ,new Tree(6)
                    }),
                })).Returns(5);

            }
        }


        [Test]
        [TestCaseSource("geTestCaseDatas")]
        //[TestCase(new TreeNode(2), ExpectedResult = null)]
        public int test(Tree root)
        {
            return target.MaxDepth(root);
        }

    }
}
