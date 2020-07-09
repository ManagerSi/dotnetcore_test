using Leetcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 19. 删除链表的倒数第N个节点
    /// https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/
    /// </summary>
    public class remove_nth_node_from_end_of_list
    {
        /// <summary>
        /// 设两个指针k,j; k先走n步后，j和k一起走，等k走到队尾，则j所在位置即使倒数第n位
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var k = head;//先走n步
            var j = head;//k走n步以后开始走
            //先走n步
            while (n>0)
            {
                k = k.next;
                n--;
            }

            //直接到队尾
            if (k == null)
            {
                if (j.next == null)
                    return null;
                else
                    return j.next;
            }

            //走到队尾
            while(k?.next != null)
            {
                k = k.next;
                j = j.next;
            }
            j.next = j.next?.next;

            return head;
        }
    }
}
