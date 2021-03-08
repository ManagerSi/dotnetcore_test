using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 231. 2的幂
    /// </summary>
    public class power_of_two
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            switch (n)
            {
                case 1:
                case 2:
                case 4:
                case 8:
                case 16:
                case 32:
                case 64:
                case 128:
                case 256:
                case 512:
                case 1024:
                case 2048:
                case 4096:
                case 8192:
                case 16384:
                case 32768:
                case 65536:
                case 131072:
                case 262144:
                case 524288:
                case 1048576:
                case 2097152:
                case 4194304:
                case 8388608:
                case 16777216:
                case 33554432:
                case 67108864:
                case 134217728:
                case 268435456:
                case 536870912:
                case 1073741824:
                    return true;
                default: return false;
            }
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo_V2(int n)
        {
            if (n == 0) return false;
            if (n == 1) return true;
            if (n % 2 == 0) 
                return IsPowerOfTwo_V2(n/2);

            return false;
        }

        /// <summary>
        /// 参考3的幂的评论，2147483648是整数范围内最大的2次幂，若n是2的幂，那么2147483648一定能整除它
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo_V3(int n)
        {
            return (n > 0) && (2147483648 % n == 0);
        }

        /// <summary>
        /// 重点在于对位运算符的理解
        /// 解法1：&运算，同1则1。 return (n > 0) && (n & -n) == n;
        /// 解释：2的幂次方在二进制下，只有1位是1，其余全是0。例如:8---00001000。负数的在计算机中二进制表示为补码(原码->正常二进制表示，原码按位取反(0-1,1-0)，最后再+1。然后两者进行与操作，得到的肯定是原码中最后一个二进制的1。例如8&(-8)->00001000 & 11111000 得 00001000，即8。 建议自己动手算一下，按照这个流程来一遍，加深印象。
        /// 解法2：移位运算：把二进制数进行左右移位。左移1位，扩大2倍；右移1位，缩小2倍。 return (n>0) && (1<<30) % n == 0;
        /// 解释：1<<30得到最大的2的整数次幂，对n取模如果等于0，说明n只有因子2。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo_V4(int n)
        {
            if (n <= 0) return false; 
            if ((n & n - 1) == 0) return true; 

            return false;
        }
    }
}
