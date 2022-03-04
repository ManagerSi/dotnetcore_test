using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 258. 各位相加
    /// https://leetcode-cn.com/problems/add-digits/
    /// </summary>
    public class add_digits
    {
        /// <summary>
        /// 暴力破解
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits(int num)
        {
            if (num < 10) return num;

            var temp = num;
            while (temp >= 10)
            {
                num = temp;
                temp = 0;

                while (num > 0)
                {
                    temp += num % 10;
                    num = num / 10;
                }
            }

            return temp;
        }

        /// <summary>
        ///  X = 100*a + 10*b + c = 99*a + 9*b + (a+b+c)；所以对9取余即可。
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits_V2(int num)
        {
            return (num - 1) % 9 + 1;
        }

        /// <summary>
        /// 暴力破解 - 递归
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits_V3(int num)
        {
            if (num < 10) return num;

            var temp = 0;
            while (num > 0)
            {
                temp += num % 10;
                num = num / 10;
            }

            return AddDigits_V3(temp);
        }
    }
}
