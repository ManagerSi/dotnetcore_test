using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    public class number_of_equivalent_domino_pairs_test
    {
        number_of_equivalent_domino_pairs target =new number_of_equivalent_domino_pairs();

        static IEnumerable<TestCaseData> geTestCaseDatas()
        {
            yield return new TestCaseData((object)new int[][]
            {
                new int[]{1,2},new int[]{2,1},new int[]{3,4},new int[]{5,6},
            }).Returns(1);
            yield return new TestCaseData((object)new int[][]
            {
                new int[]{1,2},new int[]{2,1},new int[]{2,1},new int[]{3,4},new int[]{5,6},
            }).Returns(3);
            yield return new TestCaseData((object)new int[][]
            {
                new int[]{1,2},new int[]{2,1},new int[]{2,1},new int[]{2,1},new int[]{3,4},new int[]{5,6},
            }).Returns(6);
            yield return new TestCaseData((object)new int[][]
            {
                new int[]{1,2},new int[]{2,1},new int[]{2,1},new int[]{2,1},new int[]{2,1},new int[]{3,4},new int[]{5,6},
            }).Returns(10);
        }

        [TestCaseSource("geTestCaseDatas")]
        public int test(int[][] dominoes)
        {
            return target.NumEquivDominoPairs(dominoes);
        }
    }
}
