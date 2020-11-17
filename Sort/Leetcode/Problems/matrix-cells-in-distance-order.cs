using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1030. 距离顺序排列矩阵单元格
    /// https://leetcode-cn.com/problems/matrix-cells-in-distance-order/
    /// </summary>
    public class matrix_cells_in_distance_order
    {
        /// <summary>
        /// 先生成表格，再排序
        /// </summary>
        /// <param name="R"></param>
        /// <param name="C"></param>
        /// <param name="r0"></param>
        /// <param name="c0"></param>
        /// <returns></returns>
        public int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            List<KeyValuePair<double,int[]>> kv= new List<KeyValuePair<double, int[]>>();
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    kv.Add(new KeyValuePair<double, int[]>(Math.Abs(i-r0)+ Math.Abs(j-c0),new int[2]{i,j}));
                }
            }

            return kv.OrderBy(i => i.Key).Select(i=>i.Value).ToArray();
        }
    }
}
