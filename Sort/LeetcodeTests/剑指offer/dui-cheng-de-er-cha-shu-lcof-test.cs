using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class dui_cheng_de_er_cha_shu_lcof_test
    {
        [Test]
        public void test_success()
        {
            var tClass = new dui_cheng_de_er_cha_shu_lcof();
            var tree = new TreeNode(1, new TreeNode(1, new TreeNode(2), new TreeNode(3)),
                new TreeNode(1, new TreeNode(3), new TreeNode(2)));

            var res = tClass.IsSymmetric(tree);
            Assert.True(res);


            res = tClass.IsSymmetric(null);
            Assert.True(res);

            res = tClass.IsSymmetric(new TreeNode());
            Assert.True(res);
        }
        [Test]
        public void test_fail()
        {
            var tClass = new dui_cheng_de_er_cha_shu_lcof();

            var tree = new TreeNode(1, new TreeNode(1, new TreeNode(2), new TreeNode(5)),
                new TreeNode(1, new TreeNode(3), new TreeNode(2)));
            var res = tClass.IsSymmetric(tree);
            Assert.IsFalse(res);

            tree = new TreeNode(1,new TreeNode(0));
            res = tClass.IsSymmetric(tree);
            Assert.IsFalse(res);

        }
    }
}
