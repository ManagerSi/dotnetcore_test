using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class binary_prefix_divisible_by_5_test
    {
        binary_prefix_divisible_by_5 target = new binary_prefix_divisible_by_5();

        [Test]
        [TestCase(new int[] { 0, 1, 1 }, ExpectedResult = "True,False,False")]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = "False,False,False")]
        [TestCase(new int[] { 0, 1, 1, 1, 1, 1 }, ExpectedResult = "True,False,False,False,True,False")]
        [TestCase(new int[] { 1, 1, 1, 0, 1 }, ExpectedResult = "False,False,False,False,False")]
        [TestCase(new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 }, ExpectedResult = "False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,True,False,False,True,True,True,True,False")]
        //[TestCase(new int[] { 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0 }, ExpectedResult = "False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,True,False,False,True,True,True,True,False")]

        public string test(int[] n)
        {
            return string.Join(',',target.PrefixesDivBy5(n));
        }

        [Test]
        [TestCase(new int[] { 0, 1, 1 }, ExpectedResult = "True,False,False")]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = "False,False,False")]
        [TestCase(new int[] { 0, 1, 1, 1, 1, 1 }, ExpectedResult = "True,False,False,False,True,False")]
        [TestCase(new int[] { 1, 1, 1, 0, 1 }, ExpectedResult = "False,False,False,False,False")]
        [TestCase(new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 }, ExpectedResult = "False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,True,False,False,True,True,True,True,False")]
        public string test_V2(int[] n)
        {
            return string.Join(',', target.PrefixesDivBy5_V2(n));
        }

        [Test]
        [TestCase(new int[] { 0, 1, 1 }, ExpectedResult = "True,False,False")]
        [TestCase(new int[] { 1, 1, 1 }, ExpectedResult = "False,False,False")]
        [TestCase(new int[] { 0, 1, 1, 1, 1, 1 }, ExpectedResult = "True,False,False,False,True,False")]
        [TestCase(new int[] { 1, 1, 1, 0, 1 }, ExpectedResult = "False,False,False,False,False")]
        [TestCase(new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 }, ExpectedResult = "False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,True,False,False,True,True,True,True,False")]
        [TestCase(new int[] { 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0 }, ExpectedResult = "False,False,True,False,False,False,False,False,False,False,True,True,True,True,True,True,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,False,True,False,False,False,True,False,False,True,False,False,True,True,True,True,True,True,True,False,False,True,False,False,False,False,True,True")]

        public string test_V3(int[] n)
        {
            return string.Join(',', target.PrefixesDivBy5_V3(n));
        }
    }
}
