using System;
using System.Collections.Generic;
using System.Text;
using Leetcode.Problems;
using NUnit.Framework;

namespace LeetcodeTests
{
    class image_smoother_test
    {
        image_smoother target = new image_smoother();

        //public static IEnumerable<TestCaseData> GetTestCase()
        //{
        //    yield return new TestCaseData(new int[][]
        //    {
        //        new int[] {1, 1, 1},
        //        new int[] {1, 0, 1},
        //        new int[] {1, 1, 1}
        //    }).Returns("0,0,0,0,0,0,0,0,0");
        //}

        [Test]
       // [TestCaseSource("GetTestCase")]
       public void test()
       {
           var request = new int[][]
           {
               new int[] {1, 1, 1},
               new int[] {1, 0, 1},
               new int[] {1, 1, 1}
           };

            var res = target.ImageSmoother(request);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    sb.Append($"{res[i][j]},");
                }
            }

            sb.Remove(sb.Length - 1, 1);
            Assert.AreEqual("0,0,0,0,0,0,0,0,0",sb.ToString());

            /////////////////////////////////////////////////////////////////////////////////
            
            request = new int[][]
            {
                new int[] { 100, 200, 100 },
                new int[] { 200, 50, 200 },
                new int[] { 100, 200, 100 }
            };

            res = target.ImageSmoother(request);

            sb.Clear();
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i].Length; j++)
                {
                    sb.Append($"{res[i][j]},");
                }
            }

            sb.Remove(sb.Length - 1, 1);
            Assert.AreEqual("137,141,137,141,138,141,137,141,137", sb.ToString());
        }
    }
}
