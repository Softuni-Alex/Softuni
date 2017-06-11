using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public Node Next { get; set; }

        public T Value { get; set; }
    }

    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = this.head;

        this.head = new Node(item);
        this.head.Next = old;

        if (this.Count == 0)
        {
            this.tail = this.head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = this.tail;

        this.tail = new Node(item);

        if (this.Count == 0)
        {
            this.head = this.tail;
        }
        else
        {
            old.Next = this.tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        var element = this.head.Value;
        if (element != null)
        {
            this.head = this.head.Next;
        }

        this.Count--;

        if (this.Count == 0)
        {
            this.tail = null;
        }

        return element;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        var element = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            var newTail = this.GetSecondLastNode();

            newTail.Next = null;
            this.tail = newTail;
        }

        this.Count--;

        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;

        while (currentNode != null)
        {
            yield return currentNode.Value;

            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private Node GetSecondLastNode()
    {
        var current = this.head;

        while (current.Next != this.tail)
        {
            current = current.Next;
        }

        return current;
    }
}
