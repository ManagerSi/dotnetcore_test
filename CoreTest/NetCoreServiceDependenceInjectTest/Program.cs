using System;
using NetCoreServiceDependencyInjectionTest.Samples;

namespace NetCoreServiceDependencyInjectionTest
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Test01.Run();
            Test02.Run();
        }
    }
}
