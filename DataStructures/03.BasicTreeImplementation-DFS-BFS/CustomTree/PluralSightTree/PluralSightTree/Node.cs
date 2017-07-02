using System;

namespace PluralSightTree
{
    public class Node<T> : IComparable<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int CompareTo(T other)
        {
            return this.Value.CompareTo(other);
        }
    }
}
