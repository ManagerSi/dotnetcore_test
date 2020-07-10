using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 7. 整数反转
    /// https://leetcode-cn.com/problems/reverse-integer/
    /// </summary>
    public class reverse_integer
    {
        /// <summary>
        /// 转化为字符串反转
        /// 
        /// 52 ms	15 MB
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            string xStr = x.ToString();
            string targetStr = string.Empty;
            for (int i = xStr.Length-1; i >= 0; i--)
            {
                targetStr += xStr[i];
            }
            if (x < 0)
                targetStr = "-" + targetStr.Substring(0,targetStr.Length-1);

            if (int.TryParse(targetStr, out var tartet))
            {
                return tartet;
            }
            return 0;
        }


        /// <summary>
        /// 转化为字符串反转
        /// 使用stringbuilder优化，没用
        /// 
        /// 执行用时：48 ms, 在所有 C# 提交中击败了82.68%的用户
        /// 内存消耗：14.9 MB, 在所有 C# 提交中击败了11.11%的用户
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse_V2(int x)
        {
            string xStr = x.ToString();
            StringBuilder targetStr = new StringBuilder();
            int endIndex = 0;
            if (x < 0)
            {
                endIndex = 1;
                targetStr.Append('-');
            }

            for (int i = xStr.Length - 1; i >= endIndex; i--)
            {
                targetStr.Append(xStr[i]);
            }

            if (int.TryParse(targetStr.ToString(), out var tartet))
            {
                return tartet;
            }
            return 0;
        }


        /// <summary>
        /// 用数学公式
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse_V3(int x)
        {
            var target = 0;
            while (x != 0)
            {
                var t = x % 10; //尾数

                //判断超出界限
                if (t>0 && target > (int.MaxValue - t) / 10)
                    return 0;
                if (t < 0 && target < (int.MinValue - t) / 10)
                    return 0;
                target = target * 10 + t;
                x = x / 10;
            }
            return target;
        }



        /// <summary>
        /// 用数学公式
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse_V4(int x)
        {
            int sum = 0;
            int i = 0;
            if (x == 0) return x;
            else if (x > 0)
            {
                while (x / 10 != 0)
                {
                    int a = x % 10;
                    int b = x / 10;
                    for (i = 0; b != 0; i++)
                    {
                        b = b / 10;
                    }
                    sum += a * (int)Math.Pow(10, i);
                    if (sum > int.MaxValue - 1 || sum < 0) return 0;
                    x /= 10;
                }
                if (sum > int.MaxValue - 1 - x) return 0;
                return sum + x;
            }
            else
            {
                while (x / 10 != 0)
                {
                    int a = x % 10;
                    int b = x / 10;
                    for (i = 0; b != 0; i++)
                    {
                        b = b / 10;
                    }
                    sum += a * (int)Math.Pow(10, i);
                    if (sum < int.MinValue) return 0;
                    x /= 10;
                }
                if (sum < int.MinValue - x) return 0;
                return sum + x;
            }
        }


    }
}
