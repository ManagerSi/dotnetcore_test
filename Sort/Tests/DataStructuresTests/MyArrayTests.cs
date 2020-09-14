using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructuresTests
{
    class MyArrayTests
    {
        MyArray<int> target;

        [SetUp]
        public void setup()
        {
            target = new MyArray<int>(5);
            for (int i = 0; i < 5; i++)
            {
                target[i] = i;
            }
        }

        [Test]
        public void Add_test()
        {
            target.Add(5);
            Assert.True(target.Length == 6);
            Assert.True(target[5] == 5);
        }

        [Test]
        public void Insert_test()
        {
            target.Insert(1,5);
            Assert.True(target.Length == 6);
            Assert.True(target.ToString() == "0,5,1,2,3,4");
        }

        [Test]
        public void RemoveAt_test()
        {
            target.RemoveAt(1);
            Assert.True(target.Length == 4);
            Assert.True(target.ToString() == "0,2,3,4,0");
        }

        [Test]
        public void Remove_test()
        {
            target.Remove(1);
            Assert.True(target.Length == 4);
            Assert.True(target.ToString() == "0,2,3,4,0");
        }

        [Test]
        public void RemoveAll_test()
        {
            target.RemoveAll();
            Assert.True(target.Length == 0);
            Assert.True(target.ToString() == "");
        }


    }
}
