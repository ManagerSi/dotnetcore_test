using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    class shu_zu_zhong_zhong_fu_de_shu_zi_lcof_test
    {
        private shu_zu_zhong_zhong_fu_de_shu_zi_lcof tClass = new shu_zu_zhong_zhong_fu_de_shu_zi_lcof();

        [Test]
        public void test()
        {
            var nums = new int[]{ 1,2,3,4,5,2};
            var res = tClass.FindRepeatNumber(nums);
            Assert.IsTrue(new List<int>() { 2 }.Contains(res));

            nums = new int[] { 2, 3, 1, 0, 2, 5, 3 }; 
            res = tClass.FindRepeatNumber(nums);
            Assert.IsTrue(new List<int>() { 2, 3 }.Contains(res));
        }
    }
}
