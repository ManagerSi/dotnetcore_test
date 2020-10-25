using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class find_common_characters_test
    {
        find_common_characters target = new find_common_characters();

        [Test]
        public void test_V2()
        {
            string[] s = new[] { "cool", "lock", "cook" };
            var res = target.CommonChars_V2(s);
            Assert.IsTrue(string.Join(',',res) == "c,o");

            s = new[] { "bella", "label", "roller" };
            res = target.CommonChars_V2(s);
            Assert.IsTrue(string.Join(',', res) == "e,l,l");
        }
    }
}
