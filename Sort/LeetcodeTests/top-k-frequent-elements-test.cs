using System;
using System.Collections.Generic;
using System.Text;
using Leetcode;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class top_k_frequent_elements_test
    {
        top_k_frequent_elements target = new top_k_frequent_elements();

        [Test]
        public void test()
        {
            var nums = new int[] {1, 1, 1, 2, 2, 3};
            var k = 2;
            var res = target.TopKFrequent(nums, k);
            Assert.True(string.Join(',', res) == "1,2");
        }
    }
}
