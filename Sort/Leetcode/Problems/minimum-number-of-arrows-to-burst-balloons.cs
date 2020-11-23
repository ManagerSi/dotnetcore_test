using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 452. 用最少数量的箭引爆气球
    /// https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/
    /// </summary>
    public class minimum_number_of_arrows_to_burst_balloons
    {
        /// <summary>
        /// 和其他合并区间类的题目套路一样, 都是贪心思想, 先排序, 然后遍历检查是否满足合并区间的条件
        /// 这里判断是否有交叉区间, 所以其实是计算已知区间的交集数量.
        ///     这里以[[10, 16],[2,8],[1,6],[7,12]] 为例子:
        /// 
        /// 先排序, 我是按区间开始位置排序, 排序后: [[1,6],[2,8],[7,12],[10,16]]
        /// 遍历计算交叉区间(待发射箭头),
        /// 待发射箭头的区间range = [1, 6], 需要的箭数量 arrows = 1;
        /// 区间[2, 8], 和带发射区间[1, 6] 有交集: 更新发射区域为它们的交集 range = [2, 6]
        /// 区间[7, 12], 和待发射区间[2, 6] 没有任何交集, 说明需要增加一个新的发射区域, 新的待发射区域range = [7, 12]
        /// 区间[10, 16], 和待发射区域[7, 12] 有交集, 待发射区域更新为[10, 12]
        /// 返回需要待发射区间的个数
        /// 
        ///     作者：huanggangfeng
        ///     链接：https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/solution/he-bing-qu-jian-lei-de-ti-mu-du-shi-yi-ge-tao-lu-a/
        /// 来源：力扣（LeetCode）
        /// 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int FindMinArrowShots(int[][] points)
        {
            if (points == null || points.Length == 0) return 0;

            Array.Sort(points, (left, right) =>
            {
                if (left[0] == right[0]) return 0;
                return right[0] > left[0] ? 1 : -1;
            });

            List<int[]> res = new List<int[]>();
            int[] one = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                int[] temp = new int[2];
                temp[0] = Math.Max(one[0], points[i][0]);
                temp[1] = Math.Min(one[1], points[i][1]);
                if (temp[0] <= temp[1])
                {
                    one = temp;
                }
                else
                {
                    res.Add(one);
                    one = points[i];
                }
            }
            if(!res.Contains(one))
                res.Add(one);

            return res.Count;
        }

        /// <summary>
        /// 用区间的尾部排序貌似效率会更好, 因为已经保证后面的区间右侧都是大于当前区间, 所以将发射点设置在右侧边界, 后面的区间只有左边界比它更靠左,则可以被一起处理掉
        /// 这里换个example: [[10,16],[2,5],[1,6],[7,12]] 为例子:
        /// 
        /// 先排序, 按区间结束位置排序, 排序后: [[2,5],[1, 6],[7,12],[10,16]]
        /// 遍历计算交叉区间,
        /// 发射点初始化为pos = 5, 需要的箭数量 arrows = 1;
        /// 区间[1, 6], 1 是小于5的, 在点5射箭可以干掉这个区间
        ///     区间[7, 12], 在5的位置射箭无法打掉, 说明需要增加一个新的发射点, 新的待发射点pos = 12
        /// 区间[10, 16], 10 < 12那么在12位置射箭可以干掉它
        ///     返回需要射击点数量
        /// 
        /// 作者：huanggangfeng
        ///     链接：https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/solution/he-bing-qu-jian-lei-de-ti-mu-du-shi-yi-ge-tao-lu-a/
        /// 来源：力扣（LeetCode）
        /// 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int FindMinArrowShots_V1(int[][] points)
        {
            if (points == null || points.Length == 0) return 0;

            Array.Sort(points, (left, right) =>
            {
                if (left[1] == right[1]) return 0;
                return right[1] > left[1] ? -1 : 1;

            } );

            // 发射点设置为区间最右侧的点
            int pos = points[0][1];
            int arrows = 1;
            for (int i = 1; i < points.Length; i++)
            {
                var curr = points[i];
                if (curr[0] > pos)
                {
                    pos = curr[1];
                    ++arrows;
                }
            }

            return arrows;

        }
    }
}
