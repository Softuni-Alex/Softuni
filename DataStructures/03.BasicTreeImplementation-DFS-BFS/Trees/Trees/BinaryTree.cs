using System;

public class BinaryTree<T>
{
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.Left = leftChild;
        this.Right = rightChild;
    }

    public T Value { get; set; }

    public BinaryTree<T> Left { get; set; }

    public BinaryTree<T> Right { get; set; }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.Write(new string(' ', indent * 2));

        Console.WriteLine(this.Value);

        if (this.Left != null)
        {
            this.Left.PrintIndentedPreOrder(indent + 1);
        }

        if (this.Right != null)
        {
            this.Right.PrintIndentedPreOrder(indent + 1);

        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.Left != null)
        {
            this.Left.EachInOrder(action);
        }

        action(this.Value);

        if (this.Right != null)
        {
            this.Right.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (this.Left != null)
        {
            this.Left.EachPostOrder(action);
        }

        if (this.Right != null)
        {
            this.Right.EachPostOrder(action);
        }

        action(this.Value);
    }
}
