using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class remove_duplicates_from_sorted_array_test
    {
        [Test]
        public void test()
        {
            var target = new remove_duplicates_from_sorted_array();

            var arr = new int[]{ 1,1,2};
            var res = target.RemoveDuplicates(arr);
            Assert.True(res == 2);

            arr = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            res = target.RemoveDuplicates(arr);
            Assert.True(res == 5);


        }

        [Test]
        public void test_null()
        {
            var target = new remove_duplicates_from_sorted_array();

            int[] arr = null;
            var res = target.RemoveDuplicates(arr);
            Assert.True(res == 0);

            arr = new int[] { };
            res = target.RemoveDuplicates(arr);
            Assert.True(res == 0);


        }
    }
}
