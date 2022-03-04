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
    }
}
