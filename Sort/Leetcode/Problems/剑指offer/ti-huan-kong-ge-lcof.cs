using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 05. 替换空格
    /// https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/comments/
    /// </summary>
    public class ti_huan_kong_ge_lcof
    {
        public string ReplaceSpace(string s)
        {
            return s.Replace(" ", "%20");
        }

        public string ReplaceSpace_V2(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == ' ')
                    sb.Append("%20");
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
