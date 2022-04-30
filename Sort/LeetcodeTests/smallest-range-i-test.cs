using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class smallest_range_i_test
    {
        private readonly smallest_range_i target = new smallest_range_i();

        [TestCase(new[] { 1 }, 0, ExpectedResult = 0)]
        [TestCase(new[] { 0, 10 }, 2, ExpectedResult = 6)]
        [TestCase(new[] { 1, 3, 6 }, 3, ExpectedResult = 0)]
        public int test(int[] nums, int k)
        {
            return target.SmallestRangeI(nums, k);
        }


        [TestCase(new[] { 1 }, 0, ExpectedResult = 0)]
        [TestCase(new[] { 0, 10 }, 2, ExpectedResult = 6)]
        [TestCase(new[] { 1, 3, 6 }, 3, ExpectedResult = 0)]
        public int test_V2(int[] nums, int k)
        {
            return target.SmallestRangeI_V2(nums, k);
        }
    }
}