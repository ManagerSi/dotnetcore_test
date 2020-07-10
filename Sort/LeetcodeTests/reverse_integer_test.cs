using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;

namespace LeetcodeTests
{
    public class reverse_integer_test
    {
        [Test]
        public void test1()
        {
            int i = 123;
            var result = new reverse_integer().Reverse(i);

            Assert.IsTrue(result == 321);
        }

        [Test]
        public void test_nagetive()
        {
            int i = -123;
            var result = new reverse_integer().Reverse(i);

            Assert.IsTrue(result == -321);
        }

        [Test]
        public void test_v3()
        {
            int i = 123;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == 321);
        }

        [Test]
        public void test_v3_102()
        {
            int i = 102;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == 201);
        }
        [Test]
        public void test_v3_120()
        {
            int i = 120;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == 21);
        }

        [Test]
        public void test_v3_nagetive()
        {
            int i = -123;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == -321);
        }

        
        [Test]
        public void test_v3_1534236469()
        {
            int i = 1534236469;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == 0);
        }


        [Test]
        public void test_v3_2147483648()
        {
            int i = -2147483648;
            var result = new reverse_integer().Reverse_V3(i);

            Assert.IsTrue(result == 0);
        }
    }
}
