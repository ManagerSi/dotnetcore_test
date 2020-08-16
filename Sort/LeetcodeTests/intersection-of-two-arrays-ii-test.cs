using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class intersection_of_two_arrays_ii_test
    {
        [Test]
        public void test()
        {
            int[] i1=new int[]{1,2,2,1 };
            int[] i2 = new int[] { 2, 2 };

            var res = new intersection_of_two_arrays_ii().Intersect(i1, i2);

            Assert.Fail();

        }
    }
}
