using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 973. 最接近原点的 K 个点
    /// https://leetcode-cn.com/problems/k-closest-points-to-origin/
    /// </summary>
    public class k_closest_points_to_origin
    {
        /// <summary>
        /// 函数库实现
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int K)
        {
            return points.OrderBy(i => Math.Abs(i[0] * i[0] + i[1] * i[1])).Take(K).ToArray();
        }

        /// <summary>
        /// dict 暴力
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest_V2(int[][] points, int K)
        {
            if(points==null || points.Length==0 || K<=0) 
                return new int[][]{};

            Dictionary<double, List<int[]>> dict = new Dictionary<double, List<int[]>>();
            for (int i = 0; i < points.Length; i++)
            {
                double length = Math.Abs((double)points[i][0] * points[i][0] + points[i][1] * points[i][1]);

                if(!dict.ContainsKey(length))
                    dict.Add(length, new List<int[]>());

                dict[length].Add(points[i]);
            }

            var res = new List<int[]>(){ };
            foreach (var len in dict.Keys.OrderBy(i=>i))
            {
                if (K <= dict[len].Count)
                {
                    res.AddRange(dict[len].Take(K));
                    break;
                }
                else
                {
                    res.AddRange(dict[len]);
                    K -= dict[len].Count;
                }
            }

            return res.ToArray();
        }

        /// <summary>
        /// 快排
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest_V3(int[][] points, int K)
        {
            // 使用快速选择（快排变形） 获取 points 数组中距离最小的 K 个点（第 4 个参数是下标，因此是 K - 1）
            return quickSelect(points, 0, points.Length - 1, K - 1);
        }

        private int[][] quickSelect(int[][] points, int lo, int hi, int idx)
        {
            if (lo > hi)
            {
                return new int[0][]{};
            }
            // 快排切分后，j 左边的点距离都小于等于 points[j], j 右边的点的距离都大于等于 points[j]。
            int j = partition(points, lo, hi);
            // 如果 j 正好等于目标idx，说明当前points数组中的[0, idx]就是距离最小的 K 个元素
            if (j == idx)
            {
                var dest = new int[idx + 1][];
                Array.Copy(points, dest, idx + 1);
                return dest;
            }
            // 否则根据 j 与 idx 的大小关系判断找左段还是右段
            return j < idx ? quickSelect(points, j + 1, hi, idx) : quickSelect(points, lo, j - 1, idx);
        }

        private int partition(int[][] points, int lo, int hi)
        {
            int[] v = points[lo];
            int dist = v[0] * v[0] + v[1] * v[1];
            int i = lo, j = hi + 1;
            while (true)
            {
                while (++i <= hi && points[i][0] * points[i][0] + points[i][1] * points[i][1] < dist) ;
                while (--j >= lo && points[j][0] * points[j][0] + points[j][1] * points[j][1] > dist) ;
                if (i >= j)
                {
                    break;
                }
                int[] tmp = points[i];
                points[i] = points[j];
                points[j] = tmp;
            }
            points[lo] = points[j];
            points[j] = v;
            return j;
        }
    }
}
