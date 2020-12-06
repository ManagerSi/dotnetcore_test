using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 204. 计数质数
    /// https://leetcode-cn.com/problems/count-primes/
    /// </summary>
    class count_primes
    {
        /// <summary>
        /// 定义统计，超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (IsPrimes(i))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// 定义判断
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPrimes(int n)
        {
            double max = Math.Sqrt(n);
            for (double i = 2; i <= max; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// 埃氏筛
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes_V2(int n)
        {
            bool[] isPrim = new bool[n];
            Array.Fill(isPrim, true);

            // 从 2 开始枚举到 sqrt(n)。
            for (int i = 2; i * i < n; i++)
            {
                // 如果当前是素数
                if (isPrim[i])
                {
                    // 就把从 i*i 开始，i 的所有倍数都设置为 false。
                    for (int j = i * i; j < n; j += i)
                    {
                        isPrim[j] = false;
                    }
                }
            }

            // 计数
            int cnt = 0;
            for (int i = 2; i < n; i++)
            {
                if (isPrim[i])
                {
                    cnt++;
                }
            }
            return cnt;
        }

    }
}
