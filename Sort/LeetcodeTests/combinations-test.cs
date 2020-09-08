using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class combinations_test
    {
        combinations target = new combinations();

        [Test]
        public void test()
        {
            int n = 4, k = 2;
            var res = target.Combine(n, k);
            Assert.True(res.Count == 6);

            n = 1;
            k = 1;
            res = target.Combine(n, k);
            Assert.True(res.Count == 1);
        }

        [Test]
        public void test_v2()
        {
            int n = 4, k = 2;
            var res = target.CombineV2(n, k);
            Assert.True(res.Count == 6);

            n = 1;
            k = 1;
            res = target.CombineV2(n, k);
            Assert.True(res.Count == 1);
        }
    }
}
