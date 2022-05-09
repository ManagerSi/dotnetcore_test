using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class di_string_match_test
    {
        private di_string_match target = new di_string_match();
        
        [TestCase("IDID", ExpectedResult = new int[]{ 0, 4, 1, 3, 2 })]
        [TestCase("III", ExpectedResult = new int[] { 0, 1, 2, 3 })]
        [TestCase("DDI", ExpectedResult = new int[] { 3, 2, 0, 1 })]
        public int[] test(string s)
        {
            return target.DiStringMatch(s);
        }
    }
}
