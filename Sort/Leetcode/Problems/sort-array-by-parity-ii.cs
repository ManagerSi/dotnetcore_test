using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 922. 按奇偶排序数组 II
    /// </summary>
    public class sort_array_by_parity_ii
    {
        public int[] SortArrayByParityII(int[] A)
        {
            if (A==null)
            {
                return A;
            }

            int index = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (i % 2 == 0 && A[i] % 2 != 0)
                {
                    index = i + 1;
                    while (A[index] % 2 != 0)
                    {
                        index++;
                    }

                    swap(A, i, index);
                }

                i++;

                if (i % 2 == 1 && A[i] % 2 != 1)
                {

                    index = i + 1;
                    while (A[index] % 2 != 1)
                    {
                        index++;
                    }

                    swap(A, i, index);
                }
            }

            return A;
        }

        private void swap(int[] a, int i, int index)
        {
            int temp = a[i];
            a[i] = a[index];
            a[index] = temp;
        }


        public int[] SortArrayByParityII_V2(int[] A)
        {
            if (A == null)
            {
                return A;
            }

            int[] tempA = new int[A.Length];
            int oddIndex = 0;
            int evenIndex = 1;
            for (int i = 0; i < A.Length; i++)
            {

                if (A[i] % 2 == 0)
                {
                    tempA[oddIndex] = A[i];
                    oddIndex += 2;
                }
                else
                {
                    tempA[evenIndex] = A[i];
                    evenIndex += 2;
                }
            }

            return tempA;
        }
    }
}
