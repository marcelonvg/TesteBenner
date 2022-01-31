using System;
using System.Collections.Generic;

class Network {
    private int V;
    private bool contains;
    private List<int>[] adj;
 
    // Constructor
    Network(int v)
    {
        contains = false;
        V = v;
        adj = new List<int>[ v ];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }
    void connect(int v, int w)
    {
        // Connects bidirectionally
        adj[v].Add(w); 
        adj[w].Add(v);
    }
 

    void DFS(int v, bool[] visited, int w)
    {

        visited[v] = true;
        Console.Write(v + " ");
        if (adj[v].Contains(w)) {
            this.contains = true;
            return;
        };
       

 
        List<int> vList = adj[v];
        foreach(var n in vList)
        {
            if (this.contains == true) break;

            if (!visited[n])
                DFS(n, visited, w);
        }
    }
 
    bool query(int v, int w)
    {
        bool[] visited = new bool[V];
 
        DFS(v, visited, w);

        return this.contains;

    }

 

    public static void Main(String[] args)
    {
        Network g = new Network(9);

        g.connect(1, 2);
        g.connect(1, 6);
        g.connect(2, 1);
        g.connect(2, 6);
        g.connect(2, 4);
        g.connect(4, 2);
        g.connect(5, 8);
		g.connect(6, 2);
		g.connect(6, 1);
		g.connect(8, 5);
        
 
        Console.Write(g.query(1, 5));
        Console.ReadKey();
    }
}