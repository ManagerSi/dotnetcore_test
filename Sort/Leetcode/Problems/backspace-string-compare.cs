using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 844. 比较含退格的字符串
    /// https://leetcode-cn.com/problems/backspace-string-compare/
    /// </summary>
    public class backspace_string_compare
    {
        public bool BackspaceCompare(string S, string T)
        {
            Stack<char> s1 = new Stack<char>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '#')
                    s1.TryPop(out char res);
                else
                    s1.Push(S[i]);
            }
            Stack<char> s2 = new Stack<char>();
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] == '#')
                    s2.TryPop(out char res);
                else
                    s2.Push(T[i]);
            }

            if (s1.Count != s2.Count) return false;

            while (s1.Count>0)
            {
                if (s1.Pop() != s2.Pop())
                    return false;
            }

            return true;
        }

        public bool BackspaceCompare_V2(string S, string T)
        {
            return BackString_V2(S).Equals(BackString_V2(T));
        }

        private string BackString_V2(string s)
        {
            Stack<char> s1 = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                    s1.TryPop(out char res);
                else
                    s1.Push(s[i]);
            }
            StringBuilder sb = new StringBuilder();
            while (s1.Count>0)
            {
                sb.Append(s1.Pop());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 这道题的总体思路就是先解码再比较。
        /// 由于是含有退格，我们不如反向思维一下。
        /// 可以反向遍历字符串，定义一个变量来记录当前退格数量。
        /// 首先如果当前字符就是#，当前退格数量自增。
        ///     否则，如果退格数量大于0，减少退格数量，不记录当前值；反之则记录当前值。
        /// 之后再将得到的结果反转即可(由于这道题只需要比较，甚至可以不反转)。
        /// 
        /// 作者：kd213
        ///     链接：https://leetcode-cn.com/problems/backspace-string-compare/solution/fan-xiang-bian-li-zi-fu-chuan-si-lu-fei-chang-jian/
        /// 来源：力扣（LeetCode）
        /// 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool BackspaceCompare_V3(string S, string T)
        {
            //compare two reverse string
            return BackStringReverse_V3(S).Equals(BackStringReverse_V3(T));
        }

        private string BackStringReverse_V3(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '#')
                    count++;
                else
                {
                    if (count > 0)
                        count--;
                    else
                        sb.Append(s[i]);

                }
            }

            return sb.ToString();//the reverse result
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public bool BackspaceCompare_V4(string S, string T)
        {
            int l1 = S.Length - 1, l2 = T.Length - 1;
            int skipS = 0, skipT = 0;
            while (l1 >= 0 || l2 >= 0)
            {
                while (l1 >= 0)
                {
                    if (S[l1] == '#')
                    {
                        skipS++;
                        l1--;
                    }
                    else
                    {
                        if (skipS > 0)
                        {
                            skipS--;
                            l1--;
                        }
                        else
                            break;
                    }
                }

                while (l2 >= 0)
                {
                    if (T[l2] == '#')
                    {
                        skipT++;
                        l2--;
                    }
                    else
                    {
                        if (skipT > 0)
                        {
                            skipT--;
                            l2--;
                        }
                        else
                            break;
                    }
                }

                if (l1 >= 0 && l2 >= 0)
                {
                    if (S[l1] != T[l2])
                    {
                        return false;
                    }
                }
                else
                {
                    if (l1 >= 0 || l2 >= 0)
                    {
                        return false;
                    }
                }

                l1--;
                l2--;

            }

            return true;
        }
    }
}
