using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;

namespace LeetcodeTests.剑指offer
{
    class diao_zheng_shu_zu_shun_xu_shi_qi_shu_wei_yu_ou_shu_qian_mian_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new diao_zheng_shu_zu_shun_xu_shi_qi_shu_wei_yu_ou_shu_qian_mian_lcof();

            var nums = new int[] { 1,2,3,4};
            var res = tClass.Exchange(nums);
            Assert.IsTrue(IntExtent.ToString(res) == "1,3,2,4");

            nums = new int[] {1,3,5};
            res = tClass.Exchange(nums);
            Assert.IsTrue(IntExtent.ToString(res) == "1,3,5");
        }
    }
}
