using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 31. 下一个排列
    /// https://leetcode-cn.com/problems/next-permutation/
    /// </summary>
    public class next_permutation
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            int length = nums.Length;
            int lastBigIndex = -1;

            //2 3 4 7 6 5
            for (int i = length - 1; i > 0; i--)
            {
                //找到4
                if (nums[i - 1] < nums[i])
                {
                    lastBigIndex = i - 1;

                    //找后面比i-1（4）大的最小的那个数（7，6，5 中找到5）
                    int minIndex = i;
                    for (int j = i; j < length; j++)
                    {
                        if (nums[j]>nums[lastBigIndex] && nums[j] < nums[minIndex]) 
                            minIndex = j;
                    }

                    //交换 4 和 5， 变为 2，3，5，7，6，4
                    swap(nums, lastBigIndex,minIndex);

                    //检查特殊情况，末尾两个数交换
                    if (lastBigIndex == length - 2)
                        return;

                    break;
                }
            }

            if (lastBigIndex > -1)
            {
                //对7，6，4 排序,冒泡
                for (int i = lastBigIndex+1; i < length-1; i++)
                {
                    for (int j = i+1; j < length; j++)
                    {
                        if(nums[i]>nums[j]) swap(nums,i,j);
                    }
                }
            }
            else
            {
                //所有数字降序排列

                for (int i = 0; i < length / 2; i++)
                {
                    swap(nums, i, length - i - 1);
                }
            }
        }

        private void swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }


        public void NextPermutation_V2(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
                return;

            int length = nums.Length;
            int lastBigIndex = -1;

            //2 3 4 7 6 5
            for (int i = length - 1; i > 0; i--)
            {
                //找到4
                if (nums[i - 1] < nums[i])
                {
                    lastBigIndex = i - 1;

                    //找后面比i-1（4）大的最小的那个数（7，6，5 中找到5）
                    //优化，直接和最后一个交换，因为之前比较过是降序排列的
                    int minIndex = i;
                    for (int j = i; j < length; j++)
                    {
                        if (nums[j] > nums[lastBigIndex] && nums[j] <= nums[minIndex])
                            minIndex = j;
                    }

                    //交换 4 和 5， 变为 2，3，5，7，6，4
                    swap(nums, lastBigIndex, minIndex);
                    
                    break;
                }
            }

            //从lastBigIndex开始后面一定是降序，反转为升序即可
            //若lastBigIndex=-1， 代表所有都是降序
            int l = lastBigIndex + 1;
            int r = length - 1;
            while (l < r)
            {
                swap(nums, l++, r--);
            }
        }

    }
}
