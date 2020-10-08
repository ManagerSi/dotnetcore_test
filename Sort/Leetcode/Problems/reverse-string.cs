using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 344. 反转字符串
    /// https://leetcode-cn.com/problems/reverse-string/
    /// </summary>
    public class reverse_string
    {
        /// <summary>
        /// 正常解法
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            if (s == null || s.Length <= 1)
                return;

            for (int i = 0; i < s.Length / 2; i++)
            {
                //var c = s[i];
                //s[i] = s[s.Length - i - 1];
                //s[s.Length - i - 1] = c;

                Swap(s, i, s.Length - i - 1);
            }
        }

        private void Swap(char[] array, int i, int j)
        {
            //第1种交换方式
            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            //第2种交换方式
            //    array[i] = (char) (array[i] + array[j]);
            //    array[j] = (char) (array[i] - array[j]);
            //    array[i] = (char) (array[i] - array[j]);

            //第3种交换方式
            //    array[i] = (char) (array[i] - array[j]);
            //    array[j] = (char) (array[i] + array[j]);
            //    array[i] = (char) (array[j] - array[i]);

            //第4种交换方式
            // array[i] ^= array[j];
            // array[j] ^= array[i];
            // array[i] ^= array[j];
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString_V1(char[] s)
        {
            if (s == null || s.Length <= 1)
                return;

            int left = 0, right = s.Length - 1;
            while (left<right)
            {
                //var c = s[left];
                //s[left] = s[right];
                //s[right] = c;

                Swap(s, left, right);

                left++;
                right--;
            }
        }


        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString_V2(char[] s)
        {
            if (s == null || s.Length <= 1)
                return;

            int left = 0, right = s.Length - 1;

            ReverseRecursion(s, left, right);
        }

        private void ReverseRecursion(char[] s, int left, int right)
        {
            if (left >= right) return;

            Swap(s, left, right);

            ReverseRecursion(s, ++left, --right);
        }
    }
}
