using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reorder_list_test
    {
        private reorder_list  target = new reorder_list();

        [Test]
        public void test()
        {
            ListNode node = new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4))));
            target.ReorderList(node);
            Assert.IsTrue(node.ToString() == "1,4,2,3");

            node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            target.ReorderList(node);
            Assert.IsTrue(node.ToString() == "1,5,2,4,3");

            node = new ListNode(1, new ListNode(2));
            target.ReorderList(node);
            Assert.IsTrue(node.ToString() == "1,2");

            node = new ListNode(1);
            target.ReorderList(node);
            Assert.IsTrue(node.ToString() == "1");


            node = null;
            target.ReorderList(node);
            Assert.IsNull(node);

        }
    }
}
