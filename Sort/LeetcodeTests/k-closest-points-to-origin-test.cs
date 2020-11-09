using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class k_closest_points_to_origin_test
    {
        k_closest_points_to_origin target = new k_closest_points_to_origin();

        static IEnumerable<TestCaseData> getDates()
        {
            yield return new TestCaseData(new int[][] { new int[] { 1, 3 }, new[] { -2, 2 } }, 1).Returns(new int[][] {  new[] { -2, 2 } });
            yield return new TestCaseData(new int[][] { new int[] { 3, 3}, new[] { 5,-1}, new[] { -2,4} }, 2).Returns(new int[][] { new[] { 3, 3 }, new[] { -2, 4 } });
        }

        [Test]
        [TestCaseSource("getDates")]
        public int[][] test(int[][] points, int k)
        {
            return target.KClosest(points, k);
        }

        [Test]
        [TestCaseSource("getDates")]
        public int[][] test_V2(int[][] points, int k)
        {
            return target.KClosest_V2(points, k);
        }

        [Test]
        [TestCaseSource("getDates")]
        public int[][] test_V3(int[][] points, int k)
        {
            return target.KClosest_V3(points, k);
        }
    }
}
