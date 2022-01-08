using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Graph
    {

    public List<int>[] adjacencyList;

    public Graph()
    { 

        // Creating a graph with 12 vertices
        int V = 13;
        List<int>[] adj = new List<int>[V];

        for (int i = 0; i < V; i++)
            adj[i] = new List<int>();

        // Adding edges one by one
        /*
        addEdge(adj, 0, 1);
        addEdge(adj, 0, 4);
        addEdge(adj, 1, 2);
        addEdge(adj, 1, 3);
        addEdge(adj, 1, 4);
        addEdge(adj, 2, 3);
        addEdge(adj, 3, 4);
        */



        // path for purple 0-1-4-7-8 or 0-2-3
        // path for yellow 12-9

        addEdge(adj, 0, 2);
        addEdge(adj, 0, 1);
        addEdge(adj, 1, 4); // CHECK IF 2 ALSO CAN BE ADJ OF 1
        addEdge(adj, 2, 3);
        addEdge(adj, 4, 7);
        addEdge(adj, 5, 6); 
        addEdge(adj, 6, 7);
        addEdge(adj, 7, 8);
        addEdge(adj, 9, 10);
        addEdge(adj, 10, 0);
        addEdge(adj, 11, 0);
        addEdge(adj, 12, 5);
        addEdge(adj, 12, 9);

        //printGraph(adj);
        adjacencyList = adj;

      //Console.ReadKey();
    }
    // A utility function to add an edge in an
    // undirected graph
    public void addEdge(List<int>[] adj, int u, int v)
    {
        ///////adj[u].AddLast(v);
        adj[u].Add(v);
        //adj[v].AddLast(u);
    }

    /*
    public GameObject GetAdjacent(int grid_,int numberOfAdj)
    {
        for (int i = 0; i < adj; i++)
        {

        }
        List <int> arr =
    }*/

    // A utility function to print the adjacency list
    // representation of graph
    public void printGraph(List<int>[] adj)
    {
        for (int i = 0; i < adj.Length; i++)
        {
            /////LinkedList<int> arr = adj[i];
            List<int> arr = adj[i];
            Debug.Log("head"+i);
            for (int k = 0; k < arr.Count; k++)
            {
                Debug.Log(arr[k]);
            }

            
            /*
            Debug.Log("\nAdjacency list of vertex "
                              + i);
            Debug.Log("head");

            foreach (var item in adj[i])
            {
                Debug.Log(" -> " + item);
            }
            //Debug.Log();
            */
        }
    }

 
}
