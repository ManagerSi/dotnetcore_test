using System;
using IOCDemo.V1.Factory;
using IOCDemo.V1.Models;

namespace IOCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                Console.WriteLine("demo v1:");

                Console.WriteLine("----init IOC 容器:");
                IIOCFactory iocFactory = new DefaultIOCFactory("IOCDemo");

                Console.WriteLine("----从容器获取Student");
                var result = iocFactory.GetInstent("Student");
                if (result is Student)
                {
                    Console.WriteLine("----get student succeed");
                }
                else { Console.WriteLine("----get student failed"); }
            }



            Console.ReadKey();
        }
    }
}
