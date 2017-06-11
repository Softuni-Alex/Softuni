using System;

public class LinkedQueue<T>
{
    private Node<T> head;
    private Node<T> tail;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        var newNode = new Node<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            newNode.Previous = this.tail;

            this.tail = newNode;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException("Queue is empty!");
        }

        var firstNode = this.head.Value;

        this.head = this.head.Next;

        this.Count--;

        return firstNode;
    }

    public T[] ToArray()
    {
        var result = new T[this.Count];

        var current = this.head;

        for (int i = 0; i < this.Count; i++)
        {
            result[i] = current.Value;

            current = current.Next;
        }

        return result;
    }

    private class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}