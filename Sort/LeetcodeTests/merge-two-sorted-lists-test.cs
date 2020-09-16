using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class merge_two_sorted_lists_test
    {
        merge_two_sorted_lists target = new merge_two_sorted_lists();
        [Test]
        public void test()
        {
            var n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var res = target.MergeTwoLists(n1, n2);
            Assert.True(res.ToString() == "1,1,2,3,4,4");


            n1 = null;
            n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            res = target.MergeTwoLists(n1, n2);
            Assert.True(res.ToString() == "1,3,4");

            n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            n2 = null;
            res = target.MergeTwoLists(n1, n2);
            Assert.True(res.ToString() == "1,2,4");

            n1 = null;
            n2 = null;
            res = target.MergeTwoLists(n1, n2);
            Assert.IsNull(res);
        }

        [Test]
        public void test_V2()
        {
            var n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var res = target.MergeTwoLists_V2(n1, n2);
            Assert.True(res.ToString() == "1,1,2,3,4,4");


            n1 = null;
            n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            res = target.MergeTwoLists_V2(n1, n2);
            Assert.True(res.ToString() == "1,3,4");

            n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            n2 = null;
            res = target.MergeTwoLists_V2(n1, n2);
            Assert.True(res.ToString() == "1,2,4");

            n1 = null;
            n2 = null;
            res = target.MergeTwoLists_V2(n1, n2);
            Assert.IsNull(res);
        }

        [Test]
        public void test_V3()
        {
            var n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var res = target.MergeTwoLists_V3(n1, n2);
            Assert.True(res.ToString() == "1,1,2,3,4,4");


            n1 = null;
            n2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            res = target.MergeTwoLists_V3(n1, n2);
            Assert.True(res.ToString() == "1,3,4");

            n1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            n2 = null;
            res = target.MergeTwoLists_V3(n1, n2);
            Assert.True(res.ToString() == "1,2,4");

            n1 = null;
            n2 = null;
            res = target.MergeTwoLists_V3(n1, n2);
            Assert.IsNull(res);
        }
    }
}
