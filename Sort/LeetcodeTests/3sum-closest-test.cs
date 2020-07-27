using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;

namespace LeetcodeTests
{
    class _3sum_closest_test
    {
        [Test]
        public void test()
        {
            var tClass = new _3sum_closest();

            var nums = new int[] { -1, 2, 1, -4 };
            var target = 1;

            var res = tClass.ThreeSumClosest(nums, target);
            Assert.True(res == 2 );



            nums = new int[] { 1, 1, -1, -1, 3 };
            target = -1;

            res = tClass.ThreeSumClosest(nums, target);
            Assert.True(res == -1);
        }

        [Test]
        public void test_V2()
        {
            var tClass = new _3sum_closest();

            var nums = new int[] { -1, 2, 1, -4 };
            var target = 1;

            var res = tClass.ThreeSumClosest_V2(nums, target);
            Assert.True(res == 2);



            nums = new int[] { 1, 1, -1, -1, 3 };
            target = -1;

            res = tClass.ThreeSumClosest_V2(nums, target);
            Assert.True(res == -1);
        }
    }
}
