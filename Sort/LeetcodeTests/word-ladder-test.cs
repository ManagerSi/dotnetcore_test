using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class word_ladder_test
    {
        word_ladder target = new word_ladder();

        [Test]
        public void test()
        {
            string beginWord = "hit";
            string endWord = "cog";
            List<string> wordList = new List<string> {"hot", "dot", "dog", "lot", "log", "cog"};
            var res = target.LadderLength(beginWord, endWord, wordList);
            Assert.IsTrue(res == 5);


            wordList = new List<string> { "hot", "dot", "dog", "lot", "log", };
            res = target.LadderLength(beginWord, endWord, wordList);
            Assert.IsTrue(res == 0);
        }
    }
}
