using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    class longest_common_prefix_test
    {
        [Test]
        public void MyTest()
        {
            var tClass = new longest_common_prefix();

            var strs = new string[] { "flower", "flow", "flight" };
            var res = tClass.LongestCommonPrefix(strs);
            Assert.IsTrue(res == "fl");

            strs = new string[] { "dog", "racecar", "car" };
            res = tClass.LongestCommonPrefix(strs);
            Assert.IsTrue(res == "");
        }
    }
}
