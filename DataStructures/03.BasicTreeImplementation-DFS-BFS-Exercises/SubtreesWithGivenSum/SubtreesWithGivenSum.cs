using System;
using System.Collections.Generic;
using System.Linq;

namespace SubtreesWithGivenSum
{
    public class SubtreesWithGivenSum
    {
        private static readonly Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            ReadTree();

            var root = GetRoot();

            foreach (var node in GetSubtreeWithSum(root))
            {
                PrintPreOrder(node);
                Console.WriteLine();
            }
        }

        private static void PrintPreOrder(Tree<int> node)
        {
            Console.Write(node.Value + " ");

            foreach (var child in node.Child)
            {
                PrintPreOrder(child);
            }
        }

        public static List<Tree<int>> GetSubtreeWithSum(Tree<int> root)
        {
            var target = int.Parse(Console.ReadLine());
            Console.WriteLine("Subtrees of sum " + target + ":");

            var roots = new List<Tree<int>>();

            int sum = Dfs(root, target, 0, roots);

            return roots;
        }

        private static int Dfs(Tree<int> node, int target, int current, List<Tree<int>> roots)
        {
            if (node == null)
            {
                return 0;
            }

            current = node.Value;

            foreach (var child in node.Child)
            {
                current += Dfs(child, target, current, roots);
            }

            if (current == target)
            {
                roots.Add(node);
            }

            return current;
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
}
