using Leetcode.Problems.剑指offer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeTests.剑指offer
{
    class ju_zhen_zhong_de_lu_jing_lcof_test
    {
        private ju_zhen_zhong_de_lu_jing_lcof tClass = new ju_zhen_zhong_de_lu_jing_lcof();
        [Test]
        public void test()
        {
            var nums = new char[][]{
                new char[]{ 'A', 'B', 'C', 'E'},
                new char[]{'S','F','C','S' },
                new char[]{'A','D','E','E' },
            };
            string word = "ABCCED";
            var res = tClass.Exist(nums, word);
            Assert.IsTrue(res);

            nums = new char[][]{
                new char[]{ 'a', 'a',},
            };
            word = "aa";
            res = tClass.Exist(nums, word);
            Assert.IsTrue(res);

            word = "aaa";
            res = tClass.Exist(nums, word);
            Assert.False(res);


            nums = new char[][]{
                new char[]{'C','A','A'},
                new char[]{'A','A','A'},
                new char[]{'B','C','D'},
            };
            word = "AAB";
            res = tClass.Exist(nums, word);
            Assert.IsTrue(res);


        }
    }
}
