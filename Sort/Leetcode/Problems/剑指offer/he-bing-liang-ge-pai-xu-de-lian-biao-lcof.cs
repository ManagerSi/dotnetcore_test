using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 25. 合并两个排序的链表
    /// https://leetcode-cn.com/problems/he-bing-liang-ge-pai-xu-de-lian-biao-lcof/
    /// </summary>
    public class he_bing_liang_ge_pai_xu_de_lian_biao_lcof
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            ListNode temp = new ListNode(0);
            ListNode res = temp;

            while (l1!=null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = new ListNode(l1.val);
                    temp = temp.next;
                    l1 = l1.next;
                }
                else
                {
                    temp.next = new ListNode(l2.val);
                    temp = temp.next;
                    l2 = l2.next;
                }
            }
            if (l1 != null)
                temp.next = l1;
            if (l2 != null)
                temp.next = l2;

            return res.next;
        }
    }
}
