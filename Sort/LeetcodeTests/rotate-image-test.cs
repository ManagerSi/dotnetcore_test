using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class rotate_image_test
    {
        rotate_image target = new rotate_image();

        public static IEnumerable<TestCaseData> testDates
        {
            get
            {
                //使用(object) 将数组转化下
                //奇数数组
                yield return new TestCaseData((object)new int[][]
                {
                    new[] {1, 2, 3},
                    new[] {4, 5, 6},
                    new[] {7, 8, 9},
                }).Returns(new int[][]
                {
                    new[] {7, 4, 1},
                    new[] {8, 5, 2},
                    new[] {9, 6, 3},
                });

                //偶数数组
                yield return new TestCaseData((object)new int[][]
                {
                    new[] { 5, 1, 9, 11 },
                    new[] { 2, 4, 8, 10 },
                    new[] { 13, 3, 6, 7 },
                    new[] { 15, 14, 12, 16 },
                }).Returns(new int[][]
                {
                    new[] { 15, 13, 2, 5 },
                    new[] { 14, 3, 4, 1 },
                    new[] { 12, 6, 8, 9 },
                    new[] { 16, 7, 10, 11 },
                });
            }

        }

        [TestCaseSource("testDates")]
        public int[][] test(int[][] nums)
        {
            target.Rotate(nums);
            return nums;
        }

        [TestCaseSource("testDates")]
        public int[][] test_V2(int[][] nums)
        {
            target.Rotate_V2(nums);
            return nums;
        }

        [TestCaseSource("testDates")]
        public int[][] test_V3(int[][] nums)
        {
            target.Rotate_V3(nums);
            return nums;
        }
    }
}
