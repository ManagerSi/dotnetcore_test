using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Console.WriteLine("ServiceStackDemo!");
            //ServiceStackDemo.MainDemo();

            Console.WriteLine("StackExchangeDemo!");
            StackExchangeDemo.MainDemo();

            Console.ReadKey();

        }
    }
}
