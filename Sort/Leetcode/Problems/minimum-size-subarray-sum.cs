using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 209. 长度最小的子数组
    /// https://leetcode-cn.com/problems/minimum-size-subarray-sum/
    /// </summary>
    public class minimum_size_subarray_sum
    {
        /// <summary>
        /// 双指针滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums==null || nums.Length==0)
            {
                return 0;
            }

            int res = nums.Length;
            
            for (int i = 0; i < nums.Length; i++)
            {
                var len = 1;
                var left = s - nums[i];
                if (left <= 0) return len;//单个已经满足条件

                for (int j = i+1; j < nums.Length; j++)
                {
                    left -= nums[j];
                    len++;
                    if (left<=0)
                    {
                        if (len < res)
                        {
                            res = len;
                        }
                        break;
                    }
                }

                if (i==0 && left > 0) return 0; //全部加起来还不够s
            }

            return res;
        }
    }
}
