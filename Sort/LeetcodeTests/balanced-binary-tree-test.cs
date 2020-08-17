using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class balanced_binary_tree_test
    {
        [Test]
        public void test()
        {
            var tClass = new balanced_binary_tree();

            var root = new TreeNode(3, new TreeNode(9), new TreeNode(30, new TreeNode(20), new TreeNode(12)));
            var res = tClass.IsBalanced(root);
            Assert.IsTrue(res);


            //    [1,2,2,3,null,null,3,4,null,null,4]

            root = new TreeNode(3, 
                    new TreeNode(9,new TreeNode(2,new TreeNode(3),null),null), 
                    new TreeNode(30, null,new TreeNode(20, null,new TreeNode(12))));
            res = tClass.IsBalanced(root);
            Assert.False(res);
    }
    }
}
