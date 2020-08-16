using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 733. Flood Fill
    /// https://leetcode-cn.com/problems/flood-fill/
    /// </summary>
    public class flood_fill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var origineColor = image[sr][sc];
            if (origineColor != newColor)// 如果颜色相同则不处理
                dfs(image, sr, sc, newColor, origineColor);

            return image;
        }

        private void dfs(int[][] image, int sr, int sc, int newColor, int origineColor)
        {
            // 判断是否超出边界
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length)
                return;

            if (image[sr][sc] == origineColor)
            {
                // 将颜色替换
                image[sr][sc] = newColor;
                
                // 深度优先搜索四周的像素点
                dfs(image, sr + 1, sc, newColor, origineColor);
                dfs(image, sr - 1, sc, newColor, origineColor);
                dfs(image, sr, sc + 1, newColor, origineColor);
                dfs(image, sr, sc - 1, newColor, origineColor);
            }
        }
    }
}
