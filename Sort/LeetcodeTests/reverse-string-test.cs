using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class reverse_string_test
    {
        reverse_string target = new reverse_string();

        [Test]
        public void test()
        {
            var c = new char[]{ 'h','e','l','l','o'};
            target.ReverseString(c);
            Assert.IsTrue(string.Join(",",c) == "o,l,l,e,h");

            c = new char[] {  };
            target.ReverseString(c);
            Assert.IsTrue(string.Join(",", c) == "");

            c = new char[] { 'h' };
            target.ReverseString(c);
            Assert.IsTrue(string.Join(",", c) == "h");
        }

        [Test]
        public void test_V1()
        {
            var c = new char[] { 'h', 'e', 'l', 'l', 'o' };
            target.ReverseString_V1(c);
            Assert.IsTrue(string.Join(",", c) == "o,l,l,e,h");

            c = new char[] { };
            target.ReverseString_V1(c);
            Assert.IsTrue(string.Join(",", c) == "");

            c = new char[] { 'h' };
            target.ReverseString_V1(c);
            Assert.IsTrue(string.Join(",", c) == "h");
        }


        [Test]
        public void test_V2()
        {
            var c = new char[] { 'h', 'e', 'l', 'l', 'o' };
            target.ReverseString_V2(c);
            Assert.IsTrue(string.Join(",", c) == "o,l,l,e,h");

            c = new char[] { };
            target.ReverseString_V2(c);
            Assert.IsTrue(string.Join(",", c) == "");

            c = new char[] { 'h' };
            target.ReverseString_V2(c);
            Assert.IsTrue(string.Join(",", c) == "h");
        }
    }
}
