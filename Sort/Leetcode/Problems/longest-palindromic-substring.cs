using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 5. 最长回文子串
    /// https://leetcode-cn.com/problems/longest-palindromic-substring/submissions/
    /// </summary>
    public class longest_palindromic_substring
    {
        /// <summary>
        /// 超时了。。。。
        /// 时间复杂度：O(N^3)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length==1) return s;

            string[,] result = new string[s.Length,2];
            string maxPalindrome = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    bool isPalindrome = CheckPalindrome(s, i, j);
                    if (isPalindrome)
                    {
                        result[i,0] = s.Substring(i, j - i+1);
                        if (result[i, 0].Length > maxPalindrome.Length)
                        {
                            maxPalindrome = result[i, 0];
                            result[i, 1] = maxPalindrome;
                        }
                        else
                        {
                            result[i, 1] = maxPalindrome;
                        }

                    }
                }
            }

            return maxPalindrome;
        }

        private bool CheckPalindrome(string s, int left, int right)
        {
            while (left <= right)
            {
                if (s[left] != s[right]) 
                    return false;

                left++;
                right--;
            }

            return true;
        }


        /// <summary>
        /// 优化第一种方案----还是超时
        /// 时间复杂度：O(N^3)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome_V1(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1) return s;

            string maxPalindrome = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i+1; j < s.Length; j++)
                {
                    bool isPalindrome = CheckPalindrome(s, i, j);
                    if (isPalindrome)
                    {
                        if (j - i + 1 > maxPalindrome.Length)
                        {
                            maxPalindrome = s.Substring(i, j - i + 1);
                        }
                    }
                }
            }

            return maxPalindrome.Length == 0 ? s[0].ToString(): maxPalindrome;
        }

        /// <summary>
        /// 动态规划
        /// O(n^2)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome_V2(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1) return s;

            // 特判
            int len = s.Length;
            if (len < 2)
            {
                return s;
            }

            int maxLen = 1;
            int begin = 0;

            // dp[i][j] 表示 s[i, j] 是否是回文串
            bool[,] dp = new bool[len,len];

            for (int i = 0; i < len; i++)
            {
                dp[i,i] = true;
            }

            for (int j = 1; j < len; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (s[i] != s[j])
                    {
                        dp[i,j] = false;
                    }
                    else
                    {
                        if (j - i < 3)
                        {
                            dp[i,j] = true; //单个或相邻2个相同
                        }
                        else
                        {
                            dp[i,j] = dp[i + 1,j - 1]; //dp[i][j] = true 并且(i + 1)和（j - 1)两个位置为相同的字符，此时 true。
                        }
                    }

                    // 只要 dp[i][j] == true 成立，就表示子串 s[i..j] 是回文，此时记录回文长度和起始位置
                    if (dp[i,j] && j - i + 1 > maxLen)
                    {
                        maxLen = j - i + 1;
                        begin = i;
                    }
                }
            }
        
            return s.Substring(begin, maxLen);
        }
    }
}
