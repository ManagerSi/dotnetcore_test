using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 263. 丑数
    /// https://leetcode-cn.com/problems/ugly-number/
    /// </summary>
    public class ugly_number
    {
        public bool IsUgly(int n)
        {
            if (n <= 0) return false;

            int res = n;
            while (res != 0)
            {
                if (res % 2 == 0) { res = res / 2; continue; }
                if (res % 3 == 0) { res = res / 3; continue; }
                if (res % 5 == 0) { res = res / 5; continue; }

                return res == 1;
            }

            return res == 1;
        }

        public bool IsUgly_V2(int n)
        {
            if (n < 1)
            {
                return false;
            }
            while (n % 2 == 0)
            {
                // n /= 2;
                // 位运算更省内存
                n >>= 1;
            }
            while (n % 3 == 0)
            {
                n /= 3;
            }
            while (n % 5 == 0)
            {
                n /= 5;
            }

            return n == 1;
        }
    }
}
