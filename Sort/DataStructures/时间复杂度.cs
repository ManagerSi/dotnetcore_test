using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace DataStructures
{
    public class 时间复杂度
    {
        public void Main()
        {
            var n = 10;

            //O(1)
            Console.WriteLine("O(1)");
            Console.WriteLine($"O(1):{n}");

            //O(logn)
            for (int j = 0; j < n; j=j*2)
            {
                Console.WriteLine($"O(logn){j}");
            }

            //O(n)
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"O(n):{j}");
            }

            //O(nlogn)
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Console.WriteLine($"O(nlogn):{i},{j}");
                }
            }

            //O(n^2)
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.WriteLine($"O(n^2):{j},{k}");
                }
            }

            //O(2^n)
            for (int j = 1; j < Math.Pow(n,2); j++)
            {
                Console.WriteLine($"O(n^2):{j}");
            }

            //O(n!)
            for (int j = 0; j < factorial(n); j++)
            {
                
            }
        }

        private int factorial(int n)
        {
            if (n == 1)
                return 1;
            return n + factorial(n - 1);
        }

        /// <summary>
        /// O(2^n)
        /// </summary>
        /// <param name="n"></param>
        private int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            return factorial(n - 1) + factorial(n - 2);
        }
    }
}
