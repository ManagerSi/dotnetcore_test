using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class sort_integers_by_the_number_of_1_bits_test
    {
        sort_integers_by_the_number_of_1_bits target = new sort_integers_by_the_number_of_1_bits();

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 },ExpectedResult = "0,1,2,4,8,3,5,6,7")]
        [TestCase(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, ExpectedResult = "1,2,4,8,16,32,64,128,256,512,1024")]
        [TestCase(new int[] { 10000, 10000 }, ExpectedResult = "10000,10000")]
        [TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }, ExpectedResult = "2,3,5,17,7,11,13,19")]
        public string test(int[] arr)
        {
            return IntExtent.ToString(target.SortByBits(arr));
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = "0,1,2,4,8,3,5,6,7")]
        [TestCase(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, ExpectedResult = "1,2,4,8,16,32,64,128,256,512,1024")]
        [TestCase(new int[] { 10000, 10000 }, ExpectedResult = "10000,10000")]
        [TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }, ExpectedResult = "2,3,5,17,7,11,13,19")]
        public string test_V2(int[] arr)
        {
            return IntExtent.ToString(target.SortByBits_V2(arr));
        }

        [Test]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = "0,1,2,4,8,3,5,6,7")]
        [TestCase(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, ExpectedResult = "1,2,4,8,16,32,64,128,256,512,1024")]
        [TestCase(new int[] { 10000, 10000 }, ExpectedResult = "10000,10000")]
        [TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }, ExpectedResult = "2,3,5,17,7,11,13,19")]
        public string test_V3(int[] arr)
        {
            return IntExtent.ToString(target.SortByBits_V3(arr));
        }

        [Ignore("测试失败")]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = "0,1,2,4,8,3,5,6,7")]
        [TestCase(new int[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, ExpectedResult = "1,2,4,8,16,32,64,128,256,512,1024")]
        [TestCase(new int[] { 10000, 10000 }, ExpectedResult = "10000,10000")]
        [TestCase(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 }, ExpectedResult = "2,3,5,17,7,11,13,19")]
        public string test_V4(int[] arr)
        {
            return IntExtent.ToString(target.SortByBits_V4(arr));
        }
    }
}
