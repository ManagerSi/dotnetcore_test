using Leetcode.Problems;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests
{
    public class shift_2d_grid_test
    {
        shift_2d_grid target = new shift_2d_grid();

        [Test]
        public void MyTest()
        {
            int[][] dp = new int[4][];
            dp[0] = new int[4] { 3, 8, 1, 9 };
            dp[1] = new int[4] { 19, 7, 2, 5 };
            dp[2] = new int[4] { 4, 6, 11, 10 };
            dp[3] = new int[4] { 12, 0, 21, 13 };

            int k = 4;
            var result = target.ShiftGrid(dp,k);
            Assert.NotNull(result);
        }

    }
}
