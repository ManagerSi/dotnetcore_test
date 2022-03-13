using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 393. UTF-8 编码验证
    /// https://leetcode-cn.com/problems/utf-8-validation/
    /// </summary>
    public class utf_8_validation
    {
        public const int M1 = 1 << 7;
        public const int M2 = (1 << 7) + (1 << 6);

        public bool ValidUtf8(int[] data)
        {
            int length = data.Length;
            for (int i = 0; i < length; i++)
            {
                int n = CheckHead(data[i]);
                if (n < 1 || n > 4 || n+i> length) 
                    return false;

                for (int j = 1; j < n; j++)
                {
                    if (!CheckPrefix10(data[i+j])) 
                        return false;
                }

                //go to next head
                i = i + n-1;
            }
            return true;
        }

        /// <summary>
        /// CheckPrefix is 10 or not
        ///
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool CheckPrefix10(int v)
        {
            return (v & M2) == M1;
        }

        private int CheckHead(int v)
        {
            //首位是0
            if ((v & M1) != M1) return 1;

            int count = 0;

            //var preHead = M2;
            //// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            //while ((v&preHead) == preHead)
            //{
            //    count++;
            //    preHead = preHead >> 1;
            //}

            int mask = M1;
            while ((v & mask) != 0)
            {
                count++;
                if (count > 4)
                {
                    return 0;
                }
                mask >>= 1;
            }

            return count > 1 ? count : 0;
        }
    }
}
