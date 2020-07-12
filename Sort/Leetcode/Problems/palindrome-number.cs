using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 9. 回文数
    /// https://leetcode-cn.com/problems/palindrome-number/
    /// </summary>
    public class palindrome_number
    {
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool isPalindrome(int x)
        {
            if (x == 0) return true;

            //负数不是 / 以0结尾的不是
            if (x < 0 || x % 10 == 0)
                return false;

            string str = x.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 直观上来看待回文数的话，就感觉像是将数字进行对折后看能否一一对应。
        /// 所以这个解法的操作就是 取出后半段数字进行翻转。
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool isPalindrome_V2(int x)
        {
            if (x == 0) return true;

            //负数不是 / 以0结尾的不是
            if (x < 0 || x % 10 == 0)
                return false;


            int xRevers = 0;
            while (xRevers < x)
            {
                xRevers = xRevers* 10 + x % 10;
                if (xRevers >=x)
                {
                    break;
                }
                x = x / 10;
            }

            return xRevers == x;
        }
    }
}
