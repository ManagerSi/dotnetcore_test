using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 11. 旋转数组的最小数字
    /// https://leetcode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof/
    /// </summary>
    public class xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof
    {
        /// <summary>
        /// 把整个数组看成: 左递增数组 + 右递增数组 [12345] [456123] [3111]
        /// 实际上试求右递增数组的第一个元素.所以我们里层的判断条件是判断nums[mid] 和nums[end]的关系:
        /// 
        ///     如果nums[mid] > nums[end], 说明右排序数组还在nums[mid] 的右边
        /// 
        ///     如果nums[mid] < nums[end], 说明右排序数组就在右边，并且最小值在mid或mid的左边
        /// 
        ///     如果nums[mid] == nums[end], 缩短右边界.
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int MinArray(int[] numbers)
        {
            int start = 0, end = numbers.Length - 1;

            if (numbers.Length == 1 || numbers[start]<numbers[end])
                return numbers[0];
            
            while (start<end)
            { // [41234] [34562] [31111] [30 1 11] [131 1 11] 【 2, 3, 4, 5, 1,】[ 2, 2,  2, 0, 1][3,3,1,3]
                int mid = (end+start) / 2;
                if (mid>0 && numbers[mid-1]>numbers[mid]) // mid-1 = 1 mid =2 start = 1 end = 4
                {
                    return numbers[mid];
                }
                if (mid == start)
                {
                    return numbers[mid] > numbers[end] ? numbers[end] : numbers[mid];
                }

                //只要右边比中间大，那右边一定是有序数组
                if (numbers[mid]  < numbers[end])
                    end = mid;
                else if (numbers[mid] > numbers[start])
                    start = ++mid;
                //else
                //    end--;

                else if (numbers[mid] == numbers[end]) //[3333123333333 3 3333333333]【31111】【30111】
                {
                    while (mid < end)
                    {
                        if (numbers[mid] == numbers[--end])
                        {
                            continue;
                        }
                        start = mid;
                        break;
                    }
                }
                else if (numbers[start] == numbers[mid])
                {
                    while (start < mid)
                    {
                        if (numbers[++start] == numbers[mid])
                        {
                            continue;
                        }

                        end = mid;
                        break;
                    }

                }
            }

            return numbers[start];
        }
    }
}
