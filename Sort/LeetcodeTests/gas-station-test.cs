using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class gas_station_test
    {
        gas_station target = new gas_station();

        [Test]
        [TestCase(new int[]{ 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 },ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }, ExpectedResult = -1)]
        public int test(int[] gas, int[] cost)
        {
            return target.CanCompleteCircuit(gas, cost);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }, ExpectedResult = -1)]
        public int test_V2(int[] gas, int[] cost)
        {
            return target.CanCompleteCircuit_V2(gas, cost);
        }

    }
}
