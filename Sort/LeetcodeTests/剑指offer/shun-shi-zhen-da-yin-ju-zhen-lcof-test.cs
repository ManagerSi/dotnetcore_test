using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;

namespace LeetcodeTests.剑指offer
{
    class shun_shi_zhen_da_yin_ju_zhen_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new shun_shi_zhen_da_yin_ju_zhen_lcof();

            var nums = new int[][]
            {
                new int[] {1, 2, 3, 4},
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12},
            };
            var res = tClass.SpiralOrder(nums);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Length == 12);
        }
    }
}
