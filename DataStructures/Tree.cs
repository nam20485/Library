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
            public TValue Value { get; }

            public Node Parent { get; private set; }

            public List<Node> Children { get; }                       
            public Node? LeftChild => GetNthChild(0);
            public Node? RightChild => GetNthChild(1);

            public Node(Node parent, TValue value)
            {
                Parent = parent;
                Value = value;
                Children = new ();
            }

            public void AddChild(Node child)
            {
                child.Parent = this;
                Children.Add(child);
            }

            public Node? GetNthChild(int n)
            {
                if (n < Children.Count)
                {
                    return Children[n];
                }
                return null;
            }           
        }
    }
}
