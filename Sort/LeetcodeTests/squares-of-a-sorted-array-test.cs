using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class squares_of_a_sorted_array_test
    {
        private squares_of_a_sorted_array target = new squares_of_a_sorted_array();

        [Test]
        public void test()
        {
            int[] n = new[] {-4, -1, 0, 3, 10};
            var res = target.SortedSquares(n);
            Assert.IsTrue(Utility.ToArrayString(res) ==  "0,1,9,16,100");
        }
        [Test]
        public void test_v1()
        {
            int[] n = new[] { -4, -1, 0, 3, 10 };
            var res = target.SortedSquares_V1(n);
            Assert.IsTrue(Utility.ToArrayString(res) == "0,1,9,16,100");
        }
    }
}
