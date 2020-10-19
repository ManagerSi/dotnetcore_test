using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class backspace_string_compare_test
    {
        backspace_string_compare target = new backspace_string_compare();

        [Test]
        public void test()
        {
            string s = "";
            string t = "";
            var res = target.BackspaceCompare(s, t);
            Assert.IsTrue(res);

            s = "ab#c";
            t = "ad#c";
            res = target.BackspaceCompare(s, t);
            Assert.IsTrue(res);

            s = "";
            t = "ad#c###";
            res = target.BackspaceCompare(s, t);
            Assert.IsTrue(res);

            s = "ab##";
            t = "c#d#";
            res = target.BackspaceCompare(s, t);
            Assert.IsTrue(res);

            s = "a##c";
            t = "#a#c";
            res = target.BackspaceCompare(s, t);
            Assert.IsTrue(res);

            s = "a#c";
            t = "d";
            res = target.BackspaceCompare(s, t);
            Assert.IsFalse(res);
        }

        

        [Test]
        public void test_V3()
        {
            string s = "";
            string t = "";
            var res = target.BackspaceCompare_V3(s, t);
            Assert.IsTrue(res);

            s = "ab#c";
            t = "ad#c";
            res = target.BackspaceCompare_V3(s, t);
            Assert.IsTrue(res);

            s = "";
            t = "ad#c###";
            res = target.BackspaceCompare_V3(s, t);
            Assert.IsTrue(res);

            s = "ab##";
            t = "c#d#";
            res = target.BackspaceCompare_V3(s, t);
            Assert.IsTrue(res);

            s = "a##c";
            t = "#a#c";
            res = target.BackspaceCompare_V3(s, t);
            Assert.IsTrue(res);

            s = "a#c";
            t = "d";
            res = target.BackspaceCompare_V3(s, t);
            Assert.IsFalse(res);
        }


        [Test]
        public void test_V4()
        {
            string s = "";
            string t = "";
            var res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "###ac#";
            t = "a";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "ab#c";
            t = "ad#c";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "";
            t = "ad#c###";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "ab##";
            t = "c#d#";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "a##c";
            t = "#a#c";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsTrue(res);

            s = "a#c";
            t = "d";
            res = target.BackspaceCompare_V4(s, t);
            Assert.IsFalse(res);
        }
    }
}
