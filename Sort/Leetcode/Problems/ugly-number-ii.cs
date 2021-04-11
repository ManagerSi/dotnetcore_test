using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 264. 丑数 II
    /// https://leetcode-cn.com/problems/ugly-number-ii/
    /// </summary>
    public class ugly_number_ii
    {
        /// <summary>
        /// 暴力法--超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            int i = 1;
            int count = 0;
            while (true)
            {
                if (IsUglyNumber(i))
                {
                    count++;
                    if (count == n) return i;
                }

                i++;
            }
        }

        private bool IsUglyNumber(int i)
        {
            if (i == 1) return true;

            while (i % 2 == 0) i = i / 2;
            while (i % 3 == 0) i = i / 3;
            while (i % 5 == 0) i = i / 5;

            return i == 1;
        }

        /// <summary>
        /// 最小堆
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber_V2(int n)
        {
            if (n == 1) return 1;
            SortedSet<long> list = new SortedSet<long>();
            list.Add(1);
            int counter = 1;
            while (counter < n)
            {
                var min = list.Min;
                list.Remove(min);
                list.Add(min * 2);
                list.Add(min * 3);
                list.Add(min * 5);
                counter++;
            }
            return (int)list.Min;
        }

        /// <summary>
        /// 多路归并（多指针）解法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber_V3(int n)
        {
            // ans 用作存储已有丑数（从下标 1 开始存储，第一个丑数为 1）
            int[] ans = new int[n + 1];
            ans[1] = 1;

            // 由于三个有序序列都是由「已有丑数」*「质因数」而来
            // i2、i3 和 i5 分别代表三个有序序列当前使用到哪一位「已有丑数」下标（起始都指向 1）
            for (int i2 = 1, i3 = 1, i5 = 1, idx = 2; idx <= n; idx++)
            {
                // 由 ans[iX] * X 可得当前有序序列指向哪一位
                int a = ans[i2] * 2, 
                    b = ans[i3] * 3, 
                    c = ans[i5] * 5;

                // 将三个有序序列中的最小一位存入「已有丑数」序列，并将其下标后移
                int min = Math.Min(a, Math.Min(b, c));

                // 由于可能不同有序序列之间产生相同丑数，因此只要一样的丑数就跳过（不能使用 else if ）
                if (min == a) i2++;
                if (min == b) i3++;
                if (min == c) i5++;

                ans[idx] = min;
            }
            return ans[n];
        }
    }
}
