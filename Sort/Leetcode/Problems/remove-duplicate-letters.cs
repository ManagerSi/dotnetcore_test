using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 316. 去除重复字母
    /// https://leetcode-cn.com/problems/remove-duplicate-letters/
    /// </summary>
    public class remove_duplicate_letters
    {
        public string RemoveDuplicateLetters(string s)
        {
            // 声明变量
            Dictionary<char,int> dic = new Dictionary<char, int>();
            Stack<char> stack=new Stack<char>();
            //bool[] exists = new bool[26];

            // 遍历字符串s // 初始化字母出现次数哈希表
            foreach (var c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            // 遍历字符串s
            foreach (var c in s)
            {
                //该位置字母没有在栈中出现过
                if (!stack.Contains(c)) //exists[c]
                {
                    //栈不为空 && 栈顶元素字典序列靠后 && 栈顶元素还有剩余出现次数
                    while (stack.Count>0 && stack.Peek()>c && dic[stack.Peek()]>0)
                    {
                        // 修改出现状态
                        //exists[c] = false;
                        // 栈顶元素弹出
                        stack.Pop();
                    }
                    // 该位置的字母压栈
                    stack.Push(c);
                    // 修改出现状态
                    //exists[c] = true;
                }
                // 遍历过的字母出现次数减一
                dic[c]--;
            }

            // 返回栈中元素
            return string.Join("", stack.Reverse());
        }
    }
}
