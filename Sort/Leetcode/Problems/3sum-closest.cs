using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    /// <summary>
    /// 16. 最接近的三数之和
    /// 
    /// https://leetcode-cn.com/problems/3sum-closest
    /// </summary>
    public class _3sum_closest
    {
        /// <summary>
        /// 三个指针遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums==null || nums.Length==0)
            {
                return 0;
            }

            //小于3个数，直接相加
            if (nums.Length<=3)
            {
                var sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                }

                return sum;
            }

            var res = 10000;
            for (int i = 0; i < nums.Length-2; i++)
            {
                for (int j = i+1; j < nums.Length-1; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if (Math.Abs(target - res) > Math.Abs(target - sum) )
                            res = sum;
                    }
                    
                }
            }

            return res;
        }

        /// <summary>
        /// 先排序, 然后遍历, 然后内部使用双指针, 时间复杂度应该是O(n²), 代码如下:
        /// 
        /// 1、本题和3数之和的进阶版。
        /// 首先将nums数组排序，
        /// 然后采用3个指针，头指针来对数组进行遍历，左指针指向头指针下一个，右指针指向数组最右侧，根据3个指针的元素之和与target之间的diff查来判断左右指针的移动方向。此外需要一个flag来记录3个指针的元素之和和target的大小关系。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest_V2(int[] nums, int target)
        {
            var sorted = nums.OrderBy(i => i).ToArray();

            var sum = sorted[0] + sorted[1] + sorted[2];
            for (int i = 0; i < sorted.Length-2; i++)
            {
                int l = i + 1, r = sorted.Length - 1;
                while (l < r)
                {
                    var temp = sorted[i] + sorted[l] + sorted[r];
                    if (Math.Abs(target - sum) > Math.Abs(target - temp))
                        sum = temp;

                    if (temp > target)
                        r--;
                    else if (temp < target)
                        l++;
                    else
                        return sum;
                }
            }

            return sum;
        }
    }
}
