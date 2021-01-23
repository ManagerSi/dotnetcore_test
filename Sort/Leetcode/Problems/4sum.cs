using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 18. 四数之和
    /// https://leetcode-cn.com/problems/4sum/
    /// </summary>
    public class _4sum
    { 
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            //1. sort
            Array.Sort(nums);

            //2. 双指针法
            int L, R = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;

                    L = j + 1;
                    R = nums.Length - 1;
                    while (L < R)
                    {
                        int sum = nums[i] + nums[j] + nums[L] + nums[R];
                        if (sum == target)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[L], nums[R] });
                            while (L < R && nums[L] == nums[L + 1]) L++;//去重
                            while (L < R && nums[R] == nums[R - 1]) R--;//去重
                            L++;
                            R--;
                        }
                        else if (sum > target) R--;
                        else if (sum < target) L++;
                    }

                }
            }

            return result;
        }
    }
}
