using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 830. 较大分组的位置
    /// https://leetcode-cn.com/problems/positions-of-large-groups/
    /// </summary>
    public class positions_of_large_groups
    {
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            var result = new List<IList<int>>();
            if (s == null || s.Length < 3) return result;

            int startIndex = 0;
            char preChar = '0';
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] != preChar)
                {
                    if(i-1-startIndex >= 2)
                    {
                        result.Add(new List<int> { startIndex, i-1 });
                    }
                    startIndex = i;
                    preChar = s[i];
                }
            }

            if (s[s.Length-1] == preChar && s.Length - 1 - startIndex >= 2)
            {
                result.Add(new List<int> { startIndex, s.Length - 1 });
            }

            return result;
        }
    }
}
