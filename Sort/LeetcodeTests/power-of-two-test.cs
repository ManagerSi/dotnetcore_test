using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class power_of_two_test
    {
        power_of_two target = new power_of_two();

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(2,ExpectedResult = true)]
        [TestCase(16, ExpectedResult = true)]
        [TestCase(218, ExpectedResult = false)]
        public bool test(int n)
        {
            return target.IsPowerOfTwo(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(16, ExpectedResult = true)]
        [TestCase(218, ExpectedResult = false)]
        public bool test_V2(int n)
        {
            return target.IsPowerOfTwo_V2(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(16, ExpectedResult = true)]
        [TestCase(218, ExpectedResult = false)]
        public bool test_V3(int n)
        {
            return target.IsPowerOfTwo_V3(n);
        }

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(16, ExpectedResult = true)]
        [TestCase(218, ExpectedResult = false)]
        public bool test_V4(int n)
        {
            return target.IsPowerOfTwo_V4(n);
        }
    }
}
