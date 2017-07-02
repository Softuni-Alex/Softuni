using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node<T> root;

    private BinarySearchTree(Node<T> root)
    {
        this.Copy(root);
    }

    public BinarySearchTree()
    {
    }

    public bool Contains(T value)
    {
        var current = this.root;

        while (current != null)
        {
            if (value.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else if (value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else
            {
                break;
            }
        }

        return current != null;
    }

    public void Insert(T value)
    {
        var node = new Node<T>(value);

        if (this.root == null)
        {
            this.root = node;
        }
        else
        {
            this.Add(this.root, value);
        }
    }

    private void Add(Node<T> node, T value)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            if (node.Left == null)
            {
                node.Left = new Node<T>(value);
            }
            else
            {
                this.Add(node.Left, value);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new Node<T>(value);
            }
            else
            {
                this.Add(node.Right, value);
            }
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.InOrder(action, this.root);
    }

    private void InOrder(Action<T> action, Node<T> node)
    {
        if (node != null)
        {
            this.InOrder(action, node.Left);
            action(node.Value);
            this.InOrder(action, node.Right);
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        var current = this.root;

        while (current != null)
        {
            if (item.CompareTo(current.Value) > 0)
            {
                current = current.Right;
            }
            else if (item.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else
            {
                break;
            }
        }

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node<T> parent = null;
        Node<T> min = this.root;

        while (min.Left != null)
        {
            parent = min;
            min = parent.Right;
        }

        if (parent == null)
        {
            this.root = min.Right;
        }
        else
        {
            parent.Left = min.Right;
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        var queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node<T> root, Queue<T> queue, T startRange, T endRange)
    {
        if (root == null)
        {
            return;
        }

        int nodeLowerRange = startRange.CompareTo(root.Value);
        int nodeHighRange = endRange.CompareTo(root.Value);

        if (nodeLowerRange < 0)
        {
            this.Range(root.Left, queue, startRange, endRange);
        }
        if (nodeLowerRange <= 0 && nodeHighRange >= 0)
        {
            queue.Enqueue(root.Value);
        }
        if (nodeHighRange > 0)
        {
            this.Range(root.Right, queue, startRange, endRange);
        }
    }

    private void Copy(Node<T> node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }
}

public class Launcher
{
    public static void Main()
    {

    }
}