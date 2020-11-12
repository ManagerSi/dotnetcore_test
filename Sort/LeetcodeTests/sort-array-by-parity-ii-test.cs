using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class sort_array_by_parity_ii_test
    {
        sort_array_by_parity_ii target2 = new sort_array_by_parity_ii();

        [Test]
        [TestCase(new int[]{ 4, 2, 5, 7 }, ExpectedResult = new int[]{ 4, 5, 2, 7 })]
        public int[] test_ii(int[] input)
        {
            return target2.SortArrayByParityII(input);
        }
        [Test]
        [TestCase(new int[] { 4, 2, 5, 7 }, ExpectedResult = new int[] { 4, 5, 2, 7 })]
        public int[] test_ii_V2(int[] input)
        {
            return target2.SortArrayByParityII_V2(input);
        }


        sort_array_by_parity target = new sort_array_by_parity();
        [Test]
        [TestCase(new int[] { 3, 1, 2, 4 }, ExpectedResult = new int[] { 2, 4, 3, 1 })]
        [TestCase(new int[] { 3, 1, 2, 4,6,6,6 }, ExpectedResult = new int[] { 2, 4, 6, 6, 6, 3, 1 })]
        [TestCase(new int[] { 3, 1 }, ExpectedResult = new int[] { 3, 1 })]
        public int[] test(int[] input)
        {
            return target.SortArrayByParity(input);
        }
        [Test]
        [TestCase(new int[] { 3, 1 }, ExpectedResult = new int[] { 3, 1 })]
        [TestCase(new int[] { 3, 1, 2, 4 }, ExpectedResult = new int[] { 4, 2, 1,  3 })]
        [TestCase(new int[] { 3, 1, 2, 4, 6, 6, 6 }, ExpectedResult = new int[] { 6, 6, 2, 4,  6, 1,3, })]
        public int[] test_V2(int[] input)
        {
            return target.SortArrayByParity_V2(input);
        }
        [Test]
        [TestCase(new int[] { 3, 1 }, ExpectedResult = new int[] { 3, 1 })]
        [TestCase(new int[] { 3, 1, 2, 4 }, ExpectedResult = new int[] { 4, 2, 1, 3 })]
        [TestCase(new int[] { 3, 1, 2, 4, 6, 6, 6 }, ExpectedResult = new int[] { 6, 6, 2, 4, 6, 1, 3, })]
        public int[] test_V3(int[] input)
        {
            return target.SortArrayByParity_V3(input);
        }
    }
}
