using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 283. 移动零
    /// </summary>
    public class move_zeroes
    {

        /// <summary>
        /// 错误-不能交换顺序
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int left = 0; int right = nums.Length - 1;
            while (left < right)
            {
                while (nums[right] == 0) right--;
                while (nums[left] != 0) left++;

                if (left < right)
                {
                    swap(nums, left, right);
                }
            }
        }
        private void swap(int[] a, int i, int index)
        {
            int temp = a[i];
            a[i] = a[index];
            a[index] = temp;
        }

        public void MoveZeroes_V2(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int last = nums.Length;
            for (int i = 0; i < nums.Length-1 && i<last; )
            {
                if (nums[i] != 0)
                {
                    i++;
                    continue;
                }

                for (int j = i; j < last-1; j++)
                {
                    swap(nums,j,j+1);
                }

                last--;
            }
        }

        public void MoveZeroes_V3(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int last = nums.Length-1;
            while (last > 0 && nums[last] == 0) last--;

            int i = 0;
            while (i < last)
            {
                while (i<last && nums[i] != 0) i++;

                for (int j = i; j < last; j++)
                {
                    swap(nums, j, j + 1);
                }

                last--;
            }

        }

        /// <summary>
        /// 快排思想
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes_V4(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int n = nums.Length, left = 0, right = 0;
            while (right < n)
            {
                if (nums[right] != 0)
                {
                    swap(nums, left, right);
                    left++;
                }
                right++;
            }
        }

        public void MoveZeroes_V5(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int indexNow = 0;
            int indexNum = 0;
            int m = nums.Length;

            while (indexNum < m)
            {
                if (nums[indexNum] != 0)
                {
                    nums[indexNow++] = nums[indexNum];
                }
                ++indexNum;
            }

            for (int i = indexNow; i < m; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
