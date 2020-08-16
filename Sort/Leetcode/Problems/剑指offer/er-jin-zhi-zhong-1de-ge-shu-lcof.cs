using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 15. 二进制中1的个数
    /// 
    /// https://leetcode-cn.com/problems/er-jin-zhi-zhong-1de-ge-shu-lcof/
    /// </summary>
    public class er_jin_zhi_zhong_1de_ge_shu_lcof
    {
        public int HammingWeight(uint n)
        {
            uint count = 0;
            while (n != 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return (int)count;
        }


        /// <summary>
        /// 将字符串按1分割
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight_V2(uint n)
        {
            string s = n.ToString();
            var arr = s.Split('1');
            return arr.Length-1;
        }
    }
}
