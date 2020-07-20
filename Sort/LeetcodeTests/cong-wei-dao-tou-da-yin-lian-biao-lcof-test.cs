using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class cong_wei_dao_tou_da_yin_lian_biao_lcof_test
    {
        [Test]
        public void test()
        {
            var targetClass = new cong_wei_dao_tou_da_yin_lian_biao_lcof();

            var head = new ListNode(1, new ListNode(3, new ListNode(2)));
            var res = targetClass.ReversePrint(head);
            Assert.True(res[0]== 2);
        }

        [Test]
        public void test_V2()
        {
            var targetClass = new cong_wei_dao_tou_da_yin_lian_biao_lcof();

            var head = new ListNode(1, new ListNode(3, new ListNode(2)));
            var res = targetClass.ReversePrint_V2(head);
            Assert.True(res[0] == 2);
        }
    }
}
