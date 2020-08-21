using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class container_with_most_water_test
    {
        private container_with_most_water tClass = new container_with_most_water();
        [Test]
        public void test()
        {
            var nums = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var res = tClass.MaxArea(nums);
            Assert.IsTrue(res == 49);
        }
        [Test]
        public void test_V2()
        {
            var nums = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var res = tClass.MaxArea_V2(nums);
            Assert.IsTrue(res == 49);
        }
    }
}
