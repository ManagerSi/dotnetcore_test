using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems.剑指offer
{
    public  class bao_han_minhan_shu_de_zhan_lcof
    {

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.Min();
         */

        private Stack<int> s1 = new Stack<int>();
        private Stack<int> s2 = new Stack<int>();//存最小值
        public void Push(int x)
        {
            s1.Push(x);
            if (s2.Count == 0 || s2.Peek() >= x)
                s2.Push(x);
        }

        public void Pop()
        {
            if(s1.TryPop(out var x))
            {
            if (x == s2.Peek())
                s2.Pop();
            }
        }

        public int Top()
        {
            if( s1.TryPeek(out var res))
            {
                return res;
            }
            return -1;
        }

        public int Min()
        {
            if (s2.TryPeek(out var res))
            {
                return res;
            }
            return -1;
        }
    }
}
