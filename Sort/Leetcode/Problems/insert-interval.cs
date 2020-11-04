using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 57. 插入区间
    /// https://leetcode-cn.com/problems/insert-interval/
    /// </summary>
    public class insert_interval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if(intervals==null || intervals.Length==0)
                return new int[][]{newInterval};

            List<int[]> result = new List<int[]>();
            int[] outInterval = new int[] { };
            for (int i = 0; i < intervals.Length; i++)
            {
                bool isInterval = CheckInterval(intervals[i], newInterval, out outInterval);
                if (isInterval)
                {
                    newInterval = outInterval;
                    continue;
                }
                else
                {
                    //没有新区间
                    if (newInterval == null) 
                    { 
                        result.Add(intervals[i]);
                        continue;
                    }

                    //newInterval 小于当前区间
                    if (intervals[i][0] > newInterval[1])
                    {
                        result.Add(newInterval);
                        result.Add(intervals[i]);
                        newInterval = null;
                        continue;
                    }

                    //newInterval 大于当前区间
                    result.Add(intervals[i]);
                }
            }

            //新区间在最后
            if (newInterval != null)
            {
                result.Add(newInterval);
            }

            return result.ToArray();
        }

        private bool CheckInterval(int[] v, int[] newInterval, out int[] outInterval)
        {
            outInterval = new[] {0, 0};
            if (newInterval == null) return false;

            if (newInterval[0] <= v[1] && newInterval[1] >= v[0] //新区间在左
                || v[0] <= newInterval[1] && v[1] >= newInterval[0]) //老区间在左
            {
                outInterval[0] = Math.Min(v[0], newInterval[0]);
                outInterval[1] = Math.Max(v[1], newInterval[1]);
                return true;
            }

            return false;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/insert-interval/solution/bi-xu-miao-dong-li-kou-qu-jian-ti-mu-zhong-die-qu-/
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] Insert_V2(int[][] intervals, int[] newInterval)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[][] { newInterval };

            List<int[]> res = new List<int[]>();

            // 遍历区间列表：
            // 首先将新区间左边且相离的区间加入结果集
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                res.Add(intervals[i++]);
            }

            // 接着判断当前区间是否与新区间重叠，重叠的话就进行合并，直到遍历到当前区间在新区间的右边且相离，
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                i++;
            }
            // 将最终合并后的新区间加入结果集
            res.Add(newInterval);
            
            // 最后将新区间右边且相离的区间加入结果集
            while (i < intervals.Length)
            {
                res.Add(intervals[i++]);
            }

            return res.ToArray();
        }
    }
}
