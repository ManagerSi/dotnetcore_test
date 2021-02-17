using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 448. 找到所有数组中消失的数字
    /// https://leetcode-cn.com/problems/find-all-numbers-disappeared-in-an-array/
    /// </summary>
    public class find_all_numbers_disappeared_in_an_array
    {
        ///// <summary>
        ///// 暴力破解
        ///// 先去重，后排序，再遍历
        ///// </summary>
        ///// <param name="nums"></param>
        ///// <returns></returns>
        //public IList<int> FindDisappearedNumbers(int[] nums)
        //{
        //    if (nums == null || nums.Length == 1) return null;

        //    var numsSet = nums.ToHashSet().ToArray();
        //    Array.Sort(numsSet);

        //    IList<int> result = new List<int>();
        //    for (int i = 1; i < numsSet.Length; i++)
        //    {
        //        if (numsSet[i] - numsSet[i - 1] > 1)
        //        {
        //            int gap = numsSet[i] - numsSet[i - 1];
        //            for (int j = 1; j < gap; j++)
        //            {
        //                result.Add(numsSet[i-1] + j);
        //            }
        //        }
        //    }


        //    return result;
        //}

        public IList<int> FindDisappearedNumbers_V2(int[] nums)
        {
            int n = nums.Length;
            foreach (var item in nums)
            {
                int x = (item - 1) % n;
                nums[x] += n;
            }

            List<int> ret = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= n)
                {
                    ret.Add(i + 1);
                }
            }
            return ret;
        }
    }
}
