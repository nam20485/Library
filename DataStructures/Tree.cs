using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Tree<TValue> : IEnumerable<TValue>
    {
        public int MaxChildCount { get; } 

        public Node? Root { get; set; }

        public Tree() { }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Node
        {
            public int MaxChildCount => Children.Capacity;

            public Tree<TValue> Tree { get; internal set; }

            public TValue Value { get; }

            public Node Parent { get; private set; }

            public List<Node> Children { get; }                       
            public Node? LeftChild => GetNthChild(0);
            public Node? RightChild => GetNthChild(1);
          
            protected Node(Node parent, TValue value, Tree<TValue> tree)
            {                                
                Tree = tree;                
                Parent = parent;
                Value = value;
                Children = new (tree.MaxChildCount);
            }

            public void AddChild(TValue value)
            {
                if (Children.Count >= MaxChildCount)
                {
                    throw new Exception($"Child list already full. (max number of children is {MaxChildCount})");
                }

                var child = new Node(this, value, Tree);
                Children.Add(child);
            }

            protected void AddChild(Node child)
            {
                child.Parent = this;
                child.Tree = Tree;
                Children.Add(child);
            }

            public Node? GetNthChild(int n)
            {
                if (n >= Children.Count)
                {
                    throw new Exception($"Invalid child index: {n} (max number of children is {MaxChildCount})");
                }
                return Children[n];
            }           
        }
    }
}
