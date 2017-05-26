using System;

public class ArrayList<T>
{
    private T[] array;

    public ArrayList()
    {
        this.array = new T[2];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            this.CheckTheIndex(index);

            return this.array[index];
        }
        set
        {
            this.CheckTheIndex(index);

            this.array[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count == this.array.Length)
        {
            this.Resize();
        }

        this.array[this.Count++] = item;
    }

    private void Resize()
    {
        T[] copyArray = new T[this.array.Length * 2];

        for (int i = 0; i < this.array.Length; i++)
        {
            copyArray[i] = this.array[i];
        }

        this.array = copyArray;
    }

    public T RemoveAt(int index)
    {
        this.CheckTheIndex(index);

        T element = this.array[index];

        this.array[index] = default(T);

        this.Shift(index);

        this.Count--;

        if (this.Count <= this.array.Length / 4)
        {
            this.Shrink();
        }

        return element;
    }

    private void CheckTheIndex(int index)
    {
        if (index > this.Count - 1 || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.array[i] = this.array[i + 1];
        }
    }

    private void Shrink()
    {
        T[] copyArray = new T[this.array.Length / 2];

        for (int i = 0; i < this.Count; i++)
        {
            copyArray[i] = this.array[i];
        }

        this.array = copyArray;
    }
}
