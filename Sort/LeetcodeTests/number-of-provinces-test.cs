using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class number_of_provinces_test
    {
        number_of_provinces target = new number_of_provinces();

        static IEnumerable<TestCaseData> getDatas()
        {
            yield return new TestCaseData((object)new int[][]
            {
                new int[] { 1,1,0 },
                new int[] { 1,1,0 },
                new int[] { 0,0,1 },
            }).Returns(2);
            yield return new TestCaseData((object)new int[][]
            {
                new int[] { 1,0,0 },
                new int[] { 0,1,0 },
                new int[] { 0,0,1 },
            }).Returns(3);
        }
        [Test]
        [TestCaseSource("getDatas")]
        public int test(int[][] isConnected)
        {
            return target.FindCircleNum(isConnected);
        }
    }
}
