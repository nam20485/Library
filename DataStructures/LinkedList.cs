using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class LinkedList<TValue> : DsCollectionBase<TValue>, ICollection<TValue>
    {
        private Node? _head;
        private Node? _tail;
        private int _count;

        //public Node? First => _head;
        //public Node? Last => _tail;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public LinkedList(IEnumerable<TValue> collection)
            : this()
        {
            AddRange(collection);
        }

        //
        //  ICollection interface implementation
        //
        public override int Count => _count;

        public bool IsReadOnly => false;        

        /// <summary>
        /// Add value to end of the list
        /// </summary>
        /// <param name="value">Item to add</param>        
        public override void Add(TValue? value)
        {
            AddAfter(_tail, value);
        }       

        public override void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public override TValue Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty collection.");
            }

            // _tail should != null if Count > 0
            var lastValue = _tail.Value;
            RemoveLast();
            // TODO: remove the _tail.Value explicity?
            //Remove(lastValue);
            return lastValue;
        }

        public override bool Contains(TValue value)
        {
            return Find(value) != null;
        }                

        public bool Remove(TValue value)
        {
            var toRemove = Find(value);
            if (toRemove != null)
            {
                RemoveNode(toRemove);
                return true;
            }
            return false;
        }

        //
        //  More LinkedList interface
        //
        public void AddLast(TValue value)
        {
            Add(value);
        }

        public void AddFirst(TValue value)
        {
            AddBefore(_head, value);            
        }

        protected void AddAfter(Node? node, TValue? value)
        {
            var newNode = new Node(value, this)
            {
                Previous = node
            };

            if (node != null)
            {                
                newNode.Next = node.Next;
                if (node.Next != null)
                {
                    node.Next.Previous = newNode;
                }
                else
                {
                    // we added after the current _tail, new _tail is the new node
                    _tail = newNode;
                }
                node.Next = newNode;
            }
            else
            {
                _head = newNode;
                _tail = newNode;
            }
            _count++;
        }

        protected void AddBefore(Node? node, TValue value)
        {
            var newNode = new Node(value, this)
            {
                Next = node               
            };

            if (node != null)
            {
                newNode.Previous = node.Previous;
                node.Previous = newNode;
                if (node.Next != null)
                {
                    node.Next.Previous = newNode;
                }
                if (newNode.Previous == null)
                {
                    // we added before the head, newNode is the new _head
                    _head = newNode;
                }
            }
            else
            {
                _head = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public void RemoveFirst()
        {
            RemoveNode(_head);
        }

        public void RemoveLast()
        {
            RemoveNode(_tail);
        }

        //
        //  Private implementation
        //
        protected Node? Find(TValue value)
        {
            // optimization for when the value searched for is the tail in O(1) time
            if (_tail is not null)
            {
                if (Equals(_tail.Value, value))
                {
                    return _tail;
                }
            }

            var current = _head;
            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    break;
                }
                current = current.Next;
            }
            return current;
        }

        protected void RemoveNode(Node? node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            var prevNode = node.Previous;
            var nextNode = node.Next;
            if (prevNode != null)
            {
                prevNode.Next = nextNode;
            }
            else
            {
                _head = nextNode;
            }
            if (nextNode != null)
            {
                nextNode.Previous = prevNode;
            }
            else
            {
                _tail = prevNode;
            }

            _count--;                           
        }

        //
        //  IEnumerable interface implementation
        //
        public override IEnumerator<TValue> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }        

        protected override string GetStringRepresentation()
        {
            var sb = new StringBuilder();

            var current = _head;
            while (current != null)
            {
                sb.Append(current.ToString());
                current = current.Next;
            }
            sb.Append($"  ({_count})");
            sb.AppendLine();

            var head = 0;
            current = _head;
            while (current != _head && current != null)
            {
                head++;
                current = current.Next;
            }
            //sb.Append($"{new string(' ', head)}^");        

            var tail = 0;
            current = _head;
            while (current != _tail && current != null)
            {
                tail++;
                current = current.Next;
            }
            //sb.Append($"{new string(' ', (tail-head)*5-1)}^");        

            //sb.AppendLine();
            sb.Append($"{new string(' ', head)}h");
            var tailPos = (tail - head) * 5 - 1;
            sb.Append($"{new string(' ', tailPos > 0 ? tailPos : 0)}t");

            return sb.ToString();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            // TODO: check bounds-cases and throw 
            var index = arrayIndex;
            foreach (var item in this)
            {
                array[index++] = item;
            }
        }

        public override IDsCollection<TValue> CopyOf() => new LinkedList<TValue>(this);

        protected class Node
        {
            public TValue? Value { get; }
            public Node? Next { get; internal set; }    // only Library can set Next and Previous, not user
            public Node? Previous { get; internal set; }
            public LinkedList<TValue> List { get; internal set; }

            public Node(TValue? value, LinkedList<TValue> list)
            {
                Value = value;
                Next = null;
                Previous = null;
                List = list;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                if (Previous != null)
                {
                    sb.Append("<-");
                }
                sb.Append(Value);
                if (Next != null)
                {
                    sb.Append("->");
                }
                return sb.ToString();
            }
        }
    }
}
