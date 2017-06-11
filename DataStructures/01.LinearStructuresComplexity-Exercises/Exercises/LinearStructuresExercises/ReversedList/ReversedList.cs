using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private T[] data;

    public ReversedList()
    {
        this.data = new T[2];
    }

    public int Count { get; set; }

    public int Capacity
    {
        get { return this.data.Length; }
        private set { }
    }

    public void Add(T item)
    {
        if (item != null)
        {
            if (this.data.Length <= this.Count)
            {
                this.Resize();
            }

            this.data[this.Count] = item;

            this.Count++;
        }
    }

    public T this[int index]
    {
        get
        {
            this.CheckTheIndex(index);

            var reversedArr = this.Reverse();

            return reversedArr[index];
        }
        set
        {
            if (this.data.Length <= this.Count)
            {
                this.Resize();
            }

            this.CheckTheIndex(index);

            this.data[index] = value;
            this.Count++;
        }
    }

    public T RemoveAt(int index)
    {
        this.CheckTheIndex(index);

        var reversedList = this.Reverse();

        T element = reversedList[index];

        this.data = reversedList;

        this.data[index] = default(T);

        this.Shift(index, reversedList);

        this.Count--;

        var newArr = this.Reverse();

        this.data = newArr;

        return element;
    }

    private void Shift(int index, T[] reversedList)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.data[i] = reversedList[i + 1];
        }

        this.data[this.Count - 1] = default(T);
    }

    private void Resize()
    {
        var replacingArray = new T[this.Capacity * 2];

        for (int i = 0; i < this.data.Length; i++)
        {
            replacingArray[i] = this.data[i];
        }

        this.data = replacingArray;
    }

    private void CheckTheIndex(int index)
    {
        if (index > this.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private T[] Reverse()
    {
        T[] copied = new T[this.Count];

        int index = 0;
        for (int i = this.Count; i > 0; i--)
        {
            copied[index] = this.data[i - 1];
            index++;
        }

        return copied;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}