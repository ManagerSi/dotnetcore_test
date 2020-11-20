using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 147. 对链表进行插入排序
    /// https://leetcode-cn.com/problems/insertion-sort-list/
    /// </summary>
    public class insertion_sort_list
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode InsertionSortList(ListNode head)
        {
            if (head?.next == null) return head;

            //排好序的链表
            var zero = new ListNode(0);
            zero.next = head;

            var tempH = head.next;
            var index = 1;
            while (tempH != null)
            {
                ListNode result = zero;
                var tempIndex = 0;
                //在排好序的链表中找到合适的位置
                while (tempH.val > result.next.val && tempIndex<index )
                {
                    result = result.next;
                    tempIndex++;
                }

                //保存后续节点
                var next = tempH.next;

                //在result后插入tempH
                tempH.next = result.next;
                result.next = tempH;
                index++;

                //继续遍历下个节点
                tempH = next;
            }

            //掐掉结尾
            tempH = zero;
            for (int i = 0; i < index; i++)
            {
                tempH = tempH.next;
            }
            tempH.next = null;

            return zero.next;
        }

        public ListNode InsertionSortList_V2(ListNode head)
        {
            if (head?.next == null) return head;

            var cur = head;
            var start = new ListNode(0);
            start.next = head;
            while (cur!=null)
            {
                // 当前节点
                var next = cur.next;
                var left = start; // cur.next会被改，暂存。每次从第0节点起
                while (left.next != null && left.next.val < cur.val) 
                    left = left.next;// 找 插入位置左侧节点left，即第一个右侧节点值比当前节点大的节点

                cur.next = left.next; // 当前节点 与 插入位置右侧节点 相连
                left.next = cur; // 当前节点 与 插入位置左侧节点 相连
                cur = next; // 迭代到原来的 当前节点右侧节点
            }

            return start.next; // 返回辅助链表的next，不用考虑排序后链表的第0节点在哪里

        }

        public ListNode InsertionSortList_V3(ListNode head)
        {
            if (head?.next == null) return head;

            var cur = head;
            var max = head;
            var start = new ListNode(0);
            start.next = head;

            while (cur!=null)
            {
                var next = cur.next;
                if (max.val <= cur.val)
                    max = cur;
                else
                {
                    var left = start;
                    while (left.next != null && left.next.val < cur.val) left = left.next;
                    max.next = cur.next;
                    cur.next = left.next;
                    left.next = cur;
                }

                cur = next;
            }

            return start.next;
        }
    }
}
