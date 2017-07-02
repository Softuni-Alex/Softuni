using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public T Value { get; set; }

    public IList<Tree<T>> Children { get; private set; }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);

        foreach (var child in this.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();

        this.Dfs(this, result);

        return result;
    }

    private void Dfs(Tree<T> tree, List<T> result)
    {
        foreach (var treeChild in tree.Children)
        {
            this.Dfs(treeChild, result);
        }

        result.Add(tree.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();

        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            result.Add(current.Value);

            foreach (var currentChild in current.Children)
            {
                queue.Enqueue(currentChild);
            }
        }

        return result;
    }
}
