using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class remove_element_test
    {
        remove_element target = new remove_element();

        [Test]
        public void test()
        {
            var nums = new int[] { 3, 2, 2, 3 };
            var t = 2;
            var res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 2);

            nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            t = 2;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 5);

            nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            t = 5;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 8);

            nums = new int[] { };
            t = 5;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 0);
        }

        [Test]
        public void test_V2()
        {
            var nums = new int[] { 3, 2, 2, 3 };
            var t = 2;
            var res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 2);

            nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            t = 2;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 5);

            nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            t = 5;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 8);

            nums = new int[] {  };
            t = 5;
            res = target.RemoveElement_V2(nums, t);
            Assert.True(res == 0);
        }
    }
}
