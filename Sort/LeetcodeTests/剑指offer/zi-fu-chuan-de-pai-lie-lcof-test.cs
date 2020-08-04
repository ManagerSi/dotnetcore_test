using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    class zi_fu_chuan_de_pai_lie_lcof_test
    {
        [Test]
        public void MyTest()
        {
            var tClass = new zi_fu_chuan_de_pai_lie_lcof();

            var s = "abc";
            var res = tClass.Permutation(s);
            Assert.True(res.Length == 6);
        }
    }
}
