using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class contains_duplicate_iii_test
    {
        contains_duplicate_iii target = new contains_duplicate_iii();

        [Test]
        [TestCase(new int[] { 1, 2, 3, 1 }, 3, 0, ExpectedResult = true)]
        [TestCase(new int[] { 1, 0, 1, 1 }, 1, 2, ExpectedResult = true)]
        [TestCase(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3, ExpectedResult = false)]
        [TestCase(new int[] { int.MinValue, int.MaxValue }, 1, 1, ExpectedResult = false)]
        public bool test(int[] nums, int k, int t)
        {
            return target.ContainsNearbyAlmostDuplicate(nums, k, t);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 1 }, 3, 0, ExpectedResult = true)]
        [TestCase(new int[] { 1, 0, 1, 1 }, 1, 2, ExpectedResult = true)]
        [TestCase(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3, ExpectedResult = false)]
        [TestCase(new int[] { int.MinValue, int.MaxValue }, 1, 1, ExpectedResult = false)]
        public bool test_V2(int[] nums, int k, int t)
        {
            return target.ContainsNearbyAlmostDuplicate_V2(nums, k, t);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 1 }, 3, 0, ExpectedResult = true)]
        [TestCase(new int[] { 1, 0, 1, 1 }, 1, 2, ExpectedResult = true)]
        [TestCase(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3, ExpectedResult = false)]
        [TestCase(new int[] { int.MinValue, int.MaxValue }, 1, 1, ExpectedResult = false)]
        public bool test_V3(int[] nums, int k, int t)
        {
            return target.ContainsNearbyAlmostDuplicate_V3(nums, k, t);
        }
    }
}
