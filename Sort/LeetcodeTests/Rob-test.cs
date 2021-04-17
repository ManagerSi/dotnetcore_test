using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class Rob_test
    {
        private Rob target = new Rob();

        [Test]
        [TestCase(new int[] { 2, }, ExpectedResult = 2)]
        [TestCase(new int[] { 2,3 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 2 }, ExpectedResult = 3)]
        [TestCase(new int[] { 2, 3, 2, 3, 2, 3, 2 }, ExpectedResult = 9)]
        [TestCase(new int[] { 3, 2, 3, 2, 3, 2, 3 }, ExpectedResult = 9)]
        [TestCase(new int[] { 1, 2, 3, 1 }, ExpectedResult = 4)]
        [TestCase(new int[]{1, 3, 1, 3, 100},ExpectedResult = 103)]
        [TestCase(new int[] { 1, 7, 9, 4 }, ExpectedResult = 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 }, ExpectedResult = 16)]
        public int test(int[] num)
        {
            //return target.Rob_V1(num); //1, 2, 3, 4, 5, 1, 2, 3, 4, 5 ===>答案错误

            return target.Rob_V2(num);
        }
    }
}
