using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class insert_interval_test
    {
        insert_interval target = new insert_interval();

        [Test]
        public void test()
        {
            //合并区间
            int[][] nums = new[]
            {
                new[] {1, 3},
                new[] {6, 9},
            };
            int[] interval = new[] { 2, 5 };
            var res = target.Insert(nums, interval);
            Assert.IsTrue(ArrayToString(res)=="1,5,6,9");


            nums = new[]
            {
                new[] {1,2},
                new[] {3,5},
                new[] {6,7},
                new[] {8,10},
                new[] {12,16},
            };
            interval = new[] { 4,8 };
            res = target.Insert(nums, interval);
            Assert.IsTrue(ArrayToString(res)=="1,2,3,10,12,16");
            
            //新增区间
            nums = null;
            interval = new[] { 4, 8 };
            res = target.Insert(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "4,8");

            //新增区间在头部
            nums = new[]
            {
                new[] {6, 9},
            };
            interval = new[] { 1, 3 };
            res = target.Insert(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,3,6,9");

            //新增区间在尾部
            nums = new[]
            {
                new[] { 1, 3},
            };
            interval = new[] { 6, 9 };
            res = target.Insert(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,3,6,9");
        }

        [Test]
        public void test_V2()
        {
            //合并区间
            int[][] nums = new[]
            {
                new[] {1, 3},
                new[] {6, 9},
            };
            int[] interval = new[] { 2, 5 };
            var res = target.Insert_V2(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,5,6,9");


            nums = new[]
            {
                new[] {1,2},
                new[] {3,5},
                new[] {6,7},
                new[] {8,10},
                new[] {12,16},
            };
            interval = new[] { 4, 8 };
            res = target.Insert_V2(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,2,3,10,12,16");

            //新增区间
            nums = null;
            interval = new[] { 4, 8 };
            res = target.Insert_V2(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "4,8");

            //新增区间在头部
            nums = new[]
            {
                new[] {6, 9},
            };
            interval = new[] { 1, 3 };
            res = target.Insert_V2(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,3,6,9");

            //新增区间在尾部
            nums = new[]
            {
                new[] { 1, 3},
            };
            interval = new[] { 6, 9 };
            res = target.Insert_V2(nums, interval);
            Assert.IsTrue(ArrayToString(res) == "1,3,6,9");
        }





        private string ArrayToString(int[][] input)
        {
            if(input==null || input.Length==0) return String.Empty;

            return string.Join(",", input.SelectMany(i => i));
        }
    }
}
