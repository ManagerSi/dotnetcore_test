using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class best_time_to_buy_and_sell_stock_ii_test
    {
        best_time_to_buy_and_sell_stock_ii  target = new best_time_to_buy_and_sell_stock_ii();

        [Test]
        [TestCase(new int[]{ 7, 1, 5, 3, 6, 4 },ExpectedResult = 7)]
        [TestCase(new int[] { 1, 2, 3, }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, ExpectedResult = 0)]
        public int test(int[] prices)
        {
            return target.MaxProfit(prices);
        }

        [Test]
        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, ExpectedResult = 7)]
        [TestCase(new int[] { 1, 2, 3, }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, ExpectedResult = 0)]
        public int test_V2(int[] prices)
        {
            return target.MaxProfit_V2(prices);
        }
    }
}
