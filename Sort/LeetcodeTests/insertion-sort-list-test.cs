using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class insertion_sort_list_test
    {
        insertion_sort_list target = new insertion_sort_list();

        static IEnumerable<TestCaseData> testCaseDatas()
        {
            yield return new TestCaseData(new ListNode(1, new ListNode(2, new ListNode(3)))).Returns("1,2,3");
            yield return new TestCaseData(new ListNode(3, new ListNode(2, new ListNode(1)))).Returns("1,2,3");
            yield return new TestCaseData(new ListNode(2, new ListNode(2, new ListNode(1)))).Returns("1,2,2");
            yield return new TestCaseData(new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))))).Returns("1,2,3,4");
            yield return new TestCaseData(new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4,new ListNode(0)))))).Returns("-1,0,3,4,5");
        }

        [Test]
        [TestCaseSource("testCaseDatas")]
        public string test(ListNode input)
        {
            var res = target.InsertionSortList(input);
            return (res.ToString());
        }

        [TestCaseSource("testCaseDatas")]
        public string test_V2(ListNode input)
        {
            var res = target.InsertionSortList_V2(input);
            return (res.ToString());
        }

        [TestCaseSource("testCaseDatas")]
        public string test_V3(ListNode input)
        {
            var res = target.InsertionSortList_V3(input);
            return (res.ToString());
        }
    }
}
