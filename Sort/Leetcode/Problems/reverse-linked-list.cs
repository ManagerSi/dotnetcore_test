using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;

namespace Leetcode.Problems
{
    /// <summary>
    /// 206. 反转链表
    /// https://leetcode-cn.com/problems/reverse-linked-list
    /// </summary>
    public class reverse_linked_list
    {
        private Stack<ListNode> stack = new Stack<ListNode>();
        /// <summary>
        /// 使用栈
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }

            if (stack.Count > 0)
            {
                head = stack.Pop();
            }

            var res = head;
            while (stack.Count > 0)
            {
                head.next = stack.Pop();
                head = head.next;
            }

            head.next = null;

            return res;
        }

        /// <summary>
        /// * 头插法
        /// * 1 -> 2 -> 3 -> 4 -> null
        /// * null <- 1 <- 2 <- 3 <- 4
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList_V2(ListNode head)
        {
            ListNode prev = null; //前指针节点
            ListNode curr = head; //当前指针节点
            //每次循环，都将当前节点指向它前面的节点，然后当前节点和前节点后移
            while (curr != null)
            {
                ListNode nextTemp = curr.next; //临时节点，暂存当前节点的下一节点，用于后移
                curr.next = prev; //将当前节点指向它前面的节点
                prev = curr; //前指针后移
                curr = nextTemp; //当前指针后移
            }
            return prev;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList_V3(ListNode head)
        {
            return Reverse(null, head);
        }

        private ListNode Reverse(ListNode prev, ListNode curr)
        {
            if (curr == null) return prev;

            var next = curr.next;
            curr.next = prev;

            return Reverse(curr, next);
        }


        public ListNode ReverseList_V4(ListNode head)
        {
            // 方法一：逐个将旧链表的节点插入到新链表
            // ListNode new_head = null;  //新链表的尾节点
            // while(head!=null){
            //     ListNode tmp = head;  //记录节点
            //     head = head.next;  //遍历后移
            //     tmp.next = new_head;  //将节点放入新链表表头
            //     new_head = tmp;  //更新新链表的表头
            // }
            // return new_head;

            //方法二：使用三指针遍历
            // if(head==null) return head;
            // ListNode p0 = null;  //新链表的尾节点
            // ListNode p1 = head;  //原链表的表头
            // ListNode p2 = head.next;  //原链表表头的next
            // while(p1!=null){
            //     p1.next = p0;
            //     p0 = p1;
            //     p1 = p2;
            //     if(p2!=null){
            //         p2 = p2.next;
            //     }
            // }
            // return p0;

            //方法三：递归，这个就有点妙了
            if (head == null || head.next == null) return head;
            ListNode p = ReverseList_V4(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
    }
}
