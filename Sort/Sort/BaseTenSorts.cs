using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    /// <summary>
    /// 相关概念 
    /// 稳定：如果a原本在b前面，而a=b，排序之后a仍然在b的前面。
    /// 不稳定：如果a原本在b的前面，而a=b，排序之后 a 可能会出现在 b 的后面。
    /// 时间复杂度：对排序数据的总的操作次数。反映当n变化时，操作次数呈现什么规律。
    /// 空间复杂度：是指算法在计算机内执行时所需存储空间的度量，它也是数据规模n的函数。 
    /// </summary>
    public static class BaseTenSorts
    {
        /// <summary>
        /// 获取一个int数组
        /// </summary>
        /// <param name="count"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 打印数组
        /// </summary>
        /// <param name="arr"></param>
        public static void Show(this int[] arr)
        {
            Console.WriteLine(string.Join(',',arr));
        }

        /// <summary>
        /// 交换 i 和 j 的值
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="pivot"></param>
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }


        #region 交换类排序方法(冒泡/快速)
        /// <summary>
        /// 比较相邻的元素。如果第一个比第二个大，就交换他们两个。
        /// 
        /// 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
        /// 
        /// 针对所有的元素重复以上的步骤，除了最后一个。
        /// 
        /// 持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j+1);
                    }
                }
                arr.Show();
            }
        }

        /// <summary>
        /// 快速排序使用分治法（Divide and conquer）策略来把一个串行（list）分为两个子串行（sub-lists）。
        /// 本质上来看，快速排序应该算是在冒泡排序基础上的递归分治法。
        /// 快速排序的最坏运行情况是 O(n²)，比如说顺序数列的快排。
        /// 但它的平摊期望时间是 O(nlogn)，且 O(nlogn) 记号中隐含的常数因子很小，比复杂度稳定等于 O(nlogn) 的归并排序要小很多。所以，对绝大多数顺序性较弱的随机数列而言，快速排序总是优于归并排序。
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(this int[] arr, int? left =null, int? right=null)
        {
            left = left.HasValue ? left.Value : 0;
            right = right.HasValue ? right.Value : arr.Length - 1;

            if (left<right)
            {
                var partionIndex = Partion(arr, left.Value, right.Value);
                QuickSort(arr,left,partionIndex - 1);
                QuickSort(arr, partionIndex + 1, right);
            }
        }

        /// <summary>
        /// 思路
        /// 从数列中挑出一个元素，称为 "基准"（pivot）; 
        /// 重新排序数列，所有元素比基准值小的摆放在基准前面，所有元素比基准值大的摆在基准的后面（相同的数可以到任一边）。
        ///
        /// 实现
        /// 选取第一个为"基准"（pivot）;
        /// index为小于pivot的指针
        /// 遍历left到right，如果arr[i]小于pivot, 则arr[i]移到index当前位置，并且index就+1（即left--index之间为小于pivot的数）
        /// 最后将pivot的值（第一个值）和index-1的值交换，交换后保证left--index之间为小于pivot的数，index+1--right之间为大于pivot的数 
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int Partion(int[] arr, int left, int right)
        {
            var pivot = left;
            var index = pivot + 1;
            for (int i = index; i <= right; i++)
            {
                if (arr[i] < arr[pivot])
                {
                    if(i!=index)
                        Swap(arr,i,index);
                    index++;
                }
            }
            Swap(arr, pivot, index-1);

            arr.Show();

            return index - 1;
        }


        #endregion 交换类排序方法(冒泡/快速)

        #region 插入排序（简单插入/希尔排序）

        #endregion 插入排序（简单插入/希尔排序）

        #region 选择排序（简单选择排序/堆排序）
        public static void SelectionSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var temp = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[temp] > arr[j])
                    {
                        temp = j;
                    }
                }

                if (temp != i)
                {
                    var tValue = arr[temp];
                    arr[temp] = arr[i];
                    arr[i] = tValue;
                }

                arr.Show();
            }
        }

        #endregion 选择排序（简单选择排序/堆排序）

        #region 归并排序（二路归并排序/多路归并排序）



        #endregion 归并排序（二路归并排序/多路归并排序）

        #region 非比较排序（计数排序/桶排序/基数排序）



        #endregion 非比较排序（计数排序/桶排序/基数排序）



    }
}
