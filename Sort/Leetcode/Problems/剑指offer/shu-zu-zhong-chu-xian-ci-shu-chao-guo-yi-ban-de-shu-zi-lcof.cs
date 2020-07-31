using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 39. 数组中出现次数超过一半的数字
    /// https://leetcode-cn.com/problems/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-ban-de-shu-zi-lcof/
    /// </summary>
    public class shu_zu_zhong_chu_xian_ci_shu_chao_guo_yi_ban_de_shu_zi_lcof
    {
        /// <summary>
        /// 遍历,
        /// 使用dictionary 空间换时间
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numbDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbDict.ContainsKey(nums[i]))
                    numbDict.Add(nums[i], 1);
                else
                    numbDict[nums[i]]++;

                if (numbDict[nums[i]] >= (nums.Length+1 )/ 2)
                    return nums[i];
            }
            return -1;
        }

        /// <summary>
        /// 先排序，取中间的数据
        /// 判断其左右两边是否有相等的值，若有则代表超过半数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement_V2(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];

        }


        /// <summary>
        /// 若一个数字出现的次数超过数组长度的一半，则该数字减去其他数字个数必定大于0，根据这个原理，
        /// 使用摩尔法投票法，记录一个数字，遍历数组，若是该数，票数加一，不是减一，为零下次出现什么都投一票，记录值变为下次出现的值。最后，记录中必定是出现过半的数字！
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement_V3(int[] nums)
        {
            int result = nums[0];
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    result = nums[i];
                }
                else
                {
                    count += (nums[i] == result) ? 1 : -1;
                }
            }
            return result;

        }
    }
}
