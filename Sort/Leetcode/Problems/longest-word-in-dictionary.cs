using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 720. 词典中最长的单词
    /// https://leetcode-cn.com/problems/longest-word-in-dictionary/
    /// </summary>
    public class longest_word_in_dictionary
    {
        /// <summary>
        /// 排序
        /// 哈希字典
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string LongestWord(string[] words)
        {
            Array.Sort(words, Comparison);

            string resultWord = string.Empty;
            HashSet<string> set = new HashSet<string>();

            set.Add("");
            foreach (var word in words)
            {
                if (set.Contains(word.Substring(0, word.Length - 1)))
                {
                    resultWord = word;
                    set.Add(word);
                }
            }

            return resultWord;
        }

        /// <summary>
        /// 1 按单词长短排序
        /// 2 按字母倒叙排序
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Comparison(string x, string y)
        {
            if (x.Length > y.Length)
                return 1;
            if (x.Length < y.Length)
                return -1;
            for (int q = 0; q < x.Length; q++)
            {
                if (x[q] < y[q])
                    return 1;
                if (x[q] > y[q])
                    return -1;
            }

            return 0;
        }
    }
}
