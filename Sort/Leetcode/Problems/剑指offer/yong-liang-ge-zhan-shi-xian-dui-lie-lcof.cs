using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    /// <summary>
    /// 剑指 Offer 09. 用两个栈实现队列
    /// https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof
    /// </summary>
    public class CQueue
    {
        private Stack<int> sAppend;
        private Stack<int> sDelete;
        public CQueue()
        {
            sAppend = new Stack<int>();
            sDelete = new Stack<int>();
        }

        public void AppendTail(int value)
        {
            sAppend.Push(value);
        }

        public int DeleteHead()
        {
            if(sDelete.Count>0)
            {
                return sDelete.Pop();
            }
            if (sAppend.Count > 0)
            {
                while (sAppend.Count > 0)
                {
                    sDelete.Push(sAppend.Pop());
                }
                return sDelete.Pop();
            }
            return -1;
        }
    }

    /**
     * Your CQueue object will be instantiated and called as such:
     * CQueue obj = new CQueue();
     * obj.AppendTail(value);
     * int param_2 = obj.DeleteHead();
     */
}
