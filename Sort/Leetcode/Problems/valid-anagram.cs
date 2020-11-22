using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 242. 有效的字母异位词
    /// https://leetcode-cn.com/problems/valid-anagram/
    /// </summary>
    public class valid_anagram
    {
        /// <summary>
        /// 函数--统计次数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Equals(t)) return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return false;
            if (s.Length != t.Length) return false;

            var scharDic = s.ToCharArray().GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());
            var tcharDic = t.ToCharArray().GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());

            foreach (var sChar in scharDic)
            {
                if (!tcharDic.ContainsKey(sChar.Key) || tcharDic[sChar.Key] != sChar.Value)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 统计次数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram_V2(string s, string t)
        {
            if (s==null && t==null || s.Length==0 && t.Length==0) return true;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return false;
            if (s.Length != t.Length) return false;

            Dictionary<char,int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (var c in t)
            {
                if (!dic.ContainsKey(c)) return false;
                dic[c]--;
            }

            foreach (var d in dic)
            {
                if (d.Value != 0) return false;
            }

            return true;
        }

        /// <summary>
        /// 其他人代码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram_good(string s, string t)
        {
            var dicS = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            foreach (var c in t)
            {
                if (!dicS.ContainsKey(c)) return false;
                if (--dicS[c] == 0) dicS.Remove(c);
            }

            return dicS.Count == 0;
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram_V3(string s, string t)
        {
            if (s == null && t == null || s.Length == 0 && t.Length == 0) return true;
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return false;
            if (s.Length != t.Length) return false;

            char[] s1 = s.ToCharArray();
            char[] t1 = t.ToCharArray();
            Array.Sort(s1);
            Array.Sort(t1);

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != t1[i])
                    return false;
            }

            return true;
        }
    }
}
