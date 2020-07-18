using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class sliding_window_maximum_test
    {
        [Test]
        public void test()
        {
            var target = new sliding_window_maximum();

            int[] nums = {1, 3, -1, -3, 5, 3, 6, 7};
            var res = target.MaxSlidingWindow(nums, 3);

            Assert.IsTrue(res.Length == 6);

        }

        [Test]
        public void test_V2()
        {
            var target = new sliding_window_maximum();

            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            var res = target.MaxSlidingWindow_V2(nums, 3);

            Assert.IsTrue(res.Length == 6);

        }
    }
}
