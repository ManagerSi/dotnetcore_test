using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 190. 颠倒二进制位
    /// https://leetcode-cn.com/problems/reverse-bits/
    /// </summary>
    public class reverse_bits
    {
        /// <summary>
        /// 方法一：逐位颠倒
        /// 思路
        /// 将 nn 视作一个长为 3232 的二进制串，从低位往高位枚举 nn 的每一位，将其倒序添加到翻转结果 \textit{rev}rev 中。 
        /// 代码实现中，每枚举一位就将 nn 右移一位，这样当前 nn 的最低位就是我们要枚举的比特位。当 nn 为 00 时即可结束循环。 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint ReverseBits(uint n)
        {
            uint rev = 0;
            for (int i = 0; i < 32 && n != 0; ++i)
            {
                rev |= (n & 1) << (31 - i);
                n >>= 1;
            }
            return rev;
        }



        private static readonly uint M1 = 0x55555555; // 01010101010101010101010101010101
        private static readonly uint M2 = 0x33333333; // 00110011001100110011001100110011
        private static readonly uint M4 = 0x0f0f0f0f; // 00001111000011110000111100001111
        private static readonly uint M8 = 0x00ff00ff; // 00000000111111110000000011111111
        /// <summary>
        /// 方法二：位运算分治
        /// 思路
        /// 若要翻转一个二进制串，可以将其均分成左右两部分，对每部分递归执行翻转操作，然后将左半部分拼在右半部分的后面，即完成了翻转。
        /// 由于左右两部分的计算方式是相似的，利用位掩码和位移运算，我们可以自底向上地完成这一分治流程。
        ///  
        /// 对于递归的最底层，我们需要交换所有奇偶位：
        ///     取出所有奇数位和偶数位；
        ///     将奇数位移到偶数位上，偶数位移到奇数位上。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint ReverseBits_V2(uint n)
        {
            n = n >> 1 & M1 | (n & M1) << 1;
            n = n >> 2 & M2 | (n & M2) << 2;
            n = n >> 4 & M4 | (n & M4) << 4;
            n = n >> 8 & M8 | (n & M8) << 8;
            return n >> 16 | n << 16;
        }
    }
}
