using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class best_time_to_buy_and_sell_stock_test
    {
        best_time_to_buy_and_sell_stock target = new best_time_to_buy_and_sell_stock();

        [Test]
        public void test()
        {
            var prices = new int[]{ 7,1,5,3,6,4} ;
            var res = target.MaxProfit(prices);
            Assert.IsTrue(res == 5);

            prices = new int[] { 7, 6, 4, 3, 1 };
            res = target.MaxProfit(prices);
            Assert.IsTrue(res == 0);

            prices = new int[] { };
            res = target.MaxProfit(prices);
            Assert.IsTrue(res == 0);
        }

        [Test]
        public void test_V1()
        {
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var res = target.MaxProfit_V1(prices);
            Assert.IsTrue(res == 5);

            prices = new int[] { 7, 6, 4, 3, 1 };
            res = target.MaxProfit_V1(prices);
            Assert.IsTrue(res == 0);

            prices = new int[] { };
            res = target.MaxProfit_V1(prices);
            Assert.IsTrue(res == 0);
        }


        [Test]
        public void test_V3()
        {
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var res = target.MaxProfit_V3(prices);
            Assert.IsTrue(res == 5);

            prices = new int[] { 7, 6, 4, 3, 1 };
            res = target.MaxProfit_V3(prices);
            Assert.IsTrue(res == 0);

            prices = new int[] { };
            res = target.MaxProfit_V3(prices);
            Assert.IsTrue(res == 0);
        }


        [Test]
        public void test_V4()
        {
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var res = target.MaxProfit_V4(prices);
            Assert.IsTrue(res == 5);

            prices = new int[] { 7, 6, 4, 3, 1 };
            res = target.MaxProfit_V4(prices);
            Assert.IsTrue(res == 0);

            prices = new int[] { };
            res = target.MaxProfit_V4(prices);
            Assert.IsTrue(res == 0);
        }
    }
}
