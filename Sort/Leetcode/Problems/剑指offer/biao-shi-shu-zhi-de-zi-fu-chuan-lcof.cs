using System;
using System.Collections.Generic;
using System.Linq;
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
        /// 状态定义：
        /// 
        /// 按照字符串从左到右的顺序，定义以下 9 种状态。
        /// 
        /// 0开始的空格
        /// 1幂符号前的正负号
        /// 2小数点前的数字
        /// 3小数点、小数点后的数字
        /// 4当小数点前为空格时，小数点、小数点后的数字
        /// 5幂符号
        /// 6幂符号后的正负号
        /// 7幂符号后的数字
        /// 8结尾的空格
        /// 9结束状态：
        /// 
        /// 合法的结束状态有 2, 3, 7, 8 。
        /// 链接：https://leetcode-cn.com/problems/biao-shi-shu-zhi-de-zi-fu-chuan-lcof/solution/mian-shi-ti-20-biao-shi-shu-zhi-de-zi-fu-chuan-y-2/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber_V3(string s)
        {
            var states = new List<Dictionary<char, int>>() {
                new Dictionary<char, int>(){{ ' ', 0}, {'s', 1}, {'d', 2},  {'.', 4 }},       // 0. start with 'blank'
                new Dictionary<char, int>(){{ 'd', 2}, {'.', 4 }},                         // 1. 'sign' before 'e'
                new Dictionary<char, int>(){{ 'd', 2}, {'.', 3}, { 'e', 5}, { ' ', 8 }},     // 2. 'digit' before 'dot'
                new Dictionary<char, int>(){{ 'd', 3}, { 'e', 5},{ ' ', 8 }},              // 3. 'digit' after 'dot'
                new Dictionary<char, int>(){{ 'd', 3 }},                                    // 4. 'digit' after 'dot' (‘blank’ before 'dot')
                new Dictionary<char, int>(){{ 's', 6}, { 'd', 7 }},                         // 5. 'e'
                new Dictionary<char, int>(){{ 'd', 7 }},                                    // 6. 'sign' after 'e'
                new Dictionary<char, int>(){{ 'd', 7}, { ' ', 8 }},                         // 7. 'digit' after 'e'
                new Dictionary<char, int>(){{ ' ', 8 }}                                     // 8. end with 'blank'
            };

            var index = 0;//状态
            var t = '?'; //状态
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                    t = 'd';
                else if (c == 'E' || c == 'e')
                    t = 'e';
                else if (c == '.'|| c==' ')
                    t = c;
                else if (c == '-' || c == '+')
                    t = 's';
                else
                    t = '?';

                if (!states[index].ContainsKey(t))
                    return false;

                index = states[index][t];
            }

            //var trueList = new int[] {2, 3, 7, 8};
            //return trueList.Contains(index);

            return index == 2|| index == 3 || index == 7 || index == 8;
        }
    }
}
