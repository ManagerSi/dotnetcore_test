using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using NUnit.Framework;

namespace Tests.DataStructuresTests
{
    class MyQueueTests
    {
        private MyQueueWithArray<int> target1 = new MyQueueWithArray<int>();

        [Test]
        public void MyQueueWithArray_test()
        {
            target1.Enqueue(3);
            Assert.IsTrue(target1.ToString() == "3");
            target1.Enqueue(2);
            Assert.IsTrue(target1.ToString() == "3,2");
            Assert.IsTrue(target1.Peek() == 3);
            target1.Enqueue(4);
            Assert.IsTrue(target1.ToString() == "3,2,4");
            Assert.IsTrue(target1.Contains(3) == true);
            Assert.IsTrue(target1.Peek() == 3);
            Assert.IsTrue(target1.Dequeue() == 3);
            Assert.IsTrue(target1.Peek() == 2);
            Assert.IsTrue(target1.Contains(3) == false);

            target1.Enqueue( 5);
            Assert.IsTrue(target1.ToString() == "2,4,5");

            target1.Clear();
            Assert.IsTrue(target1.ToString() == "");
            var ex = Assert.Catch<InvalidOperationException>(() => target1.Peek());
            Assert.IsTrue(ex.Message == "queue is empty");

        }

        [Test]
        public void MyQueueWithNode_test()
        {
            Assert.Fail("to do implement");
        }
    }
}
