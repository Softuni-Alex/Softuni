using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintTree
{
    public class Program
    {
        private static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();

            var root = FindRoot();

            Print(0, root);
        }

        private static void Print(int indented, Tree<int> root)
        {
            Console.Write(new string(' ', indented));
            Console.WriteLine(root.Value);

            for (int i = 0; i < root.Child.Count; i++)
            {
                Print(indented + 2, root.Child[i]);
            }
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

        private static Tree<int> FindRoot()
        {
            return tree.Values.FirstOrDefault(x => x.Parent == null);
        }
    }
}
