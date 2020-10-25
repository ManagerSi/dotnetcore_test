using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 143. 重排链表
    /// https://leetcode-cn.com/problems/reorder-list/
    /// </summary>
    public class reorder_list
    {
        public void ReorderList(ListNode head)
        {
            if (head?.next?.next == null)
                return;

            var tempH = head;
            var list = new List<ListNode>();
            while (tempH!=null)
            {
                list.Add(tempH);
                tempH = tempH.next;
            }

            tempH = head;
            for (int i = 0; i < list.Count/2; i++)
            {
                var last = list[list.Count - 1 - i];
                last.next = tempH.next;
                tempH.next = last;

                tempH = last.next;
            }

            tempH.next = null;
        }
    }
}
