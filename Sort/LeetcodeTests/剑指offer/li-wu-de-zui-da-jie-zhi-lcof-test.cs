using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;

namespace LeetcodeTests.剑指offer
{
    class li_wu_de_zui_da_jie_zhi_lcof_test
    {
        [Test]
        public void test()
        {
            var tClass = new li_wu_de_zui_da_jie_zhi_lcof();

            var grid =  new int[][] {
                new int[] { 1, 3, 1 }, 
                new int[] { 1, 5, 1 }, 
                new int[] { 4, 2, 1 }

            };
            var res = tClass.MaxValue(grid);
            Assert.True(res == 12);
        }

        [Test]
        public void test_V1()
        {
            var tClass = new li_wu_de_zui_da_jie_zhi_lcof();

            var grid = new int[][] {
                new int[] { 1, 3, 1 },
                new int[] { 1, 5, 1 },
                new int[] { 4, 2, 1 }

            };
            var res = tClass.MaxValue_V1(grid);
            Assert.True(res == 12);
        }

        [Test]
        public void test_V2()
        {
            var tClass = new li_wu_de_zui_da_jie_zhi_lcof();

            var grid = new int[][] {
                new int[] { 1, 3, 1 },
                new int[] { 1, 5, 1 },
                new int[] { 4, 2, 1 }

            };
            var res = tClass.MaxValue_V2(grid);
            Assert.True(res == 12);
        }
    }
}
