using _01.LinkedQueue;
using System;

namespace TestLinkedQueue
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTest
    {
        private LinkedQueue<int> linkedQueue;

        [TestInitialize]
        public void TestInit()
        {
            this.linkedQueue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void Test_Enqueue_ShouldAddElement()
        {
            this.linkedQueue.Enqueue(3);

            Assert.AreEqual(1, this.linkedQueue.Count);
        }

        [TestMethod]
        public void Test_EnqueueAndDequeueElement()
        {
            this.linkedQueue.Enqueue(4);
            this.linkedQueue.Enqueue(2);

            Assert.AreEqual(2, this.linkedQueue.Count);

            this.linkedQueue.Dequeue();
            Assert.AreEqual(1, this.linkedQueue.Count);
        }

        [TestMethod]
        public void Test_EnqueueAndDequeueExpectedOne()
        {
            for (int i = 0; i < 10; i++)
            {
                this.linkedQueue.Enqueue(i);
            }
            Assert.AreEqual(10, this.linkedQueue.Count);
        }

        [TestMethod]
        public void Test_EnqueueDequeueAndCheckCount()
        {
            this.linkedQueue.Enqueue(1);
            this.linkedQueue.Enqueue(5);
            this.linkedQueue.Enqueue(3);
            this.linkedQueue.Enqueue(2);
            this.linkedQueue.Enqueue(7);

            this.linkedQueue.Dequeue();
            this.linkedQueue.Dequeue();
            this.linkedQueue.Dequeue();

            Assert.AreEqual(2, this.linkedQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_DequeueEmptyQueue_ShouldThrow()
        {
            this.linkedQueue.Dequeue();
        }

        [TestMethod]
        public void Test_Clear()
        {
            this.linkedQueue.Clear();
            Assert.AreEqual(0, this.linkedQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_PeekShouldThrow()
        {
            this.linkedQueue.Peek();
        }

        [TestMethod]
        public void TestContains()
        {
            this.linkedQueue.Enqueue(3);
            this.linkedQueue.Enqueue(5);
            this.linkedQueue.Enqueue(7);

            bool contains = this.linkedQueue.Contains(3);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void TestContainsShouldFail()
        {
            bool contains = this.linkedQueue.Contains(3);

            Assert.IsFalse(contains);
        }
    }
}