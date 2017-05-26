using System;

namespace TDD
{
    public class CustomStack<T>
    {
        private const int DefaultCapacity = 16;
        private T[] items;

        public CustomStack(int capacity = DefaultCapacity)
        {

            this.Capacity = capacity;
            this.items = new T[Capacity];
            this.Count = 0;
        }

        private void Resize()
        {
            var newItems = new T[this.Capacity * 2];
            Array.Copy(this.items, newItems, this.Count);
            this.items = newItems;
            this.Capacity *= 2;
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");

            }
            var lastItem = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(T);
            Count--;
            return lastItem;

        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return this.items[this.Count - 1];

        }
    }
}
