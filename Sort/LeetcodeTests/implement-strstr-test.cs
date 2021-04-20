using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class implement_strstr_test
    {
        implement_strstr target = new implement_strstr();

        [Test]
        [TestCase("a", "a", ExpectedResult = 0)]
        [TestCase("hello","ll",ExpectedResult = 2)]
        [TestCase("hello", "", ExpectedResult = 0)]
        [TestCase("aaaaa", "abc", ExpectedResult = -1)]
        [TestCase("", "", ExpectedResult = 0)]
        public int test(string a,string b)
        {
            return target.StrStr(a, b);
        }

        [Test]
        [TestCase("a", "a", ExpectedResult = 0)]
        [TestCase("hello", "ll", ExpectedResult = 2)]
        [TestCase("hello", "", ExpectedResult = 0)]
        [TestCase("aaaaa", "abc", ExpectedResult = -1)]
        [TestCase("", "", ExpectedResult = 0)]
        [TestCase("mississippi", "issip", ExpectedResult = 4)]
        public int test_V1(string a, string b)
        {
            return target.StrStr_V1(a, b);
        }

        [Test]
        [TestCase("a", "a", ExpectedResult = 0)]
        [TestCase("hello", "ll", ExpectedResult = 2)]
        [TestCase("hello", "", ExpectedResult = 0)]
        [TestCase("aaaaa", "abc", ExpectedResult = -1)]
        [TestCase("", "", ExpectedResult = 0)]
        [TestCase("mississippi", "issip", ExpectedResult = 4)]
        public int test_V2(string a, string b)
        {
            return target.StrStr_V2(a, b);
        }
    }
}
