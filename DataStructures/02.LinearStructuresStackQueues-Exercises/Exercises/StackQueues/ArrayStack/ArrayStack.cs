using System;

public class ArrayStack<T>
{
    private T[] data;
    private const int Capacity = 16;

    public ArrayStack(int capacity = Capacity)
    {
        this.data = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count == this.data.Length)
        {
            this.Grow();
        }

        this.data[this.Count] = element;

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack empty!");
        }

        var element = this.data[this.Count - 1];

        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[this.Count];

        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.data[this.Count - 1 - i];
        }

        return newArray;
    }

    private void Grow()
    {
        var newData = new T[this.Count * 2];

        for (int i = 0; i < this.data.Length; i++)
        {
            newData[i] = this.data[i];
        }

        this.data = newData;
    }
}
