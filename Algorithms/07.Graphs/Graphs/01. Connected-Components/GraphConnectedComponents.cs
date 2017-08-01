﻿using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph = new List<int>[]
     {
        new List<int>() { 3, 6 },
        new List<int>() { 3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() { },
        new List<int>() { 2 }
     };

    private static bool[] visited = new bool[graph.Length];

    public static void Main()
    {
        graph = ReadGraph();

        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");
                DFS(startNode);
                Console.WriteLine();
            }
        }
    }

    private static void DFS(int vertex) //node
    {
        if (!visited[vertex])
        {
            visited[vertex] = true;

            foreach (var child in graph[vertex])
            {
                DFS(child);
            }

            Console.Write(" " + vertex);
        }
    }
}
