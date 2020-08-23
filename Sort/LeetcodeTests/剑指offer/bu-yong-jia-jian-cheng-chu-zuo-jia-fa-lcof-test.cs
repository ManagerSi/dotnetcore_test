using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    class bu_yong_jia_jian_cheng_chu_zuo_jia_fa_lcof_test
    {
        private bu_yong_jia_jian_cheng_chu_zuo_jia_fa_lcof tClass = new bu_yong_jia_jian_cheng_chu_zuo_jia_fa_lcof();
        [Test]
        public void test()
        {
            int a = 10, b = 24;
            var res = tClass.Add(a, b);
            Assert.IsTrue(res == a + b);

            a = -1; b =2;
            res = tClass.Add(a, b);
            Assert.IsTrue(res == a + b);
        }
    }
}
