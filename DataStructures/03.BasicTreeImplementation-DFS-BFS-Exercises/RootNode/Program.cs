using System;
using System.Collections.Generic;
using System.Linq;

namespace RootNode
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        private static Tree<int> FindNodeByValue(int value)
        {
            if (!tree.ContainsKey(value))
            {
                tree[value] = new Tree<int>(value);
            }

            return tree[value];
        }

        private static void Add(int parent, int child)
        {
            var parentNode = FindNodeByValue(parent);
            var childNode = FindNodeByValue(child);

            parentNode.Child.Add(childNode);
            childNode.Parent = parentNode;
        }

        private static void ReadTree()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                var line = Console.ReadLine().Split(' ');

                Add(int.Parse(line[0]), int.Parse(line[1]));
            }
        }

        private static Tree<int> FindRoot()
        {
            return tree.Values.FirstOrDefault(x => x.Parent == null);
        }

        public static void Main()
        {
            ReadTree();

            var root = FindRoot();

            Console.WriteLine("Root node: " + root.Value);
        }
    }
}
