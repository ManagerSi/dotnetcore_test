using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 70. 爬楼梯
    /// https://leetcode.cn/problems/climbing-stairs
    /// </summary>
    public class climbing_stairs
    {
        /// <summary>
        /// 动态规划-从头计算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int climbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int a = 1, b = 2, res = 0;
            for (int i = 3; i <= n; i++)
            {
                res = a + b;
                a = b;
                b = res;
            }

            return res;
        }
    }
}
