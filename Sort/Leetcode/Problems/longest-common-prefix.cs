using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 14. 最长公共前缀
    /// https://leetcode-cn.com/problems/longest-common-prefix/
    /// </summary>
    public class longest_common_prefix
    {
        /// <summary>
        /// 方法一：横向扫描
        /// 依次遍历字符串数组中的每个字符串，对于每个遍历到的字符串，更新最长公共前缀，当遍历完所有的字符串以后，即可得到字符串数组中的最长公共前缀。
        /// 时间复杂度：O(mn)O(mn)，其中 mm 是字符串数组中的字符串的平均长度，nn 是字符串的数量。最坏情况下，字符串数组中的每个字符串的每个字符都会被比较一次。
        /// 空间复杂度：O(1)O(1)。使用的额外空间复杂度为常数。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public String LongestCommonPrefix(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            String prefix = strs[0];
            int count = strs.Length;
            for (int i = 1; i < count; i++)
            {
                prefix = longestCommonPrefix(prefix, strs[i]);
                if (prefix.Length == 0)
                {
                    break;
                }
            }
            return prefix;
        }

        private String longestCommonPrefix(String str1, String str2)
        {
            int Length = Math.Min(str1.Length, str2.Length);
            int index = 0;
            while (index < Length && str1[index] == str2[index])
            {
                index++;
            }
            return str1.Substring(0, index);
        }
    }
}
