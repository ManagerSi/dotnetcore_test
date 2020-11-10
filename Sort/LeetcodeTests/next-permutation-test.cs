using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class next_permutation_test
    {
        next_permutation target = new next_permutation();

        [Test]
        [TestCase(new int[] { 2, 3, 4, 7, 6, 5 }, ExpectedResult = new int[] { 2, 3, 5, 4, 6, 7 })]
        [TestCase(new int[]{ 1, 2, 3 },ExpectedResult = new int[]{ 1, 3, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = new int[] { 1, 2,3 })]
        [TestCase(new int[] { 1, 1, 5 }, ExpectedResult = new int[] { 1, 5, 1 })]
        public int[] test(int[] nums)
        {
            target.NextPermutation(nums);
            return nums;
        }

        [Test]
        [TestCase(new int[] { 2,3,1 }, ExpectedResult = new int[] {3,1,2 })]
        [TestCase(new int[] { 2, 3, 4, 7, 6, 5 }, ExpectedResult = new int[] { 2, 3, 5, 4, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 3, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 1, 5 }, ExpectedResult = new int[] { 1, 5, 1 })]
        public int[] test_V2(int[] nums)
        {
            target.NextPermutation_V2(nums);
            return nums;
        }
    }
}
