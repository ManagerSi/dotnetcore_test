using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 20. 表示数值的字符串
    /// https://leetcode-cn.com/problems/biao-shi-shu-zhi-de-zi-fu-chuan-lcof/
    /// </summary>
    public class biao_shi_shu_zhi_de_zi_fu_chuan_lcof
    {
        public bool IsNumber(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            if (decimal.TryParse(s, out var num))
                return true;

            try
            {
                Single.Parse(s);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

            return false;

        }

        /// <summary>
        /// 正则
        /// 这题简直就是：试用例猜规则。 现在基本可以明确规则如下：
        /// 
        /// 数字两边可以有空格，但是中间插空格不行；
        /// 除了数字之外，合法字符还有'e'、'E'、'+'、'-'、'.'；
        /// 'e'、'E'等价，用来划分底数与指数，只能出现一次，前面为科学计数法的底数，后面为指数；
        /// '+'、'-'只能作为正负号，但是不可以作为加减号，也就是只能出现在底数和指数的前面，不能出现在两个数字中间；
        /// '.'只能在底数上，不能在指数上，且只能出现一次，'.'两边任一边有数字均算一个完整的数字，但单独一个'.'不行。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber_V2(string s)
        {
            var pattern = "^[+-]?(((\\d+\\.?)|(\\.\\d+))|(\\d+\\.\\d+))([eE][+-]?\\d+)?$";//"^[+-]?((\\d*)|(\\d+.)|(.\\d+))([eE][+-]?\\d+)?$"; //^[+-]?(((\\d+\\.?)|(\\.\\d+))|(\\d+\\.\\d+))([eE][+-]?\\d+)?$
            if (Regex.IsMatch(s.Trim(), pattern))
                return true;

            return false;
        }

        /// <summary>
        /// 状态机
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber_V3(string s)
        {
            return false;
        }
    }
}
