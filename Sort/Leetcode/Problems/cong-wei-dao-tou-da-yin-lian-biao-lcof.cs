using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 剑指 Offer 06. 从尾到头打印链表
    /// https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/
    /// </summary>
    public class cong_wei_dao_tou_da_yin_lian_biao_lcof
    {
        /// <summary>
        /// 两次循环，获取链表长度，直接使用数组随机读取进行赋值
        /// 时间O(n)
        /// 空间O(n)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ReversePrint(ListNode head)
        {
            if (head == null)
                return new int[] { };

            var h = head;
            var len = 0;
            while (h!=null)
            {
                len++;
                h = h.next;
            }

            var arr = new int[len];
            for (int i = len-1; i >= 0 ; i--)
            {
                arr[i] = head.val;
                head = head.next;
            }

            return arr;
        }


        private Stack<int> stack = new Stack<int>();
        /// <summary>
        /// 使用栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] ReversePrint_V2(ListNode head)
        {
            if (head == null)
                return new int[] { };

            var h = head;
            while (h != null)
            {
                stack.Push(h.val);
                h = h.next;
            }

            var arr = new int[stack.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = stack.Pop();
            }

            return arr;
        }
    }
}
