using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class search_a_2d_matrix_ii_test
    {
        [Test]
        public void test()
        {
            var testClass = new search_a_2d_matrix_ii();

           int[,] nums = new int[,] {{1, 4, 7, 11, 15}, {2, 5, 8, 12, 19}, {3, 6, 9, 16, 22}, {10, 13, 14, 17, 24}, {18, 21, 23, 26, 30}};
           int target = 5;
           bool res = testClass.SearchMatrix(nums, target);
           Assert.True(res);

        }

        [Test]
        public void test_V2()
        {
            var testClass = new search_a_2d_matrix_ii();

            int[,] nums = new int[,] { { 1, 4, 7, 11, 15 }, { 2, 5, 8, 12, 19 }, { 3, 6, 9, 16, 22 }, { 10, 13, 14, 17, 24 }, { 18, 21, 23, 26, 30 } };
            int target = 5;
            bool res = testClass.SearchMatrix_V2(nums, target);
            Assert.True(res);

        }

        [Test]
        public void test_V2_false()
        {
            var testClass = new search_a_2d_matrix_ii();

            int[,] nums = new int[,] { {-5 }};
            int target = -10;
            bool res = testClass.SearchMatrix_V2(nums, target);
            Assert.False(res);

        }


        [Test]
        public void test_V3()
        {
            var testClass = new search_a_2d_matrix_ii();

            int[][] nums = new int[][] { new int[] { 1, 4, 7, 11, 15 }, new int[] { 2, 5, 8, 12, 19 }, new int[] { 3, 6, 9, 16, 22 }, new int[] { 10, 13, 14, 17, 24 }, new int[] { 18, 21, 23, 26, 30 } };
            int target = 5;
            bool res = testClass.SearchMatrix_V3(nums, target);
            Assert.True(res);

        }

        [Test]
        public void test_V3_false()
        {
            var testClass = new search_a_2d_matrix_ii();

            int[][] nums = new int[][] { };
            int target = 5;
            bool res = testClass.SearchMatrix_V3(nums, target);
            Assert.True(res);

        }
    }
}
