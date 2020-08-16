using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class flood_fill_test
    {
        [Test]
        public void test()
        {
            var tClass = new flood_fill();


            var nums = new int[][]{ 
                    new int[]{1,1,1}, 
                    new int[] { 1,1,0}, 
                    new int[] {1,0,1 },
                };
            var l = 1;
            var r = 1;
            var color = 2;
            var res = tClass.FloodFill(nums, l, r, color);
            Assert.IsTrue(res.Length ==3);
                
                
        }
    }
}
