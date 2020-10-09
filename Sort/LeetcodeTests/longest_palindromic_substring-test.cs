using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class longest_palindromic_substring_test
    {
        longest_palindromic_substring target = new longest_palindromic_substring();

        [Test]
        public void test()
        {
            var s = "";
            var res = target.LongestPalindrome(s);
            Assert.IsTrue(res == "");

            s = null;
            res = target.LongestPalindrome(s);
            Assert.IsTrue(res == null);

            s = "babad";
            res = target.LongestPalindrome(s);
            Assert.IsTrue(res == "bab");

            s = "ac";
            res = target.LongestPalindrome(s);
            Assert.IsTrue(res == "a");
        }


        [Test]
        public void test_V1()
        {
            var s = "";
            var res = target.LongestPalindrome_V1(s);
            Assert.IsTrue(res == "");

            s = null;
            res = target.LongestPalindrome_V1(s);
            Assert.IsTrue(res == null);

            s = "babad";
            res = target.LongestPalindrome_V1(s);
            Assert.IsTrue(res == "bab");

            s = "ac";
            res = target.LongestPalindrome_V1(s);
            Assert.IsTrue(res == "a");

            s = "cbbd";
            res = target.LongestPalindrome_V1(s);
            Assert.IsTrue(res == "bb");
        }

        [Test]
        public void test_V2()
        {
            var s = "";
            var res = target.LongestPalindrome_V2(s);
            Assert.IsTrue(res == "");

            s = null;
            res = target.LongestPalindrome_V2(s);
            Assert.IsTrue(res == null);

            s = "babad";
            res = target.LongestPalindrome_V2(s);
            Assert.IsTrue(res == "bab");

            s = "ac";
            res = target.LongestPalindrome_V2(s);
            Assert.IsTrue(res == "a");

            s = "cbbd";
            res = target.LongestPalindrome_V2(s);
            Assert.IsTrue(res == "bb");
        }
    }
}
