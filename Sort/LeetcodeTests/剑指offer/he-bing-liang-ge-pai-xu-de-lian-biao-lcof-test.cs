using Leetcode.Model;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    class he_bing_liang_ge_pai_xu_de_lian_biao_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new he_bing_liang_ge_pai_xu_de_lian_biao_lcof();

            var l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            var res = tClass.MergeTwoLists(l1, l2);
            Assert.IsTrue(res.ToString() == "1,1,2,3,4,4");
        }
    }
}
