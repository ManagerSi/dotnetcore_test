using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class valid_anagram_test
    {
        private valid_anagram target = new valid_anagram();

        [Test]
        [TestCase("", "", ExpectedResult = true)]
        [TestCase("anagram", "nagaram", ExpectedResult = true)]
        [TestCase("rat", "cat", ExpectedResult = false)]
        public bool test(string s,string t)
        {
            return target.IsAnagram(s, t);
        }

        [TestCase("", "", ExpectedResult = true)]
        [TestCase("anagram", "nagaram", ExpectedResult = true)]
        [TestCase("rat", "cat", ExpectedResult = false)]
        public bool test_V2(string s, string t)
        {
            return target.IsAnagram_V2(s, t);
        }

        [TestCase("", "", ExpectedResult = true)]
        [TestCase("anagram", "nagaram", ExpectedResult = true)]
        [TestCase("rat", "cat", ExpectedResult = false)]
        public bool test_good(string s, string t)
        {
            return target.IsAnagram_good(s, t);
        }

        [TestCase("", "", ExpectedResult = true)]
        [TestCase("anagram", "nagaram", ExpectedResult = true)]
        [TestCase("rat", "cat", ExpectedResult = false)]
        public bool test_V3(string s, string t)
        {
            return target.IsAnagram_V3(s, t);
        }
    }
}
