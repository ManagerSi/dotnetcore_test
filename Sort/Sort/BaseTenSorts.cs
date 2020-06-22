using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public static class BaseTenSorts
    {
        public static int[] GetIntArray(int count = 10, int max = Int32.MaxValue)
        {
            int[] arr =new int[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = r.Next(max);
            }

            return arr;
        }
        public static void Show(this int[] arr)
        {
            Console.WriteLine(string.Join(',',arr));
        }


        public static void BubbleSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length -1; i++)
            {
                for (int j = 0; j < arr.Length -1 - i; j++)
                {
                    if (arr[j]>arr[j+1])
                    {
                        var temp = arr[j+1];
                        arr[j+1] = arr[j];
                        arr[j] = temp;
                    }
                }
                arr.Show();
            }
        }

        public static void SelectionSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                var temp = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[temp] > arr[j])
                    {
                        temp = j;
                    }
                }

                if (temp!=i)
                {
                    var tValue = arr[temp];
                    arr[temp] = arr[i];
                    arr[i] = tValue;
                }

                arr.Show();
            }
        }
    }
}
