using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class number_of_operations_to_make_network_connected_test
    {
        number_of_operations_to_make_network_connected target = new number_of_operations_to_make_network_connected();

        static IEnumerable< TestCaseData > GetTestCaseDatas()
        {
            yield return new TestCaseData(4, (object)new int[][] {
                new int[] { 1 ,0},
                new int[] { 2 ,0},
                new int[] { 2 ,1},
             }).Returns(1);

            yield return new TestCaseData(6, (object)new int[][] {
                new int[] { 0,1},
                new int[] { 2 ,0},
                new int[] { 0,3},
                new int[] {1,2},
                new int[] {1,3},
             }).Returns(2);

            yield return new TestCaseData(6, (object)new int[][] {
                new int[] { 0,1},
                new int[] { 2 ,0},
                new int[] { 0,3},
                new int[] {1,2},
             }).Returns(-1);

            yield return new TestCaseData(5, (object)new int[][] {
                new int[] { 0,1},
                new int[] { 2 ,0},
                new int[] {2,3},
                new int[] {3,4},
             }).Returns(0);
        }
        [Test]
        [TestCaseSource("GetTestCaseDatas")]
        public int test(int n, int[][] connections)
        {
            return target.makeConnected(n, connections);
        }
    }
}
