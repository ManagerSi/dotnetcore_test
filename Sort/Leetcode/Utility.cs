using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public static class Utility
    {
        public static int[] CreateIntArray(int length = 10, int maxValue = 100)
        {
            Random rd = new Random(maxValue);
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = rd.Next(maxValue);
            }
            return arr;
        }

        public static void ArrayShow(this int[] arr)
        {
            if (arr == null || arr.Length ==0)
            {
                return;
            }

            Console.WriteLine(string.Join(',',arr));
        }

        public static string ToArrayString(this int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            return string.Join(',', arr);
        }

    }
}
