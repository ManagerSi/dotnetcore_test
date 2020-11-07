using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class count_of_range_sum_test
    {
        count_of_range_sum target = new count_of_range_sum();

        [Test]
        public void test()
        {
            int[] nums = new[] { -2, 5, -1 };
            int min = -2, max = 2;
            var res = target.CountRangeSum(nums, min, max);
            Assert.IsTrue(res == 3);


            nums = new[] {-2147483647,0,-2147483647,2147483647 };
            min = -564;
            max = 3864;
            res = target.CountRangeSum(nums, min, max);
            Assert.IsTrue(res == 3);
        }

        [Test]
        public void test_V2()
        {
            int[] nums = new[] { -2, 5, -1 };
            int min = -2, max = 2;
            var res = target.CountRangeSum_V2(nums, min, max);
            Assert.IsTrue(res == 3);


            nums = new[] { -2147483647, 0, -2147483647, 2147483647 };
            min = -564;
            max = 3864;
            res = target.CountRangeSum_V2(nums, min, max);
            Assert.IsTrue(res == 3);
        }
    }
}
