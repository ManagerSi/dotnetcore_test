using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 767. 重构字符串
    /// https://leetcode-cn.com/problems/reorganize-string/
    /// </summary>
    public class reorganize_string
    {
        /// <summary>
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string ReorganizeString(string S)
        {
            if (string.IsNullOrWhiteSpace(S)) return string.Empty;
            
            //统计个数
            Dictionary<char,int> dic = new Dictionary<char, int>();
            int maxCout = 0;
            int maxChar;
            for (int i = 0; i < S.Length; i++)
            {
                if (dic.ContainsKey(S[i]))
                    dic[S[i]] += 1;
                else
                    dic.Add(S[i],1);

                if (dic[S[i]] > maxCout)
                {
                    maxCout = dic[S[i]];
                    maxChar = S[i];
                }
            }

            if (S.Length %2 ==0 && maxCout > S.Length / 2 //偶数
                || S.Length % 2 == 1 && maxCout > S.Length / 2 + 1)  //奇数
                return string.Empty;

            int ind = 0;
            char[] res = new char[S.Length];
            foreach (var keyValuePair in dic.OrderByDescending(i=>i.Value))
            {
                int count = keyValuePair.Value;
                while (count != 0)
                {
                    res[ind] = keyValuePair.Key;
                    ind = ind + 2;
                    if (ind >= S.Length)
                        ind = 1;

                    count -= 1;
                }
            }

            return string.Join("", res);
        }
    }
}
