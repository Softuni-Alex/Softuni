using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static SortedDictionary<int, Tree<int>> tree = new SortedDictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();

        var leafs = FindLeafs();

        Print(leafs);
    }

    private static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());

        for (int i = 1; i < nodeCount; i++)
        {
            string[] line = Console.ReadLine().Split(' ');

            int parent = int.Parse(line[0]);
            int child = int.Parse(line[1]);

            Add(parent, child);
        }
    }

    private static void Add(int parent, int child)
    {
        var parentNode = FindNode(parent);
        var childNode = FindNode(child);

        parentNode.Child.Add(childNode);
        childNode.Parent = parentNode;
    }

    private static Tree<int> FindNode(int value)
    {
        if (!tree.ContainsKey(value))
        {
            tree[value] = new Tree<int>(value);
        }

        return tree[value];
    }

    private static List<Tree<int>> FindLeafs()
    {
        var leafs = tree.Values.Where(l => l.Child.Count == 0).ToList();

        return leafs;
    }

    private static void Print(List<Tree<int>> leafs)
    {
        Console.Write("Leaf nodes: ");
        foreach (var leaf in leafs)
        {
            Console.Write(leaf.Value + " ");
        }
    }
}
