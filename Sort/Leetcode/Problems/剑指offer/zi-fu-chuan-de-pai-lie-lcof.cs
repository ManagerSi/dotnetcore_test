using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 38. 字符串的排列
    /// https://leetcode-cn.com/problems/zi-fu-chuan-de-pai-lie-lcof
    /// </summary>
    public class zi_fu_chuan_de_pai_lie_lcof
    {
        /// <summary>
        /// 回溯法
        /// https://leetcode-cn.com/problems/zi-fu-chuan-de-pai-lie-lcof/solution/mian-shi-ti-38-zi-fu-chuan-de-pai-lie-hui-su-fa-by/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string[] Permutation(string s)
        {
            c = s.ToCharArray();
            dfs(0);
            return result.ToArray();
        }
        List<string> result = new List<string>();
        char[] c = null;
        private void dfs(int index)
        {
            if (index == c.Length - 1)
            {
                result.Add(string.Join("", c));
                return;
            }

            HashSet<char> set = new HashSet<char>();
            for (int i = index; i < c.Length; i++)
            {
                if (set.Contains(c[i])) continue;   // 重复，因此剪枝
                set.Add(c[i]);
                swap(i, index);   // 交换，将 c[i] 固定在第 x 位 
                dfs(index + 1);   // 开启固定第 x + 1 位字符
                swap(i, index);   // 恢复交换
            }
        }

        private void swap(int i, int index)
        {
            var temp = c[i];
            c[i] = c[index];
            c[index] = temp;
        }
    }
}
