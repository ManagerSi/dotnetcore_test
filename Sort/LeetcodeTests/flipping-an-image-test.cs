using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class flipping_an_image_test
    {
        flipping_an_image target = new flipping_an_image();

        public static IEnumerable<TestCaseData> GetTestCaseDatas()
        {
            yield return new TestCaseData(
                    (object)new int[][]
                    {
                        new[]{ 1, 1, 0 },
                        new[] { 1, 0, 1 },
                        new[] { 0, 0, 0 },
                    })
                    .Returns((object)new int[][]
                    {
                        new[]{  1,0,0 },
                        new[] {0,1,0 },
                        new[] { 1,1,1 },
                    });

            yield return new TestCaseData(
                    (object)new int[][]
                    {
                        new[]{ 1,1,0,0 },
                        new[] { 1,0,0,1 },
                        new[] {0,1,1,1 },
                        new[] {1,0,1,0 },
                    })
                .Returns((object)new int[][]
                {
                    new[]{ 1,1,0,0 },
                    new[] {0,1,1,0 },
                    new[] { 0,0,0,1 },
                    new[] { 1,0,1,0 },
                });
    }

        [Test]
        [TestCaseSource("GetTestCaseDatas")]
        public int[][] test(int[][] coordinates)
        {
            return target.FlipAndInvertImage(coordinates);
        }
    }
}
