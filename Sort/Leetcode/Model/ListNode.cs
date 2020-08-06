using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Model
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val)
        {
            this.val = val;
        }
        public ListNode(int val, ListNode next)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(val);

            var tempN = next;
            while (tempN != null)
            {
                sb.Append(",");
                sb.Append(tempN.val);
                tempN = tempN.next;
            }
            return sb.ToString();
        }
    }
}
