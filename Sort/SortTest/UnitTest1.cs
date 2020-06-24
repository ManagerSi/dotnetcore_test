using System;
using System.Diagnostics;
using NUnit.Framework;
using Sort;

namespace SortTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();

        }

        [Test]
        public void BubbleSort_Test()
        {
            Console.WriteLine("*****√∞≈›≈≈–Ú****************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("****************************************");

            //√∞≈›
            arr.BubbleSort();

            //ºÏ≤È
            for (int i = 0; i < arr.Length-1; i++)
            {
                Assert.LessOrEqual(arr[i],arr[i+1]);
            }
        }
        [Test]
        public void QuickSort_Test()
        {
            Console.WriteLine("*****—°‘Ò≈≈–Ú*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //—°‘Ò
            arr.QuickSort();

            //ºÏ≤È
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }




        [Test]
        public void SelectionSort_Test()
        {
            Console.WriteLine("*****—°‘Ò≈≈–Ú*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //—°‘Ò
            arr.SelectionSort();

            //ºÏ≤È
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }
    }
}