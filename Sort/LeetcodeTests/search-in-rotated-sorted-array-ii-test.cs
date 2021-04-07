﻿using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class search_in_rotated_sorted_array_ii_test
    {
        search_in_rotated_sorted_array_ii target = new search_in_rotated_sorted_array_ii();

        [Test]
        [TestCase(new int[]{ 2, 5, 6, 0, 0, 1, 2 }, 0, ExpectedResult = true)]
        [TestCase(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3, ExpectedResult = false)]
        public bool test(int[] nums, int t)
        {
            return target.Search(nums, t);
        }
    }
}
