using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reorganize_string_test
    {
        reorganize_string target =new reorganize_string();

        [Test]
        [TestCase("abbabbaaab", ExpectedResult = "ababababab")]
        [TestCase("vvvlo", ExpectedResult = "vlvov")]
        [TestCase("aab", ExpectedResult = "aba")]
        [TestCase("a", ExpectedResult = "a")]
        public string test(string s)
        {
            return target.ReorganizeString(s);
        }
    }
}
