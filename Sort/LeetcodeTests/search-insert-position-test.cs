using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class search_insert_position_test
    {
        [Test]
        public void test()
        {
            var tClass = new search_insert_position();

            var nums = new int[] { 1, 3, 5, 6 };
            var res = tClass.SearchInsert(nums, 5);
            Assert.IsTrue(res == 2);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert(nums, 2);
            Assert.IsTrue(res == 1);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert(nums, 7);
            Assert.IsTrue(res == 4);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert(nums, 0);
            Assert.IsTrue(res == 0);
        }

        [Test]
        public void test_V3()
        {
            var tClass = new search_insert_position();

            var nums = new int[] { 1, 3, 5, 6 };
            var res = tClass.SearchInsert_V3(nums, 5);
            Assert.IsTrue(res == 2);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert_V3(nums, 2);
            Assert.IsTrue(res == 1);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert_V3(nums, 7);
            Assert.IsTrue(res == 4);

            nums = new int[] { 1, 3, 5, 6 };
            res = tClass.SearchInsert_V3(nums, 0);
            Assert.IsTrue(res == 0);
        }
    }
}
