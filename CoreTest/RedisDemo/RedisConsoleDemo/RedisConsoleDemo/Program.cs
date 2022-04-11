using System;
using RedisConsoleDemo.MessageQueueDemo;

namespace RedisConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            //Console.WriteLine("ServiceStackDemo!");
            //ServiceStackDemo.MainDemo();

            //Console.WriteLine("StackExchangeDemo!");
            //StackExchangeDemo.MainDemo();

            Console.WriteLine("MessageQueue demo");
            MqByList.Demo();

            Console.ReadKey();

        }
    }
}
