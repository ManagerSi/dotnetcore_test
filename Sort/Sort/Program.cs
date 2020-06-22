using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**********************************************************");

            //冒泡
            arr.BubbleSort();

            Console.ReadKey();
        }
    }
}
