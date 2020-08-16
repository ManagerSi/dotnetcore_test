using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;

namespace LeetcodeTests.剑指offer
{
    class er_jin_zhi_zhong_1de_ge_shu_lcof_test
    {
        [Test]
        public void test_success()
        {
            var tClass = new er_jin_zhi_zhong_1de_ge_shu_lcof();
            uint input = 00110011u;

            var res = tClass.HammingWeight(input);
            Assert.True(res == 4);

        }

        [Test]
        public void test_V2_success()
        {
            var tClass = new er_jin_zhi_zhong_1de_ge_shu_lcof();

            uint input = 00110011u;
            var res = tClass.HammingWeight_V2(input);
            Assert.True(res == 4);

             input = 000111001011;
             res = tClass.HammingWeight_V2(input);
            Assert.True(res == 6);

            input = 00000000000000000000000010000000;
            res = tClass.HammingWeight_V2(input);
            Assert.True(res == 1);
            
        }
    }
}
