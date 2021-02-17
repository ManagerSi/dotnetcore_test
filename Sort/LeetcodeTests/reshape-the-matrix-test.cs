using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reshape_the_matrix_test
    {
        reshape_the_matrix target = new reshape_the_matrix();

        static IEnumerable<TestCaseData> GeTestCaseDatas()
        {
            //yield return new TestCaseData(new[]
            //{
            //    new[] {1, 3},
            //    new[] {6, 9},
            //}, 2,2).Returns(new[]
            //{
            //    new[] {1, 3},
            //    new[] {6, 9},
            //});

            yield return new TestCaseData(new[]
            {
                new[] {1, 3},
                new[] {6, 9},
            },1, 4).Returns(new[]
            {
                new[] {1, 3, 6, 9}
            });

        }

        [Test]
        [TestCaseSource("GeTestCaseDatas")]
        public int[][] test(int[][] nums, int r,int c)
        {
            return target.MatrixReshape(nums, r, c);
        }
    }
}
