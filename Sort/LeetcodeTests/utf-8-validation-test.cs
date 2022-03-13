using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class utf_8_validation_test
    {
        private utf_8_validation target = new utf_8_validation();

        [Test]
        [TestCase(new int[] { 197, 130, 1 }, ExpectedResult = true)]
        [TestCase(new int[] { 235, 140, 4 }, ExpectedResult = false)]
        [TestCase(new int[] { 237 }, ExpectedResult = false)]
        [TestCase(new int[] { 145 }, ExpectedResult = false)]
        [TestCase(new int[] { 10 }, ExpectedResult = true)]
        public bool test(int[] data)
        {
            return target.ValidUtf8(data);
        }
    }
}
