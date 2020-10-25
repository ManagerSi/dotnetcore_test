using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 234. 回文链表
    /// https://leetcode-cn.com/problems/palindrome-linked-list
    /// </summary>
    public class palindrome_linked_list
    {
        /// <summary>
        /// 使用栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            //遍历,压入栈，统计长度
            Stack<int> stack = new Stack<int>();
            var h = head;
            while (h != null)
            {
                stack.Push(h.val);
                h = h.next;
            }

            var halfLength = stack.Count / 2;
            for (int i = 0; i < halfLength; i++)
            {
                if (head.val != stack.Pop())
                    return false;
                head = head.next;
            }

            return true;
        }

        #region 其他人的想法
        /// <summary>
        /// 折半
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool isPalindrome_V2(ListNode head)
        {
            // 要实现 O(n) 的时间复杂度和 O(1) 的空间复杂度，需要翻转后半部分
            if (head == null || head.next == null)
            {
                return true;
            }
            ListNode fast = head;
            ListNode slow = head;
            // 根据快慢指针，找到链表的中点
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            slow = reverse(slow.next);
            while (slow != null)
            {
                if (head.val != slow.val)
                {
                    return false;
                }
                head = head.next;
                slow = slow.next;
            }
            return true;
        }

        private ListNode reverse(ListNode head)
        {
            // 递归到最后一个节点，返回新的新的头结点
            if (head.next == null)
            {
                return head;
            }
            ListNode newHead = reverse(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }

        #endregion

        public bool IsPalindrome_V3(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            thisNode = head;
            return recursively_check(head);
        }

        private ListNode thisNode = null;
        private bool recursively_check(ListNode lastNode)
        {
            if (lastNode != null)
            {
                if (!recursively_check(lastNode.next))
                {
                    return false;
                }

                if (lastNode.val != thisNode.val)
                {
                    return false;
                }

                thisNode = thisNode.next;
            }

            return true;
        }
    }
}
