using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class remove_k_digits_test
    {
        remove_k_digits target = new remove_k_digits();

        [Test]
        [TestCase("1432219",3,ExpectedResult = "1219")]
        [TestCase("10200", 1, ExpectedResult = "200")]
        [TestCase("12345", 0, ExpectedResult = "12345")]
        [TestCase("10", 1, ExpectedResult = "0")]
        public string test(string num,int k)
        {
            return target.RemoveKdigits(num, k);
        }
    }
}
