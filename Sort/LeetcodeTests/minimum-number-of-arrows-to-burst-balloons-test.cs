using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class minimum_number_of_arrows_to_burst_balloons_test
    {
        private minimum_number_of_arrows_to_burst_balloons target = new minimum_number_of_arrows_to_burst_balloons();

        static IEnumerable<TestCaseData> PrepareDates()
        {
            //单独返回int[][]不识别，报错，Object of type 'System.Int32[]' cannot be converted to type 'System.Int32[][]'
            //增加一个参数后可以正常识别
            yield return new TestCaseData(new int[][] {new int[] { -2147483646, -2147483645 }, new[] { 2147483646, 2147483647 } },1).Returns(2);
            yield return new TestCaseData(new int[][] {  new[] { 2147483646, 2147483647 } , new int[] { -2147483646, -2147483645 } }, 1).Returns(2);
            yield return new TestCaseData(new int[][] { new int[] { 1, 3 }, new[] { -2, 2 } }, 1).Returns(1);
            yield return new TestCaseData(new int[][] { new int[] { 10, 16 }, new int[] { 2, 8 }, new int[] { 1, 6 }, new int[] { 7, 12 } }, 1).Returns(2);
            yield return new TestCaseData(new int[][] { new int[] { 1, 2 }, new int[] { 3,4}, new int[] { 5, 6 }, new int[] { 7, 9 } }, 1).Returns(4);
            yield return new TestCaseData(new int[][] { new int[] { 1, 2 }, new int[] { 2,3 }, new int[] { 3,4 }, new int[] { 4,5 } }, 1).Returns(2);
            yield return new TestCaseData(new int[][] { new int[] { 1, 2 }, new int[] { 1, 2 } }, 1).Returns(1);
            yield return new TestCaseData(new int[][] { new int[] { 1, 2 } }, 1).Returns(1);
            yield return new TestCaseData(new int[][] {  }, 1).Returns(0);
        }

        [TestCaseSource("PrepareDates")]
        public int test(int[][] input, int i)
        {
            return target.FindMinArrowShots(input);
        }

        [TestCaseSource("PrepareDates")]
        public int test_V1(int[][] input, int i)
        {
            return target.FindMinArrowShots_V1(input);
        }
    }
}