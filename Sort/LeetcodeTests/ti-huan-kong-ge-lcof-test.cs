using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class ti_huan_kong_ge_lcof_test
    {
        [Test]
        public void test()
        {
            var tclass = new ti_huan_kong_ge_lcof();
            var str = "abcd efg hijklmn";

            var res = tclass.ReplaceSpace(str);
            Assert.True(res == "abcd%20efg%20hijklmn");

        }

        [Test]
        public void test_V2()
        {
            var tclass = new ti_huan_kong_ge_lcof();
            var str = "abcd efg hijklmn";

            var res = tclass.ReplaceSpace_V2(str);
            Assert.True(res == "abcd%20efg%20hijklmn");

        }
    }
}
