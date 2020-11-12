using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 905. 按奇偶排序数组
    /// </summary>
    public class sort_array_by_parity
    {
        /// <summary>
        /// 额外数组
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortArrayByParity(int[] A)
        {
            if (A == null) return A;

            int length = A.Length;
            int[] even = new int[length];
            int[] odd = new int[length];
            int evenIndex = 0;
            int oddIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    even[evenIndex++] = A[i];
                }
                else
                {
                    odd[oddIndex++] = A[i];
                }
            }
            
            for (int i = evenIndex,j=0; i < length; i++,j++)
            {
                even[i] = odd[j];
            }

            return even;
        }

        /// <summary>
        /// 快排--双指针
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortArrayByParity_V2(int[] A)
        {
            int l = 0;
            int r = A.Length - 1;
            while (l<r)
            {
                while (l < r && A[l]%2==0)
                {
                    l++;
                }
                while (l < r && A[r] % 2 == 1)
                {
                    r--;
                }
                if(l < r)
                    swap(A, l, r);
            }

            return A;
        }

        private void swap(int[] a, int i, int index)
        {
            int temp = a[i];
            a[i] = a[index];
            a[index] = temp;
        }
        /// <summary>
        /// 双指针改进
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] SortArrayByParity_V3(int[] A)
        {
            if (A == null || A.Length <= 1) return A;
            int i = 0, j = A.Length - 1;
            //while循环-双指针，i从前往后寻找奇数，j从后向前寻找偶数
            while (i < j)
            {//重点是i<j条件(由于初始i=0,j=len-1都是边界条件)
                if ((A[i] & 1) == 1)
                {
                    while (j > i && (A[j] & 1) == 1) j--;
                    swap(A, i, j);
                    j--;//i和j交换之后，j位置便是奇数
                }
                i++;
            }
            return A;
        }
    }
}
