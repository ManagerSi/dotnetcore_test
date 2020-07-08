using Leetcode.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 2. 两数相加
    /// https://leetcode-cn.com/problems/add-two-numbers/
    /// </summary>
    public class add_two_numbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode  root = new ListNode(0);
            var result = root;
            var carry = 0;
            while(l1 != null || l2 != null || carry != 0)
            {
                var v1 = l1?.val ?? 0;
                var v2 = l2?.val ?? 0;
                var sum = v1 + v2 + carry;
                if (sum >= 10)
                {
                    carry = 1;
                    root.next = new ListNode(sum % 10);
                }
                else
                {
                    carry = 0;
                    root.next = new ListNode(sum);
                }
                l1 = l1.next;
                l2 = l2.next;
                root = root.next;
            }
            return result.next;
        }

    }
}
