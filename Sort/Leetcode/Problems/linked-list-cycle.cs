using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 141. 环形链表
    /// https://leetcode-cn.com/problems/linked-list-cycle/
    /// </summary>
    public class linked_list_cycle
    {
        private HashSet<int> set = new HashSet<int>();
        /// <summary>
        /// 使用hashset
        ///
        /// 妈蛋，链表中不同node val可以一样，所以这个办法不可行
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        [Obsolete]
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            while (head.next != null)
            {
                if (!set.Contains(head.val))
                    set.Add(head.val);
                else
                    return true;

                head = head.next;
            }

            return false;
        }

        /// <summary>
        /// 使用快慢指针，若有环则一定相遇
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle_V2(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            var fast = head.next.next; //每次两步
            var slow = head.next;      //每次1步
            while (fast != null && fast.next != null)
            {
                if (fast.val == slow.val) return true;

                fast = fast.next.next;
                slow = slow.next;
            }

            return false;
        }
    }
}
