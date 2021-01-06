using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 399. 除法求值
    /// https://leetcode-cn.com/problems/evaluate-division/
    /// </summary>
    public class evaluate_division
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            double[] res = new double[queries.Count];
            Dictionary<string, double> dict = new Dictionary<string, double>();
            HashSet<string> set = new HashSet<string>();
            // 根据 equations 和 values 构建初始字典. 由 a / b = 2 可知 b / a = 1 / 2 顺带一起加进去
            // 加逗号是为了应对给的例子是 ["a", "aa"] 这种情况，用于区分 "a, aa" 和 "aa, a"
            for (int i = 0; i < values.Length; i++)
            {
                dict[equations[i][0] + ", " + equations[i][1]] = values[i];
                dict[equations[i][1] + ", " + equations[i][0]] = 1 / values[i];
                set.Add(equations[i][0]);
                set.Add(equations[i][1]);
            }
            // Floyd算法, 简单来说就是根据 a / b = 2, b / c = 3 来求 a / c = 6 的过程
            foreach (var k in set)
            {
                foreach (var i in set)
                {
                    foreach (var j in set)
                    {
                        if (dict.ContainsKey(i + ", " + k) && dict.ContainsKey(k + ", " + j))
                        {
                            dict[i + ", " + j] = dict[i + ", " + k] * dict[k + ", " + j];
                        }
                    }
                }
            }
            // 在字典中查找要求的结果
            for (int i = 0; i < queries.Count; i++)
            {
                res[i] = dict.ContainsKey(queries[i][0] + ", " + queries[i][1])
                    ? dict[queries[i][0] + ", " + queries[i][1]]
                    : -1;
            }
            return res;
        }

    }
}
