using System.Runtime.Serialization;

namespace Library.DataStructures
{
    public class PriorityQueue<TValue, TKey> : Heap<PriorityQueue<TValue, TKey>.Node>
    {
        public PriorityQueue()
            : base()
        {
        }

        public PriorityQueue(IComparer<Node> comparer)
            : base(comparer)
        {
        }

        public PriorityQueue(IEnumerable<Node> collection)
            : base(collection)
        {
        }

        public PriorityQueue(IEnumerable<Node> collection, IComparer<Node> comparer)
            : base(collection, comparer)
        {
        }

        public void Insert(TValue value, TKey key)
        {
            Insert(new Node(value, key));
        }

        public void Insert(Node newNode)
        {
            // make room for new node
            //_items.EnsureCapacity(_items.Count + 1);

            _heapSize++;
            var index = _heapSize - 1;
            while (index > 0 && _comparer.Compare(_items[ParentIndex(index)], newNode) < 0)
            {
                var parentIndex = ParentIndex(index);
                if (index < _items.Count)
                {
                    _items[index] = _items[parentIndex];
                }
                else
                {
                    _items.Insert(index, _items[parentIndex]);
                }
                
                index = parentIndex;
            }
            if (index < _items.Count)
            {
                _items[index] = newNode;            
            }
            else
            {
                _items.Insert(index, newNode);
            }
        }        

        public override IEnumerator<PriorityQueue<TValue, TKey>.Node> GetEnumerator()
        {
            while (Count > 0)
            {
                yield return Remove();
            }
        }

        public class Node : IComparable<Node>
        {
            public TValue Value { get; }
            public TKey Key { get; }
            
            public Node(TValue value, TKey key)
            {
                Value = value;
                Key = key;
            }

            public int CompareTo(PriorityQueue<TValue, TKey>.Node? other)
            {
                if (other is null)
                {
                    // TODO: what to return if other is null?
                    // throw exception?
                }

                return Comparer<TKey>.Default.Compare(Key, other.Key);
            }

            public override string ToString()
            {
                return $"{{Value: {Value}, Key: {Key}}}";
            }
        }
    }

    [Serializable]
    public class InvalidPriorityQueueException : Exception
    {
        public InvalidPriorityQueueException()
        {
        }

        public InvalidPriorityQueueException(string? message) : base(message)
        {
        }

        public InvalidPriorityQueueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPriorityQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
