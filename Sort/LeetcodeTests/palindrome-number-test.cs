using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class palindrome_number_test
    {
        [Test]
        public void test()
        {
            var x = 12321;
            var res = new palindrome_number().isPalindrome(x);

            Assert.IsTrue(res);
        }

        [Test]
        public void test_0()
        {
            var x = 0;
            var res = new palindrome_number().isPalindrome(x);

            Assert.IsTrue(res);
        }

        [Test]
        public void test_V2_test()
        {
            var x = 12321;
            var res = new palindrome_number().isPalindrome_V2(x);

            Assert.IsTrue(res);
        }
        [Test]
        public void test_V2_test2()
        {
            var x = 1221;
            var res = new palindrome_number().isPalindrome_V2(x);

            Assert.IsTrue(res);
        }
    }
}
