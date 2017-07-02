using System;
using System.Collections.Generic;
using System.Linq;

public class DeepestNode
{
    private static readonly Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();

        var root = GetRoot();

        var deepest = FindDeepestNode(root);

        Console.WriteLine("Deepest node: " + deepest.Value);
    }

    private static Tree<int> GetRoot()
    {
        return tree.Values.FirstOrDefault(n => n.Parent == null);
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

    private static Tree<int> FindDeepestNode(Tree<int> root)
    {
        int maxLevel = 0;
        Tree<int> deepest = null;

        Dfs(root, 1, ref maxLevel, ref deepest);

        return deepest;
    }

    private static void Dfs(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
    {
        if (node == null)
        {
            return;
        }

        if (level > maxLevel)
        {
            deepest = node;
            maxLevel = level;
        }

        foreach (var child in node.Child)
        {
            Dfs(child, level + 1, ref maxLevel, ref deepest);
        }
    }
}
