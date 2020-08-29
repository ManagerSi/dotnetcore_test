using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class minimum_size_subarray_sum_test
    {
        private minimum_size_subarray_sum target = new minimum_size_subarray_sum();

        [Test]
        public void test()
        {
            int[] nums = new int[]{ 2, 3, 1, 2, 4, 3 };
            int s = 7;
            var res = target.MinSubArrayLen(s, nums);
            Assert.True(res == 2);

            //数组为空
            nums = new int[] {  };
            s = 1;
            res = target.MinSubArrayLen(s, nums);
            Assert.True(res == 0);


            //1个数就满足条件
            nums = new int[] { 2, 3, 1, 2, 4, 3 };
            s = 1;
            res = target.MinSubArrayLen(s, nums);
            Assert.True(res == 1);

            //全部加起来也不够20
            nums = new int[] { 2, 3, 1, 2, 4, 3 };
             s = 20; 
            res = target.MinSubArrayLen(s, nums);
            Assert.True(res == 0);
        }
    }
}
