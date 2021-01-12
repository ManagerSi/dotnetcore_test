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
        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum_V2(int[][] isConnected)
        {
            int provinces = isConnected.Length;
            int[] parent = new int[provinces];
            for (int i = 0; i < provinces; i++)
            {
                parent[i] = i;
            }
            for (int i = 0; i < provinces; i++)
            {
                for (int j = i + 1; j < provinces; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        union(parent, i, j);
                    }
                }
            }
            int circles = 0;
            for (int i = 0; i < provinces; i++)
            {
                if (parent[i] == i)
                {
                    circles++;
                }
            }
            return circles;
        }

        public void union(int[] parent, int index1, int index2)
        {
            parent[find(parent, index1)] = find(parent, index2);
        }

        public int find(int[] parent, int index)
        {
            if (parent[index] != index)
            {
                parent[index] = find(parent, parent[index]);
            }
            return parent[index];
        }

    }
}
