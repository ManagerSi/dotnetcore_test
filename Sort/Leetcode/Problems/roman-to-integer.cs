using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 13. 罗马数字转整数
    /// 
    /// https://leetcode-cn.com/problems/roman-to-integer/
    /// </summary>
    
    public class roman_to_integer
    {
        private Dictionary<char,int> dict = new Dictionary<char, int>()
        {
            {'I',             1       },
            {'V',             5       },
            {'X',             10      },
            {'L',             50      },
            {'C',             100     },
            {'D',             500     },
            {'M',             1000    },
            {'a',             4    },
            {'b',             9    },
            {'c',             40    },
            {'d',             90    },
            {'e',             400    },
            {'f',             900    },
        };
        private Dictionary<string, string> replaceDict = new Dictionary<string, string>()
        {
            {"IV", "a"  },
            {"IX", "b"  },
            {"XL", "c"  },
            {"XC", "d"  },
            {"CD", "e"  },
            {"CM", "f"  },
        };
        /// <summary>
        /// 使用dict提前定义
        /// 使用string的replace
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            foreach (var rep in replaceDict)
            {
                s = s.Replace(rep.Key, rep.Value);
            }

            int res = 0;
            foreach (var c in s)
            {
                res += dict.ContainsKey(c) ? dict[c] : 0;
            }

            return res;
        }
    }

}
