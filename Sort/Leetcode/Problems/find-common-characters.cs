using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1002. 查找常用字符
    /// https://leetcode-cn.com/problems/find-common-characters/
    /// </summary>
    public class find_common_characters
    {
        public IList<string> CommonChars_V2(string[] A)
        {
            Dictionary<char, int> dict = A[0].ToHashSet().ToDictionary(i => (char)i, value => A[0].Length);

            List<char> charList = new List<char>(dict.Keys);
            for (int i = 0; i < dict.Count; i++)
            {
                foreach (var word in A)
                {
                    var count = word.Count(w => w == charList[i]);
                    dict[charList[i]] = Math.Min(dict[charList[i]], count);
                }
            }

            IList<string> res = new List<string>();
            foreach (var item in dict.Where(i=>i.Value>0))
            {
                for (int i = 0; i < item.Value; i++)
                {
                    res.Add(item.Key.ToString());
                }
            }

            return res;
        }
    }
}
