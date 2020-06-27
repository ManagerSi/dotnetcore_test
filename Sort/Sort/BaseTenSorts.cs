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
        /// 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
        /// 针对所有的元素重复以上的步骤，除了最后一个。
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
        /// 
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
        /// <summary>
        /// 插入排序（Insertion-Sort）的算法描述是一种简单直观的排序算法。
        /// 它的工作原理是通过构建有序序列，对于未排序数据，在已排序序列中从后向前扫描，找到相应位置并插入。
        ///
        /// 时间复杂度(平均)： O(n2)
        /// 时间复杂度(最坏)：O(n2)
        /// 时间复杂度(最好)：O(n)
        /// 
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertSort(this int[] arr)
        {
            int index,//有序数组的尾部
                tempI;//当前循环的指针
            for (int i = 1; i < arr.Length; i++)
            {
                index = i-1;
                tempI = i;
                while (index>=0 && arr[tempI]<arr[index])
                {
                    Swap(arr, tempI,index);
                    index--;
                    tempI--;
                }

                arr.Show();
            }
        }

        /// <summary>
        /// 希尔排序这个名字，来源于它的发明者希尔，也称作“缩小增量排序”，是插入排序的一种更高效的改进版本。
        /// 插入排序对于大规模的乱序数组的时候效率是比较慢的，因为它每次只能将数据移动一位，
        /// 希尔排序为了加快插入的速度，让数据移动的时候可以实现跳跃移动，节省了一部分的时间开支。
        /// 
        /// 最好情况的时间复杂度是O(n)，
        /// 最坏情况的时间复杂度是O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        public static void ShellSort(this int[] arr)
        {
            if (arr == null || arr.Length < 2) return;

            //设置步长h，实现分组
            for (int h = arr.Length/2; h > 0; h/=2)
            {
                int index,//有序数组的尾部
                    tempI;//当前循环的数值
                //循环每个分组
                for (int i = h; i < arr.Length; i++)
                {
                    //arr[h-i] 所在的分组为 ... arr[i-2*h],arr[i-h], arr[i+h] ...
                    index = i - h;//有序数组尾部
                    tempI = arr[i];//当前循环的数值
                    while (index >= 0 && tempI < arr[index]) //当前值<有序数组最后一个，则需要交换
                    {
                        arr[index + h] = arr[index];
                        index-=h;
                    }
                    arr[index+h] = tempI;
                }

                arr.Show();
            }
        }

        #endregion 插入排序（简单插入/希尔排序）

        #region 选择排序（简单选择排序/堆排序）
        /// <summary>
        /// 首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置，
        /// 然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
        /// 以此类推，直到所有元素均排序完毕。
        ///
        /// 表现最稳定的排序算法之一，
        /// 因为无论什么数据进去都是O(n2)的时间复杂度，所以用到它的时候，数据规模越小越好。
        /// 唯一的好处可能就是不占用额外的内存空间了吧。
        /// 理论上讲，选择排序可能也是平时排序一般人想到的最多的排序方法了吧。
        /// 
        /// 时间复杂度(平均)： O(n2)
        /// 时间复杂度(最坏)：O(n2)
        /// 时间复杂度(最好)：O(n2)
        /// 
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="arr"></param>
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
