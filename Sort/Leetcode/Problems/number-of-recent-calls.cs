using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    /// <summary>
    /// 933. 最近的请求次数
    /// https://leetcode-cn.com/problems/number-of-recent-calls/
    /// </summary>
    public class number_of_recent_calls
    {
        private Queue<int> _q;
        public number_of_recent_calls()
        {
            _q = new Queue<int>(1000);
        }

        /// <summary>
        /// 并返回过去 3000 毫秒内发生的所有请求数（包括新请求）。即只记录最近3000ms的请求
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Ping(int t)
        {
            _q.Enqueue(t);
            while (_q.Peek() < t - 3000)
            {
                _q.Dequeue();
            }
            return _q.Count;
        }

    }
}
