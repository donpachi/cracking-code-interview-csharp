using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1_route_bw_nodes
{
    /* Given a directed graph, design an algorithm to found out whether there is a
     * route between nodes 
     * Thoughts: DFS or BFS will work. BFS will find shortest path, lets go with BFS
     * BFS will require starting at a node and queueing up its neighbors for visit order to do a level-by-level search
     */
    class Program
    {
        class Node
        {
            public bool Visited { get; set; }
            public Node[] neighbours;
        }

        class Graph
        {
            Node[] nodes;
            public Graph() { }
            //returns an iterable collection of all the nodes in the graph
            public Node[] GetNodes() { return nodes; }
        }

        bool IsConnected(Graph g, Node src, Node dst)
        {
            if (src == dst) return true;
            //make sure we're working with a new search
            foreach (Node n in g.GetNodes()) n.Visited = false;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(src); 
            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (node != null)   // conditional takes care of empty graph case
                {
                    foreach(Node neighbour in node.neighbours)
                    {
                        if (!neighbour.Visited)
                        {
                            if (neighbour == dst)
                                return true;
                            else
                                q.Enqueue(neighbour);
                        }
                    }
                }
                node.Visited = true;
            }
            return false;
        }

        static void Main(string[] args)
        {
        }
    }
}
