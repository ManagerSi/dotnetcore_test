using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1319. 连通网络的操作次数
    /// https://leetcode-cn.com/problems/number-of-operations-to-make-network-connected/
    /// </summary>
    public class number_of_operations_to_make_network_connected
    {
        public int makeConnected(int n, int[][] connections)
        {
            if (connections.Length < n - 1)
            {
                return -1;
            }

            UnionFind uf = new UnionFind(n);
            foreach (int[] conn in connections)
            {
                uf.unite(conn[0], conn[1]);
            }

            return uf.setCount - 1;
        }
    }

    // 并查集模板
    public class UnionFind
    {
        int[] parent;
        int[] size;
        int n;
        // 当前连通分量数目
        public int setCount;

        public UnionFind(int n)
        {
            this.n = n;
            this.setCount = n;
            this.parent = new int[n];
            this.size = new int[n];
            Array.Fill<int>(size, 1);
            for (int i = 0; i < n; ++i)
            {
                parent[i] = i;
            }
        }

        public int findset(int x)
        {
            return parent[x] == x ? x : (parent[x] = findset(parent[x]));
        }

        public bool unite(int x, int y)
        {
            x = findset(x);
            y = findset(y);
            if (x == y)
            {
                return false;
            }
            if (size[x] < size[y])
            {
                int temp = x;
                x = y;
                y = temp;
            }
            parent[y] = x;
            size[x] += size[y];
            --setCount;
            return true;
        }

        public bool connected(int x, int y)
        {
            x = findset(x);
            y = findset(y);
            return x == y;
        }
    }
}
