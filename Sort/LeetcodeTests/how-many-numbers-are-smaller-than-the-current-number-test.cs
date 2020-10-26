using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class how_many_numbers_are_smaller_than_the_current_number_test
    {
        how_many_numbers_are_smaller_than_the_current_number target = new how_many_numbers_are_smaller_than_the_current_number();

        [Test]
        [TestCase(arg: new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        [TestCase(arg: new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(arg: new int[] { 1, 2, 2, 4 }, ExpectedResult = new int[] { 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 8, 1, 2, 2, 3 }, ExpectedResult = new int[] { 4, 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 2,2,2,2,2 }, ExpectedResult = new int[] {0,0,0,0,0})]
        public int[] test(int[] nums)
        {
            return target.SmallerNumbersThanCurrent(nums);
        }

        [TestCase(arg: new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        [TestCase(arg: new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(arg: new int[] { 1, 2, 2, 4 }, ExpectedResult = new int[] { 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 8, 1, 2, 2, 3 }, ExpectedResult = new int[] { 4, 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 2, 2, 2, 2, 2 }, ExpectedResult = new int[] { 0, 0, 0, 0, 0 })]
        public int[] test_V2(int[] nums)
        {
            return target.SmallerNumbersThanCurrent_V2(nums);
        }

        [TestCase(arg: new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        [TestCase(arg: new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(arg: new int[] { 1, 2, 2, 4 }, ExpectedResult = new int[] { 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 8, 1, 2, 2, 3 }, ExpectedResult = new int[] { 4, 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 2, 2, 2, 2, 2 }, ExpectedResult = new int[] { 0, 0, 0, 0, 0 })]
        public int[] test_V3(int[] nums)
        {
            return target.SmallerNumbersThanCurrent_V3(nums);
        }

        [TestCase(arg: new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        [TestCase(arg: new int[] { }, ExpectedResult = new int[] { })]
        [TestCase(arg: new int[] { 1, 2, 2, 4 }, ExpectedResult = new int[] { 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 8, 1, 2, 2, 3 }, ExpectedResult = new int[] { 4, 0, 1, 1, 3 })]
        [TestCase(arg: new int[] { 2, 2, 2, 2, 2 }, ExpectedResult = new int[] { 0, 0, 0, 0, 0 })]
        public int[] test_V4(int[] nums)
        {
            return target.SmallerNumbersThanCurrent_V4(nums);
        }
    }
}
