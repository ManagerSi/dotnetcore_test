using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class possible_bipartition_test
    {
        private possible_bipartition target = new possible_bipartition();


        [Test]
        public void Test()
        {
            int n = 4;
            int[][] dislikes = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 3 },
                new int[] { 2, 4 },
            };
            var result = target.PossibleBipartition(n, dislikes);
            Assert.IsTrue(result);
        }
}

}
