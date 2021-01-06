using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Extend;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class evaluate_division_test
    {
        evaluate_division target = new evaluate_division();

        [Test]
        public void test1()
        {
            IList<IList<string>> equations = new List<IList<string>>()
            {
                new List<string>(){ "a", "b" }, 
                new List<string>(){ "b", "c" }
            };

            double[] values = new[] {2.0, 3.0};
            IList< IList<string> > queries = new List<IList<string>>()
            {
                new List<string>(){ "a", "c" },
                new List<string>(){ "b","a" },
                new List<string>(){"a","e" },
                new List<string>(){ "a","a" },
                new List<string>(){ "x","x" },
            };

            var res = target.CalcEquation(equations, values, queries);
            Assert.IsTrue(DoubleExtent.ToString(res) == "6,0.5,-1,1,-1");

        }

        [Test]
        public void test2()
        {
            IList<IList<string>> equations = new List<IList<string>>()
            {
                new List<string>(){ "a", "b" },
                new List<string>(){ "b", "c" },
                new List<string>(){ "bc","cd" },
            };

            double[] values = new[] { 1.5, 2.5, 5.0 };
            IList<IList<string>> queries = new List<IList<string>>()
            {
                new List<string>(){ "a", "c" },
                new List<string>(){ "c","b" },
                new List<string>(){"bc","cd"},
                new List<string>(){ "cd","bc"},
            };

            var res = target.CalcEquation(equations, values, queries);
            Assert.IsTrue(DoubleExtent.ToString(res) == "3.75,0.4,5,0.2");

        }

        [Test]
        public void test3()
        {
            IList<IList<string>> equations = new List<IList<string>>()
            {
                new List<string>(){ "a", "b" },
            };

            double[] values = new[] {0.5};
            IList<IList<string>> queries = new List<IList<string>>()
            {
                new List<string>(){ "a", "b" },
                new List<string>(){ "b","a" },
                new List<string>(){"a","c"},
                new List<string>(){ "x","y"},
            };

            var res = target.CalcEquation(equations, values, queries);
            Assert.IsTrue(DoubleExtent.ToString(res) == "0.5,2,-1,-1");

        }
    }
}
