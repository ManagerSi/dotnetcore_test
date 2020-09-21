using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class convert_bst_to_greater_tree_test
    {
        convert_bst_to_greater_tree target = new convert_bst_to_greater_tree();
        [Test]
        public void test()
        {
            var root = new TreeNode(5, new TreeNode(2), new TreeNode(13));
            var res = target.ConvertBST(root);
            Assert.True(res.ToPreorderString()=="18,20,13");

            root = new TreeNode(5, new TreeNode(2,new TreeNode(1),new TreeNode(3)), new TreeNode(13,new TreeNode(8)));
            res = target.ConvertBST(root);
            Assert.True(res.ToPreorderString() == "26,31,32,29,13,21");
        }

        [Test]
        public void test_V2()
        {
            var root = new TreeNode(5, new TreeNode(2), new TreeNode(13));
            var res = target.ConvertBST_V2(root);
            Assert.True(res.ToPreorderString() == "18,20,13");

            target.sum = 0;
            root = new TreeNode(5, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(13, new TreeNode(8)));
            res = target.ConvertBST_V2(root);
            Assert.True(res.ToPreorderString() == "26,31,32,29,13,21");
        }

        [Test]
        public void test_V3()
        {
            var root = new TreeNode(5, new TreeNode(2), new TreeNode(13));
            var res = target.ConvertBST_V3(root);
            Assert.True(res.ToPreorderString() == "18,20,13");

            target.sum = 0;
            root = new TreeNode(5, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(13, new TreeNode(8)));
            res = target.ConvertBST_V3(root);
            Assert.True(res.ToPreorderString() == "26,31,32,29,13,21");
        }
    }
}
