using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 547. 省份数量
    /// </summary>
    public class number_of_provinces
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int provinces = isConnected.Length;
            bool[] visited = new bool[provinces];
            int circles = 0;
            for (int i = 0; i < provinces; i++)
            {
                if (!visited[i])
                {
                    dfs(isConnected, visited, provinces, i);
                    circles++;
                }
            }
            return circles;
        }

        public void dfs(int[][] isConnected, bool[] visited, int provinces, int i)
        {
            for (int j = 0; j < provinces; j++)
            {
                if (isConnected[i][j] == 1 && !visited[j])
                {
                    visited[j] = true;
                    dfs(isConnected, visited, provinces, j);
                }
            }

        }
    }
}
