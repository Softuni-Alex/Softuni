using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int Capacity = 4;
        private T[] data;

        public Queue()
        {
            this.data = new T[Capacity];
        }

        public int Count { get; set; }

        public int Head { get; set; }

        public int Tail { get; set; } = -1;

        public void Enqueue(T element)
        {
            if (this.data.Length == this.Count)
            {
                this.Grow();
            }

            if (this.Count > 0)
            {
                int targetIndex = 0;

                if (this.Tail < this.Head)
                {
                    for (int i = this.Head; i < this.data.Length; i++)
                    {
                        this.data[targetIndex] = this.data[i];
                        targetIndex++;
                    }

                    for (int i = 0; i <= this.Tail; i++)
                    {
                        this.data[targetIndex] = this.data[i];
                        targetIndex++;
                    }
                }
                else
                {
                    for (int i = this.Head; i <= this.Tail; i++)
                    {
                        this.data[targetIndex] = this.data[i];
                        targetIndex++;
                    }
                }

                this.Head = 0;
                this.Tail = targetIndex - 1;
            }
            else
            {
                this.Head = 0;
                this.Tail = -1;
            }

            if (this.Tail == this.data.Length - 1)
            {
                this.Tail = 0;
            }
            else
            {
                this.Tail++;
            }

            this.data[this.Tail] = element;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = this.data[this.Head];

            if (this.Head == this.data.Length - 1)
            {
                this.Head = 0;
            }
            else
            {
                this.Head++;
            }

            this.Count--;

            return value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return this.data[this.Head];
        }

        private void Grow()
        {
            var newArray = new T[this.Count * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newArray[i] = this.data[i];
            }

            this.data = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count > 0)
            {
                if (this.Tail < this.Head)
                {
                    for (int i = this.Head; i < this.data.Length; i++)
                    {
                        yield return this.data[i];
                    }

                    for (int i = 0; i <= this.Head; i++)
                    {
                        yield return this.data[i];
                    }
                }
                else
                {
                    for (int i = this.Head; i <= this.Tail; i++)
                    {
                        yield return this.data[i];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}