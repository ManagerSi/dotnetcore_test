using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    internal class number_of_recent_calls_test
    {
        public number_of_recent_calls target;

        [SetUp]
        public void setup()
        {
            target = new number_of_recent_calls();
        }
        [TestCase(new int[]{1,100,3001,3002}, ExpectedResult = "1,2,3,3")]
        public string test(int[] args)
        {
            List<int> results = new List<int>();
            //args always has value
            foreach (var i in args)
            {
                results.Add(target.Ping(i));
            }
            return string.Join(',',results);
        }
    }
}
