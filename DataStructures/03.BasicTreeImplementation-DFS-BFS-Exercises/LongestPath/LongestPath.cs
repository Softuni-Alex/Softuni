using System;
using System.Collections.Generic;
using System.Linq;

public class LongestPath
{
    private static readonly Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();
    private static List<int> result = new List<int>();

    public static void Main()
    {
        ReadTree();

        int maxLevel = 0;

        Dfs(GetRoot(), 1, ref maxLevel);

        Print(result);
    }

    private static Tree<int> GetRoot()
    {
        return tree.Values.FirstOrDefault(t => t.Parent == null);
    }

    private static void Dfs(Tree<int> root, int level, ref int maxLevel)
    {
        if (root == null)
        {
            return;
        }

        if (level > maxLevel)
        {
            result.Add(root.Value);
            maxLevel = level;
        }

        foreach (var child in root.Child)
        {
            Dfs(child, level + 1, ref maxLevel);
        }
    }

    private static void Print(List<int> longestPath)
    {
        Console.Write("Longest path: ");
        foreach (var longest in longestPath)
        {
            Console.Write(longest + " ");
        }
    }

    #region Tree Operations
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
    #endregion
}
