using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Extend
{
    public  static  class IntExtent
    {
        public static string ToString(this int[] nums)
        {
            if (nums == null) return string.Empty;
            return string.Join(',', nums);
        }
    }
}
