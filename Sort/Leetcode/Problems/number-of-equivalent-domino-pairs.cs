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

        /// <summary>
        /// 注意到二元对中的元素均不大于 99，因此我们可以将每一个二元对拼接成一个两位的正整数，即 (x, y) \to 10x + y(x,y)→10x+y。这样就无需使用哈希表统计元素数量，而直接使用长度为 100100 的数组即可。
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public int NumEquivDominoPairs_V2(int[][] dominoes)
        {
            if (dominoes == null || dominoes.Length == 0) return 0;

            int[] num = new int[100];
            int ret = 0;
            foreach (int[] domino in dominoes)
            {
                int val = domino[0] < domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];
                ret += num[val];
                num[val]++;
            }

            return ret;
        }
    }
}
