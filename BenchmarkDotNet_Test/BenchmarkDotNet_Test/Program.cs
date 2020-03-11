using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNet_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var summary =  BenchmarkRunner.Run<Md5VsSha256>();

            Summary summary = BenchmarkRunner.Run<TestContext>();
        }
    }


}
