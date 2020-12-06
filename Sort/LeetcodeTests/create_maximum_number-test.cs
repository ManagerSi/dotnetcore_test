using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class create_maximum_number_test
    {
        create_maximum_number target = new create_maximum_number();
        [TestCase(new int[]{ 3, 4, 6, 5 }, new int[] { 9, 1, 2, 5, 8, 3 }, 5, ExpectedResult = new int[] { 9, 8, 6, 5, 3 })]
        [TestCase(new int[] { 6, 7 }, new int[] { 6, 0, 4 }, 5, ExpectedResult = new int[] { 6, 7, 6, 0, 4 })]
        [TestCase(new int[] { 3, 9 }, new int[] { 8, 9 }, 3, ExpectedResult = new int[] { 9, 8, 9 })]
        [TestCase(new int[] { }, new int[] { 8, 9 }, 1, ExpectedResult = new int[] { 9 })]
        [TestCase(new int[] { }, new int[] { 8, 9 }, 0, ExpectedResult = new int[] {  })]
        [TestCase(
            new int[] { 4, 6, 9, 1, 0, 6, 3, 1, 5, 2, 8, 3, 8, 8, 4, 7, 2, 0, 7, 1, 9, 9, 0, 1, 5, 9, 3, 9, 3, 9, 7, 3, 0, 8, 1, 0, 9, 1, 6, 8, 8, 4, 4, 5, 7, 5, 2, 8, 2, 7, 7, 7, 4, 8, 5, 0, 9, 6, 9, 2 }, 
            new int[] { 9, 9, 4, 5, 1, 2, 0, 9, 3, 4, 6, 3, 0, 9, 2, 8, 8, 2, 4, 8, 6, 5, 4, 4, 2, 9, 5, 0, 7, 3, 7, 5, 9, 6, 6, 8, 8, 0, 2, 4, 2, 2, 1, 6, 6, 5, 3, 6, 2, 9, 6, 4, 5, 9, 7, 8, 0, 7, 2, 3 }, 
            60, 
            ExpectedResult = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 8, 8, 6, 8, 8, 4, 4, 5, 7, 5, 2, 8, 2, 7, 7, 7, 4, 8, 5, 0, 9, 6, 9, 2, 0, 2, 4, 2, 2, 1, 6, 6, 5, 3, 6, 2, 9, 6, 4, 5, 9, 7, 8, 0, 7, 2, 3 })]
        public int[] test(int[] a, int[] b,int k)
        {
            return target.MaxNumber(a, b, k);
        }
    }
}
