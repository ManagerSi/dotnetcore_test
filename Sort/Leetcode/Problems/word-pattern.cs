using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 290. 单词规律
    /// https://leetcode-cn.com/problems/word-pattern/
    /// </summary>
    public class word_pattern
    {
        public bool WordPattern(string pattern, string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(pattern)) return false;

            var sValues = s.Split(" ");
            if (sValues.Length != pattern.Length) return false;

            Dictionary<char, string> dic = new Dictionary<char, string>();
            dic.Add(pattern[0], sValues[0]);
            for (int i = 1; i < sValues.Length; i++)
            {
                if (dic.ContainsKey(pattern[i]))
                {
                    if (!dic[pattern[i]].Equals(sValues[i]))
                        return false;
                }
                else if (dic.Values.Contains(sValues[i]))
                    return false;
                else
                    dic.Add(pattern[i], sValues[i]);
            }

            return true;
        }

        public bool WordPattern_V2(string pattern, string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(pattern)) return false;

            var sValues = s.Split(" ");
            if (sValues.Length != pattern.Length) return false;

            Dictionary<char, string> dic = new Dictionary<char, string>();
            HashSet<string> set = new HashSet<string>();
            dic.Add(pattern[0], sValues[0]);
            set.Add(sValues[0]);
            for (int i = 1; i < sValues.Length; i++)
            {
                if (dic.ContainsKey(pattern[i]))
                {
                    if (!dic[pattern[i]].Equals(sValues[i]))
                        return false;
                }
                else if (set.Contains(sValues[i]))
                    return false;
                else
                {
                    dic.Add(pattern[i], sValues[i]);
                    set.Add(sValues[i]);
                }

            }

            return true;
        }
    }
}
