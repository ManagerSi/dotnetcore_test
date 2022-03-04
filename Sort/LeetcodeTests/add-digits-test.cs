using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Model;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class add_digits_test
    {
        private add_digits target = new add_digits();


        [TestCase(38,ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 1)]
        public int test(int num)
        {
            return target.AddDigits(num);
        }


        [TestCase(38, ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 1)]
        public int test_V2(int num)
        {
            return target.AddDigits_V2(num);
        }

        [TestCase(38, ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 1)]
        public int test_V3(int num)
        {
            return target.AddDigits_V3(num);
        }
    }
}
