using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class matrix_cells_in_distance_order_test
    {
        matrix_cells_in_distance_order target = new matrix_cells_in_distance_order();

        [Test]
        [TestCase(1, 2, 0, 0, ExpectedResult = "0,0,0,1")]
        [TestCase(2, 2, 0, 1, ExpectedResult = "0,1,0,0,1,1,1,0")]
        [TestCase(2, 3, 1, 2, ExpectedResult = "1,2,0,2,1,1,0,1,1,0,0,0")]
        [TestCase(3, 5, 2, 3, ExpectedResult = "2,3,1,3,2,2,2,4,0,3,1,2,1,4,2,1,0,2,0,4,1,1,2,0,0,1,1,0,0,0")]
        public string test(int R, int C, int r0, int c0)
        {
            return IntExtent.ToString(target.AllCellsDistOrder(R, C, r0, c0));
        }
    }
}
