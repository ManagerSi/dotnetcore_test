using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class odd_even_linked_list_test
    {
        odd_even_linked_list target = new odd_even_linked_list();

        [Test]
        public void test()
        {
            ListNode node = new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4,new ListNode(5)))));
            var res = target.OddEvenList(node);
            Assert.IsTrue(res.ToString() == "1,3,5,2,4");

            node = new ListNode(2, new ListNode(1, new ListNode(3, new ListNode(5, new ListNode(6,new ListNode(4,new ListNode(7)))))));
            res = target.OddEvenList(node);
            Assert.IsTrue(res.ToString() == "2,3,6,7,1,5,4");
        }
    }
}
