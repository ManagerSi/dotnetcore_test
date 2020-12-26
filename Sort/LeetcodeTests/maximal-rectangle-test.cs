using Leetcode.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetcodeTests
{
    class maximal_rectangle_test
    {
        maximal_rectangle target = new maximal_rectangle();

        static IEnumerable<TestCaseData> geTestCaseDatas
        {
            get
            {
                yield return new TestCaseData((object)new char[][] { }).Returns(0);
                yield return new TestCaseData((object)new char[][] {new []{'0'} }).Returns(0);
                yield return new TestCaseData((object)new char[][] { new[] { '1' } }).Returns(1);
                yield return new TestCaseData((object)new char[][] {new char[] {'0', '1'}, new char[] {'0', '1'}}).Returns(2);
                yield return new TestCaseData((object)new char[][] { 
                        new char[] { '1', '0', '1', '0', '0' }, 
                        new char[] { '1', '0', '1', '1', '1' },
                        new char[] { '1','1','1','1','1' },
                        new char[] { '1','0','0','1','0' },
                    }).Returns(6);
            }
        }

        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public int test(char[][] c)
        {
            return target.MaximalRectangle(c);
        }
        [Test]
        [TestCaseSource("geTestCaseDatas")]
        public int test_V2(char[][] c)
        {
            return target.MaximalRectangle_V2(c);
        }
    }
}
