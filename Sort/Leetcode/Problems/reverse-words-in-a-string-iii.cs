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
        /// use my reverse
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords_V2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            string[] spliteList = s.Trim().Split(" ").Where(i => !string.IsNullOrEmpty(i)).ToArray();
            for (int i = 0; i < spliteList.Length; i++)
            {
                var s1 = spliteList[i];
                spliteList[i] = reverse(s1);
            }

            return string.Join(" ", spliteList);
        }

        private string reverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }


        /// <summary>
        /// 手动reverse
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords_V3(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return String.Empty;
            }

            var res = new StringBuilder();

            var word = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (word.Length > 0)
                    {
                        if(res.Length>0)
                            res.Append(' ');

                        for (int j = word.Length-1; j >=0 ; j--)
                        {
                            res.Append(word[j]);
                        }
                    }

                    word.Clear();
                    continue;
                }

                word.Append(s[i]);
            }

            if (word.Length > 0)
            {
                if (res.Length > 0)
                    res.Append(' ');

                for (int j = word.Length - 1; j >= 0; j--)
                {
                    res.Append(word[j]);
                }
            }

            return res.ToString();
        }




    }
}
