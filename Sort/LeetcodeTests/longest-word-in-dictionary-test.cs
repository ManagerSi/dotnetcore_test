using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class longest_word_in_dictionary_test
    {
        private longest_word_in_dictionary target = new longest_word_in_dictionary();

        protected static IEnumerable<TestCaseData> GetStringses()
        {
            yield return new TestCaseData(new List<string> { "w", "wo", "wor", "worl", "world" }).Returns("world");
            yield return new TestCaseData(new List<string> { "w", "wo", "woa", "wor", "worl", "world" }).Returns("world");
            yield return new TestCaseData(new List<string> { "a", "banana", "app", "appl", "ap", "apply", "apple" }).Returns("apple");

        }

        [Test]
        [TestCaseSource("GetStringses")]
        public string test(List<string> words)
        {

            return target.LongestWord(words.ToArray());
        }
    }
}
