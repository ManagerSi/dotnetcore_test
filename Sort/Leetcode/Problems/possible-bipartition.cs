﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    public class possible_bipartition
    {
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            int[] color = new int[n + 1];
            IList<int>[] g = new IList<int>[n + 1];
            for (int i = 0; i <= n; ++i)
            {
                g[i] = new List<int>();
            }
            foreach (int[] p in dislikes)
            {
                g[p[0]].Add(p[1]);
                g[p[1]].Add(p[0]);
            }
            for (int i = 1; i <= n; ++i)
            {
                if (color[i] == 0 && !DFS(i, 1, color, g))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DFS(int curnode, int nowcolor, int[] color, IList<int>[] g)
        {
            color[curnode] = nowcolor;
            foreach (int nextnode in g[curnode])
            {
                if (color[nextnode] != 0 && color[nextnode] == color[curnode])
                {
                    return false;
                }
                if (color[nextnode] == 0 && !DFS(nextnode, 3 ^ nowcolor, color, g))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
