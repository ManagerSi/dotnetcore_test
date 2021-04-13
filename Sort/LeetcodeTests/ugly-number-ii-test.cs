using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class ugly_number_ii_test
    {
        ugly_number_ii target = new ugly_number_ii();

        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(10,ExpectedResult = 12)]
        [TestCase(11, ExpectedResult = 15)]
        //[TestCase(1352, ExpectedResult = 402653184)] //too long time
        
        public int test(int n)
        {
            return target.NthUglyNumber(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 12)]
        [TestCase(11, ExpectedResult = 15)]
        [TestCase(1352, ExpectedResult = 402653184)]
        public int test_V2(int n)
        {
            return target.NthUglyNumber_V2(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 12)]
        [TestCase(11, ExpectedResult = 15)]
        [TestCase(1352, ExpectedResult = 402653184)]
        public int test_V3(int n)
        {
            return target.NthUglyNumber_V3(n);
        }
    }
}
