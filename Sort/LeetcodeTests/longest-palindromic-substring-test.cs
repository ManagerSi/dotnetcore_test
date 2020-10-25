using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class longest_palindromic_substring_test
    {
        longest_palindromic_substring target = new longest_palindromic_substring();
        [Test]
        public void test()
        {
            var str = "babad";
            var res = target.LongestPalindrome(str);
            Assert.AreEqual(res, "bab");

            str = "cbbd"; 
            res = target.LongestPalindrome(str);
            Assert.AreEqual(res, "bb");
        }
    }
}
