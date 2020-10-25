using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class palindrome_linked_list_tet
    {
        [Test]
        public void test_true()
        {
            var target = new palindrome_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            var res = target.IsPalindrome(head);
            Assert.True(res);


            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(2, new ListNode(1)))));
            res = target.IsPalindrome(head);
            Assert.True(res);
        }
        [Test]
        public void test_false()
        {
            var target = new palindrome_linked_list();
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(1))));

            var res = target.IsPalindrome(head);
            Assert.False(res);
        }

        [Test]
        public void test_V3()
        {
            var target = new palindrome_linked_list();

            var head = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            var res = target.IsPalindrome_V3(head);
            Assert.True(res);

            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(2, new ListNode(1)))));
            res = target.IsPalindrome_V3(head);
            Assert.True(res);

            target = new palindrome_linked_list();
            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(1))));

            res = target.IsPalindrome(head);
            Assert.False(res);
        }
    }
}
