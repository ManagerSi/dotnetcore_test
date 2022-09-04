using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class min_cost_climbing_stairs_test
    {
        private min_cost_climbing_stairs target = new min_cost_climbing_stairs();

        [Test]
        [TestCase(new int[]{1, 100, 1, 1, 1, 100, 1, 1, 100, 1},ExpectedResult = 6)]
        public int test(int[] cost)
        {
            return target.MinCostClimbingStairs(cost);
        }
    }
}
