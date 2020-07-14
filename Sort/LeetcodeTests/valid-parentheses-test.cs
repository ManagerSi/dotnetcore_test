using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class valid_parentheses_test
    {
        [Test]
        public void test_success()
        {
            var validClass = new valid_parentheses();

            string s = "()";
            var res = validClass.IsValid(s);
            Assert.True(res);

            s = "()[]{}";
             res = validClass.IsValid(s);
            Assert.True(res);
        }

        [Test]
        public void test_empty()
        {
            var validClass = new valid_parentheses();

            var s = "";
            var res = validClass.IsValid(s);
            Assert.True(res);

            s = null;
            res = validClass.IsValid(s);
            Assert.True(res);
        }

        [Test]
        public void test_false()
        {
            var validClass = new valid_parentheses();

            var s = "(]";
            var res = validClass.IsValid(s);
            Assert.False(res);

            s = "(]";
            res = validClass.IsValid(s);
            Assert.False(res);

            s = "]";
            res = validClass.IsValid(s);
            Assert.False(res);
            
        }

        #region V2
        [Test]
        public void test_V2_success()
        {
            var validClass = new valid_parentheses();

            string s = "()";
            var res = validClass.IsValid_V2(s);
            Assert.True(res);

            s = "()[]{}";
            res = validClass.IsValid_V2(s);
            Assert.True(res);
        }

        [Test]
        public void test_V2_empty()
        {
            var validClass = new valid_parentheses();

            var s = "";
            var res = validClass.IsValid_V2(s);
            Assert.True(res);

            s = null;
            res = validClass.IsValid_V2(s);
            Assert.True(res);
        }

        [Test]
        public void test_V2_false()
        {
            var validClass = new valid_parentheses();

            var s = "(]";
            var res = validClass.IsValid_V2(s);
            Assert.False(res);

            s = "(]";
            res = validClass.IsValid_V2(s);
            Assert.False(res);

            s = "]";
            res = validClass.IsValid_V2(s);
            Assert.False(res);

        }
        #endregion
    }
}
