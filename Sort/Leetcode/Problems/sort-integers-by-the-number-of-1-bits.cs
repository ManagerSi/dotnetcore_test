using Medallion.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1356. 根据数字二进制下 1 的数目排序
    /// https://leetcode-cn.com/problems/sort-integers-by-the-number-of-1-bits/
    /// </summary>
    public class sort_integers_by_the_number_of_1_bits: IComparer<int>
    {
        public int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, ((a, b) =>
            {
                //return (OnesCount(a) - OnesCount(b)) ?? a - b;
                int countA = OnesCount(a);
                int countB = OnesCount(b);

                if (countA == countB)
                    return a - b;
                else
                    return countA - countB;
            }));

            return arr;
        }
        /// <summary>
        /// 暴力遍历
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int OnesCount(int n)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((n & (1 << i)) != 0)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/sort-integers-by-the-number-of-1-bits/solution/fu-xi-wei-yun-suan-fu-1356-gen-ju-shu-zi-er-jin-zh/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortByBits_V2(int[] arr)
        {
            Array.Sort(arr, ((a, b) =>
            {
                //return (OnesCount(a) - OnesCount(b)) ?? a - b;
                int countA = OnesCount_V2(a);
                int countB = OnesCount_V2(b);

                if (countA == countB)
                    return a - b;
                else
                    return countA - countB;
            }));

            return arr;
        }

        private int OnesCount_V2(int n)
        {
            int count = 0;
            while (n!=0)
            {
                count += n & 1;//尾数为1
                n = n >> 1;//右移
            }

            return count;
        }

        /// <summary>
        /// 类库
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortByBits_V3(int[] arr)
        {
            return arr.OrderBy(i => Convert.ToString(i,2).Count(c => c == '1')).ThenBy(i => i).ToArray();
        }



        /// <summary>
        /// PriorityQueue 类库
        /// 需改进
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortByBits_V4(int[] arr)
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>(arr, new sort_integers_by_the_number_of_1_bits());//继承 IComparer<int>
            for (int i = 0; i < arr.Length; i++)
            {
                priorityQueue.Add(arr[i]);
            }
            int index = 0;
            while (priorityQueue.Count>0)
            {
                arr[index++] = priorityQueue.Dequeue();
            }

            return arr;
        }

        public int Compare([AllowNull] int a, [AllowNull] int b)
        {
            int countA = OnesCount_V2(a);
            int countB = OnesCount_V2(b);

            if (countA == countB)
                return a - b;
            else
                return countA - countB;
        }
    }
}
