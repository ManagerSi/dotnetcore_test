using Leetcode.Extend;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeTests
{
    class positions_of_large_groups_test
    {
        positions_of_large_groups target = new positions_of_large_groups();

        [Test]
        [TestCase("abbxxxx", ExpectedResult = "3,6")]
        [TestCase("abbxxxxzzy", ExpectedResult ="3,6")]
        [TestCase("aaa", ExpectedResult = "0,2")]
        [TestCase("abc", ExpectedResult = "")]
        [TestCase("", ExpectedResult = "")]
        [TestCase("abcdddeeeeaabbbcd", ExpectedResult = "3,5,6,9,12,14")]
        public string test(string s)
        {
            var res = target.LargeGroupPositions(s);
            return string.Join(',', res.Select(i=> ListExtent.ToString(i)));
        }
    }
}
