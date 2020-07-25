using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class zhong_jian_er_cha_shu_lcof_test
    {
        [Test]
        public void test()
        {
            var tar = new zhong_jian_er_cha_shu_lcof();
            int[] preorder = {3, 9, 20, 15, 7};
            int[] inorder = {9, 3, 15, 20, 7};

            var res = tar.BuildTree(preorder, inorder);
            Assert.True(res.val == 3);
        }
    }
}
