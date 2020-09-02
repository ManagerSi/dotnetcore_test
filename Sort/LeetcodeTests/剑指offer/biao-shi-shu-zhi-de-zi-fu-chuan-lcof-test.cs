using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems.剑指offer;
using NUnit.Framework;

namespace LeetcodeTests.剑指offer
{
    class biao_shi_shu_zhi_de_zi_fu_chuan_lcof_test
    {
        private biao_shi_shu_zhi_de_zi_fu_chuan_lcof target = new biao_shi_shu_zhi_de_zi_fu_chuan_lcof();

        /// <summary>
        /// ".8+" 不通过
        /// </summary>
        [Test]
        public void test()
        {
            var trueStr = new string[]{
                "+100","5e2","-123","3.1416","-1E-16","0123"
            };
            foreach (var s in trueStr)
            {
                var res = target.IsNumber(s);
                Assert.True(res);
            }

            var falseStr = new string[] {  "12e", "1a3.14", "1.2.3", "+-5", "12e+5.4"}; 
            foreach (var s in falseStr)
            {
                var res = target.IsNumber(s);
                Assert.False(res);
            }
        }


        [Test]
        public void test_V2()
        {
            var trueStr = new string[]{ "1 ","+100","5e2","-123","3.1416","-1E-16","0123"
            };
            foreach (var s in trueStr)
            {
                var res = target.IsNumber_V2(s);
                Assert.True(res);
            }

            var falseStr = new string[] { ".8+", "12e", "1a3.14", "1.2.3", "+-5", "12e+5.4" };
            foreach (var s in falseStr)
            {
                var res = target.IsNumber_V2(s);
                Assert.False(res);
            }
        }
    }
}
