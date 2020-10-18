using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
 public   class remove_nth_node_from_end_of_list_test
    {
        [Test]
        public void test()
        {
            var node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

            var result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd(node, 2);

            while (result.next != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
            Assert.Pass();
        }
        [Test]
        public void test1()
        {
            var node = new ListNode(1);

            var result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd(node, 1);

            while (result?.next != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
            Assert.Pass();
        }
        [Test]
        public void test2()
        {
            var node = new ListNode(1,new ListNode(2));

            var result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd(node, 2);

            while (result?.next != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
            Assert.Pass();
        }

        [Test]
        public void test_V2()
        {
            var node = new ListNode(1, new ListNode(2));
            var result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd_V2(node, 2);
            Assert.IsTrue(result?.ToString()=="2");

            node = new ListNode(1);
            result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd_V2(node, 1);
            Assert.IsTrue(result==null);

            node = new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4))));
            result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd_V2(node, 1);
            Assert.IsTrue(result?.ToString() == "1,2,3");

            node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            result = new remove_nth_node_from_end_of_list().RemoveNthFromEnd_V2(node, 4);
            Assert.IsTrue(result?.ToString() == "2,3,4");
        }
    }
}
