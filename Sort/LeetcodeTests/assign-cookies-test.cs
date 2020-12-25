using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class assign_cookies_test
    {
        assign_cookies target = new assign_cookies();

        [Test]
        [TestCase(new int[]{1,2,3},new int[]{1,1,4},ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 1 }, new int[] { 1, 1, 3, 1 }, ExpectedResult = 3)]
        public int test(int[] a, int[] b)
        {
            return target.FindContentChildren(a, b);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 1, 4 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 1 }, new int[] { 1, 1, 3, 1 }, ExpectedResult = 3)]
        public int test_V2(int[] a, int[] b)
        {
            return target.FindContentChildren_V2(a, b);
        }

        
    }
}
