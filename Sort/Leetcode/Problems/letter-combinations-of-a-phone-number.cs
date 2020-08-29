using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 17. 电话号码的字母组合
    /// https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number/
    /// </summary>
    public class letter_combinations_of_a_phone_number
    {
        private Dictionary<char, string> dict = new Dictionary<char, string>()
        {
            {'0',""}, // 0
            {'1',""}, // 1
            {'2',"abc"}, // 2
            {'3',"def"}, // 3
            {'4',"ghi"}, // 4
            {'5',"jkl"}, // 5
            {'6',"mno"}, // 6
            {'7',"pqrs"}, // 7
            {'8',"tuv" }, // 8
            {'9',"wxyz"}, // 9
        };
        private List<string> list = new List<string>()
        {
            "", // 0
            "", // 1
            "abc", // 2
            "def", // 3
            "ghi", // 4
            "jkl", // 5
            "mno", // 6
            "pqrs", // 7
            "tuv", // 8
            "wxyz", // 9
        };
        /// <summary>
        /// dfs 回溯
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return res;
            }

            StringBuilder sb = new StringBuilder();

            DFS(digits,0,res,sb);

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digits">输入的数字集合</param>
        /// <param name="index">所处理的数字索引</param>
        /// <param name="res">结果</param>
        /// <returns></returns>
        private void DFS(string digits, int index,  IList<string> res, StringBuilder sb)
        {
            if (index >= digits.Length)
            {
                res.Add(sb.ToString());

                return;
            }

            //拿到数字对应的字母组合
            var letters = dict[digits[index]];
            for (int i = 0; i < letters.Length; i++)
            {
                DFS(digits, index + 1, res, sb.Append(letters[i]));
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
