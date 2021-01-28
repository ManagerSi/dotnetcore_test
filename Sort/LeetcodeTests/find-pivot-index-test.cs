using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class find_pivot_index_test
    {
        find_pivot_index target = new find_pivot_index();

        [Test]
        [TestCase(new int[] { 1},ExpectedResult =0)]
        [TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = -1)]
        [TestCase(new int[] { 2, 1, -1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 1 }, ExpectedResult = 4)]
        public int test(int[] nums)
        {
            return target.PivotIndex(nums);
        }

        [Test]
        [TestCase(new int[] { 1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = -1)]
        [TestCase(new int[] { 2, 1, -1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 1 }, ExpectedResult = 4)]
        public int test_V2(int[] nums)
        {
            return target.PivotIndex_V2(nums);
        }


        [Test]
        [TestCase(new int[] { 1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = -1)]
        [TestCase(new int[] { 2, 1, -1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 1 }, ExpectedResult = 4)]
        public int test_V3(int[] nums)
        {
            return target.PivotIndex_V3(nums);
        }
    }
}
