using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 21. 调整数组顺序使奇数位于偶数前面
    /// https://leetcode-cn.com/problems/diao-zheng-shu-zu-shun-xu-shi-qi-shu-wei-yu-ou-shu-qian-mian-lcof/
    /// </summary>
    public class diao_zheng_shu_zu_shun_xu_shi_qi_shu_wei_yu_ou_shu_qian_mian_lcof
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Exchange(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return nums;
            int l = 0,r = nums.Length-1;
            while (l < r)
            {
                while (l<r && nums[l] % 2 == 1)//奇数
                    l++;
                while (l < r && nums[r] % 2 == 0)
                    r--;

                if (l < r)
                {
                    var temp = nums[l];
                    nums[l] = nums[r];
                    nums[r] = temp;
                    l++;
                    r--;
                }
            }
            return nums;
        }
    }
}
