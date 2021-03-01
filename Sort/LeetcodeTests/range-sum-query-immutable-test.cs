using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class range_sum_query_immutable_test
    {
        
        [Test]
        public void test()
        {
            int[] nums = new[] {-2, 0, 3, -5, 2, -1};
            range_sum_query_immutable.NumArray target = new range_sum_query_immutable.NumArray(nums);
            int result = 0;

            result = target.SumRange(0, 2);
            Assert.True(result == 1);

            result = target.SumRange(2, 5);
            Assert.True(result == -1);

            result = target.SumRange(0, 5);
            Assert.True(result == -3);

        }

        [Test]
        public void test_V2()
        {
            int[] nums = new[] { -2, 0, 3, -5, 2, -1 };
            range_sum_query_immutable.NumArray_V2 target = new range_sum_query_immutable.NumArray_V2(nums);
            int result = 0;

            result = target.SumRange(0, 2);
            Assert.True(result == 1);

            result = target.SumRange(2, 5);
            Assert.True(result == -1);

            result = target.SumRange(0, 5);
            Assert.True(result == -3);

        }
    }
}
