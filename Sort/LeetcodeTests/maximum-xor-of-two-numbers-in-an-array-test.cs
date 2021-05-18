using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class maximum_xor_of_two_numbers_in_an_array_test
    {
        private maximum_xor_of_two_numbers_in_an_array target = new maximum_xor_of_two_numbers_in_an_array();

        [Test]
        [TestCase(new int[] { 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 2, 4 }, ExpectedResult = 6)]
        [TestCase(new int[] { 8, 10, 2 }, ExpectedResult = 10)]
        [TestCase(new int[] { 3, 10, 5, 25, 2, 8 }, ExpectedResult = 28)]
        [TestCase(new int[] { 14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70 }, ExpectedResult = 127)]
        public int test(int[] nums)
        {
            return target.FindMaximumXOR(nums);
        }
    }
}
