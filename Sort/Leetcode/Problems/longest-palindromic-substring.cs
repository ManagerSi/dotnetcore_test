using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 5. 最长回文子串
    /// https://leetcode-cn.com/problems/longest-palindromic-substring/
    /// </summary>
    public class longest_palindromic_substring
    {
        /// <summary>
        /// DP 动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public String LongestPalindrome(String s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n,n];
            String ans = "";
            for (int l = 0; l < n; ++l)
            {
                for (int i = 0; i + l < n; ++i)
                {
                    int j = i + l;
                    if (l == 0)
                    {
                        dp[i,j] = true;
                    }
                    else if (l == 1)
                    {
                        dp[i,j] = (s[i] == s[j]);
                    }
                    else
                    {
                        dp[i,j] = (s[i] == s[j] && dp[i + 1, j - 1]);
                    }
                    if (dp[i,j] && l + 1 > ans.Length)
                    {
                        ans = s.Substring(i, i + l + 1);
                    }
                }
            }
            return ans;
        }

    }
}
