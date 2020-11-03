using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class valid_mountain_array_test
    {
        valid_mountain_array target = new valid_mountain_array();

        public static class testCaseClass
        {
            public static IEnumerable<TestCaseData> GetCases
            {
                get {
                    yield return new TestCaseData(new int[] { 2, 1 }).Returns(false);
                    yield return new TestCaseData(new int[] { 3, 5, 5 }).Returns(false);
                    yield return new TestCaseData(new int[] { 0, 3, 2, 1 }).Returns(true);
                    yield return new TestCaseData(new int[] { 0, 3, 3, 1 }).Returns(false);//中间平
                    yield return new TestCaseData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Returns(false);//只升
                    yield return new TestCaseData(new int[] { 9,8,7,6 }).Returns(false);//只降
                }
                
            }
        }

        [TestCaseSource(typeof(testCaseClass), "GetCases")]
        public bool test(int[] a)
        {
            return target.ValidMountainArray(a);
        }

        [TestCaseSource(typeof(testCaseClass), "GetCases")]
        public bool test_V2(int[] a)
        {
            return target.ValidMountainArray_V2(a);
        }
    }
}
