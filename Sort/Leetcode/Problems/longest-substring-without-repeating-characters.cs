using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 3. 无重复字符的最长子串
    /// https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    public class longest_substring_without_repeating_characters
    {
        /// <summary>
        /// 双循环
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int maxLength = 0;
            //List<string> subStrList = new List<string>();
            List<char> sb = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                //初始
                sb.Add(s[i]);

                for (int j = i+1; j < s.Length; j++)
                {
                    //判断
                    if (s[i] == s[j] || sb.Contains(s[j]))
                    {
                        break;
                    }

                    sb.Add(s[j]);
                }

                //结束
                //subStrList.Add(string.Join("",sb));
                //设置长度
                if (sb.Count > maxLength) maxLength = sb.Count;
                //清空
                sb.Clear();
            }

            return maxLength;
        }


        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring_V2(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            // 哈希集合，记录每个字符是否出现过
            HashSet<char> occ = new HashSet<char>();
            int n = s.Length;
            var result = 0;

            // 右指针，初始值为 -1，相当于我们在字符串的左边界的左侧，还没有开始移动
            int rk = -1;
            for (int i = 0; i < n; ++i)
            {
                if (i != 0)
                {
                    // 左指针向右移动一格，移除一个字符
                    occ.Remove(s[i - 1]);
                }

                //滑动窗口
                while (rk + 1 < n && !occ.Contains(s[rk + 1]))
                {
                    // 不断地移动右指针
                    occ.Add(s[rk + 1]);
                    ++rk;
                }
                // 第 i 到 rk 个字符是一个极长的无重复字符子串
                result = Math.Max(result, rk - i + 1);
            }
            return result;

        }


        /// <summary>
        /// 滑动窗口  v2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring_V3(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int maxLength = 0;
            Dictionary<char, int> dic= new Dictionary<char, int>();

            int leftIndex = 0;
            for (int rightIndex = 0; rightIndex < s.Length; rightIndex++)
            {
                if (dic.ContainsKey(s[rightIndex]))
                {
                    leftIndex = Math.Max(leftIndex, dic[s[rightIndex]] + 1);

                    dic[s[rightIndex]] = rightIndex;
                }
                else
                {
                    dic.Add(s[rightIndex], rightIndex);
                }

                //设置长度
                maxLength = Math.Max(maxLength, rightIndex - leftIndex + 1);
            }

            return maxLength;
        }
    }
}
