using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1128. 等价多米诺骨牌对的数量
    /// https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/
    /// </summary>
    public class number_of_equivalent_domino_pairs
    {
        /// <summary>
        /// 转为字符串
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            if (dominoes == null || dominoes.Length == 0) return 0;

            List<string> strList = new List<string>(dominoes.Length);
            foreach (var domino in dominoes)
            {
                strList.Add(domino[0] > domino[1] ? $"{domino[1]},{domino[0]}" : $"{domino[0]},{domino[1]}");
            }
            //2个一样->return 1, (n-1)+(n-2)+...+2+1 => n*(n-1)/2
            //3个一样->return 3,
            //4个一样->return 6,
            //5个一样->return 10,
            return strList.GroupBy(i => i).Sum(i => i.Count() * (i.Count() - 1) / 2);

        }
    }
}
