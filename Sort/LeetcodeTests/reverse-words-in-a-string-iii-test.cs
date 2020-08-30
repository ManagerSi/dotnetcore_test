using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reverse_words_in_a_string_iii_test
    {
        private reverse_words_in_a_string_iii target = new reverse_words_in_a_string_iii();

        [Test]
        public void test()
        {
            string s = "Let's take LeetCode contest";
            var res = target.ReverseWords(s);
            Assert.True(res == "s'teL ekat edoCteeL tsetnoc");

            //s is empty
            s = "";
            res = target.ReverseWords(s);
            Assert.True(res == "");


            //space at start
            s = " sd sa";
            res = target.ReverseWords(s);
            Assert.True(res == "ds as");
        }

        [Test]
        public void test_V3()
        {
            string s = "Let's take LeetCode contest";
            var res = target.ReverseWords_V3(s);
            Assert.True(res == "s'teL ekat edoCteeL tsetnoc");

            //s is empty
            s = "";
            res = target.ReverseWords_V3(s);
            Assert.True(res == "");


            //space at start
            s = " sd sa";
            res = target.ReverseWords_V3(s);
            Assert.True(res == "ds as");
        }
    }
}
