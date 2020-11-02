using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class word_break_ii_test
    {
        word_break_ii target = new word_break_ii();

        [Test]
        public void test()
        {
            string s = "catsanddog";
            var wordDict = new List<string>{"cat", "cats", "and", "sand", "dog"};
            var res = target.WordBreak(s, wordDict);
            Assert.True(res.Count==2);
            Assert.True(res.Contains("cats and dog"));
            Assert.True(res.Contains("cat sand dog"));

            s = "pineapplepenapple";
             wordDict = new List<string> { "apple", "pen", "applepen", "pine", "pineapple" };
             res = target.WordBreak(s, wordDict);
            Assert.True(res.Count == 3);
            Assert.True(res.Contains("pine apple pen apple"));
            Assert.True(res.Contains("pineapple pen apple"));
            Assert.True(res.Contains("pine applepen apple"));

            s = "catsandog";
            wordDict = new List<string> { "cats", "dog", "sand", "and", "cat" };
            res = target.WordBreak(s, wordDict);
            Assert.True(res.Count == 0);
        }
    }
}
