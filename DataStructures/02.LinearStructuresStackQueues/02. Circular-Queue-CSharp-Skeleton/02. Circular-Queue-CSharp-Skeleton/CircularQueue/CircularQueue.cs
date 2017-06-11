using System;

public class CircularQueue<T>
{
    private T[] data;
    private const int DefaultCapacity = 4;
    private int startIndex = 0;
    private int endIndex = 0;

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.data = new T[capacity];
    }

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        if (this.Count >= this.data.Length)
        {
            this.Resize();
        }

        this.data[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.data.Length;

        this.Count++;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var result = this.data[this.startIndex];
        this.startIndex = (this.startIndex + 1) % this.data.Length;

        this.Count--;

        return result;
    }

    private void Resize()
    {
        var newData = new T[this.data.Length * 2];

        this.CopyAllElements(newData);

        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElements(T[] newArray)
    {
        int sourceIndex = this.startIndex;

        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.data[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.data.Length;
        }

        this.data = newArray;
    }

    public T[] ToArray()
    {
        var elements = new T[this.Count];

        for (int i = 0; i < this.Count; i++)
        {
            elements[i] = this.data[i];
        }

        return elements;
    }
}

public class Example
{
    public static void Main()
    {
        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //int first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //queue.Enqueue(-7);
        //queue.Enqueue(-8);
        //queue.Enqueue(-9);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //queue.Enqueue(-10);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");
    }
}
