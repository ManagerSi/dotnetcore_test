using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;

namespace LeetcodeTests
{
    class reverse_linked_list_test
    {
        [Test]
        public void test()
        {
            var target = new reverse_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var res = target.ReverseList(head);
            Assert.True(res.val==5);

            head = new ListNode(1);
            res = target.ReverseList(head);
            Assert.True(res.val == 1);

            head = null;
            res = target.ReverseList(head);
            Assert.True(res==null);
        }

        [Test]
        public void test_V2()
        {
            var target = new reverse_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var res = target.ReverseList_V2(head);
            Assert.True(res.val == 5);

            head = new ListNode(1);
            res = target.ReverseList_V2(head);
            Assert.True(res.val == 1);

            head = null;
            res = target.ReverseList_V2(head);
            Assert.True(res == null);
        }


        [Test]
        public void test_V3()
        {
            var target = new reverse_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var res = target.ReverseList_V3(head);
            Assert.True(res.val == 5);

            head = new ListNode(1);
            res = target.ReverseList_V3(head);
            Assert.True(res.val == 1);

            head = null;
            res = target.ReverseList_V3(head);
            Assert.True(res == null);
        }


        [Test]
        public void test_V4()
        {
            var target = new reverse_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var res = target.ReverseList_V4(head);
            Assert.True(res.val == 5);

            head = new ListNode(1);
            res = target.ReverseList_V4(head);
            Assert.True(res.val == 1);

            head = null;
            res = target.ReverseList_V4(head);
            Assert.True(res == null);
        }
    }
}
