using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 21. 合并两个有序链表
    /// https://leetcode-cn.com/problems/merge-two-sorted-lists/
    /// </summary>
    public class merge_two_sorted_lists
    {
        /// <summary>
        /// 常规做法，新建队列
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            ListNode head = null;
            ListNode temp = null;
            if (l1.val < l2.val)
            {
                head = new ListNode(l1.val);
                l1 = l1.next;
            }
            else
            {
                head = new ListNode(l2.val);
                l2 = l2.next;
            }

            temp = head;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    temp.next = new ListNode(l2.val);
                    l2 = l2.next;
                }

                temp = temp.next;
            }

            if (l1 != null)
                temp.next = l1;
            else
                temp.next = l2;

            return head;
        }

        /// <summary>
        /// 递归，原有队列
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists_V2(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists_V2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists_V2(l1, l2.next);
                return l2;
            }

        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists_V3(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode head = new ListNode(0);
            ListNode temp = head;
            while (l1!=null && l2!=null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    temp.next = l2;
                    l2 = l2.next;
                }

                temp = temp.next;
            }
            if (l1 != null)
                temp.next = l1;
            else
                temp.next = l2;

            return head.next;
        }
    }
}
