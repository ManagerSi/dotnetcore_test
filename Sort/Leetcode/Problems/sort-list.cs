using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 148. 排序链表
    /// https://leetcode-cn.com/problems/sort-list/
    /// </summary>
    public class sort_list
    {
        /// <summary>
        /// 你可以在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序吗？
        /// 归并排序（自顶向下)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            return SortPartial(head, null);
        }

        private ListNode SortPartial(ListNode head, ListNode trial)
        {
            if (head == null) return head;

            //超过两个节点，分开
            if (head.next == trial)
            {
                head.next = null;
                return head;
            }

            var fast = head; 
            var slow = head;
            while (fast != trial)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != trial)
                    fast = fast.next;
            }

            ListNode mid = slow;

            var n1 = SortPartial(head, mid);
            var n2 = SortPartial(mid, trial);

            return MergePartial(n1, n2);
        }

        private ListNode MergePartial(ListNode n1, ListNode n2)
        {
            if (n1 == null) return n2;
            if (n2 == null) return n1;

            var res = new ListNode(0);
            var temp = res;
            while (n1!=null && n2!= null)
            {
                if (n1.val < n2.val)
                {
                    temp.next = n1;
                    n1 = n1.next;
                }
                else
                {
                    temp.next = n2;
                    n2 = n2.next;
                }

                temp = temp.next;
            }

            temp.next = n1 ?? n2;

            return res.next;
        }

        /// <summary>
        /// 非递归
        /// 归并排序 自顶向下
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList_V2(ListNode head)
        {
            if (head?.next == null) return head;

            var fast = head.next;
            var slow = head;
            while (fast?.next!=null && slow!=null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            //断开链接
            var next = slow.next;
            slow.next = null;

            var left = SortList_V2(head);
            var right = SortList_V2(next);

            //合并
            var result = new ListNode(0);
            var temp = result;
            while (left!=null && right!=null)
            {
                if (left.val < right.val)
                {
                    temp.next = left;
                    left = left.next;
                }
                else
                {
                    temp.next = right;
                    right = right.next;
                }

                temp = temp.next;
            }
            temp.next = left ?? right;
            
            return result.next;
        }


        /// <summary>
        /// 非递归
        /// 归并排序 自底向上
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList_V3(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            int length = 0;
            ListNode node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            ListNode dummyHead = new ListNode(0, head);
            for (int subLength = 1; subLength < length; subLength <<= 1)
            {
                ListNode prev = dummyHead, curr = dummyHead.next;
                while (curr != null)
                {
                    ListNode head1 = curr;
                    for (int i = 1; i < subLength && curr.next != null; i++)
                    {
                        curr = curr.next;
                    }
                    ListNode head2 = curr.next;
                    curr.next = null;
                    curr = head2;
                    for (int i = 1; i < subLength && curr != null && curr.next != null; i++)
                    {
                        curr = curr.next;
                    }
                    ListNode next = null;
                    if (curr != null)
                    {
                        next = curr.next;
                        curr.next = null;
                    }
                    ListNode merged = MergePartial(head1, head2);
                    prev.next = merged;
                    while (prev.next != null)
                    {
                        prev = prev.next;
                    }
                    curr = next;
                }
            }
            return dummyHead.next;
        }
    }
}
