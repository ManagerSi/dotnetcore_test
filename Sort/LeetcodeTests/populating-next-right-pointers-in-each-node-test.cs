using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;
using Node = Leetcode.Problems.populating_next_right_pointers_in_each_node_ii.Node;

namespace LeetcodeTests
{
    class populating_next_right_pointers_in_each_node_test
    {
        populating_next_right_pointers_in_each_node target = new populating_next_right_pointers_in_each_node();

        [Test]
        public void test()
        {
            var node = new Node(1,
                new Node(2, new Node(4), new Node(5)),
                new Node(3, new Node(6), new Node(7)));
            var res = target.Connect(node);

            Assert.True(res.left.next == res.right);
        }

        [Test]
        public void test_V1()
        {
            var node = new Node(1,
                new Node(2, new Node(4), new Node(5)),
                new Node(3, new Node(6), new Node(7)));
            var res = target.Connect_V1(node);

            Assert.True(res.left.next == res.right);
        }
    }
}
