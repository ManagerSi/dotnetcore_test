using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof_test
    {
        [Test]
        public void test()
        {
            var tclass = new xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof();

            //var num = new int[] {  };
            //var res = tclass.MinArray(num);
            //Assert.True(res == 0);

            var num = new int[] { 3 };
            var res = tclass.MinArray(num);
            Assert.True(res == 3);


            num = new int[] { 1, 2, 3, 4, 5, };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 5, 1, 2, 3, 4, };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 4, 5, 1, 2, 3, };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3, 4, 5, 1, 2 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 2, 3, 4, 5, 1, };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

        }

        [Test]
        public void test1()
        {
            var tclass = new xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof();

            var num = new int[] { 0, 1, 2, 2, 2, };
            var res = tclass.MinArray(num);
            Assert.True(res == 0);

            num = new int[] { 2, 0, 1, 2, 2, };
            res = tclass.MinArray(num);
            Assert.True(res == 0);

            num = new int[] { 2, 2, 0, 1, 2,  };
            res = tclass.MinArray(num);
            Assert.True(res == 0);

            num = new int[] { 2, 2, 2, 0, 1 };
            res = tclass.MinArray(num);
            Assert.True(res == 0);
        }

        [Test]
        public void test2()
        {
            var tclass = new xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof();

            var num = new int[] { 3,1,1,1 };
            var res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3, 1, 1, 1, 1 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);
        }

        [Test]
        public void test3()
        {
            var tclass = new xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof();

            var num = new int[] { 1, 1, 1 };
            var res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3,3,1,3 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3, 1, 3, 3 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3,3,1,3,3,3,3,3,3,3,3, 3, 3,3,3,3,3,3,3,3,3,3,3 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

            num = new int[] { 3, 3,  3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);
        }

        [Test]
        public void test4()
        {
            var tclass = new xuan_zhuan_shu_zu_de_zui_xiao_shu_zi_lcof();

            var num = new int[] { 1, 2, 2, 2, 0, 1, 1 };
            var res = tclass.MinArray(num);
            Assert.True(res == 0);

            num = new int[] { 3, 3, 1, 3 };
            res = tclass.MinArray(num);
            Assert.True(res == 1);

        }
    }
}