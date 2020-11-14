using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1122. 数组的相对排序
    /// https://leetcode-cn.com/problems/relative-sort-array/
    /// </summary>
    public class relative_sort_array
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr1.Length <= 1) return arr1;

            int a1Index = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = a1Index; j < arr1.Length; j++)
                {
                    if (arr1[j] == arr2[i])
                    {
                        swap(arr1, j, a1Index);
                        a1Index++;
                    }
                }
            }

            Array.Sort(arr1, a1Index, arr1.Length - a1Index);

            return arr1;
        }

        private void swap(int[] arr1, int j, int a1Index)
        {
            if (j == a1Index) return;
            if (j < 0 || j >= arr1.Length || a1Index < 0 || a1Index >= arr1.Length) return;

            int temp = arr1[j];
            arr1[j] = arr1[a1Index];
            arr1[a1Index] = temp;
        }


        public int[] RelativeSortArray_V2(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> num2index = Enumerable.Range(0, arr2.Length)
                .ToDictionary(p => arr2[p], p => p);
            return arr1.Where(p => num2index.ContainsKey(p))
                .OrderBy(p => num2index[p])
                .Concat(arr1.Where(p => !num2index.ContainsKey(p)).OrderBy(p => p))
                .ToArray();
        }
        public int[] RelativeSortArray_V3(int[] arr1, int[] arr2)
        {
            List<int> list = arr2.ToList();
            arr1 = arr1.OrderBy(a => list.IndexOf(a)).OrderBy(a => list.IndexOf(a) == -1 ? a : 0).ToArray();
            return arr1;
        }

    }
}
