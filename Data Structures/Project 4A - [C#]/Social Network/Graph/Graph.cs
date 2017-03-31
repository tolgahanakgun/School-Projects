using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightedGraph
{
    class Graph
    {
        private int MAX_VERTS = 20;
        private int INFINITY = 1000000;
        private Vertex[] vertexList; // list of vertices
        private int[,] adjMat;      // adjacency matrix
        private int nVerts;          // current number of vertices
        private int currentVert;
        private PriorityQ thePQ;
        private int nTree;           // number of verts in tree
    // -------------------------------------------------------------
        public Graph()               // constructor
        {
            vertexList = new Vertex[MAX_VERTS];
                                                // adjacency matrix
            adjMat = new int[MAX_VERTS,MAX_VERTS];
            nVerts = 0;
            for(int j=0; j<MAX_VERTS; j++)      // set adjacency
                for(int k=0; k<MAX_VERTS; k++)   //    matrix to 0
                adjMat[j,k] = INFINITY;
            thePQ = new PriorityQ();
        }  // end constructor
    // -------------------------------------------------------------
        public void addVertex(string lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
    // -------------------------------------------------------------
        public void addEdge(int start, int end,int weight)
        {
            adjMat[start,end] = weight;
            adjMat[end,start] = weight;
        }
    // -------------------------------------------------------------
        public void displayVertex(int v)
        {
            Console.WriteLine(vertexList[v].label);
        }

        public void mst()  // minimum spanning tree (depth first)
        {
            currentVert = 0;          // start at 0

            while(nTree < nVerts-1)   // while not all verts in tree
                {                      // put currentVert in tree
                vertexList[currentVert].isInTree = true;
                nTree++;

                // insert edges adjacent to currentVert into PQ
                for(int j=0; j<nVerts; j++)   // for each vertex,
                {
                if(j==currentVert)         // skip if it's us
                    continue;
                if(vertexList[j].isInTree) // skip if in the tree
                    continue;
                int distance = adjMat[currentVert,j];
                if( distance == INFINITY)  // skip if no edge
                    continue;
                putInPQ(j, distance);      // put it in PQ (maybe)
                }
                if(thePQ.getSize()==0)           // no vertices in PQ?
                    {
                        Console.WriteLine(" GRAPH NOT CONNECTED");
                    return;
                    }
                // remove edge with minimum distance, from PQ
                Edge theEdge = thePQ.removeMin();
                int sourceVert = theEdge.srcVert;
                currentVert = theEdge.destVert;

                // display edge from source to current
                Console.WriteLine( vertexList[sourceVert].label );
                Console.WriteLine( vertexList[currentVert].label );
                Console.WriteLine(" ");
                }  // end while(not all verts in tree)

            // mst is complete
            for(int j=0; j<nVerts; j++)     // unmark vertices
                vertexList[j].isInTree = false;
        }  // end mstw

        public void putInPQ(int newVert, int newDist)
        {
            // is there another edge with the same destination vertex?
            int queueIndex = thePQ.find(newVert);
            if (queueIndex != -1)              // got edge's index
            {
                Edge tempEdge = thePQ.peekN(queueIndex);  // get edge
                int oldDist = tempEdge.distance;
                if (oldDist > newDist)          // if new edge shorter,
                {
                    thePQ.removeN(queueIndex);  // remove old edge
                    Edge theEdge =
                                new Edge(currentVert, newVert, newDist);
                    thePQ.insert(theEdge);      // insert new edge
                }
                // else no action; just leave the old vertex there
            }  // end if
            else  // no edge with same destination vertex
            {                              // so insert new one
                Edge theEdge = new Edge(currentVert, newVert, newDist);
                thePQ.insert(theEdge);
            }
        }  // end putInPQ()

        private int minDistance(int[] dist, bool[] sptSet, int MAX)
        {
            int min = Int16.MaxValue, min_index = 0;
            for (int v = 0; v < MAX; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            return min_index;
        }

        public int dijkstra(int[,] graph, int MAX, int src, int dest)
        {
            int[] dist = new int[MAX];
            bool[] sptSet = new bool[MAX];
            for (int i = 0; i < MAX; i++)
            {
                dist[i] = Int16.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0;
            for (int count = 0; count < MAX - 1; count++)
            {
                int u = minDistance(dist, sptSet, MAX);
                sptSet[u] = true;
                for (int v = 0; v < MAX; v++)
                    if (!sptSet[v] && (graph[u, v] != null) && dist[u] != Int16.MaxValue
                                                && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }
            return dist[dest];
        }

        public void GraphOlustur()
        {
            Graph theGraph = new Graph();

            theGraph.addVertex("John");           // 0  (start for mst)
            theGraph.addVertex("Olivia");        // 1
            theGraph.addVertex("Celine");       // 2
            theGraph.addVertex("Chloe");       // 3
            theGraph.addVertex("Jack");       // 4
            theGraph.addVertex("Winston");   // 5

            theGraph.addEdge(0, 1, 12);      // John   - Olivia     12
            theGraph.addEdge(0, 3, 9);       // John   - Chloe      9
            theGraph.addEdge(0, 4, 7);       // John   - Jack       7
            theGraph.addEdge(1, 2, 5);       // Olivia - Celine     5
            theGraph.addEdge(1, 4, 8);       // Olivia - Jack       8
            theGraph.addEdge(2, 4, 6);       // Celine - Jack       6
            theGraph.addEdge(2, 5, 10);      // Celine - Winston    10
            theGraph.addEdge(3, 4, 4);       // Chloe  - Jack       4
            theGraph.addEdge(3, 5, 15);      // Chloe  - Winston    15
            theGraph.addEdge(4, 5, 16);      // Jack   - Winston    16

        }
    }
}
