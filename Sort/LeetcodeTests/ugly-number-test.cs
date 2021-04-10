using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class ugly_number_test
    {
        ugly_number target = new ugly_number();

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(6,ExpectedResult = true)]
        [TestCase(8, ExpectedResult = true)]
        [TestCase(14, ExpectedResult = false)]
        public bool test(int n)
        {
            return target.IsUgly(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(6, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = true)]
        [TestCase(14, ExpectedResult = false)]
        public bool test_V2(int n)
        {
            return target.IsUgly_V2(n);
        }
    }
}
