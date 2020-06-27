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
            Console.WriteLine("*****ð������****************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("****************************************");

            //ð��
            arr.BubbleSort();

            //���
            for (int i = 0; i < arr.Length-1; i++)
            {
                Assert.LessOrEqual(arr[i],arr[i+1]);
            }
        }
        [Test]
        public void QuickSort_Test()
        {
            Console.WriteLine("*****ѡ������*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //ѡ��
            arr.QuickSort();

            //���
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }

        [Test]
        public void InsertSort_Test()
        {
            Console.WriteLine("*****��������*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //ѡ��
            arr.InsertSort();

            //���
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }

        [Test]
        public void ShellSort_Test()
        {
            Console.WriteLine("*****ϣ������*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //ѡ��
            arr.ShellSort();

            //���
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }


        [Test]
        public void SelectionSort_Test()
        {
            Console.WriteLine("*****ѡ������*************************");
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**************************************");

            //ѡ��
            arr.SelectionSort();

            //���
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.LessOrEqual(arr[i], arr[i + 1]);
            }
        }
    }
}