using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.DataStructures
{
    public class Graph<TValue> where TValue : IEquatable<TValue>
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

        public class Node : Graph<TValue>     // each node is, and can be treated as, a "sub-graph"
        {
            public TValue Value { get; }

            public Node(TValue value)
            {
                Value = value;
            }

            public class List : List<Node>  { }

            internal Node DfsHelper(TValue value, System.Collections.Generic.HashSet<Node> visited)
            {
                if (Value.Equals(value))
                {
                    return this;
                }
                else
                {
                    visited.Add(this);
                    foreach (var child in Nodes)
                    {
                        if (! visited.Contains(child))
                        {
                            var found = child.DfsHelper(value, visited);
                            if (found != null)
                            {
                                return found;
                            }
                        }
                    }

                    return null;
                }
            }
        }

        public Node BreadthFirstSearch(TValue value)
        {
            if (Nodes.Count > 0)
            {
                var q = new Queue<Node>();
                var visited = new System.Collections.Generic.HashSet<Node>();

                q.Enqueue(Nodes.First());
                visited.Add(Nodes.First());

                while (!q.IsEmpty())
                {
                    var current = q.Dequeue();

                    if (current.Value.Equals(value))
                    {
                        return current;
                    }

                    foreach (var child in current.Nodes)
                    {
                        if (!visited.Contains(child))
                        {
                            visited.Add(child);
                            q.Enqueue(child);
                        }
                    }
                }
            }

            return null;
        }

        public Node DepthFirstSearch(TValue value)
        {
            if (Nodes.Count > 0)
            {
               return Nodes.First().DfsHelper(value, new System.Collections.Generic.HashSet<Node>());
            }

            return null;
        }        
    }
}
