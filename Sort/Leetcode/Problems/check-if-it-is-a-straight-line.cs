using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 1232. 缀点成线
    /// </summary>
    public class check_if_it_is_a_straight_line
    {
        /// <summary>
        /// 向量平行法
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates == null || coordinates.Length < 2) return false;

            for (int i = 2; i < coordinates.Length; i++)
                if ((coordinates[1][1] - coordinates[0][1]) * (coordinates[i][0] - coordinates[0][0]) != (coordinates[i][1] - coordinates[0][1]) * (coordinates[1][0] - coordinates[0][0]))
                    return false;
            return true;
        }
    }
}
