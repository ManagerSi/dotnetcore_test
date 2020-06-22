using System;
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
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**********************************************************");

            //ð��
            arr.BubbleSort();

            //���
            for (int i = 0; i < arr.Length-1; i++)
            {
                Assert.Less(arr[i],arr[i+1]);

            }
        }
        [Test]
        public void SelectionSort_Test()
        {
            var arr = BaseTenSorts.GetIntArray(10, 1000);
            arr.Show();
            Console.WriteLine("**********************************************************");

            //ѡ��
            arr.SelectionSort();

            //���
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.Less(arr[i], arr[i + 1]);

            }
        }
    }
}