using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 557. 反转字符串中的单词 III
    /// https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/
    /// </summary>
    public class reverse_words_in_a_string_iii
    {
        /// <summary>
        /// use string libary
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            string[] spliteList = s.Trim().Split(" ").Where(i=>!string.IsNullOrEmpty(i)).ToArray();

            for (int i = 0; i < spliteList.Length; i++)
            {
                var s1 = spliteList[i];
                spliteList[i] = string.Join("", s1.Reverse());
            }

            return string.Join(" ", spliteList);
        }


        /// <summary>
        /// use string libary
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords_V2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            string[] spliteList = s.Trim().Split(" ");

            for (int i = 0; i < spliteList.Length; i++)
            {
                var s1 = spliteList[i];
                spliteList[i] = string.Join("", s1.Reverse());
            }

            return string.Join(" ", spliteList);
        }
    }
}
