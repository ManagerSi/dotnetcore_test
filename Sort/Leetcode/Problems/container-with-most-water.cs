using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 11. 盛最多水的容器
    /// https://leetcode-cn.com/problems/container-with-most-water/
    /// </summary>
    public class container_with_most_water
    {
        /// <summary>
        /// 双指针
        /// 擦，这是双for
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length == 1) return 0; 

            int result = 0;
            for (int i = 0; i < height.Length-1; i++)
            {
                for (int j = i+1; j < height.Length; j++)
                {
                    var tempV = CalculateV(height, i, j);
                    if (result < tempV) result = tempV;
                }
            }

            return result;
        }


        /// <summary>
        /// 双指针 real
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea_V2(int[] height)
        {
            if (height == null || height.Length == 1) return 0;

            int result = 0;
            int left = 0, right = height.Length-1;
            while(left < right)
            {
                var tempV = CalculateV(height, left, right);
                if (result < tempV) result = tempV;

                if (height[left] < height[right])
                    left++;
                else
                    right--;

            }
            
            return result;
        }


        /// <summary>
        /// 计算容积（长*高）
        /// </summary>
        /// <param name="height"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int CalculateV(int[] nums, int i, int j)
        {
            var length = Math.Abs(i - j);
            var heigh = Math.Min(nums[i], nums[j]);
            return heigh * length;
        }
    }
}
