using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetcodeTests
{

    public class binary_search_test
    {
        private binary_search _target;
        
        [SetUp]
        public void init()
        {
            _target = new binary_search();
        }
        [Test]
        [TestCase(new int[] { 1, 2, 3, }, 0, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2, 3, }, 5, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2, 3, },3, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 },5, ExpectedResult = 4)]
        public int test(int[] nums, int target)
        {
            return _target.Search(nums, target);
        }
    }
}
