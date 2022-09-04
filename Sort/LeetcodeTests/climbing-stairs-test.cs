using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class climbing_stairs_test
    {
        private climbing_stairs target = new climbing_stairs();
       
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 5)]
        [TestCase(30, ExpectedResult = 1346269)]
        public int test(int n)
        {
            return target.climbStairs(n);
        }
    }
}
