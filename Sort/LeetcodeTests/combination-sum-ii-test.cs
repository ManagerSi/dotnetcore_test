using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class combination_sum_ii_test
    {
        combination_sum_ii target = new combination_sum_ii();

        [Test]
        public void test()
        {
            int[] sum = new[] {10, 1, 2, 7, 6, 1, 5};
            int tar = 8;
            var res = target.CombinationSum2(sum, tar);
            Assert.True(res.Count == 4);
        }
    }
}
