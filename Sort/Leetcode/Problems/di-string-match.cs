using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 942. 增减字符串匹配
    /// https://leetcode.cn/problems/di-string-match/
    /// </summary>
    public class di_string_match
    {
        /// <summary>
        /// 贪心法
        /// 要求生成的是排列，意味着0到S.size()范围内的每个数只能出现一次，也就是说是一个消耗性选择的过程。当我们需要决定一个位置的数字时，根据的信息是“当前位置和下一个位置的数字大小关系”。如果要求是递增的，那么只要确保当前选择的是剩余可选范围内最小的那个，那么下一个位置上，在剩余的数字中不管选哪个都能保证比当前位置的更大。递减同理。所以需要维护一个“剩余可选的数字范围”，每次要么从中取出最小的那个，要么取出最大的那个，所以只需要记录这个范围的最小值和最大值即可。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] DiStringMatch(string s)
        {
            List<int> result = new List<int>();
            int min = 0; int max = s.Length;
            foreach (char c in s)
            {
                if (c == 'I')
                    result.Add(min++);
                else
                    result.Add(max--);
            }
            result.Add(min);

            return result.ToArray();
        }
    }
}
