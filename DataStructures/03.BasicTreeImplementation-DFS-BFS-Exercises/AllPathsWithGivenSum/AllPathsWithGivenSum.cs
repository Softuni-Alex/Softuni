using System;
using System.Collections.Generic;
using System.Linq;

public class AllPathsWithGivenSum
{
    private static readonly Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();
    private static int sum = 0;

    public static void Main()
    {
        ReadTree();

        var root = GetRoot();

        var path = FindPathSum(root);

        Console.Write("Paths of sum " + sum + ":");
        Console.WriteLine();
        foreach (var leaf in path)
        {
            PrintPath(leaf);
        }
    }

    private static void PrintPath(Tree<int> leaf)
    {
        var stack = new Stack<int>();

        var current = leaf;

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Parent;
        }

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }

    public static List<Tree<int>> FindPathSum(Tree<int> root)
    {
        var leafs = new List<Tree<int>>();

        Dfs(root, sum, 0, leafs);

        return leafs;
    }

    public static void Dfs(Tree<int> node, int target, int current, List<Tree<int>> leafs)
    {
        if (node == null)
        {
            return;
        }

        current += node.Value;

        if (current == target && node.Child.Count == 0)
        {
            leafs.Add(node);
        }

        foreach (var child in node.Child)
        {
            Dfs(child, target, current, leafs);
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

        sum = int.Parse(Console.ReadLine());
    }

    public static Tree<int> GetRoot()
    {
        return tree.Values.FirstOrDefault(r => r.Parent == null);
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