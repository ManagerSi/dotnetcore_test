using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class n_th_tribonacci_number_test
    {
        private n_th_tribonacci_number target = new n_th_tribonacci_number();

        [Test]
        public void test()
        {
            int input = 1;
            var r = target.Tribonacci(input);
            Assert.AreEqual(input, r);

            input = 2;
            r = target.Tribonacci(input);
            Assert.AreEqual(1, r);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(23, ExpectedResult = 410744)]
        public int test2(int n)
        {
            return target.Tribonacci(n);
        }


        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 4)]
        [TestCase(23, ExpectedResult = 410744)]
        public int testV1_1(int n)
        {
            return target.Tribonacci_V1(n);
        }
    }
}
