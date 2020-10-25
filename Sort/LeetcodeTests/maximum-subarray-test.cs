using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class maximum_subarray_test
    {
        maximum_subarray target= new maximum_subarray();

        [Test]
        public void test()
        {
            var nums = new int[] { };
            var res = target.MaxSubArray(nums);
            Assert.IsTrue(res == int.MinValue);

            nums = new int[] { -2 };
            res = target.MaxSubArray(nums);
            Assert.IsTrue(res == -2);

            nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            res = target.MaxSubArray(nums);
            Assert.IsTrue(res == 6);
        }


        [Test]
        public void test_V1()
        {
            var nums = new int[] { };
            var res = target.MaxSubArray_V1(nums);
            Assert.IsTrue(res == int.MinValue);

            nums = new int[] { -2 };
            res = target.MaxSubArray_V1(nums);
            Assert.IsTrue(res == -2);

            nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            res = target.MaxSubArray_V1(nums);
            Assert.IsTrue(res == 6);
        }
    }
}
