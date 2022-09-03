using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    public class n_th_tribonacci_number
    {
        /// <summary>
        /// 递归超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            return Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
        }


        /// <summary>
        /// 直接用递归的话会超时，给定的通项公式可以进一步推导 T(n+3) = T(n+2) + T(n+1) +T(n+0)， T(n+4) = T(n+3) + T(n+2) + T(n+1)， 两者相减 T(n+4) - T(n+3) = T(n+3) - T(n)， 所以T(n) = 2T(n-1) - T(n+4)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci_V1(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            if (n == 3) return 2;
            if (n == 4) return 4;
            return 2 * Tribonacci_V1(n - 1) - Tribonacci_V1(n - 4);
        }

        /// <summary>
        /// 动态规划:使用三个变量，从前往后算一遍即可。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci_V2(int n)
        {

            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;

            int a = 0, b = 1, c = 1;
            int res = 0;
            for (int i = 3; i <= n; ++i)
            {
                res = a + b + c;
                a = b;
                b = c;
                c = res;
            }

            return res;
        }
    }
}
