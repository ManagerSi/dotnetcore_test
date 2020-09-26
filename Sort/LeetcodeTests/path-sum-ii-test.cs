using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class path_sum_ii_test
    {
        path_sum_ii target = new path_sum_ii();

        [Test]
        public void test()
        {
            TreeNode root = 
                new TreeNode(5,
                 new TreeNode(4,
                             new TreeNode(11,new TreeNode(7),new TreeNode(2)),
                            null),
                new TreeNode(8,
                             new TreeNode(13),
                            new TreeNode(4,new TreeNode(5),new TreeNode(1))));

            var res = target.PathSum(root, 22);
            Assert.IsTrue(res.Count == 2);


            root =null;
            res = target.PathSum(root, 22);
            Assert.IsTrue(res.Count == 0);


            root = new TreeNode(2,new TreeNode(2));
            res = target.PathSum(root, 0);
            Assert.IsTrue(res.Count == 0);

            root = new TreeNode(-2, null,new TreeNode(-3));
            res = target.PathSum(root, -5);
            Assert.IsTrue(res.Count == 1);
        }
    }
}
