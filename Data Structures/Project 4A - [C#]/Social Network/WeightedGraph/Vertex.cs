using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeightedGraph
{
    class Vertex
    {
        public string label;        // label (e.g. 'A')
        public bool isInTree;
        // -------------------------------------------------------------
        public Vertex(string lab)   // constructor
        {
            label = lab;
            isInTree = false;
        }
    }
}
