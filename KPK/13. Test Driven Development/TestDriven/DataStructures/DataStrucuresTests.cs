namespace DataStructures
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TDD;

    [TestClass]
    public class DataStructuresTests
    {
        private CustomStack<int> stack;

        [TestInitialize]
        public void TestInit()
        {
            this.stack = new CustomStack<int>();
        }

        [TestMethod]
        public void Push_ShouldIncrementCount()
        {
            stack.Push(5);
            Assert.AreEqual(1, stack.Count);

        }

        [TestMethod]
        public void PushOverCapacity_ShouldResizeCorrectly()
        {
            var fixedStack = new CustomStack<int>(1);
            for (int i = 0; i < 100; i++)
            {
                fixedStack.Push(i);
            }
            Assert.AreEqual(100, fixedStack.Count);
        }

        [TestMethod]
        public void Pushed_MultipleElements_ShouldBePoppedInReverseOrder()
        {
            int[] numbers = { 3, 5, 10, 6, 2, 3, 1 };

            for (int i = 0; i < numbers.Length; i++)
            {
                this.stack.Push(numbers[i]);
            }
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                var currentNum = this.stack.Pop();
                Assert.AreEqual(numbers[i], currentNum);
            }
        }

        [TestMethod]
        public void Peek_NonEmptyStack_ShouldReturnLastPushedElementWithoutRemovingIt()
        {
            this.stack.Push(3);
            this.stack.Push(2);
            this.stack.Push(5);
            var lastElement = this.stack.Peek();
            Assert.AreEqual(5, lastElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ShouldThrow()
        {
            this.stack.Peek();
        }

        [TestMethod]
        public void Peek_ShouldReturnLastPushedElement_WithoutRemovingIt()
        {
            int count = this.stack.Count;
            this.stack.Push(5);
            this.stack.Peek();

            Assert.AreEqual(count + 1, this.stack.Count);
        }

        [TestMethod]
        public void Pop_NonEmptyStackShouldReturnLastPushedElementAndRemoveIt()
        {
            const int LastItem = 10;

            for (int currentItem = 0; currentItem <= LastItem; currentItem++)
            {
                this.stack.Push(currentItem);
            }
            var count = this.stack.Count;
            var poppedItem = this.stack.Pop();

            Assert.AreEqual(LastItem, poppedItem);
            Assert.AreEqual(count - 1, this.stack.Count);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStackShouldThrow()
        {
            this.stack.Pop();
        }
    }
}