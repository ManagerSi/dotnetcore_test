using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 455. 分发饼干
    /// https://leetcode-cn.com/problems/assign-cookies/
    /// </summary>
    public class assign_cookies
    {
        /// <summary>
        /// 使用字典 --- 超时
        /// 
        /// </summary>
        /// <param name="g">children</param>
        /// <param name="s">cookies</param>
        /// <returns></returns>
        public int FindContentChildren(int[] g, int[] s)
        {
            //Dictionary<int,int> gDic = g.GroupBy(i=>i).OrderBy(i=>i.Key).ToDictionary(i=>i.Key,i=>i.Count());
            Dictionary<int, int> sDic = s.GroupBy(i => i).OrderBy(i => i.Key).ToDictionary(i => i.Key, i => i.Count());

            int result = 0;
            foreach (var child in g.OrderBy(i=>i))
            {
                var cook = sDic.FirstOrDefault(i => i.Key >= child && i.Value>0);
                if (cook.Value == 0)
                    break;

                result++;
                sDic[cook.Key]--;
            }

            return result;
        }

        public int FindContentChildren_V2(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int numOfChildren = g.Length, numOfCookies = s.Length;
            int count = 0;
            for (int i = 0, j = 0; i < numOfChildren && j < numOfCookies; i++, j++)
            {
                while (j < numOfCookies && g[i] > s[j])
                {
                    j++;
                }
                if (j < numOfCookies)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
