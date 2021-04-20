using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 28. 实现 strStr()
    /// </summary>
    public class implement_strstr
    {
        /// <summary>
        /// 使用内置函数
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            return haystack.IndexOf(needle, StringComparison.Ordinal);
        }

        /// <summary>
        /// 暴力匹配
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr_V1(string haystack, string needle)
        {
            var hLength = haystack.Length;
            var nLength = needle.Length;

            if (nLength == 0) return 0;

            for (int i = 0; i <= hLength-nLength; i++)
            {
                var hIndex = i;
                var nIndex = 0;
                while (nIndex < nLength && haystack[hIndex] == needle[nIndex])
                {
                    hIndex++;
                    nIndex++;
                }

                if (nIndex == nLength) return i;

            }

            return -1;
        }

        /// <summary>
        /// KMP
        /// </summary>
        /// <param name="ss"></param>
        /// <param name="pp"></param>
        /// <returns></returns>
        public int StrStr_V2(string ss, string pp)
        {
            if (pp.Length==0) return 0;

            // 分别读取原串和匹配串的长度
            int n = ss.Length, m = pp.Length;
            // 原串和匹配串前面都加空格，使其下标从 1 开始
            ss = " " + ss;
            pp = " " + pp;

            // 构建 next 数组，数组长度为匹配串的长度（next 数组是和匹配串相关的）
            int[] next = new int[m + 1];
            // 构造过程 i = 2，j = 0 开始，i 小于等于匹配串长度 【构造 i 从 2 开始】
            for (int i = 2, j = 0; i <= m; i++)
            {
                // 匹配不成功的话，j = next(j)
                while (j > 0 && pp[i] != pp[j + 1]) j = next[j];
                // 匹配成功的话，先让 j++
                if (pp[i] == pp[j + 1]) j++;
                // 更新 next[i]，结束本次循环，i++
                next[i] = j;
            }

            // 匹配过程，i = 1，j = 0 开始，i 小于等于原串长度 【匹配 i 从 1 开始】
            for (int i = 1, j = 0; i <= n; i++)
            {
                // 匹配不成功 j = next(j)
                while (j > 0 && ss[i] != pp[j + 1]) j = next[j];
                // 匹配成功的话，先让 j++，结束本次循环后 i++
                if (ss[i] == pp[j + 1]) j++;
                // 整一段匹配成功，直接返回下标
                if (j == m) return i - m;
            }

            return -1;
        }
    }
}
