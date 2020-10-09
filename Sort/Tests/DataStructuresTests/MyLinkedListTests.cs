using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests.DataStructuresTests
{
    class MyLinkedListTests
    {
        MyLinkedList<int> target;

        [SetUp]
        public void setup()
        {
            target = new MyLinkedList<int>();
        }

        [Test]
        public void IsEmpty_test()
        {
            target.AddFromHead(2);
            target.AddFromTail(5);
            target.AddFromHead(1);
            target.InsertElem(3,4);

            var res = target.GetElem(1);
            Assert.IsTrue(res == 1);
            res = target.GetElem(2);
            Assert.IsTrue(res == 2);
            res = target.GetElem(3);
            Assert.IsTrue(res == 4);

            target.DeleteElem(3);
            res = target.GetElem(3);
            Assert.IsTrue(res == 5);
        }
    }
}
