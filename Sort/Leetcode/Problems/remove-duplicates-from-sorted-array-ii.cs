using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 80. 删除有序数组中的重复项 II
    /// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/
    /// </summary>
    public class remove_duplicates_from_sorted_array_ii
    {
        private readonly int _limit = 2;
        public int RemoveDuplicates(int[] nums)
        {
            int pre = int.MinValue;
            int dupCount = 0;
            int delCount = 0;
            int end = nums.Length;
            for (int i = 0; i < end; i++)
            {
                if (nums[i] != pre)
                {
                    dupCount=1;
                    pre = nums[i];
                    continue;
                }

                dupCount++;
                if (dupCount > _limit)
                {
                    if (nums[i] == nums[nums.Length - 1])
                    {
                        delCount += nums.Length - i - delCount;
                        break;
                    }

                    DeleteByIndex(nums, i);
                    delCount++;
                    end--;
                    i--;
                }

            }

            return nums.Length - delCount;
        }

        private void DeleteByIndex(int[] nums, int i)
        {
            for (int j = i; j < nums.Length-1; j++)
            {
                nums[j] = nums[j + 1];
            }
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates_V2(int[] nums)
        {
            int len = nums.Length;
            if (len < 3)
            {
                return len;
            }
            int slow = 2, fast = 2;
            while (fast < len)
            {
                //检查上上个应该被保留的元素nums[slow−2] 是否和当前待检查元素nums[fast] 相同
                if (nums[slow - 2] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }
    }
}
