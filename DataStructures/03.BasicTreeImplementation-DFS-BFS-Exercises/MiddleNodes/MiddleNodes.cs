using System;
using System.Collections.Generic;
using System.Linq;

public class MiddleNodes
{
    private static readonly SortedDictionary<int, Tree<int>> tree = new SortedDictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();

        var middleNodes = FindMiddleNodes();

        Print(middleNodes);
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

    private static List<Tree<int>> FindMiddleNodes()
    {
        var middleNodes = tree.Values
            .Where(n => n.Child.Count > 0 && n.Parent != null)
            .OrderBy(n => n.Value)
            .ToList();

        return middleNodes;
    }

    private static void Print(List<Tree<int>> middleNodes)
    {
        Console.Write("Middle nodes: ");
        foreach (var middleNode in middleNodes)
        {
            Console.Write(middleNode.Value + " ");
        }
    }
}
