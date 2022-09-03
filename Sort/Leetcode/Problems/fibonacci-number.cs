using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Problems
{
    public class fibonacci_number
    {
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
