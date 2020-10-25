using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class swap_nodes_in_pairs_test
    {
        swap_nodes_in_pairs target = new swap_nodes_in_pairs();

        [Test]
        public void test()
        {
            ListNode node = new ListNode(1,new ListNode(2,new ListNode(3,new ListNode(4))));
            var res = target.SwapPairs(node);
            Assert.IsTrue(res.ToString() == "2,1,4,3");

            node = new ListNode(1, new ListNode(2, new ListNode(3)));
            res = target.SwapPairs(node);
            Assert.IsTrue(res.ToString() == "2,1,3");

            node = new ListNode(1);
            res = target.SwapPairs(node);
            Assert.IsTrue(res.ToString() == "1");

            node = null;
            res = target.SwapPairs(node);
            Assert.IsNull(res);
        }
    }
}
