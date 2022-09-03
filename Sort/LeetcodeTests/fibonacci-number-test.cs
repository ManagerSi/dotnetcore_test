using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class fibonacci_number_test
    {
        private fibonacci_number target = new fibonacci_number();

        [Test]
        public void test()
        {
            int input = 1;
            var r = target.Fib(input);
            Assert.AreEqual(input, r);

            input = 2;
            r = target.Fib(input);
            Assert.AreEqual(1, r);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1,ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 3)]
        public int test2(int n)
        {
            return target.Fib(n);
        }
    }
}
