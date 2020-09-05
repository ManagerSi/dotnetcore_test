using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    
    class permutation_sequence_test
    {
        permutation_sequence target = new permutation_sequence();

        [Test]
        public void test()
        {
            var n = 3;
            var orderIndex = 3;
            var res = target.GetPermutation(n, orderIndex);
            Assert.True("213" == res);
        }
    }
}
