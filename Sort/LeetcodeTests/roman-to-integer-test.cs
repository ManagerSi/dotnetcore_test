using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class roman_to_integer_test
    {
        [Test]
        public void test()
        {
            var target = new roman_to_integer();

            var s = "III";
            var res = target.RomanToInt(s);
            Assert.True(res == 3);

            s = "IV";
            res = target.RomanToInt(s);
            Assert.True(res == 4);


            s = "IX";
            res = target.RomanToInt(s);
            Assert.True(res == 9);

            s = "LVIII";
            res = target.RomanToInt(s);
            Assert.True(res == 58);

            s = "MCMXCIV";
            res = target.RomanToInt(s);
            Assert.True(res == 1994);
        }
    }
}
