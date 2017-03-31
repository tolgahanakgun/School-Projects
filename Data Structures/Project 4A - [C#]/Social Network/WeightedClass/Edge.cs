using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightedGraph
{
    class Edge
    {
        public int srcVert;   // index of a vertex starting edge
        public int destVert;  // index of a vertex ending edge
        public int distance;  // distance from src to dest
        // -------------------------------------------------------------
        public Edge(int sv, int dv, int d)  // constructor
        {
            srcVert = sv;
            destVert = dv;
            distance = d;
        }
    }
}
