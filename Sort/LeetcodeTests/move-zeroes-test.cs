using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class move_zeroes_test
    {
        private move_zeroes target = new move_zeroes();

        [Test]
        [TestCase(new int[]{ 0, 1, 0, 3, 12 }, ExpectedResult = new int[]{ 1, 3, 12, 0, 0 })]
        [TestCase(new int[] { 0,0,1 }, ExpectedResult = new int[] { 1, 0, 0 })]
        public int[] test_V2(int[] n)
        {
            target.MoveZeroes_V2(n);
            return n;
        }

        [TestCase(new int[] { 1, 1 }, ExpectedResult = new int[] { 1, 1 })]
        [TestCase(new int[] { 0, 1, 0, 3, 12 }, ExpectedResult = new int[] { 1, 3, 12, 0, 0 })]
        [TestCase(new int[] { 0, 0, 1 }, ExpectedResult = new int[] { 1, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = new int[] { 0, 0, 0 })]
        public int[] test_V3(int[] n)
        {
            target.MoveZeroes_V3(n);
            return n;
        }

        [TestCase(new int[] { 1, 1 }, ExpectedResult = new int[] { 1, 1 })]
        [TestCase(new int[] { 0, 1, 0, 3, 12 }, ExpectedResult = new int[] { 1, 3, 12, 0, 0 })]
        [TestCase(new int[] { 0, 0, 1 }, ExpectedResult = new int[] { 1, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = new int[] { 0, 0, 0 })]
        public int[] test_V4(int[] n)
        {
            target.MoveZeroes_V4(n);
            return n;
        }


        [TestCase(new int[] { 1, 1 }, ExpectedResult = new int[] { 1, 1 })]
        [TestCase(new int[] { 0, 1, 0, 3, 12 }, ExpectedResult = new int[] { 1, 3, 12, 0, 0 })]
        [TestCase(new int[] { 0, 0, 1 }, ExpectedResult = new int[] { 1, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0 }, ExpectedResult = new int[] { 0, 0, 0 })]
        public int[] test_V5(int[] n)
        {
            target.MoveZeroes_V5(n);
            return n;
        }
    }
}
