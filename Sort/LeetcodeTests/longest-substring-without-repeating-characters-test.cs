using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class longest_substring_without_repeating_characters_test
    {
        private longest_substring_without_repeating_characters target = new longest_substring_without_repeating_characters();

        [Test]
        public void test()
        {
            var s = "abcabcbb";
            var res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 3);

            s = "bbbbb";
            res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 1);

            s = "pwwkew";
            res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 3);

            s = "aab";
            res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 2);

            s = "dvdf";
            res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 3);

            s = "";
            res = target.LengthOfLongestSubstring(s);
            Assert.IsTrue(res == 0);
        }

        [Test]
        public void test_V2()
        {
            var s = "abcabcbb";
            var res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 3);

            s = "bbbbb";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 1);

            s = "pwwkew";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 3);

            s = "aab";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 2);

            s = "dvdf";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 3);

            s = "";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 0);

            s = "tmmzuxt";
            res = target.LengthOfLongestSubstring_V2(s);
            Assert.IsTrue(res == 5);
        }

        [Test]
        public void test_V3()
        {
            var s = "abcabcbb";
            var res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 3);

            s = "bbbbb";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 1);

            s = "pwwkew";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 3);

            s = "aab";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 2);

            s = "dvdf";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 3);

            s = "";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 0);

            s = "tmmzuxt";
            res = target.LengthOfLongestSubstring_V3(s);
            Assert.IsTrue(res == 5);
        }
    }
}
