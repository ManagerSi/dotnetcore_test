using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class relative_sort_array_test
    {
        relative_sort_array target =new relative_sort_array();

        [Test]
        public void test()
        {
            var a1 = new int[] { 5,3,1 };
            var a2 = new int[] {  };
            var res = target.RelativeSortArray(a1, a2);
            Assert.True(res.ToArrayString() == "1,3,5");

            a1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            a2 = new int[] { 2, 1, 4, 3, 9, 6 };
            res = target.RelativeSortArray(a1, a2);
            Assert.True(res.ToArrayString() == "2,2,2,1,4,3,3,9,6,7,19");

        }

        [Test]
        public void test_V2()
        {
            var a1 = new int[] { 5, 3, 1 };
            var a2 = new int[] { };
            var res = target.RelativeSortArray_V2(a1, a2);
            Assert.True(res.ToArrayString() == "1,3,5");

            a1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            a2 = new int[] { 2, 1, 4, 3, 9, 6 };
            res = target.RelativeSortArray_V2(a1, a2);
            Assert.True(res.ToArrayString() == "2,2,2,1,4,3,3,9,6,7,19");
        }
        [Test]
        public void test_V3()
        {
            var a1 = new int[] { 5, 3, 1 };
            var a2 = new int[] { };
            var res = target.RelativeSortArray_V3(a1, a2);
            Assert.True(res.ToArrayString() == "1,3,5");

            a1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            a2 = new int[] { 2, 1, 4, 3, 9, 6 };
            res = target.RelativeSortArray_V3(a1, a2);
            Assert.True(res.ToArrayString() == "2,2,2,1,4,3,3,9,6,7,19");
        }
    }
}
