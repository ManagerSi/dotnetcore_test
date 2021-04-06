using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class remove_duplicates_from_sorted_array_ii_test
    {
        remove_duplicates_from_sorted_array_ii target = new remove_duplicates_from_sorted_array_ii();

        [Test]
        [TestCase(new int[] { 1, 2, 3, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 3, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 2, 2, 3, 3 }, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 1, 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = 2)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, ExpectedResult = 7)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3 }, ExpectedResult = 7)]
        [TestCase(new int[] { 1, 1, 1, 1, 2, 2, 3 }, ExpectedResult = 5)]
        public int test(int[] nums)
        {
            return target.RemoveDuplicates(nums);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 3, 3 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 2, 2, 3, 3 }, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 1, 1, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = 2)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, ExpectedResult = 7)]
        [TestCase(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3 }, ExpectedResult = 7)]
        [TestCase(new int[] { 1, 1, 1, 1, 2, 2, 3 }, ExpectedResult = 5)]
        public int test_v2(int[] nums)
        {
            return target.RemoveDuplicates_V2(nums);
        }
    }
}
