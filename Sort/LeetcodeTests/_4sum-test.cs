using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    public class _4sum_test
    {
        [Test]
        public void test()
        {
            var tClass = new _4sum();

            var nums = new int[] { 1, 0, -1, 0, -2, 2};
            var res = tClass.FourSum(nums, 0);
            Assert.IsTrue(res.Count == 3);


            nums = new int[] { 0,0,0,0 };
            res = tClass.FourSum(nums, 0);
            Assert.IsTrue(res.Count == 1);

            nums = new int[] { -3, -1, 0, 2, 4, 5 };
            res = tClass.FourSum(nums, 0);
            Assert.IsTrue(res.Count == 1);

            nums = new int[] { -3,-2,-1,0,0,1,2,3 };
            res = tClass.FourSum(nums, 0);
            Assert.IsTrue(res.Count == 8);
        }
    }
}
