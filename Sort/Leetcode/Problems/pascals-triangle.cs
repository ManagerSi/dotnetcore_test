using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 118. 杨辉三角
    /// https://leetcode-cn.com/problems/pascals-triangle/
    /// </summary>
    public class pascals_triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                IList<int> list = new List<int>();
                // 第0层
                if (i == 0)
                {
                    list.Add(1);
                }
                else
                {
                    // 每层元素个数为层数+1（此处层数从0开始）
                    for (int j = 0; j < i + 1; j++)
                    {
                        // 上一层
                        IList<int> upList = res[res.Count - 1];
                        // 左上角值
                        int upLeft = 0;
                        if (j - 1 >= 0)
                        {
                            upLeft = upList[j - 1];
                        }
                        // 右上角值
                        int upRight = 0;
                        if (upList.Count >= j + 1)
                        {
                            upRight = upList[j];
                        }
                        list.Add(upLeft + upRight);
                    }
                }
                res.Add(list);
            }
            return res;

        }
    }
}
