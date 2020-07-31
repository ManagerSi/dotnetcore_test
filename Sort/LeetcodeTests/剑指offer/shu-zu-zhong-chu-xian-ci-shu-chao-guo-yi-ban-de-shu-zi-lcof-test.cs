using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    public class shu_zu_zhong_chu_xian_ci_shu_chao_guo_yi_ban_de_shu_zi_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new shu_zu_zhong_chu_xian_ci_shu_chao_guo_yi_ban_de_shu_zi_lcof();

            var nums = new int[] { 1, 2, 3, 2, 2, 2, 5, 4, 2 };
            var res = tClass.MajorityElement(nums);
            Assert.IsTrue(res == 2);


            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            res = tClass.MajorityElement(nums);
            Assert.IsTrue(res == 2);

        }

        [Test]
        public void test_V2()
        {
            var tClass = new shu_zu_zhong_chu_xian_ci_shu_chao_guo_yi_ban_de_shu_zi_lcof();

            var nums = new int[] { 1, 2, 3, 2, 2, 2, 5, 4, 2 };
            var res = tClass.MajorityElement_V2(nums);
            Assert.IsTrue(res == 2);


            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            res = tClass.MajorityElement_V2(nums);
            Assert.IsTrue(res == 2);

        }

        [Test]
        public void test_V3()
        {
            var tClass = new shu_zu_zhong_chu_xian_ci_shu_chao_guo_yi_ban_de_shu_zi_lcof();

            var nums = new int[] { 1, 2, 3, 2, 2, 2, 5, 4, 2 };
            var res = tClass.MajorityElement_V3(nums);
            Assert.IsTrue(res == 2);


            nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            res = tClass.MajorityElement_V3(nums);
            Assert.IsTrue(res == 2);

        }
    }
}