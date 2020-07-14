using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 20. 有效的括号
    /// https://leetcode-cn.com/problems/valid-parentheses/
    ///
    /// 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
    /// </summary>
    public class valid_parentheses
    {
        private Dictionary<char, char> hesesDict = new Dictionary<char, char>()
        {
            { '(', ')'},
            { '{', '}'},
            { '[', ']'},
        };

        /// <summary>
        /// 使用栈和字典共同作用
        /// </summary>
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            Stack<char> stack = new Stack<char>();

            foreach (var VARIABLE in s)
            {
                if(hesesDict.ContainsKey(VARIABLE))
                    stack.Push(hesesDict[VARIABLE]);
                else
                    if (stack.Count == 0 || stack.Pop() != VARIABLE)
                        return false;
            }

            if (stack.Count > 0)
                return false;

            return true;
        }

        /// <summary>
        /// hard code
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        public bool IsValid_V2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(')');
                }
                else if (c == '{')
                {
                    stack.Push('}');
                }
                else if (c == '[')
                {
                    stack.Push(']');
                }
                else if (stack.Count==0 || c != stack.Pop())
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
