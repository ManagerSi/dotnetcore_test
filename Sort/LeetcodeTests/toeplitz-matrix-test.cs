using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class toeplitz_matrix_test
    {
        toeplitz_matrix target = new toeplitz_matrix();

        public static IEnumerable<TestCaseData> getTestData()
        {
            yield return new TestCaseData(
                (object)new int[][]
                {
                    new []{1,3},
                    new []{3,1}
                }).Returns(true);

            yield return new TestCaseData(
                (object) new int[][]
                {
                    new []{1,2,3,4},
                    new []{5,1,2,3},
                    new []{9,5,1,2},
                }).Returns(true);
            yield return new TestCaseData(
                (object)new int[][]
                {
                    new []{1,3},
                    new []{3,2}
                }).Returns(false);
            yield return new TestCaseData(
                (object)new int[][]
                {
                    new []{1,2},
                    new []{2,1},
                    new []{3,2},
                    new []{4,3},
                    new []{5,4},
                }).Returns(true);
        }

        [TestCaseSource("getTestData")]
        public bool test(int[][] nums)
        {
            return target.IsToeplitzMatrix(nums);
        }

        [TestCaseSource("getTestData")]
        public bool test_V2(int[][] nums)
        {
            return target.IsToeplitzMatrix_V2(nums);
        }
    }
}
