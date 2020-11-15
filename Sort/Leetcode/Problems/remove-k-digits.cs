using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 402. 移掉K位数字
    /// https://leetcode-cn.com/problems/remove-k-digits/
    /// </summary>
    public class remove_k_digits
    {
        /// <summary>
        /// 单调栈
        /// 1、删除 k 个 数字：
        ///     1.查找 非“递增”数对，
        ///     若找到，则 删除第一个 非“递增”数对 的 第一个数字
        ///     2. 若 整个序列满足“递增”，则 删除最后一个元素
        ///2、若 当前字符串的 第一个字符是 '0'，且 字符串长度不为1,则 删除当前第一个字符
        ///3、删去队首的 字符'0'
        ///4、结果 转换
        ///
        ///运行结果
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            if (string.IsNullOrEmpty(num) || k >= num.Length)
                return "0";

            if (k <= 0)
                return num;

            Stack<char> stack = new Stack<char>();
            foreach (var n in num)
            {
                while (stack.Count > 0 && n < stack.Peek() && k>0)
                {
                    stack.Pop();
                    k--;
                }

                stack.Push(n);
            }

            for (int i = 0; i < k; i++)
            {
                stack.Pop();
            }

            StringBuilder sb = new StringBuilder(stack.Count);
            while (stack.Count>0)
            {
                sb.Insert(0, stack.Pop());
            }

            while (sb.Length>0 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }

            if (sb.Length == 0)
                return "0";

            return sb.ToString();
        }
    }
}
