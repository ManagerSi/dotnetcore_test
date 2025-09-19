using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeTests
{
    internal class merge_sorted_array_test
    {
        merge_sorted_array target = new merge_sorted_array();

        [Test]
        [TestCase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, ExpectedResult = "122356")]
        [TestCase(new int[] { 1 }, 1, new int[] { }, 0, ExpectedResult = "1")]
        [TestCase(new int[] { 1, 2 }, 2, new int[] {  }, 0, ExpectedResult = "12")]
        [TestCase(new int[] { 1, 0 }, 1, new int[] { 1 }, 1, ExpectedResult = "11")]
        [TestCase(new int[] { 0 }, 0, new int[] { 1 }, 1, ExpectedResult = "1")]
        [TestCase(new int[] { 0, 0 }, 0, new int[] { 1, 2 }, 2, ExpectedResult = "12")]
        public string test(int[] input, int m, int[] input2, int n)
        {
            target.Merge(input, m, input2, n);
            return string.Join("", input);
        }
    }
}
