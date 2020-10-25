using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class partition_equal_subset_sum_test
    {
        partition_equal_subset_sum target = new partition_equal_subset_sum();

        [Test]
        public void test()
        {
            int[] nums = new int[] { };
            var result = target.CanPartition(nums);
            Assert.IsFalse(result);

            nums = new int[] {3 };
            result = target.CanPartition(nums);
            Assert.IsFalse(result);

            nums = new int[] { 1, 5, 11, 5 };
            result = target.CanPartition(nums);
            Assert.IsTrue(result);
            
            nums = new int[] { 1, 2, 3, 5 };
            result = target.CanPartition(nums);
            Assert.IsFalse(result);

            nums = new int[] { 1, 1 };
            result = target.CanPartition(nums);
            Assert.IsTrue(result);
        }
    }
}
