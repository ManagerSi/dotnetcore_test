using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    public class image_smoother
    {
        public int[][] ImageSmoother(int[][] img)
        {
            int[][] imgResult = new int[img.Length][];

            for (int i = 0; i < img.Length; i++)
            {
                imgResult[i] = new int[img[i].Length];
                for (int j = 0; j < img[i].Length; j++)
                {
                    imgResult[i][j] = GetAverageValue(img, i, j);
                }
            }

            return imgResult;
        }

        private int GetAverageValue(int[][] img, int i, int j)
        {
            //self
            var count = 1;
            var summary = img[i][j];

            var hasLeft = j - 1 >= 0;
            var hasUp = i - 1 >= 0;
            var hasRight = j + 1 < img[i].Length;
            var hasDown = i + 1 < img.Length;


            //左上
            if (hasLeft && hasUp)
            {
                count++;
                summary += img[i-1][j-1];
            }
            //上
            if (hasUp)
            {
                count++;
                summary += img[i-1][j];
            }
            //右上
            if (hasUp && hasRight)
            {
                count++;
                summary += img[i-1][j+1];
            }
            //左
            if (hasLeft)
            {
                count++;
                summary += img[i][j-1];
            }
            //右
            if (hasRight)
            {
                count++;
                summary += img[i][j+1];
            }
            //左下
            if (hasLeft && hasDown)
            {
                count++;
                summary += img[i+1][j-1];
            }
            //下
            if (hasDown)
            {
                count++;
                summary += img[i+1][j];
            }
            //右下
            if (hasRight && hasDown)
            {
                count++;
                summary += img[i+1][j+1];
            }

            return (summary / count);
        }
    }
}
