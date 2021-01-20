using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1018. 可被 5 整除的二进制前缀
    /// https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/
    /// </summary>
    public class binary_prefix_divisible_by_5
    {
        /// <summary>
        /// 数字太长导致溢出
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5(int[] A)
        {
            var result = new List<bool>();
            if (A == null || A.Length == 0) return result;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < A.Length; i++)
            {
                sb.Append(A[i]);
                var str = sb.ToString();
                var numb = Convert.ToUInt64(str, 2);

                if (numb % 5 == 0)
                    result.Add(true);
                else
                    result.Add(false);
            }

            return result;
        }

        /// <summary>
        /// 数字太长导致溢出
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_V2(int[] A)
        {
            var result = new List<bool>();
            if (A == null || A.Length == 0) return result;

            UInt64 num = 0;
            for (int i = 0; i < A.Length; i++)
            {
                num = num << 1; //左移相当于 *2
                num += (UInt64)A[i];

                result.Add(num % 5 == 0);
            }

            return result;
        }

        /// <summary>
        /// 解决本题的关键思路在于最后一位是不是0或5的问题，
        /// 那么每次操作只需要保留最后一项即可，每次读取新的一位就乘2，相当于二进制的进位，
        /// 然后把个位与5取余是否等于0的结果放入到已经设定的数组中
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_V3(int[] A)
        {
            var result = new List<bool>();
            if (A == null || A.Length == 0) return result;

            int num = 0;
            for (int i = 0; i < A.Length; i++)
            {
                num = (num << 1) + A[i]; //左移相当于 *2
                num %= 10;

                result.Add(num % 5 == 0);
            }

            return result;
        }
    }
}
