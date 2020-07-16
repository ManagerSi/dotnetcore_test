using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class linked_list_cycle_test
    {
        [Test]
        public void test()
        {
            var target = new linked_list_cycle();

            ListNode node = new ListNode(-4);
            ListNode head = new ListNode(3,new ListNode(2,new ListNode(0, node)));
            node.next = head.next;//成环

            var res = target.HasCycle(head);

            Assert.IsTrue(res);
        }

        [Test]
        public void test_V2()
        {
            var target = new linked_list_cycle();

            ListNode node = new ListNode(-4);
            ListNode head = new ListNode(3, new ListNode(2, new ListNode(0, node)));
            node.next = head.next;//成环

            var res = target.HasCycle_V2(head);

            Assert.IsTrue(res);

        }
    }
}
