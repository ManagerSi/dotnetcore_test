using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// https://leetcode-cn.com/problems/two-sum/
    /// </summary>
    public class TwoSum : BaseRun
    {
        public void Rune()
        {
            int length = 10;
            var arr = Utility.CreateIntArray(length);
        }
        
        /// <summary>
        /// 暴力破解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] Solution(int[] nums, int target)
        {
            if (nums==null || nums.Length<1)
            {
                throw new Exception("invalide input");
            }
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]+nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new ArgumentException("IllegalArgumentException, No two sum solution");
        }

        /// <summary>
        /// 有问题，若数组内有重复则dictionary会报错
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SolutionTwo(int[] nums, int target)
        {
            if (nums == null || nums.Length < 1)
            {
                throw new Exception("invalide input");
            }
            var table = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //需要对重复值进行判断；因为结果的唯一，所以若有重复值，且答案中包含了重复值的话，说明必有 重复值*2==target; 否则直接忽略重复值即可
                if (table.ContainsKey(nums[i]))
                {
                    if (nums[i] * 2 == target)
                    {
                        return new int[] { i, table[nums[i]] };
                    }
                }
                else
                {
                    table.Add(nums[i], i);
                }

            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (table.ContainsKey(complement) && table[complement]!=i)
                {
                    return new int[2] { i, table[complement] };
                }
            }
            throw new ArgumentException("IllegalArgumentException, No two sum solution");
        }
    }
}
