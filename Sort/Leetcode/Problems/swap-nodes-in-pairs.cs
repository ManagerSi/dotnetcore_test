using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 24. 两两交换链表中的节点
    /// https://leetcode-cn.com/problems/swap-nodes-in-pairs/
    /// </summary>
    public class swap_nodes_in_pairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var tempH = head;
            ListNode prev = null;
            while (tempH != null && tempH.next!=null)
            {

                var next = tempH.next.next;
                var node1 = tempH;
                var node2 = tempH.next;

                if (prev == null)
                {
                    node1.next = next;
                    node2.next = node1;
                    head = node2;
                }
                else
                {
                    prev.next = node2;
                    node1.next = next;
                    node2.next = node1;
                }

                prev = node1;
                tempH = next;

            }

            return head;
        }
    }
}
