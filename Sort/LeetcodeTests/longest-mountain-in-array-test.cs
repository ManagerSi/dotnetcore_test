using Leetcode.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetcodeTests
{
    class longest_mountain_in_array_test
    {
        longest_mountain_in_array target = new longest_mountain_in_array();

        [Test]
        [TestCase(new int[] { 2, 1, 4, 7, 3, 2, 5 }, ExpectedResult = 5)]
        [TestCase(new int[] { 7, 3, 2 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 0)]
        [TestCase(new int[] { 2,2,2 }, ExpectedResult = 0)]
        public int test(int[] input)
        {
            return target.LongestMountain(input);
        }
    }
}
