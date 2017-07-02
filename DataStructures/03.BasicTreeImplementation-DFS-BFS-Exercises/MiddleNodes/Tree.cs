using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] child)
    {
        this.Value = value;
        this.Child = new List<Tree<T>>();

        foreach (var chil in child)
        {
            this.Child.Add(chil);
            chil.Parent = this;
        }
    }

    public T Value { get; set; }

    public Tree<T> Parent { get; set; }

    public List<Tree<T>> Child { get; private set; }
}