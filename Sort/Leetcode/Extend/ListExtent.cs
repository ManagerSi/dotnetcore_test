using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Extend
{
    public  static  class ListExtent
    {
        public static string ToString<T>(IList<T> nums)
        {
            if (nums == null) return string.Empty;
            return string.Join(',', nums);
        }
    }
}
