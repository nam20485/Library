using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Graph<TValue>
    {
        //public enum GraphType
        //{
        //    Directed,
        //    Undirected
        //}

        //public GraphType Type { get; }

        public Node.List Nodes { get; } = new Node.List();

        //public Graph(GraphType type)
        //{
        //    Type = type;
        //}

        public void Add(Node n)
        {
            Nodes.Add(n);
        }

        public class Node : Graph<TValue>       // each node is, and can be treated as, a "sub-graph"
        {
            public TValue Value { get; }

            public Node(TValue value)
            {
                Value = value;
            }

            public class List : List<Node>  { }
        }
    }
}
