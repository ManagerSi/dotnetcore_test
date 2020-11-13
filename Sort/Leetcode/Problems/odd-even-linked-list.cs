using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 328. 奇偶链表
    /// https://leetcode-cn.com/problems/odd-even-linked-list/
    /// </summary>
    public class odd_even_linked_list
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode evenHead = head.next;
            ListNode odd = head;//奇数
            ListNode even = evenHead;//偶数
            while (even?.next != null)
            {
                //1,2,3,4
                odd.next = even.next;
                odd = odd.next;

                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }
    }
}
