using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leetcode.Problems;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace LeetcodeTests
{
    /// </summary>
    public class find_all_numbers_disappeared_in_an_array_test
    {
        find_all_numbers_disappeared_in_an_array target = new find_all_numbers_disappeared_in_an_array();

        [Test]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        //[TestCase(new int[] { 4, 2, 3, 1 }, ExpectedResult = (IList<int>)null)]
        [TestCase(new int[] { 4, 2, 3, 1 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 4, 3, 2, 7, 7, 2, 3, 1 }, ExpectedResult = new int[] { 5, 6, 8 })]
        [TestCase(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, ExpectedResult = new int[] { 5, 6 })]
        public int[] test(int[] nums)
        {
            return target.FindDisappearedNumbers_V2(nums)?.ToArray();
        }
    }
}
