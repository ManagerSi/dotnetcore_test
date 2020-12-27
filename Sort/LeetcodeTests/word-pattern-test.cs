using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class word_pattern_test
    {
        private word_pattern target = new word_pattern();

        [Test]
        [TestCase("abba", "dog cat cat dog", ExpectedResult = true)]
        [TestCase("abba", "dog cat cat fish", ExpectedResult = false)]
        [TestCase("aaaa", "dog cat cat fish", ExpectedResult = false)]
        [TestCase("abba", "dog dog dog dog", ExpectedResult = false)]
        [TestCase("abba", "", ExpectedResult = false)]
        [TestCase("", "dog cat cat dog", ExpectedResult = false)]
        public bool test(string pattern, string s)
        {
            return target.WordPattern(pattern, s);
        }

        [Test]
        [TestCase("abba", "dog cat cat dog", ExpectedResult = true)]
        [TestCase("abba", "dog cat cat fish", ExpectedResult = false)]
        [TestCase("aaaa", "dog cat cat fish", ExpectedResult = false)]
        [TestCase("abba", "dog dog dog dog", ExpectedResult = false)]
        [TestCase("abba", "", ExpectedResult = false)]
        [TestCase("", "dog cat cat dog", ExpectedResult = false)]
        public bool test_V2(string pattern, string s)
        {
            return target.WordPattern_V2(pattern, s);
        }
    }
}
