using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class letter_combinations_of_a_phone_number_test
    {
        letter_combinations_of_a_phone_number target = new letter_combinations_of_a_phone_number();

        [Test]
        public void test()
        {
            var numbs = "23";
            var res = target.LetterCombinations(numbs);
            Assert.True(res.Count==9);
        }
    }
}
