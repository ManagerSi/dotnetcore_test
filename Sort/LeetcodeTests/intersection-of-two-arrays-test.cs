using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class intersection_of_two_arrays_test
    {
        intersection_of_two_arrays target = new intersection_of_two_arrays();

        [Test]
        [TestCase(null, new int[] { 2, 2 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] {  }, new int[] { 2, 2 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 },ExpectedResult = new int[] { 2 })]
        [TestCase(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, ExpectedResult = new int[] { 4 ,9 })]
        public int[] test(int[] n1, int[] n2)
        {
            return  target.Intersection(n1, n2).OrderBy(i=>i).ToArray();
        }
    }
}
