using System;
using System.Collections.Generic;

public class TopologicalSorter
{
    public static HashSet<string> visited;
    private static HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.Graph = graph;
        visited = new HashSet<string>();
        cycleNodes = new HashSet<string>();
    }

    public Dictionary<string, List<string>> Graph { get; set; }

    public ICollection<string> TopSort()
    {
        var sorted = new LinkedList<string>();

        foreach (var node in Graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(string node, LinkedList<string> result)
    {
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach (var nodes in Graph.Keys)
            {
                this.DFS(nodes, result);
            }

            cycleNodes.Remove(node);
            result.AddFirst(node);
        }
    }
}
