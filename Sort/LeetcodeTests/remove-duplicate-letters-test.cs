using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class remove_duplicate_letters_test
    {
        remove_duplicate_letters target = new remove_duplicate_letters();

        [Test]
        [TestCase("bcabc", ExpectedResult = "abc")]
        [TestCase("cbacdcbc", ExpectedResult = "acdb")]
        public string test(string s)
        {
            return target.RemoveDuplicateLetters(s);
        }
    }
}
