using CustomLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestLinkedList
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        public void TestInit()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        public void TestAddItemToListShouldPass()
        {
            this.dynamicList.Add(4);
            Assert.AreEqual(1, this.dynamicList.Count);
        }

        [TestMethod]
        public void TestAddTenItemsToList()
        {
            for (int i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }
            Assert.AreEqual(10, this.dynamicList.Count);
        }

        [TestMethod]
        public void TestRemoveItem()
        {
            this.dynamicList.Add(3);
            this.dynamicList.Add(5);
            this.dynamicList.Add(2);

            this.dynamicList.Remove(2);

            Assert.AreEqual(2, this.dynamicList.Count);
        }

        [TestMethod]
        public void TestRemoveAtShouldPass()
        {
            this.dynamicList.Add(1);
            this.dynamicList.Add(3);
            this.dynamicList.Add(5);

            this.dynamicList.RemoveAt(2);
            Assert.AreEqual(2, this.dynamicList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAtShouldThrow()
        {
            this.dynamicList.RemoveAt(2);
        }

        [TestMethod]
        public void TestContainsAnElement()
        {
            for (int i = 0; i < 10; i++)
            {
                this.dynamicList.Add(i);
            }

            bool result = this.dynamicList.Contains(4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIndexOfShouldPass()
        {
            this.dynamicList.Add(3);
            this.dynamicList.Add(11);
            this.dynamicList.Add(13);
            this.dynamicList.Add(15);


            var result = this.dynamicList.IndexOf(15);

            Assert.AreEqual(3, result);

        }
    }
}