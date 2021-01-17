using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class check_if_it_is_a_straight_line_test
    {
        check_if_it_is_a_straight_line target = new check_if_it_is_a_straight_line();

        public static IEnumerable<TestCaseData> GetTestCaseDatas()
        {
            yield return new TestCaseData((object)new int[][] { }).Returns(false);
            yield return new TestCaseData((object)new int[][] {
                new int[] {1, 1 },new int[] {2, 2},new int[] {3, 3},new int[] {4, 4},new int[] {5,5},new int[] {7, 7}
            }).Returns(true);
            yield return new TestCaseData((object)new int[][] { 
                new int[] {1, 1 },new int[] {2, 2},new int[] {3, 4},new int[] {4, 5},new int[] {5, 6},new int[] {7, 7}
            }).Returns(false);
        }

        [Test]
        [TestCaseSource("GetTestCaseDatas")]
        public bool test(int[][] coordinates)
        {
            return target.CheckStraightLine(coordinates);
        }
    }
}
