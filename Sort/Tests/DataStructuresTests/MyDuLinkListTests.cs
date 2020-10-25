using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructuresTests
{
    class MyDuLinkListTests
    {
        private MyDuLinkList<int> target = new MyDuLinkList<int>();

        [Test]
        public void test()
        {
            target.AddFirst(3);
            Assert.IsTrue(target.ToString() == "3");
            target.AddFirst(2);
            Assert.IsTrue(target.ToString() == "2,3");
            Assert.IsTrue(target.GetElemData(1) == 2); //index of head is 0
            Assert.IsTrue(target.GetElemData(2) == 3);
            Assert.IsTrue(target.GetElem(2).Data == 3);
            target.AddLast(4);
            Assert.IsTrue(target.ToString() == "2,3,4");
            Assert.IsTrue(target.GetElemData(3) == 4);
            Assert.IsTrue(target.ListLength() == 3);
            
            Assert.IsTrue(target.GetElem(2).Data == 3);
            Assert.IsTrue(target.LocateElemIndex(3) == 2);
            Assert.IsTrue(target.LocateElemIndex(2) == 1); 
            Assert.IsTrue(target.PriorElemData(3) == 2);
            Assert.IsTrue(target.NextElemData(3) == 4);
            Assert.IsTrue(target.PriorElemData(2) == 0);//head

            target.ListInsert(2, 5);
            Assert.IsTrue(target.ToString() == "2,5,3,4");


            target.ListDelete(2);
            Assert.IsTrue(target.ToString() == "2,3,4");

        }
    }
}
