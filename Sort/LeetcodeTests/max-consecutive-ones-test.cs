using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class max_consecutive_ones_test
    {
        max_consecutive_ones target = new max_consecutive_ones();

        [Test]
        [TestCase(new int[] { 1, 1, 1,  }, ExpectedResult = 3)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 0, 1, 1, 0 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 0,  1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 1, 0, 1, 1, 1 }, ExpectedResult = 3)]
        public int test(int[] nums)
        {
            return target.FindMaxConsecutiveOnes(nums);
        }

        [TestCase(new int[] { 1, 1, 1, }, ExpectedResult = 3)]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 0, 1, 1, 0 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 1, 1, 0, 1 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 1, 0, 1, 1, 1 }, ExpectedResult = 3)]
        public int test_V2(int[] nums)
        {
            return target.FindMaxConsecutiveOnes_V2(nums);
        }

    }
}
