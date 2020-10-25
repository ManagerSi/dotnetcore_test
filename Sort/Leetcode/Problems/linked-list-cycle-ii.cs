using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 142. 环形链表 II
    /// https://leetcode-cn.com/problems/linked-list-cycle-ii/
    /// </summary>
    public class linked_list_cycle_ii
    {
        public ListNode DetectCycle(ListNode head)
        {
            //无环
            if (head == null || head.next == null) return null;

            var tempH = head;
            Dictionary<ListNode, ListNode> dict = new Dictionary<ListNode, ListNode>();
            while (tempH != null)
            {
                if (dict.ContainsKey(tempH))
                {
                    return dict[tempH];
                }
                else
                {
                    dict.Add(tempH,tempH);
                }

                tempH = tempH.next;
            }

            return null;
        }


        public ListNode DetectCycle_V2(ListNode head)
        {
            //无环
            if (head == null || head.next == null) return null;

            var tempH = head;
            HashSet<ListNode> set = new HashSet<ListNode>();
            while (tempH != null)
            {
                if (set.Contains(tempH))
                {
                    return tempH;
                }
                else
                {
                    set.Add(tempH);
                }

                tempH = tempH.next;
            }

            return null;
        }

        /// <summary>
        /// 快慢指针
        /// https://leetcode-cn.com/problems/linked-list-cycle-ii/solution/142-huan-xing-lian-biao-ii-jian-hua-gong-shi-jia-2/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle_V3(ListNode head)
        {
            //无环
            if (head == null || head.next == null) return null;

            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                // 快慢指针相遇
                if (slow == fast)
                {
                    //此时从head 和 相遇点，同时查找直至相遇
                    var index = head;
                    while (index != slow)
                    {
                        index = index.next;
                        slow = slow.next;
                    }

                    return index;
                }
            }

            return null;
        }
    }
}
