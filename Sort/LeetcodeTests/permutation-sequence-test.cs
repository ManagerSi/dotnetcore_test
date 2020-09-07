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


        [Test]
        public void test_v2()
        {
            var n = 3;
            var orderIndex = 3;
            var res = target.GetPermutation_v2(n, orderIndex);
            Assert.True("213" == res);



            n = 4;
            orderIndex = 9;
            res = target.GetPermutation_v2(n, orderIndex);
            Assert.True("2314" == res);
        }
    }
}
